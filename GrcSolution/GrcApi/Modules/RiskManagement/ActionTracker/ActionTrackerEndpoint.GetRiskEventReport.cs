using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.Risk;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.ActionTracker;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 27/12/2023
     * Development Group: GRCTools
     * The endpoint get risk identification report within specified date range
    */
    public class ActionTrackerEndpointGetRiskEventReport
    {
        /// <summary>
        /// The endpoint get risk identification report within specified date range
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="riskEventRepo"></param>
        /// <param name="lossRepo"></param>
        /// <param name="deptRepo"></param>
        /// <param name="businessRepo"></param>
        /// <returns></returns>

        public static async Task<IResult> HandleAsync(
            Guid unitId, DateOnly startDate, DateOnly endDate, ICurrentUserService currentUserService, IRepository<ActionManagement> getActionManag, IRepository<Unit> getUnitName,
            IRepository<RiskEvent> repository, IRepository<RiskEffectManagement> riskEffect, IRepository<RiskEventManagement> riskEventMgRepo,
            IRepository<LossManagement> lossRepo, IRepository<Department> deptRepo,
            IRepository<BusinessEntity> businessRepo, IRepository<RiskEventType> riskEventTypeRepo, IRepository<RiskEventTypeCategory> riskEventTypeCategoRepo,
            IRepository<RiskEventTypeSubCategory> riskEventTypeSubCategoRepo, IRepository<RiskDriver> riskDriverRepo, IRepository<RiskDriverCategory> riskDriverCategoRepo,
            IRepository<RiskDriverSubCategory> riskDriverSubCategoRepo, IRepository<RiskEffectCategory> riskEffectCatRepo
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

                var getRiskIdentification = new List<ActionTrackerDtoRiskReport>();

                var getAllUnits = await getUnitName.GetAllAsync();
                var unitName = getAllUnits.Find(u => u.Id == unitId)?.Name;
                var idOfUnitWithSameName = getAllUnits.Where(u => u.Name == unitName)
                                                    .Select(u => u.Id)
                                                    .ToList();

                var depts = await deptRepo.GetAllAsync();
                var business = await businessRepo.GetAllAsync();
                var riskActionMgt = await getActionManag.GetAllAsync();
                var riskEffectMgt = await riskEffect.GetAllAsync();
                var riskEventMgt = await riskEventMgRepo.GetAllAsync();
                var riskLossMgt = await lossRepo.GetAllAsync();
                var riskEventTypes = await riskEventTypeRepo.GetAllAsync();
                var riskEventTypesCatgo = await riskEventTypeCategoRepo.GetAllAsync();
                var riskEventTypeSubCatego = await riskEventTypeSubCategoRepo.GetAllAsync();
                var riskDrivers = await riskDriverRepo.GetAllAsync();
                var riskDriverCatego = await riskDriverCategoRepo.GetAllAsync();
                var riskDriverSubCatego = await riskDriverSubCategoRepo.GetAllAsync();
                var riskEffectCatego = await riskEffectCatRepo.GetAllAsync();
                var riskEvent = repository.GetContextByConditon(r => idOfUnitWithSameName.Contains(r.UnitId) && r.DateOfIdentification >= startDate && r.DateOfIdentification <= endDate).ToList();

                foreach (var risk in riskEvent)
                {
                    var actionMg = riskActionMgt.Find(x => x.RiskEventId == risk.Id);
                    var effectMg = riskEffectMgt.Find(x => x.RiskEventId == risk.Id);
                    var eventMg = riskEventMgt.Find(x => x.RiskEventId == risk.Id);
                    var lossMg = riskLossMgt.Find(x => x.RiskEventId == risk.Id);
                    var deptName = depts.FirstOrDefault(u => u.Id == risk.DepartmentId)?.Name;
                    var businessName = business.FirstOrDefault(u => u.Id == risk.BusinessEntityId)?.Name;
                    var riskEventTypeName = riskEventTypes.FirstOrDefault(u => u.Id == eventMg?.EventTypeId)?.Name;
                    var riskEventTypeCatName = riskEventTypesCatgo.FirstOrDefault(u => u.Id == eventMg?.EventCategoryId)?.Name;
                    var riskEventTypeSubCatName = riskEventTypeSubCatego.FirstOrDefault(u => u.Id == eventMg?.EventSubCategoryId)?.Name;
                    var riskDriverName = riskDrivers.FirstOrDefault(u => u.Id == eventMg?.RiskDriverId)?.Name;
                    var riskDriverCatName = riskDriverCatego.FirstOrDefault(u => u.Id == eventMg?.RiskDriverCategoryId)?.Name;
                    var riskDriverSubCatName = riskDriverSubCatego.FirstOrDefault(u => u.Id == eventMg?.RiskDriverSubCategoryId)?.Name;
                    var effectCatName = riskEffectCatego.FirstOrDefault(u => u.Id == effectMg?.EffectCategoryId)?.Name;

                    getRiskIdentification.Add(new ActionTrackerDtoRiskReport
                    {
                        ActionManagementId = actionMg?.Id,
                        OccurrenceDate = risk.DateOfIdentification,
                        DateOfIdentification = risk.DateOfIdentification,
                        EventDescription = risk.RiskEventDescription,
                        EventLocation = businessName,
                        EventLocationDepartment = deptName,
                        EventLocationUnit = unitName,
                        LastUpdated = risk.ModifiedOnUtc,
                        DateCreated = risk.CreatedOnUtc,
                        EventIdentifier = risk.ReportedByUsername,
                        EventType = riskEventTypeName,
                        EventCategory = riskEventTypeCatName,
                        EventSubCategory = riskEventTypeSubCatName,
                        RiskDriver = riskDriverName,
                        RiskDriverCategory = riskDriverCatName,
                        RiskDriverSubCategory = riskDriverSubCatName,
                        RiskDriverDescription = eventMg?.RiskDriverDescription,
                        EffectType = effectMg?.EffectType.ToString(),
                        EffectCategory = effectCatName,
                        LossValue = effectMg?.LossValue,
                        RationaleForGrossLosValue = effectMg?.RationaleForGrossLossValue,
                        EffectDescription = effectMg?.EffectDescription,
                        Action = actionMg?.Action,
                        ActionProgress = actionMg?.ActionProgress,
                        ActionResolutionDate = actionMg?.ActionResolutionDate,
                        ActionOwner = actionMg?.ActionOwner,
                        ActionStatus = actionMg?.ActionStatus.ToString(),
                        GrossLossValue = lossMg?.GrossLossValue,
                        RecoveryAmount = lossMg?.RecoveredAmount,
                        RecoveryDate = lossMg?.RecoveryDate,
                        RecoveryDescription = lossMg?.RecoveryDescription,
                        NetLoss = lossMg?.NetLoss,
                        AccountImpacted = lossMg?.AccountImpacted,
                        Status = risk.AssesmentStatus.ToString(),
                        Requester = risk.Requester,
                        Approval = risk.Approval,
                        ApprovalDate = risk.ApprovalDate
                    });
                }

                return TypedResults.Ok(getRiskIdentification);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
   
    
}
    
