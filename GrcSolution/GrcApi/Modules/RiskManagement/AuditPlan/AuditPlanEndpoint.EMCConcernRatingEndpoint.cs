using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 27/02/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Executive Management (Group CEO and Deputy) to perform risk rating on the business entities
*/
    public class EMCConcernRatingEndpoint
    {
        /// <summary>
        /// Executive Management (Group CEO and Deputy) to perform risk rating on the business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="emcRating"></param>
        /// <param name="armholdco"></param>
        /// <param name="armim"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armhill"></param>
        /// <param name="armtarmagri"></param>
        /// <param name="armshareservice"></param>
        /// <param name="businessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] EMCConcernRequest rating, IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMHoldingCompanyEMCRating> armholdco, IRepository<ARMIMEMCRating> armim,
            IRepository<ARMSecurityEMCRating> armsecurity, IRepository<ARMTrusteeEMCRating> armtrustee, IRepository<ARMHILLEMCRating> armhill, IRepository<ARMAgribusinessEMCRating> armtarmagri,
            IRepository<ARMSharedServiceEMCRating> armshareservice, IRepository<BusinessRiskRating> businessRiskRating, 
            IRepository<DigitalFinancialServiceEMCRating> dfs, IRepository<ARMCapitalEMCRating> armCapital, IRepository<ARMTAMEMCRating> tam, ClaimsPrincipal user,
            IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;

                var getBusinessRiskRating = businessRiskRating.GetContextByConditon(x => x.Id == rating.BusinessRiskRatingId).FirstOrDefault();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.Ok($"The Business Risk Rating with id {rating.BusinessRiskRatingId} does not exist");
                }
                //chech if user has performed rating before
                var getUser = emcRating.GetContextByConditon(x => x.EmcRequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    return TypedResults.Ok($"The user has performed rating for the year {DateTime.Now.Year} with the Id: {getUser.Id}");
                }
                //log request
                var logRequest = EMCConcernRiskRating.Create(rating.BusinessRateRequesterName, requesterName, rating.BusinessRiskRatingId, rating.Comment);
                await emcRating.AddAsync(logRequest);
                //log emc rating arm holding company
                var savearmholdcorating = ARMHoldingCompanyEMCRating.Create(logRequest.Id, rating.ARMHoldingCompany);
                await armholdco.AddAsync(savearmholdcorating);
                //log emc rating arm tam
                var saveTam = ARMTAMEMCRating.Create(logRequest.Id, rating.ARMTAM);
                await tam.AddAsync(saveTam);
                //log emc rating DFS
                var saveDFS = DigitalFinancialServiceEMCRating.Create(logRequest.Id, rating.DigitalFinancialService);
                await dfs.AddAsync(saveDFS);
                //log emc rating ARMCapital
                var saveARMCapital = ARMCapitalEMCRating.Create(logRequest.Id, rating.ARMCapital);
                await armCapital.AddAsync(saveARMCapital);
                //log emc rating arm im
                var savearmimrating = ARMIMEMCRating.Create(logRequest.Id, rating.ARMIM);
                await armim.AddAsync(savearmimrating);
                //log emc rating arm security
                var savearmsecurityrating = ARMSecurityEMCRating.Create(logRequest.Id, rating.ARMSecurity);
                await armsecurity.AddAsync(savearmsecurityrating);
                //log emc rating arm trustee
                var savetrusteerating = ARMTrusteeEMCRating.Create(logRequest.Id, rating.ARMTrustee);
                await armtrustee.AddAsync(savetrusteerating);
                //log emc rating arm hill
                var savearmhillrating = ARMHILLEMCRating.Create(logRequest.Id, rating.ARMHILL);
                await armhill.AddAsync(savearmhillrating);
                //log emc rating arm agribusiness
                var savearmagrirating = ARMAgribusinessEMCRating.Create(logRequest.Id, rating.ARMAgribusiness);
                await armtarmagri.AddAsync(savearmagrirating);
                //log emc rating arm share service
                var saveshareservicerating = ARMSharedServiceEMCRating.Create(logRequest.Id, rating.ARMSharedService);
                await armshareservice.AddAsync(saveshareservicerating);
                await armshareservice.SaveChangesAsync();

                EMCConcernRatingResponse response = new EMCConcernRatingResponse
                {
                    EMCConcernRatingId = logRequest.Id
                };
                getBusinessRiskRating.UpdateIsEMCRated();
                await businessRiskRating.SaveChangesAsync();

                #region Send email to the InternalAudit-HQ 
                string subject = "Excecutive Management Concern Assessment.";
                string emailTo = config["EmailConfiguration:InternalAudit"];
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear Team, <br><br> {requesterName} has completed the EMC risk assessment. <br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, logRequest.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"EMC: Request created successfully {logRequest.Id} but email message was not logged");
                }
                #endregion

                return TypedResults.Created($"apra/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
