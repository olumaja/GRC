using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Org.BouncyCastle.Tls;
using System;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 06/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class UpdateAuditAnnouncementMemoEndpoint
    {
        /// <summary>
        /// Commence Engagement- Update Audit Announcement Memo  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="auditmemo"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateAuditAnnouncementMemoRequest request, IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, 
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                if (request.periodFrom > request.periodTo)
                {
                    return TypedResults.BadRequest("Oops, periodTo cannot be earlier than periodFrom");
                }
                var checkIfauditmemoIdExist = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == request.CommenceEngagementId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (checkIfauditmemoIdExist == null) { return TypedResults.NotFound("Record was not found or it has been previously approved"); }
                               
                //save req
                string Savesalutation = $"Dear {checkIfauditmemoIdExist.Salutation}, \r\nTrust you are doing well. \r\nThis is to formally notify you that a {request.Recommendation} Audit of {checkIfauditmemoIdExist.Unit} unit will commence on {request.CommenceDate.ToString("yyyy-MM-dd")}. \r\nDuring the audit, we will review the existence, adequacy and effectiveness of controls and processes in place for the unit’s operations, to determine if they are properly designed and operating as intended. We will also review compliance with policies and procedures as they relate to the unit. This will enable us to provide reasonable assurance to the business and key stakeholders on the effectiveness of these controls in addressing key risks within the {checkIfauditmemoIdExist.Unit}.\r\n";
                string saveauditScoped = $"The audit is for the period {request.periodFrom.ToString("dd MMMM yyyy")} to {request.periodTo.ToString("dd MMMM yyyy")}, and it will cover the areas listed in the attached Audit Engagement Letter.";
                string saveworkApproach = $"The Audit review will be carried out using the following work approach: \r\n» One-on-one interviews and walkthroughs with some process owners. \r\n» Review of policies and procedures. \r\n» Evaluation of the effectiveness of key controls and sample testing. \r\n» Documentation of draft audit findings and recommendations; discussions with Management prior to the finalization of the report. \r\n» Incorporation of Management’s comments and finalization of the report. \r\nWhere control weaknesses and audit exceptions are identified, these will be communicated on an on-going basis during the audit. Upon conclusion of the testing phase, Internal Audit will prepare a draft report summarizing key findings and recommendations on how the control issues can be remediated. We will solicit feedback regarding our findings, including your management action plans, and follow up on the implementation of our recommendations.";
                string saverole = $"Please note that you are required to notify relevant staff about the commencement of this audit and kindly communicate to us the liaison for this review.\r\nAlso attached to this email is our initial list of information requirements. The list of requirements is not exhaustive, and additional requests may be made during the audit. Please assist in ensuring that all requirements are provided promptly for our review. Evidence should be uploaded in this folder Information Requirements.\r\n We expect to issue a final report in {request.CommenceDate.ToString("MMMM yyyy")}.\r\n We look forward to working with you and other members of the team on this audit. Kindly contact {requesterName}, or any member of the Internal Audit team, should you require any additional information.\r\n Thank you";

                //update request               
                checkIfauditmemoIdExist.UpdateAuditAnnouncementMemoAuditExecutionstring(checkIfauditmemoIdExist.Id, checkIfauditmemoIdExist.CommenceEngagementAuditexecutionId, Savesalutation, saveauditScoped, saveworkApproach, saverole, checkIfauditmemoIdExist.Unit, request.Recommendation, request.CommenceDate, request.periodFrom, request.periodTo, request.PreviousFrom, request.PreviousTo);
                checkIfauditmemoIdExist.SetModifiedBy(checkIfauditmemoIdExist.Id);
                checkIfauditmemoIdExist.SetModifiedOnUtc(DateTime.Now);
                auditmemo.SaveChanges();

                return TypedResults.Ok("Record updated successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
