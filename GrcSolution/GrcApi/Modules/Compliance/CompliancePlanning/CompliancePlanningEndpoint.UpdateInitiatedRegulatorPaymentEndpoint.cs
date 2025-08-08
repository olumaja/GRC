using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Payment: Update Initiated Regulator Payment By Id Endpoint    
      */
    public class UpdateInitiatedRegulatorPaymentEndpoint
    {
        /// <summary>
        /// Update Initiated Regulator Payment By Id  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="compPayment"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateComplianceRegulatorPaymentReq request, IRepository<ComplianceRegulatoryPayment> compPayment,
             IEmailService EmailService, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getDetail = await compPayment.GetByIdAsync(request.RegulatorPaymentId);

                if (getDetail is null)
                {
                    return TypedResults.NotFound($"Regulator was not found");
                }

                var updatedPayment = new UpdatePaymentReq(
                    Regulator: request.Regulator,
                    BusinessEntity: request.BusinessEntity,
                    DeadLine: request.DeadLine,
                    PaymentDetail: request.PaymentDetail,
                    MeansOfPaymentAmount: request.MeansOfPaymentAmount,
                    Amount: request.Amount,
                    ProcessOfficer: request.ProcessOfficer
                );
                getDetail.UpdateComplianceRegulatorPayment(updatedPayment, currentUserService.CurrentUserFullName);
                getDetail.SetModifiedOnUtc(DateTime.Now);
                compPayment.Update(getDetail);
                await compPayment.SaveChangesAsync();

                var response = new InitiateRegulatorPaymentResp
                {
                    RegulatorPaymentId = request.RegulatorPaymentId
                };
                #region ARMSecurity
                string emailSentTo = "";
                if ((request.Regulator != "INSURANCE" || request.Regulator != "Custodian & Allied Insurance") && request.BusinessEntity == "ARM Securities")
                {
                    emailSentTo = config["EmailConfiguration:ARMSEcurityRegulatoryEmailTo"];
                }
                if ((request.Regulator == "INSURANCE" || request.Regulator == "Custodian & Allied Insurance") && request.BusinessEntity == "ARM Securities")
                {
                    emailSentTo = config["EmailConfiguration:ARMSEcurityInsurranceRegulatoryEmailTo"];
                }
                #endregion
                #region ARMIM
                if (request.Regulator != "Custodian & Allied Insurance" && request.BusinessEntity == "ARM IM")
                {
                    emailSentTo = config["EmailConfiguration:ARMIMRegulatoryEmailTo"];
                }
                if ((request.Regulator == "INSURANCE" || request.Regulator == "Custodian & Allied Insurance") && request.BusinessEntity == "ARM IM")
                {
                    emailSentTo = config["EmailConfiguration:ARMIMInsurranceRegulatoryEmailTo"];
                }
                #endregion
                #region ARMTrustee
                if ((request.Regulator != "INSURANCE" || request.Regulator != "Custodian & Allied Insurance") && (request.BusinessEntity == "ARM Trustee" || request.BusinessEntity == "ARM TAM"))
                {
                    emailSentTo = config["EmailConfiguration:ARMTrusteeRegulatoryEmailTo"];
                }
                if ((request.Regulator == "INSURANCE" || request.Regulator == "Custodian & Allied Insurance") && (request.BusinessEntity == "ARM Trustee" || request.BusinessEntity == "ARM TAM"))
                {
                    emailSentTo = config["EmailConfiguration:ARMTrusteeInsurranceRegulatoryEmailTo"];
                }
                #endregion 
                #region ARMCP
                if ((request.Regulator != "INSURANCE" || request.Regulator != "Custodian & Allied Insurance") && request.BusinessEntity == "ARM Capital Partner" )
                {
                    emailSentTo = config["EmailConfiguration:ARMCPRegulatoryEmailTo"];
                }
                if ((request.Regulator == "INSURANCE" || request.Regulator == "Custodian & Allied Insurance") && request.BusinessEntity == "ARM Capital Partner")
                {
                    emailSentTo = config["EmailConfiguration:ARMCPInsurranceRegulatoryEmailTo"];
                }
                #endregion 
                #region Log email request  

                string subject = $"New Compliance Payment Request";
                string amount = $"₦{string.Format("{0:#,#.00} ", request.Amount)}";
                string emailTo = emailSentTo; 
                string toCC = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Hello, <br>Compliance Regulator payment request: <br> Regulator => {request.Regulator}, <br> Business Entity => {request.BusinessEntity}, <br>Amount => {amount}, <br>Deadline => {request.DeadLine} <br>has been Updated. <br> <br>Kindly click on the link for further information:<br> <a href={linkToGRCTool}>{request.Regulator} Compliance Payment</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, request.RegulatorPaymentId, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"Request created successfully {response} but email message was not logged");
                }
                #endregion
                return TypedResults.Ok("Updated succcessfully");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
