using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Arm.GrcTool.Domain;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceDepartment : AuditEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<ComplianceBusinessDepartment> ComplianceBusinessDepartment { get; set; }

        public static ComplianceDepartment Create(Guid id, string departmentName)
        {
            return new ComplianceDepartment { Id = id, Name = departmentName };
        }
    }
        
    // This is a join table for compliance business and compliance department
    public class ComplianceBusinessDepartment : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ComplianceBusinessId { get; private set; }
        public Guid ComplianceDepartmentId { get; private set; }
        public ComplianceDepartment ComplianceDepartment { get; set; }
        public ComplianceBusines ComplianceBusiness { get; set; }

        public static ComplianceBusinessDepartment Create(Guid complianceBusinessId, Guid complianceDepartmentId)
        {
            return new ComplianceBusinessDepartment
            {
                ComplianceBusinessId = complianceBusinessId,
                ComplianceDepartmentId = complianceDepartmentId
            };
        }
    }

    public class ComplianceBusines : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? BusinessName { get; private set; }
        public string? BusinessPhoneNumber { get; private set; }
        public string? RCNumber { get; private set; }
        public string? Description { get; private set; }
        public string? Address { get; private set; }
        public string? NameOfManagerOrMD { get; private set; }
        public string? CTO { get; private set; }
        public string? InitiatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public List<ComplianceRulesBusiness> ComplianceRulesBusiness { get; set; }
        public List<ComplianceBusinessDepartment> ComplianceBusinessDepartment { get; set; }

        public static ComplianceBusines Create(ComplianceBusinesDto request, string? initiatedBy)
        {
            return new ComplianceBusines
            {
                BusinessName = request.BusinessName,
                BusinessPhoneNumber = request.BusinessPhoneNumber,
                RCNumber = request.RCNumber,
                Description = request.Description,
                Address = request.Address,
                NameOfManagerOrMD = request.NameOfManagerOrMD,
                CTO = request.CTO,
                InitiatedBy = initiatedBy
            };
        }

        public static ComplianceBusines Create(Guid id, string businessName)
        {
            return new ComplianceBusines
            {
                Id = id,
                BusinessName = businessName
            };
        }

        public void UpdateBusiness(UpdateComplianceBusiness request)
        {
            BusinessName = request.BusinessName;
            BusinessPhoneNumber = request.BusinessPhoneNumber;
            RCNumber = request.RCNumber;
            Address = request.Address;
            Description = request.Description;
            NameOfManagerOrMD = request.NameOfManagerOrMD;
            CTO = request.CTO;
            UpdatedBy = request.UpdatedBy;
        }
    }

    // This is a join table for compliance rules and compliance business
    public class ComplianceRulesBusiness : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ComplianceRuleId { get; private set; }
        public Guid BusinessId { get; private set; }
        public ComplianceRules ComplianceRule { get; set; }
        public ComplianceBusines ComplianceBusiness { get; set; }

        public static ComplianceRulesBusiness Create(Guid complianceRuleId, Guid businessId)
        {
            return new ComplianceRulesBusiness
            {
                ComplianceRuleId = complianceRuleId,
                BusinessId = businessId
            };
        }
    }

    public class ComplianceRules : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceRegulator))]
        public Guid ComplianceRegulatorId { get; set; }
        [ForeignKey(nameof(ComplianceRegulatorId))]
        public ComplianceRegulator ComplianceRegulator { get; set; }
        public string? Section { get; set; }
        public string? Heading { get; set; }
        public string? Deadline { get; set; }
        public string? IssuesOrFillingOrReturn { get; set; }
        public string? Responsibilities { get; set; }
        public string? Penalty { get; set; }
        public string? InitiatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public List<ComplianceRulesBusiness> ComplianceRulesBusiness { get; set; }

        public static ComplianceRules Create(Guid complianceRegulatorId, ComplianceRulesAndRegulatorDto request, string? initiatedBy)
        {
            return new ComplianceRules
            {
                ComplianceRegulatorId = complianceRegulatorId,
                Section = request.Section,
                Heading = request.Heading,
                Deadline = request.Deadline,
                IssuesOrFillingOrReturn = request.IssuesOrFillingOrReturn,
                Responsibilities = request.Responsibilities,
                Penalty = request.Penalty,
                InitiatedBy = initiatedBy
            };
        }

        public static ComplianceRules Create(
            Guid complianceRegulatorId, string section, string heading, string? deadline, string issuesOrFillingOrReturn,
            string responsibilities, string penalty, string businessInvolved
        )
        {
            return new ComplianceRules
            {
                ComplianceRegulatorId = complianceRegulatorId,
                Section = section,
                Heading = heading,
                Deadline = deadline,
                IssuesOrFillingOrReturn = issuesOrFillingOrReturn,
                Responsibilities = responsibilities,
                Penalty = penalty
            };
        }

        public static ComplianceRules ExcelUploadCreate(Guid complianceRegulatorId, ComplianceRulesExcelUploadReq request, string? initiatedBy)
        {
            return new ComplianceRules
            {
                ComplianceRegulatorId = complianceRegulatorId,
                Section = request.Section,
                Heading = request.Heading,
                Deadline = request.DeadlineOrPeriodForFillingReturns,
                IssuesOrFillingOrReturn = request.IssuesOrFillingOrReturns,
                Responsibilities = request.Responsibilities,
                Penalty = request.PenaltForNonComplianceIfAny,
                InitiatedBy = initiatedBy
            };
        }


    }
    public class ComplianceRegulator : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? RegulatorTitle { get; set; }
        public string? Description { get; set; }
        public string? InitiatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public List<ComplianceRules> ComplianceRules { get; set; }

        public static ComplianceRegulator Create(ComplianceRegulatorDto request, string? initiatedBy)
        {
            return new ComplianceRegulator
            {
                RegulatorTitle = request.RegulatorTitle,
                Description = request.Description,
                InitiatedBy = initiatedBy
            };
        }

        public static ComplianceRegulator Create(Guid id, string title, string description = null)
        {
            return new ComplianceRegulator
            {
                Id = id,
                RegulatorTitle = title,
                Description = description
            };
        }
    }
}
