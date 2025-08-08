namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class ReducedFunctionalityModeReq
    {
        public string? ComputerName { get; set; } = null;
        public string? LastSeenOnCrowdStrike { get; set; } = null;
        public string? MACAddress { get; set; } = null;
        public string? SystemVersion { get; set; } = null;
        public string? LoggedOnUser { get; set; } = null;
        public string? LastSeenOnManageEngine { get; set; } = null;
    }
}
