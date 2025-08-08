//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.Shared;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
//{
//    /*
//     * Original Author: Sodiq Quadre
//     * Date Created: 06/12/2023
//     * Development Group: GRCTools
//     * This endpoint fetches list of Risk Identification  and the total number of the Risk Identification by date range 
//     * This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment by date range 
//     * The list of the records are paginated
//     */
//    public class GetRiskeventAndRCSAReportsEndpoint
//    {

//        /// <summary>
//        /// This endpoint fetches list of Risk Identification  and the total number of the Risk Identification by date range 
//        /// This endpoint fetches list Risk Control Self Assessment and the total number of the Risk Control Self Assessment by date range
//        /// </summary>
//        /// <param name="getRcsaUnit"></param>
//        /// <param name="getActionManag"></param>
//        /// <param name="getUnitName"></param>
//        /// <param name="getAllRcsa"></param>
//        /// <param name="repository"></param>
//        /// <param name="startDate"></param>
//        /// <param name="endDate"></param> 
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(IRepository<ProcessInherentRiskControl> getInherentRiskControl,
//            IRepository<RiskControlSelfAssessmentUnit> getRCSAUnit,
//            IRepository<DocumentRSCAProcess> getDocumentRCSA, IRepository<ActionManagement> getActionManag,
//            IRepository<Unit> getUnitName, IRepository<RiskControlSelfAssessment> getAllRcsa, IRepository<RiskEvent> repository,
//            DateOnly startDate, DateOnly endDate, ClaimsPrincipal user)
//        {
//            if (user is null)
//            {
//                return TypedResults.BadRequest("User must be logged in");
//            }
//            var getRiskIdentification = new List<RiskIdentificationList>();
//            var getRcsa = new List<RiskControlSelfAssessmentList>();
//            var getAllUnits = await getUnitName.GetAllAsync();
//            var getActionMag = await getActionManag.GetAllAsync();

//            var getRCSAInherentRiskControl = await getInherentRiskControl.GetAllAsync();
//            var getDocumentRCSAProcess = await getDocumentRCSA.GetAllAsync();
//            #region get Risk Identification reports         

//            var reportRiskIdentResult = repository.GetContextByConditon(x => x.DateOfIdentification >= startDate && x.DateOfIdentification <= endDate).ToList();

//            var riskIdentityResultIds = reportRiskIdentResult.Select(x => x.Id).ToList();

//            var totalReportResultList = reportRiskIdentResult.Count();
//            foreach (var item in getActionMag)
//            {
//                if (riskIdentityResultIds.Contains(item.RiskEventId))
//                {
//                    var riskEvent = reportRiskIdentResult.Find(x => x.Id == item.RiskEventId);
//                    var riskEventUnitName = getAllUnits.Find(x => x.Id == riskEvent.UnitId);
//                    var eventUnitNameResp = "";
//                    if (riskEventUnitName != null)
//                    {
//                        eventUnitNameResp = riskEventUnitName.Name;

//                    }
//                    getRiskIdentification.Add(new RiskIdentificationList
//                    {
//                        ActionManagementId = item.Id,
//                        ActionOwner = item.ActionOwner,
//                        ActionPlan = item.Action,
//                        BusinessUnit = eventUnitNameResp,
//                        DueDate = item.ActionResolutionDate,
//                        Status = item.ActionStatus
//                        //Status = item.ActionResolutionDate < DateOnly.FromDateTime(DateTime.Now) ? "Over Due" : "Pending"
//                    });
//                }
//            }
//            #endregion

//            #region get RCSA reports
//            var reportRcsaResult = getAllRcsa.GetContextByConditon(c => c.StartDate >= startDate && c.EndDate <= endDate).Select(x => x.Id).ToList();

//            var totalRcsaResultList = reportRcsaResult.Count();

//            var getRcsaUnitName = getRCSAUnit.GetAll().Include(x => x.DocumentRSCAProcess).ThenInclude(y => y.ProcessInherentRiskControls).ToList();

//            foreach (var item in getRcsaUnitName)
//            {
//                if (reportRcsaResult.Contains(item.RiskControlSelfAssessmentId))
//                {
//                    foreach (var res in item.DocumentRSCAProcess.ProcessInherentRiskControls)
//                    {
//                        getRcsa.Add(new RiskControlSelfAssessmentList
//                        {
//                            ProcessInherentRiskId = res.Id,
//                            ActionPlan = res.CorrectiveActions,
//                            ActionOwner = res.ActionOwnerUserName,
//                            BusinessUnit = item.Unit.Name,
//                            DueDate = res.TimeLine,
//                            Status = res.ActionStatus
//                        });

//                    };
//                }
//            }

//            #endregion

//            GetRiskEventAndRCSAReportTrackers response = new GetRiskEventAndRCSAReportTrackers()
//            {
//                NumberOfRiskIdentification = totalReportResultList,
//                NumberOfRiskControlSelfAssessment = totalRcsaResultList,
//                RiskIdentification = getRiskIdentification,
//                RiskControlSelfAssessment = getRcsa,
//            };
//            return TypedResults.Ok(response);
//        }

//    }
//}
