using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Shared;
using System.Security.Claims;
using Microsoft.VisualBasic;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 06/12/2023
   * Development Group: GRCTools
   * This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment  
   */
    public class GetRCSAWithCountActionTrackerEndpoint
    {
        /// <summary>
        /// This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment 
        /// </summary>
        /// <param name="getInherentRiskControl"></param>
        /// <param name="getRCSAUnit"></param>
        /// <param name="getDocumentRCSA"></param>
        /// <param name="getActionManag"></param>
        /// <param name="getUnitName"></param>
        /// <param name="getAllRcsa"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ProcessInherentRiskControl> getInherentRiskControl,
            IRepository<RiskControlSelfAssessmentUnit> getRCSAUnit, IRepository<RSCAProcess> rcsaProcess,
            IRepository<DocumentRSCAProcess> getDocumentRCSA, IRepository<ActionManagement> getActionManag,
            IRepository<Unit> getUnitName, IRepository<RiskControlSelfAssessment> getAllRcsa, ICurrentUserService currentUserService
        )            
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getRcsa = new List<RiskControlSelfAssessmentList>();
                string status = "";
                var getRCSAInherentRiskControl = getInherentRiskControl.GetAll();

                if (!currentUserService.CurrentUserUnitName.Equals("Risk Management", StringComparison.OrdinalIgnoreCase))
                {
                    getRCSAInherentRiskControl = getRCSAInherentRiskControl.Where(r => r.ActionOwnerUserName == currentUserService.CurrentUserEmail);
                }

                var documentRCSAProcessIds = getRCSAInherentRiskControl.Select(r => r.DocumentRCSAProcessId)
                                                                        .ToHashSet();

                var reportRcsa = await getAllRcsa.GetAllAsync();
                var processes = await rcsaProcess.GetAllAsync();

                var getRcsaUnitName = getRCSAUnit.GetAll()
                                                .Include(u => u.Unit)
                                                .Include(x => x.DocumentRSCAProcess)
                                                .ThenInclude(y => y.ProcessInherentRiskControls)
                                                .Where(x => documentRCSAProcessIds.Contains(x.DocumentRSCAProcess.Id))
                                                .ToList();

                foreach (var item in getRcsaUnitName)
                {
                    foreach (var res in item.DocumentRSCAProcess.ProcessInherentRiskControls)
                    {
                        if (res.ActionStatus == PIRCActionState.Open)
                        {
                            status = "Open";
                        }
                        if (res.ActionStatus == PIRCActionState.Pending)
                        {
                            status = "Pending";
                        }
                        if (res.ActionStatus == PIRCActionState.Complete)
                        {
                            status = "Completed";
                        }

                        var getRcsaPeriodCover = reportRcsa.Find(c => c.Id == item.RiskControlSelfAssessmentId);
                        var process = processes.Find(p => p.Id == res.ProcessId)?.Name;

                        getRcsa.Add(new RiskControlSelfAssessmentList
                        {
                            ProcessInherentRiskId = res.Id,
                            ActionPlan = res.CorrectiveActions,
                            ActionOwner = res.ActionOwnerUserName,
                            BusinessUnit = item.Unit.Name,
                            DueDate = res.TimeLine,
                            Status = status,
                            Progress = res.ActionProgress,
                            CorrectiveActions = res.ActionProgress,
                            Processes = "", //rcsaProc,
                            StartDate = getRcsaPeriodCover?.StartDate,
                            EndDate = getRcsaPeriodCover?.EndDate,
                            PeriodCovered = string.Format("{0} - {1}", getRcsaPeriodCover?.PeriodFrom, getRcsaPeriodCover?.PeriodTo),
                            InherentRisk = res.InherentRisk,
                            Control = res.Control,
                            Test = res.TestToApply,
                            TestResult = res.TestResult,
                            ControlEffectiveness = res.ColourEffectiveness,
                            ResidualRiskRating = res.ResidualRiskRating,
                            ResidualRiskLevel = res.ResidualRiskLevel,
                            ResidualRisk = res.ResidualRisks,
                            Requester = item.Requester,
                            Approval = item.Approval,
                            ApprovalDate = item.ApprovalDate
                        });
                    };
                }

                GetRCSAReportTrackers resp = new GetRCSAReportTrackers()
                {
                    NumberOfRiskControlSelfAssessment = getRcsa.Count,
                    RiskControlSelfAssessment = getRcsa,
                };
                return TypedResults.Ok(resp);
            }
            catch ( Exception ex )
            {
                return TypedResults.NotFound("Record not found");
            }
            
        }           

    }
}
