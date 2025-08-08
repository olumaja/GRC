using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{

    /*
    * Original Author: Sodiq Quadre
    * Date Created: 10/05/2024
    * Development Group: Audit plan Risk Assessment - GRCTools
    * The endpoint create Audit program
    */
    public class CommenceEngagementAuditProgramEndpoint
    {
        /// <summary>
        /// Commence Engagement- Audit Program
        /// This endpoint create audit program and send email notifcation
        /// </summary>
        /// <param name="postAuditPrograms"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="inforRequirement"></param>
        /// <param name="commenceEng"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            [FromBody] PostAuditProgramRequest postAuditPrograms, IRepository<AnualAuditUniverseRiskRating> repoAnualAuditUniverse, 
            IRepository<AuditProgramAuditExecution> repoAuditProgram, IRepository<CommenceEngagementAuditexecution> repoCommenceEng,
            IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user,
            ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }              

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var freshProgram = new List<AuditProgramAuditExecution>();
                var checkIiAnualAuditUniverseIdExist = repoAnualAuditUniverse.GetContextByConditon(c => c.Id == postAuditPrograms.AnualAuditUniverseRiskRatingId)
                                                                            .FirstOrDefault();
                if (checkIiAnualAuditUniverseIdExist is null) 
                    return TypedResults.NotFound("No record found"); 

                var commenceEngagement = repoCommenceEng.GetContextByConditon(c => c.AnualAuditUniverseRiskRatingId == postAuditPrograms.AnualAuditUniverseRiskRatingId && c.Team == postAuditPrograms.Team)
                                                        .FirstOrDefault();

                if (commenceEngagement is null)  
                    return TypedResults.NotFound("Commence Engagement has not been performed");

                //var auditPrograms = repoAuditProgram.GetContextByConditon(c => c.RequesterName == requesterName && c.Team == postAuditPrograms.Team);
                //if(auditPrograms.Any() )
                //    return TypedResults.BadRequest($"Audit program has been previously submited");

                var getUnit = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == commenceEngagement.Id)
                                        .FirstOrDefault();

                foreach ( var auditProgram in postAuditPrograms.auditProgrammes)
                {
                    freshProgram.Add(
                        AuditProgramAuditExecution.Create(
                            postAuditPrograms.Team, requesterName, commenceEngagement.Id, auditProgram.Process, auditProgram.SubProcess, auditProgram.RiskDescription,
                            auditProgram.ControlDescription, auditProgram.ControlDescription, auditProgram.ReviewProcedure, auditProgram.InformationRequired,
                            auditProgram.Comment
                    ));
                }

                repoAuditProgram.AddRange(freshProgram);

                commenceEngagement.UpdateEngagementPlan();
                repoCommenceEng.SaveChanges();

                #region Send email to the InternalAudit-HQ 
               
                string subject = $" Audit Program - {getUnit.Unit}";
                string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                //string emailTo = getUnit.Recipient;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string supervisorName = config["EmailConfiguration:InternalAudirSupervisorName"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {supervisorName}, <br> {requesterName} has submitted the audit program for {getUnit.Unit} '{getUnit.Recommendation}' for your review and approval. <br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, commenceEngagement.Id, emailTo, toCC);
               
                #endregion

                CommenceEngagementAuditexecutionResp response = new CommenceEngagementAuditexecutionResp
                {
                    CommenceEngagementId = commenceEngagement.Id
                };

                return TypedResults.Created($"aep/{response}", response);
            }
            catch ( Exception ex )
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
