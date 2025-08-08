namespace GrcApi.Modules.Shared.EmailNotification.Response
{
    public class EmailWithAttachmentResponse
    {
        public string Recipient { get; set; }
        public bool Status { get; set; }
        public string ResponseString { get; set; }
    }

    public class EmailWithAttachmentRequest
    {
        public List<EmailAttachment> attachments { get; set; }
        public bool isBodyHtml { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public string toEmail { get; set; }
        public string toCc { get; set; }
    }

    public record EmailAttachment(string fileName, string attachmentfile);
}
