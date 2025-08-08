using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Regulator Payment: Initiate compliance Payment Endpoint.     
      */
    public class InitiateRegulatorPaymentEndpoint
    {

        /// <summary>
        /// Initiate Regulator Payment Endpoint.  
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="comPayment"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] InitiateRegulatorPaymentDto request, IRepository<ComplianceRegulatoryPayment> comPayment,
            IEmailService EmailService, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                if (request.DeadLine < DateTime.Now) return TypedResults.BadRequest("DeadLine date cannot be earlier than today's date");

                var year = DateTime.Now.Year;
                                               
                var checkIfpaymentExist = comPayment.GetContextByConditon(c => c.Regulator == request.Regulator && c.BusinessEntity == request.BusinessEntity && c.CreatedOnUtc.Year == year).FirstOrDefault();
                if (checkIfpaymentExist != null) { return TypedResults.Ok($"Payment has been previously initiated"); }

                if (checkIfpaymentExist == null)
                {
                    //log request

                    var logRequest = ComplianceRegulatoryPayment.InitiatePayment(request, currentUserService.CurrentUserFullName);
                    logRequest.SetModifiedOnUtc(DateTime.Now);
                    await comPayment.AddAsync(logRequest);

                    await comPayment.SaveChangesAsync();
                    var response = new InitiateRegulatorPaymentResp
                    {
                        RegulatorPaymentId = logRequest.Id
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
                    if ((request.Regulator != "INSURANCE" || request.Regulator != "Custodian & Allied Insurance") && request.BusinessEntity == "ARM IM")
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
                    if ((request.Regulator != "INSURANCE" || request.Regulator != "Custodian & Allied Insurance") && request.BusinessEntity == "ARM Capital Partner")
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
                    //string filePath = config["EmailConfiguration:filePath"];
                    string emailTo = emailSentTo; // config["EmailConfiguration:RiskMgtUnit"];
                    string toCC = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string body = $"Hello, <br> New compliance regulator payment request initiated: <br> Regulator body => {request.Regulator}, <br> Business Entity => {request.BusinessEntity}, <br>Amount => {amount},<br> Deadline => {request.DeadLine}. <br>Kindly click on the link for further information: <br><a href={linkToGRCTool}>{request.Regulator} Compliance Payment</a>.";
                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, logRequest.Id, emailTo, toCC);
                    if (logEmailRequest == false)
                    {
                        return TypedResults.Ok($"Request created successfully {response} but email message was not logged");
                    }
                    #endregion

                    return TypedResults.Created($"ar/{response}", response);
                }

                return TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
