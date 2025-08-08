using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public record PaginatedGetNotifyISOChampionResp(PaginationMeta PaginationMeta, List<GetNotifyISOChampionResponse> Response);

    public class GetNotifyISOChampionResponse
    {
        public Guid NotifyISOId { get; set; }
        public string? Unit { get; set; }
        public string? Objective { get; set; }        
        public DateTime DateIdentify { get; set; }
    }

    public record PaginatedGetISOChampionUnitHeadResp(PaginationMeta PaginationMeta, List<GetISOChampionUnitHeadResponse> Response);

    public class GetISOChampionUnitHeadResponse
    {
        public Guid NotifyISOId { get; set; }
        public DateTime? DateIdentified { get; set; }
        public string? Category { get; set; }
        public string? Asset { get; set; }
        public string? DescriptionOfAsset { get; set; }
        public string? Status { get; set; }
    }


    public record PaginatedGetApprovedRiskResponse(PaginationMeta PaginationMeta, List<GetApprovedRiskResponse> Response);

    public class GetApprovedRiskResponse
    {
        public string? Unit { get; set; }
        public int Count { get; set; }

    }
}
