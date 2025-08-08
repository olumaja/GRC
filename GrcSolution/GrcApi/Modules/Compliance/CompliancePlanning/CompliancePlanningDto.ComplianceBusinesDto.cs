using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public class UpdateComplianceBusiness
    {
        public string BusinessName { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string RCNumber { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string NameOfManagerOrMD { get; set; }
        public string CTO { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class UpdateComplianceBusinesDto : ComplianceBusinesDto
    {
        public Guid BusinessId { get; set; }
    }

    public class ComplianceBusinesDto
    {       
        public string? BusinessName { get; set; }
        public string? BusinessPhoneNumber { get; set; }
        public string? RCNumber { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? NameOfManagerOrMD { get; set; }
        public string? CTO { get; set; }
        public List<Guid> DepartmentIds { get; set; } = new List<Guid>();
    }

    public class ComplianceBusinesDtoValidator : AbstractValidator<ComplianceBusinesDto>
    {
        public ComplianceBusinesDtoValidator()
        {
            RuleFor(x => x.BusinessName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.BusinessPhoneNumber).NotNull().Matches("^[0-9]{11}$").WithMessage("invalid phone number, it must be 11 digits"); //   Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(x => x.BusinessPhoneNumber).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.RCNumber).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Description).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Address).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.NameOfManagerOrMD).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.CTO).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DepartmentIds).NotEmpty();
        }
    }

    public class ComplianceRegulatorDto
    {       
        public string? RegulatorTitle { get; set; }
        public string? Description { get; set; }       
    }

    public class GetComplianceRegulatorById
    {
        public Guid RegulatorId { get; set; }
        public string? RegulatorTitle { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
    
    public record RuleExcelUpload(Guid regulatorId, IFormFile rules)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a RuleExcelUpload object and returns object
        /// </summary>     
        public static ValueTask<RuleExcelUpload> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["regulatorId"], out var regulatorId);
           
            return ValueTask.FromResult(new RuleExcelUpload(
                   regulatorId,                  
                   httpContext.Request.Form.Files.GetFile("rules")
                ));
        }
    }
    public class RuleExcelUploadValidator : AbstractValidator<RuleExcelUpload>
    {
        public RuleExcelUploadValidator()
        {
            RuleFor(model => model.regulatorId).NotEmpty();
            RuleFor(model => model.rules).NotEmpty();        
          
        }
    }

    public class ComplianceRegulatorDtoValidator : AbstractValidator<ComplianceRegulatorDto>
    {
        public ComplianceRegulatorDtoValidator()
        {
            RuleFor(x => x.RegulatorTitle).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Description).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class ComplianceRulesAndRegulatorDto
    {
        public Guid RegulatorId { get; set; }
        public string? Section { get; set; }
        public string? Heading { get; set; }
        public string? Deadline { get; set; }
        public string? IssuesOrFillingOrReturn { get; set; }
        public string? Responsibilities { get; set; }
        public string? Penalty { get; set; }
        public List<Guid> BusinessInvolvedIds { get; set; }
    }


    public class ComplianceRulesAndRegulatorDtoValidator : AbstractValidator<ComplianceRulesAndRegulatorDto>
    {
        DateTime deadLine = DateTime.Now;
        public ComplianceRulesAndRegulatorDtoValidator()
        {
            RuleFor(x => x.Section).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Heading).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.IssuesOrFillingOrReturn).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Responsibilities).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Penalty).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Deadline).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);

        }
    }

    public class GetRulesAndRegulatorDetail
    {
        public Guid RuleId { get; set; }
        public string? Section { get; set; }
        public string? Heading { get; set; }
        public string? Deadline { get; set; }
        public string? IssuesOrFillingOrReturn { get; set; }
        public string? Responsibilities { get; set; }
        public string? Penalty { get; set; }
        public string? BusinessInvolved { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class UpdateComplianceRulesAndRegulator
    {
        public Guid RuleId { get; set; }
        public string? Section { get; set; }
        public string? Heading { get; set; }
        public string? Deadline { get; set; }
        public string? IssuesOrFillingOrReturn { get; set; }
        public string? Responsibilities { get; set; }
        public string? Penalty { get; set; }
        public List<Guid> BusinessInvolvedIds { get; set; }
    }

    public class GetRegulatorDetails
    {
        public string RegulatorTitle { get; set; }
        public string? NoOfRules { get; set; }       
    }

    public class GetComplianceBusinesResponse
    {
        public Guid Id { get; set; } 
        public string? BusinessName { get; set; }
        public string? BusinessPhoneNumber { get; set; }
        public string? RCNumber { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? NameOfManagerOrMD { get; set; }
        public string? CTO { get; set; }
        public DateTime DateCreated { get; set; }
        public int NumberOfDepartment { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }

    public class GetComplianceBusinesByIdResponse
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string RCNumber { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string NameOfManagerOrMD { get; set; }
        public string CTO { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public List<GetComplianceDeparment> Departments { get; set; }
    }

    public class GetRegulatorDetailsResponse
    {
        public Guid RegulatorId { get; set; }
        public string RegulatorTitle { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public int NoOfRules { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
    public class ComplianceRulesDetails
    {
        public Guid RuleId { get; set; }
        public string? Section { get; set; }
        public string? Heading { get; set; }
        public string? Deadline { get; set; }
        public string? IssuesOrFillingOrReturn { get; set; }
        public string? Responsibilities { get; set; }
        public string? Penalty { get; set; }
        public string? BusinessInvolved { get; set; }
    }

    public class ComplianceRulesExcelUploadReq
    {
        public string? Section { get; set; } = null;
        public string? Heading { get; set; } = null;
        public string? IssuesOrFillingOrReturns { get; set; } = null;
        public string? DeadlineOrPeriodForFillingReturns { get; set; } = null;
        public string? Responsibilities { get; set; } = null;
        public string? PenaltForNonComplianceIfAny { get; set; } = null;
    }

    public class GetComplianceLevelList
    {      
        public string BusinessUnit { get; set; }
        public string ReportName { get; set; }
        public string Frequesncy { get; set; }
        public DateTime? DeadLine { get; set; }
        public string? RespondStatus { get; set; }
        public int? AttachementCount { get; set; }
        public string? ReportStatus { get; set; }
        public string? LeveLStatus { get; set; }
        public string? ReasonForRejection { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ProcessOfficer { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }

}
