using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 06/12/2023
     * Development Group: GRCTools
     * This endpoint fetches list of Risk Identification  and the total number of the Risk Identification 
     */
    public class GetRiskIdentificationWithCountEndpoint
    {
        /// <summary>
        /// This endpoint fetches list of Risk Identification  and the total number of the Risk Identification.  
        /// </summary>
        /// <param name="getRCSAUnit"></param>
        /// <param name="getActionManag"></param>
        /// <param name="getUnitName"></param>
        /// <param name="repository"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ActionManagement> getActionManag, IRepository<Unit> getUnitName, IRepository<RiskEvent> repository, IRepository<RiskEffectManagement> riskEffectRepo,
            IRepository<LossManagement> lossRepo, IRepository<User> userRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                string email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var getRiskIdentification = new List<RiskIdentificationList>();
                var getActionMag = await getActionManag.GetAllAsync();
                if (!currentUserService.CurrentUserUnitName.Equals("Risk Management", StringComparison.OrdinalIgnoreCase))
                    getActionMag = getActionMag.Where(a => a.ActionOwner == email).ToList();

                var users = await userRepo.GetAllAsync();
                var getAllUnits = await getUnitName.GetAllAsync();
                var riskEvent = await repository.GetAllAsync();
                //var lossManagement = await lossRepo.GetAllAsync();
                //var riskEffect = await riskEffectRepo.GetAllAsync();

                //var reportRiskIdent = repository.GetContextByConditon(x => x.Id != default).ToList();
                var riskIdentityIds = riskEvent.Select(x => x.Id).ToList();
                //var totalReporttList = getActionMag.Count();           
                //var lossManagement = await lossRepo.GetAllAsync();
                foreach (var item in getActionMag)
                {
                    //var getRiskEffect = riskEffect.Find(x => x.RiskEventId == item.RiskEventId); // was commented out
                    var getRiskEventDetail = riskEvent.Find(x => x.Id == item.RiskEventId);
                    //var loss = lossManagement.Find(x => x.RiskEventId == item.RiskEventId);  // was commented out
                    var riskEventUnitName = getAllUnits.Find(x => x.Id == getRiskEventDetail.UnitId);
                    var eventUnitNameResp = "";
                    if (riskEventUnitName != null)
                    {
                        eventUnitNameResp = riskEventUnitName.Name;
                    }


                    getRiskIdentification.Add(new RiskIdentificationList
                    {
                        ActionManagementId = item.Id,
                        ActionOwner = item.ActionOwner,
                        ActionPlan = item.Action,
                        BusinessUnit = eventUnitNameResp,
                        DueDate = item.ActionResolutionDate,
                        Status = getRiskEventDetail.AssesmentStatus.ToString(),
                        ActionStatus = item.ActionStatus.ToString(),
                        Action = item.Action,
                        ActionresolutionDate = item.ActionResolutionDate,
                        ActionProgress = item.ActionProgress,
                        DateOfIdentification = getRiskEventDetail.DateOfIdentification,
                        OccurrenceDate = getRiskEventDetail.DateOfOccurence,
                        EventDescription = getRiskEventDetail.RiskEventDescription,
                        EventIdentifier = getRiskEventDetail.ReportedByUsername,
                        GrossLossValue = getRiskEventDetail.EstimatedLoss,
                        DateCreated = getRiskEventDetail.DateOfIdentification,
                        LossValue = default, //getRiskEffect.LossValue,
                        EffectCategory = default, //getRiskEffect.EffectCategoryId,
                        EffectDescription = "", //getRiskEffect.EffectDescription,
                        EffectType = default, //getRiskEffect.EffectType,
                        RationalForGrossLossValue = "", //getRiskEffect.RationaleForGrossLossValue,
                        LastUpdate = getRiskEventDetail.ModifiedOnUtc,
                        RecoveryDate = item.ActionResolutionDate,
                        RecoveryDescription = getRiskEventDetail.RiskEventDescription,
                        RiskDriver = item.ActionOwner,

                        //mocked
                        EventSubCategory = "",
                        RiskDriverSubCategory = "",
                        RiskSubCategory = "",
                        AccountImpacted = "", //loss.AccountImpacted,                       
                        EventCategory = "",
                        EventType = default, //loss.RecoveryTypeId,
                        EventLocation = "",
                        EventLocationUnit = "",
                        EventLocationDepartment = "",
                        NetLoss = default, //loss.NetLoss,
                        RecoverdAmount = default //loss.RecoveredAmount,                       

                    });
                }

                GetRiskEventReportTrackers resp = new GetRiskEventReportTrackers()
                {
                    NumberOfRiskIdentification = getRiskIdentification.Count,
                    RiskIdentification = getRiskIdentification,
                };
                return TypedResults.Ok(resp);

            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
         }

    }
}