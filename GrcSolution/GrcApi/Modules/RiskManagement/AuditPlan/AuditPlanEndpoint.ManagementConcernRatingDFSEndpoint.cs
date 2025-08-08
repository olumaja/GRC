using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 01/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint allow Management Concern to perform risk rating on the DFS business entities
 */
    public class ManagementConcernRatingDFSEndpoint
    {
        /// <summary>
        /// Management Concern to perform risk rating on the DFS business entities
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
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ManagementConcernDigitalFinancialServiceRequest mgtConcernRatingReq, IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernDFS> mgtConcernRating,
                     IRepository<ManagementConcernBusinessUnitDFSRating> businessRating, IRepository<ManagementConcernSharedServiceDFSRating> shareserviceRating,
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
                if (unit != "DFS") { return TypedResults.Forbid(); }
                              
                var getBusinessRiskRating = businessRiskRating.GetContextByConditon(x => x.Id == mgtConcernRatingReq.DigitalFinancialService.BusinessRiskRatingId).FirstOrDefault();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.Ok($"The Business Risk Rating with id {mgtConcernRatingReq.DigitalFinancialService.BusinessRiskRatingId} does not exist");
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
                    var saveMgtConcern = ManagementConcernDFS.Create(getId.Id, requesterName, mgtConcernRatingReq.DigitalFinancialService.Comment);
                    await mgtConcernRating.AddAsync(saveMgtConcern);
                    //log business and business unit
                    var saverating = ManagementConcernBusinessUnitDFSRating.Create(mgtConcernRatingReq.DigitalFinancialService, saveMgtConcern.Id);
                    await businessRating.AddAsync(saverating);
                    //log shared service
                    var saveSharedServicerating = ManagementConcernSharedServiceDFSRating.Create(mgtConcernRatingReq.DigitalFinancialService, saveMgtConcern.Id);
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
                    var linkToGRCTool = string.Format(config["EmailConfiguration:InternalAuditSupervisorApprovalLink"], mgtConcernRatingReq.DigitalFinancialService.BusinessRiskRatingId);
                    string body = $"Dear Team,<br><br> {requesterName} has completed the risk assessment for Digital Financial Service.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";

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
                    var saveMgtConcernRating = ManagementConcernRiskRating.CreateManagementConcernRiskRating(mgtConcernRatingReq.DigitalFinancialService.BusinessRateRequesterName, requesterName, mgtConcernRatingReq.DigitalFinancialService.BusinessRiskRatingId);
                    await managementConcernRating.AddAsync(saveMgtConcernRating);
                    //log requester email and comment
                    var saveMgtConcern2 = ManagementConcernDFS.Create(saveMgtConcernRating.Id, requesterName, mgtConcernRatingReq.DigitalFinancialService.Comment);
                    await mgtConcernRating.AddAsync(saveMgtConcern2);
                    //log business and business unit
                    var saverating2 = ManagementConcernBusinessUnitDFSRating.Create(mgtConcernRatingReq.DigitalFinancialService, saveMgtConcern2.Id);
                    await businessRating.AddAsync(saverating2);
                    //log shared service
                    var saveSharedServicerating2 = ManagementConcernSharedServiceDFSRating.Create(mgtConcernRatingReq.DigitalFinancialService, saveMgtConcern2.Id);
                    await shareserviceRating.AddAsync(saveSharedServicerating2);
                    await shareserviceRating.SaveChangesAsync();

                    BusinessRiskRatingResponse resp = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = saveMgtConcernRating.Id
                    };
                    //getBusinessRiskRating.UpdateIsManagementRated();
                    //await businessRiskRating.SaveChangesAsync();
                    #region Send email to the InternalAudit-HQ 
                    
                    string subject = "Business Management Risk Assessment Ready for Approval.";
                    string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                    string toCC = config["EmailConfiguration:InternalAudit"];
                    var linkToGRCTool = string.Format(config["EmailConfiguration:InternalAuditSupervisorApprovalLink"], mgtConcernRatingReq.DigitalFinancialService.BusinessRiskRatingId);
                    string body = $"Dear Team,<br><br> {requesterName} has completed the risk assessment for Digital Financial Service.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";

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
