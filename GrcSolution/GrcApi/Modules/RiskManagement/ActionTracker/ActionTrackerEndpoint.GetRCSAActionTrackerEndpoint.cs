using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Shared;
using System.Security.Claims;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Org.BouncyCastle.Ocsp;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 06/12/2023
    * Development Group: GRCTools
    * This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment by date range 
    */
    public class GetRCSAActionTrackerEndpoint
    {
        /// <summary>
        /// This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment by date range
        /// </summary>
        /// <param name="getInherentRiskControl"></param>
        /// <param name="getRCSAUnit"></param>
        /// <param name="getDocumentRCSA"></param>
        /// <param name="getActionManag"></param>
        /// <param name="getUnitName"></param>
        /// <param name="getAllRcsa"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ProcessInherentRiskControl> getInherentRiskControl,
            IRepository<RiskControlSelfAssessmentUnit> getRCSAUnit, IRepository<RSCAProcess> rcsaProcess,
            IRepository<DocumentRSCAProcess> getDocumentRCSA, IRepository<ActionManagement> getActionManag,
            IRepository<Unit> getUnitName, IRepository<RiskControlSelfAssessment> getAllRcsa,
            DateOnly startDate, DateOnly endDate, ClaimsPrincipal user, ICurrentUserService currentUserService
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

                foreach (var rcsa in rcsaReports)
                {
                    foreach (var rcsaUnit in rcsa.RiskControlSelfAssessmentUnits)
                    {
                        var unitName = units.FirstOrDefault(u => u.Id == rcsaUnit.UnitId)?.Name;

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
