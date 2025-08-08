using System.Text.Json.Serialization;

namespace Arm.GrcApi.Modules.Shared.EmailNotification
{
    public class EmailDto
    {
    }

    public class SmsRequest
    {
        public string Message { get; set; }
        public string MobileNumber { get; set; }
    }
    public class EmailRequest
    {
        public bool isBodyHtml { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string ToEmail { get; set; }
        public string ToCc { get; set; }
        public EmailRequest()
        {

        }
    }

    public class EmailRequestUpdated
    {
        [JsonPropertyName("body")] public string Body { get; set; }
        [JsonPropertyName("hasAttachment")] public bool HasAttachment { get; set; }
        [JsonPropertyName("isHtml")] public bool IsHtml { get; set; }
        [JsonPropertyName("requestID")] public string RequestID { get; set; }
        [JsonPropertyName("sender")] public string Sender { get; set; }
        [JsonPropertyName("subject")] public string Subject { get; set; }
        [JsonPropertyName("recipents")] public List<string> recipents { get; set; }
        [JsonPropertyName("bcc")] public List<string> Bcc { get; set; }
        [JsonPropertyName("cc")] public List<string> Cc { get; set; }
        [JsonPropertyName("channel")] public string Channel { get; set; }
        [JsonPropertyName("attachments")] public List<AttachementRequest> Attachments { get; set; } = new();
    }

    public class AttachementRequest
    {
        public string? FileName { get; set; }
        public string? AttachmentContent { get; set; }
    }

    public class EmailResponseUpdated
    {
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public bool isSuccessful { get; set; }
        public object responseData { get; set; }
    }

    public class EmailResponse
    {
        public string Recipient { get; set; }
        public bool Status { get; set; }
        public string ResponseString { get; set; }
        public EmailResponse()
        {
            Status = false;
        }
    }
}
