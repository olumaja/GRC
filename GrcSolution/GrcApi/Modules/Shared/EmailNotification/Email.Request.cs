
namespace Arm.GrcTool.Infrastructure
{
    public record EmailRequest
    (
        string To,
        string CC,
        string Subject,
        string Message,
        ModuleType ModuleItemType,
        Guid ModuleItemId
     );

    //public record SendEmailRequest
    //{
    //    public string To { get; set; }
    //    public string CC { get; set; }
    //    public string Subject { get; set; }
    //    public string Message { get; set; }
    //    public ModuleType ModuleItemType { get; set; }
    //    public Guid ModuleItemId { get; set; }
    //}
    




}
