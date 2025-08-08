using Arm.GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class OperationControlResp
    {
        public string LoggedBy { get; set; }
        public string OperationalActivity { get; set; }
        public string TransactionCallOverType { get; set; }
        public string ExceptionSummary { get; set; }
        public string ActionPoint { get; set; }
        public string ActionOwner { get; set; }
        public string Unit { get; set; }
        public string ExceptionCategory { get; set; }
        public DateTime ProposedDeadline { get; set; }
        public DateTime? DateResolved { get; set; }
        public string Status { get; set; }
    }

    public record PaginatedOperationControl(PaginationMeta PaginationMeta, List<OperationControlResp> PaginatedExceptions);
}
