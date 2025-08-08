using Arm.GrcTool.Domain.RiskEvent;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
     record RiskEventReportDto(
        DateOnly OccurenceDate,
        DateOnly DateOfIdentification,
           string EventDescription,
           string EventLocation,
           string EventDepartment,
        decimal Loss,
        decimal NetLoss,
        decimal LossInRationale,
        decimal GrossLoss,
        decimal RecoveredAmount,
           string EventIdentifier,
        DateTime? LastUpdated,
        DateTime DateCreated,
           string Status, //Status Status,

         Guid ActionManagementId ,
            string ActionPlan ,
            string ActionOwner ,
            string BusinessUnit ,
            string ActionProgress ,
         DateOnly DueDate ,
         DateOnly OccurrenceDate ,
            string EventLocationDepartment ,
          string EventLocationUnit ,
         DateTime? LastUpdate ,    
         Guid EventType ,
          string EventCategory ,
            string EventSubCategory ,
            string RiskSubCategory ,
            string RiskDriver ,
            string RiskDriverSubCategory ,
         EffectType EffectType ,
         Guid EffectCategory ,
         decimal LossValue ,
            string? RationalForGrossLossValue ,
            string EffectDescription ,
          string Action ,
         DateOnly ActionresolutionDate ,
         decimal GrossLossValue ,
         decimal RecoverdAmount ,
         DateOnly RecoveryDate ,
            string RecoveryDescription ,
          string AccountImpacted 
    );
    
}
