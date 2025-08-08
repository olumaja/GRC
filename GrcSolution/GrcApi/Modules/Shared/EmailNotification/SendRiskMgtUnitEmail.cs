using Arm.GrcTool.Domain;
using DocumentFormat.OpenXml.Spreadsheet;
using GrcApi.Modules.Shared;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Arm.GrcApi.Modules.Shared.EmailNotification
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 24/11/2023
     * Development Group: GRCTools
     * The Email notification service
     */
    public class SendRiskMgtUnitEmail
    {
        /// <summary>
        /// Send Audit Announcement Memo Email Async
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="emailTo"></param>
        /// <param name="toCC"></param>
        /// <param name="salutation"></param>
        /// <param name="partialScopeAudit"></param>
        /// <param name="corporateTransformationOfficeCTO"></param>
        /// <param name="commenceDate"></param>
        /// <param name="unit"></param>
        /// <param name="reportDate"></param>
        /// <param name="officerName"></param>
        /// <param name="auditPeriodFrom"></param>
        /// <param name="auditPeriodTo"></param>
        /// <param name="informationRequirementLink"></param>
        /// <param name="filePath"></param>
        /// <param name="config"></param>
        public static void SendAuditAnnouncementMemoEmailAsync(string subject, string emailTo, string toCC, string salutation,
            string partialScopeAudit, string corporateTransformationOfficeCTO, DateTime commenceDate, string unit, DateTime reportDate,
            string officerName, DateTime auditPeriodFrom, DateTime auditPeriodTo, string informationRequirementLink, string filePath, IConfiguration config)
        {            
            string emailMessage = "";
            string cetNumber = config["EmailConfiguration:cetNumber"];
            string cetEmail = config["EmailConfiguration:cetEmail"];
            string year = DateTime.Now.Year.ToString();
            if (System.IO.File.Exists(filePath))
            {
                FileStream f1 = new FileStream(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(f1);
                emailMessage = emailMessage + sr.ReadToEnd();
               
                emailMessage = emailMessage.Replace("[salutation]", salutation);
                emailMessage = emailMessage.Replace("[PartialScopeAudit]", partialScopeAudit);
                emailMessage = emailMessage.Replace("[CorporateTransformationOfficeCTO]", corporateTransformationOfficeCTO);
                emailMessage = emailMessage.Replace("[CommenceDate]", commenceDate.ToString());
                emailMessage = emailMessage.Replace("[unit]", unit);
                emailMessage = emailMessage.Replace("[ReportDate]", reportDate.ToString());
                emailMessage = emailMessage.Replace("[officerName]", officerName);
                emailMessage = emailMessage.Replace("[AuditPeriodFrom]", auditPeriodFrom.ToString());
                emailMessage = emailMessage.Replace("[AuditPeriodTo]", auditPeriodTo.ToString());
                emailMessage = emailMessage.Replace("[InformationRequirements]", informationRequirementLink);
                emailMessage = emailMessage.Replace("[CETNumber]", cetNumber);
                emailMessage = emailMessage.Replace("[CETEmail]", cetEmail);
                emailMessage = emailMessage.Replace("[CurrentYear]", year);
                //  salutation   partialScopeAudit  corporateTransformationOfficeCTO commenceDate  unit
                //  reportDate  officerName  auditPeriodFrom  auditPeriodTo informationRequirementLink
                f1.Close();
            }

            EmailRequest sendEmail = new EmailRequest();
            sendEmail.isBodyHtml = true;
            sendEmail.Message = emailMessage;
            sendEmail.ToEmail = emailTo;
            sendEmail.ToCc = toCC;
            sendEmail.Subject = subject;
            SendRiskMgtUnitEmail.SendEmailNotification(sendEmail, config);
        }


        /// <summary>
        /// Send email notification to the appropriate channels
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="emailTo"></param>
        /// <param name="toCC"></param>
        /// <param name="linkToGRCTool"></param>
        /// <param name="body"></param>
        /// <param name="filePath"></param>
        /// <param name="config"></param>
        public static void SendRiskMgtUnitEmailAsyncV1(string subject, string emailTo, string toCC, string body, string filePath, IConfiguration config)
        {
            string emailMessage = "";
            string cetNumber = config["EmailConfiguration:cetNumber"];
            string cetEmail = config["EmailConfiguration:cetEmail"];
            string year = DateTime.Now.Year.ToString();
            if (System.IO.File.Exists(filePath))
            {
                FileStream f1 = new FileStream(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(f1);
                emailMessage = emailMessage + sr.ReadToEnd();
                emailMessage = emailMessage.Replace("[Context]", body);
                emailMessage = emailMessage.Replace("[CETNumber]", cetNumber);
                emailMessage = emailMessage.Replace("[CETEmail]", cetEmail);
                emailMessage = emailMessage.Replace("[CurrentYear]", year);
                f1.Close();
            }

            EmailRequest sendEmail = new EmailRequest();
            sendEmail.isBodyHtml = true;
            sendEmail.Message = emailMessage;
            sendEmail.ToEmail = emailTo;
            sendEmail.ToCc = toCC;
            sendEmail.Subject = subject;
            SendRiskMgtUnitEmail.SendEmailNotification(sendEmail, config);

        }
              
        public static void SendEmailNotification(EmailRequest request, IConfiguration config)
        {
            EmailResponse response = new EmailResponse();
            string smtpServer = config["EmailConfiguration:smtpServer"];
            string port = config["EmailConfiguration:port"];
            string mailusername = config["EmailConfiguration:mailusername"];
            string password = config["EmailConfiguration:password"];
            bool enableSsl = true;
            string credentialRequired = config["EmailConfiguration:credentialRequired"];
            string fromEmailId = config["EmailConfiguration:fromEmailId"];
            string accountName = config["EmailConfiguration:accountName"];
            string clientDomain = config["EmailConfiguration:clientDomain"];

            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient(smtpServer, Convert.ToInt16(port));

            try
            {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                NetworkCredential mNetworkCredential = new NetworkCredential(mailusername, password, clientDomain);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = enableSsl;
                smtpClient.Credentials = mNetworkCredential;
                request.Message = request.Message.Replace("%%emailaddress%%", request.ToEmail);
                mailMessage.IsBodyHtml = request.isBodyHtml;
                mailMessage.To.Add(request.ToEmail);
                if (!string.IsNullOrEmpty(request.ToCc))
                {
                    mailMessage.CC.Add(request.ToCc);
                }
                mailMessage.From = new MailAddress(fromEmailId, accountName);
                mailMessage.Subject = request.Subject;
                mailMessage.Body = request.Message;
                smtpClient.Send(mailMessage);
                response.Status = true;
                response.ResponseString = "Sent";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.ResponseString = $"{ex.Message}";
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient = null;
            }

            response.Recipient = request.ToEmail;
            return;
        }
               
    }
}
