using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    public class BIAReportDto {

        public DateOnly DateStarted { get; set; }
        public int BusinessUnitCount {get; set; }
        public DateOnly PeriodFrom { get; set; }
        public  DateOnly PeriodTo  {get; set; }
        public  DateOnly StartDate  {get; set; }
        public  DateOnly EndDate  {get; set; }
        public  BIAStatus Status  {get; set; }
        public string? BuinessUnitName {get; set; }
        public string? Process { get; set; }
        public string? FinancialImpact { get; set; }
        public string? CustomerExperience { get; set; }
        public string? OtherProcessPeople { get; set; }
        public string? RegulatoryLegal { get; set; }
        public string? Reputation { get; set; }
        public string? ThirdPartyImpact { get; set; }
        public string? MBCO { get; set; }
        public string? MAO { get; set; }
        public string?   RTO { get; set; }
        public string? RPO { get; set; }
        public string? Priority { get; set; }
        public string? ResponsibleBusinessUnit { get; set; }
        public string? ApplicationUsedToRunProcess { get; set; }
        public string? KeyVendors { get; set; }
        public string? AnyNonElectronicVitalRecord { get; set; }
        public string? AlternativeWorkaround { get; set; }
        public string? PrimaryRecoveryStrategy { get; set; }
        public string? PeakPeriod { get; set; }
        public string? RemoteWork { get; set; }
        public ICollection<Data> Datas { get; set; }



        //string Financial

        /*

    buinessUnit:string,
    periodCovered:string,
    startDate:string,
    endDate:string,
    processes:string,
    status:string,
    finacial:string,
    customerExperience:string,
    otherProcess_slash_peole:string,
    regulatory_legal:string,
    reputation:string,
    third_party_impact:string,
    mbco:string,
    mao:string,
    rto:string,
    rpo:string,
    priority:string,
    responsible_buiness_unit:string,
    key_vendors:string,
    any_non_electronic_vital_records:string,
    alternative_workarrounds_durring_system_fail:string,
    primary_recovery_strategy_and_solution:string,
    peak_perioddd:string,
    remote_working:string
         */

    }




    public class Data
    {
        
        public string BusinessUnit { get; set; }
        
        public string FinacialResponsibilty { get; set; }
        
        public string CustomerExperience { get; set; }
        
        public string OtherProcess_slash_people { get; set; }
        
        public string Regulatory_legal { get; set; }
        
        public string Reputation { get; set; }
        
        public string Third_party_impact { get; set; }
        
        public string Mbco { get; set; }
        
        public string Mao { get; set; }
        
        public string Rto { get; set; }
        
        public string Rpo { get; set; }
        
        public string Priority { get; set; }
        
        public string Responsible_buiness_unit { get; set; }
        
        public string Key_vendors { get; set; }
        
        public string Any_non_electronic_vital_records { get; set; }
        
        public string Alternative_workarrounds_durring_system_fail { get; set; }
        
        public string Primary_recovery_strategy_and_solution { get; set; }
        
        public string Peak_period { get; set; }
        
        public string Remote_workin { get; set; }

    }
}
