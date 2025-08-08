using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public class GetRiskAssessmentReportByUnitEndpoint
    {
        public static async Task<IResult> HandleAsync(string unit, string? riskRating, DateTime? startDate, DateTime? endDate, 
            IRepository<InfosecRiskAssessmentModel> riskRepo, bool isDownload
        )
        {
            const int lowRiskLimit = 4;
            const int mediumRiskLimit = 12;
            const int highRiskLimit = 25;
            var riskAssessment = riskRepo.GetContextByConditon(r => r.Unit == unit);

            var totalResidualRisk = riskAssessment.Count();
            var totalLow = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) <= lowRiskLimit).Count();
            var totalMedium = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) > lowRiskLimit && Convert.ToInt32(l.ResidualRisk) <= mediumRiskLimit).Count();
            var totalHigh = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) > mediumRiskLimit && Convert.ToInt32(l.ResidualRisk) <= highRiskLimit).Count();

            if (startDate.HasValue && endDate.HasValue)
            {
                if (startDate > endDate)
                    return TypedResults.BadRequest("Start date cannot be greater than end date");

                riskAssessment = riskAssessment.Where(l => l.CreatedOnUtc.Date >= startDate.Value.Date && l.CreatedOnUtc.Date <= endDate.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(riskRating))
            {
                riskRating = riskRating.ToUpper();

                if(riskRating == "LOW")
                    riskAssessment = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) <= lowRiskLimit);
                else if (riskRating == "MEDIUM")
                    riskAssessment = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) > lowRiskLimit && Convert.ToInt32(l.ResidualRisk) <= mediumRiskLimit);
                else if (riskRating == "HIGH")
                    riskAssessment = riskAssessment.Where(l => Convert.ToInt32(l.ResidualRisk) > mediumRiskLimit && Convert.ToInt32(l.ResidualRisk) <= highRiskLimit);
                else
                    return TypedResults.BadRequest("Risk rating can only be Low, Medium or High");
            }

            if (isDownload)
            {
                if (riskAssessment.Count() == 0)
                    return TypedResults.NotFound("No record found");

                var reportName = "RiskAssessmentReport";
                var headers = new List<string> {
                    "Asset", "Asset Description", "Risk Assessment Date", "Category", "Confidentiality Rating", "Integrity Rating",
                    "Availability Rating", "Asset Value", "Asset Score", "Vulnerability", "Vulnerability Rating", "Threats", "Existing Primary Control",
                    "Impact Rating", "Likelihood Of Threat Occurring", "Risk Score", "Risk Value", "Risk Options", "Planned Control", "Control Effectiveness",
                    "Residual Risk", "Risk Owner", "Action Owner", "Additional Information", "Proposed Closure Date", "Remediation Status", "Requested By",
                    "Requested Date", "Approved By", "ApprovedvDate"
                };

                var riskReports = riskAssessment.Select(r => new UnitRiskAssessmentReportResponse
                {
                    Asset = r.Asset,
                    AssetDescription = r.AssetDescription,
                    RiskAssessmentDate = r.RiskAssessmentDate,
                    Category = r.Category,
                    ConfidentialityRating = r.ConfidentialityRating.GetEnumDestription(),
                    IntegrityRating = r.IntegrityRating.GetEnumDestription(),
                    AvailabilityRating = r.AvailabilityRating.GetEnumDestription(),
                    AssetValue = r.AssetValue,
                    AssetScore = r.AssetScore.GetEnumDestription(),
                    Vulnerability = r.Vulnerability,
                    VulnerabilityRating = r.VulnerabilityRating.GetEnumDestription(),
                    Threats = r.Threat,
                    ExistingPrimaryControl = r.ExistingPrimaryControls.Select(e => e.Name).FirstOrDefault(),
                    ImpactRating = r.ImpactRating.GetEnumDestription(),
                    LikelihoodofThreatOccurring = r.LikehoodOfthreatOccuring.GetEnumDestription(),
                    RiskScore = r.RiskScore,
                    RiskValue = r.RiskValue,
                    RiskOptions = r.RiskOption,
                    PlannedControl = r.PlannedControls.Select(p => p.Name).FirstOrDefault(),
                    ControlEffectiveness = r.ControlEffective,
                    ResidualRisk = r.ResidualRisk,
                    RiskOwner = r.ResidualRisk,
                    ActionOwner = r.ActionOwner,
                    AdditionalInformation = r.AdditionalInformation,
                    ProposedClosureDate = r.ProposeClosureDate,
                    RemediationStatus = r.RemediationStatus.GetEnumDestription(),
                    RequestedBy = r.CreatedBy,
                    RequestedDate = r.CreatedOnUtc,
                    ApprovedBy = r.ApprovedBy,
                    ApprovedDate = r.DateApproved
                }).ToList();

                var excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, riskReports);
                return TypedResults.File(excelByte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{reportName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
            }

            var response = riskAssessment.Select(r => new UnitRiskAssessment
            {
                Asset = r.Asset,
                AssetDescription = r.AssetDescription,
                RiskAssessmentDate = r.RiskAssessmentDate,
                Category = r.Category,
                ActionOwner = r.ActionOwner,
                RequestedBy = r.CreatedBy,
                RequestedDate = r.CreatedOnUtc,
                ApprovedBy = r.ApprovedBy,
                ApprovedDate = r.DateApproved,
                Status = r.Status.GetEnumDestription()
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
