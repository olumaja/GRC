using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 01/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint allow Management Concern to perform risk rating on the business entities and shared services
 */
    public class ManagementConcernRatingARMHillEndpoint
    {

        /// <summary>
        /// Management Concern to perform risk rating on the business entities and shared services
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="mgtConcernRatingReq"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtConcernRating"></param>
        /// <param name="businessRating"></param>
        /// <param name="shareserviceRating"></param>
        /// <param name="businessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ManagementConcernARMHillRiskRatingRequest mgtConcernRatingReq, IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMHill> mgtConcernRating,
                     IRepository<ManagementConcernBusinessUnitARMHillRating> businessRating, IRepository<ManagementConcernSharedServiceARMHillRating> shareserviceRating,
                     IRepository<BusinessRiskRating> businessRiskRating, ClaimsPrincipal user, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                string unit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (unit != "ARMHIIL") { return TypedResults.Forbid(); }
                               
                var getBusinessRiskRating = businessRiskRating.GetContextByConditon(x => x.Id == mgtConcernRatingReq.ARMHill.BusinessRiskRatingId).FirstOrDefault();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.Ok($"The Business Risk Rating with id {mgtConcernRatingReq.ARMHill.BusinessRiskRatingId} does not exist");
                }
                //check if user has rated this before
                var getByEmail = mgtConcernRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"The user has performed rating for the year {DateTime.Now.Year}");
                }
                var getId = managementConcernRating.GetContextByConditon(x => x.ManagementConcernRequesterName == requesterName).FirstOrDefault();
                if (getId != null)
                {

                    //log requester email and comment
                    var saveMgtConcern = ManagementConcernARMHill.Create(getId.Id, requesterName, mgtConcernRatingReq.ARMHill.Comment);
                    await mgtConcernRating.AddAsync(saveMgtConcern);
                    //log business and business unit
                    var saverating = ManagementConcernBusinessUnitARMHillRating.Create(mgtConcernRatingReq.ARMHill, saveMgtConcern.Id);
                    await businessRating.AddAsync(saverating);
                    //log shared service
                    var saveSharedServicerating = ManagementConcernSharedServiceARMHillRating.Create(mgtConcernRatingReq.ARMHill, saveMgtConcern.Id);
                    await shareserviceRating.AddAsync(saveSharedServicerating);
                    await shareserviceRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = getId.Id
                    };
                    //getBusinessRiskRating.UpdateIsManagementRated();
                    //await businessRiskRating.SaveChangesAsync();
                    #region Send email to the InternalAudit-HQ 

                    string subject = "Business Management Risk Assessment Ready for Approval.";
                    string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                    string toCC = config["EmailConfiguration:InternalAudit"];
                    var linkToGRCTool = string.Format(config["EmailConfiguration:InternalAuditSupervisorApprovalLink"], mgtConcernRatingReq.ARMHill.BusinessRiskRatingId);
                    string body = $"Dear Team,<br><br> {requesterName} has completed the risk assessment for ARMHill.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";

                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getId.Id, emailTo, toCC);
                    if (logEmailRequest == false)
                    {
                        return TypedResults.Ok($"Request created successfully {getId.Id} but email message was not logged");
                    }
                    #endregion
                    return TypedResults.Created($"apra/{response}", response);
                }

                if (getId == null)
                {
                    //log req
                    var saveMgtConcernRating = ManagementConcernRiskRating.CreateManagementConcernRiskRating(mgtConcernRatingReq.ARMHill.BusinessRateRequesterName, requesterName, mgtConcernRatingReq.ARMHill.BusinessRiskRatingId);
                    await managementConcernRating.AddAsync(saveMgtConcernRating);
                    //log requester email and comment
                    var saveMgtConcern2 = ManagementConcernARMHill.Create(saveMgtConcernRating.Id, requesterName, mgtConcernRatingReq.ARMHill.Comment);
                    await mgtConcernRating.AddAsync(saveMgtConcern2);
                    //log business and business unit
                    var saverating2 = ManagementConcernBusinessUnitARMHillRating.Create(mgtConcernRatingReq.ARMHill, saveMgtConcern2.Id);
                    await businessRating.AddAsync(saverating2);
                    //log shared service
                    var saveSharedServicerating2 = ManagementConcernSharedServiceARMHillRating.Create(mgtConcernRatingReq.ARMHill, saveMgtConcern2.Id);
                    await shareserviceRating.AddAsync(saveSharedServicerating2);
                    await shareserviceRating.SaveChangesAsync();

                    BusinessRiskRatingResponse resp = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = saveMgtConcernRating.Id
                    };
                   // await businessRiskRating.SaveChangesAsync();
                    #region Send email to the InternalAudit-HQ 
                    
                    string subject = "Business Management Risk Assessment Ready for Approval.";
                    string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                    string toCC = config["EmailConfiguration:InternalAudit"];
                    var linkToGRCTool = string.Format(config["EmailConfiguration:InternalAuditSupervisorApprovalLink"], mgtConcernRatingReq.ARMHill.BusinessRiskRatingId);
                    string body = $"Dear Team,<br><br> {requesterName} has completed the risk assessment for ARMHill.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";

                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, saveMgtConcernRating.Id, emailTo, toCC);
                    if (logEmailRequest == false)
                    {
                        return TypedResults.Ok($"Request created successfully {saveMgtConcernRating.Id} but email message was not logged");
                    }
                    #endregion
                    return TypedResults.Created($"apra/{resp}", resp);
                }
                return TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }

    }
}
