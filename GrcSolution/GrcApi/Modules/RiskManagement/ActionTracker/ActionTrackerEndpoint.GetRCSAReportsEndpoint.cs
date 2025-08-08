using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using static System.Net.Mime.MediaTypeNames;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 15/12/2023
* Development Group: GRCTools
* This endpoint fetches list Risk Control Self Assessment by date range and unitId
*/
    public class GetRCSAReportsEndpoint
    {
        /// <summary>
        /// This endpoint fetches list Risk Control Self Assessment by date range and unitId
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="user"></param>
        /// <param name="unitRepo"></param>
        /// <param name="getAllRcsa"></param>
        /// <returns></returns>
        /// 


        public static async Task<IResult> HandleAsync(
            Guid unitId, DateOnly startDate, DateOnly endDate, IRepository<RSCAProcess> rcsaProcess,
            IRepository<Unit> getUnitName, IRepository<RiskControlSelfAssessment> getAllRcsa, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                if (startDate == default || endDate == default)
                {
                    return TypedResults.BadRequest("Enter valid date format");
                }

                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }

                var response = new List<ActionTrackerRCSAReport>();
                var units = await getUnitName.GetAllAsync();
                var processes = await rcsaProcess.GetAllAsync();
                var rcsaReports = getAllRcsa.GetContextByConditon(r => r.StartDate >= startDate && r.EndDate <= endDate)
                                            .Include(r => r.RiskControlSelfAssessmentUnits)
                                            .ThenInclude(u => u.DocumentRSCAProcess)
                                            .ThenInclude(d => d.ProcessInherentRiskControls)
                                            .ToList();

                var unitName = units.Find(u => u.Id == unitId)?.Name;
                var idOfUnitWithSameName = units.Where(u => u.Name == unitName)
                                                    .Select(u => u.Id)
                                                    .ToList();

                foreach (var rcsa in rcsaReports)
                {
                    foreach (var rcsaUnit in rcsa.RiskControlSelfAssessmentUnits)
                    {
                        if (!idOfUnitWithSameName.Contains(rcsaUnit.UnitId))
                            continue;

                        if (rcsaUnit.DocumentRSCAProcess.ProcessInherentRiskControls.Count > 0)
                        {
                            foreach (var processControl in rcsaUnit.DocumentRSCAProcess.ProcessInherentRiskControls)
                            {

                                var processName = processes.FirstOrDefault(u => u.Id == processControl.ProcessId)?.Name;

                                response.Add(new ActionTrackerRCSAReport
                                {
                                    PeriodFrom = rcsa.PeriodFrom,
                                    PeriodTo = rcsa.PeriodTo,
                                    StartDate = rcsa.StartDate,
                                    EndDate = rcsa.EndDate,
                                    DateCreated = rcsa.CreatedOnUtc,
                                    BusinessUnit = unitName,
                                    Processes = processName,
                                    InherentRisk = processControl.InherentRisk,
                                    Control = processControl.Control,
                                    Test = processControl.TestToApply,
                                    TestResult = processControl.TestResult,
                                    ControlEffectiveness = processControl.ColourEffectiveness,
                                    ResidualRisk = processControl.ResidualRisks,
                                    ResidualRiskRating = processControl.ResidualRiskRating,
                                    ResidualRiskLevel = processControl.ResidualRiskLevel,
                                    CorrectiveActions = processControl.CorrectiveActions,
                                    ActionOwner = processControl.ActionOwnerUserName,
                                    ActionProgress = processControl.ActionProgress,
                                    TimeLine = processControl.TimeLine,
                                    Status = rcsaUnit.DocumentRSCAProcess.Status.ToString(),
                                    Requester = rcsaUnit.Requester,
                                    Approval = rcsaUnit.Approval,
                                    ApprovalDate = rcsaUnit.ApprovalDate
                                });
                            }
                        }
                        else
                        {
                            response.Add(new ActionTrackerRCSAReport
                            {
                                PeriodFrom = rcsa.PeriodFrom,
                                PeriodTo = rcsa.PeriodTo,
                                StartDate = rcsa.StartDate,
                                EndDate = rcsa.EndDate,
                                DateCreated = rcsa.CreatedOnUtc,
                                BusinessUnit = unitName,
                                Processes = null,
                                InherentRisk = null,
                                Control = null,
                                Test = null,
                                TestResult = null,
                                ControlEffectiveness = null,
                                ResidualRisk = null,
                                ResidualRiskRating = null,
                                ResidualRiskLevel = null,
                                CorrectiveActions = null,
                                ActionOwner = null,
                                ActionProgress = null,
                                TimeLine = null,
                                Status = rcsaUnit.DocumentRSCAProcess.Status.ToString(),
                                Requester = rcsaUnit.Requester,
                                Approval = rcsaUnit.Approval,
                                ApprovalDate = rcsaUnit.ApprovalDate
                            });
                        }
                    }
                }

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
