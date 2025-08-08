using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GrcApi.Modules.Compliance.CompliancePlanning;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class GetInternalControlResp
    {
        public Guid InternalControlId { get; set; } 
        public string? Title { get; set; }
        public int? NoOfCollaboration { get; set; } 
        public int? NoOfActionOwners { get; set; } 
        public string? IssueSummary { get; set; }
        public int? AttachmentCount { get; set; } 
        public string? ReasonForRejection { get; set; } 
        public string Status { get; set; } 
        public string? Collaborators { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public List<GetInternalControlActionOwnerResp> ActionToResolve { get; set; }
        public List<GetAttachedReportResponse> Attachments { get; set; }
    }

    public class GetInternalControlActionOwnerResp
    {       
        //public string? ActionToBeResolved { get; set; }
        public string? ActionOwner { get; set; }
        public string? ActionOwnerEmail { get; set; }
        public string? Unit { get; set; }
        public string? ActionOwnerStatus { get; set; } 
        public DateTime Deadline { get; set; }
    }

    public record PaginatedAllInternalControl(PaginationMeta PaginationMeta, List<GetAllInternalControlResp> Responses);

    public class GetAllInternalControlResp
    {
        public Guid InternalControlId { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Collaborators { get; set; }
        public int? ActionOwners { get; set; }
        public string Status { get; set; }
    }

    public record PaginatedInternalControlForActionOwner(
        PaginationMeta PaginationMeta,
        List<GetAllInternalControlForActionOwner> Responses
    );

    public class GetAllInternalControlForActionOwner
    {
        public Guid ActionOwnerId { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }

    public record PaginatedClosedInternalControl(PaginationMeta PaginationMeta, List<GetClosedInternalControlResponse> Responses);

    public class GetClosedInternalControlResponse
    {
        public Guid InternalControlId { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? InitiatingOfficer { get; set; }
        public string? Collaborators { get; set; }
    }

    public class GetClosedInternalControlByIdResponse
    {
        public Guid InternalControlId { get; set; }
        public string? Title { get; set; }
        public string? IssueSummary { get; set; }
        public List<GetClosedInternalControlAction> Actions { get; set; }
        public DocumentTrail DocumentTrail { get; set; }

    }

    public class DocumentTrail
    {
        public string OfficerName { get; set; }
        public string Unit { get; set; }
        public List<GetAttachedReportResponse> Attachments { get; set; }
        public List<ActionOwnerDocumentTrail> ActionOwnerDocumentTrails { get; set; }
    }

    public class ActionOwnerDocumentTrail
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public List<GetAttachedReportResponse> Attachments { get; set; }
    }

    public class GetClosedInternalControlAction
    {
        public string? ActionToBeResolved { get; set; }
        public string? InitiatingOfficer { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime Deadline { get; set; }
        public List<ActionOwnerReportResponse> ActionOwners { get; set; }
    }

    public class ActionOwnerReportResponse
    {
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string? ResponseSummary { get; set; }
        public int DocumentCount { get; set; }
        public DateTime? DateReplied { get; set; }
    }

    public record GetActionOwnerInternalControlByIdResponse(
        Guid  ActionOwnerId,
        string? Title,
        string? IssueSummary,
        string? ActionToBeResolved,
        string? ReasonForRejection,
        string? Response,
        DateTime Deadline,
        string Status,
        string? ActionOwnerStatus,
        string? ReasonForReject,
        List<GetAttachedReportResponse> Attactments,
        List<GetAttachedReportResponse> ActionOwnerAttachments
    );

    public class GetInternalControlByIdResponse
    {
        public Guid InternalControlId { get; set; }
        public string? Title { get; set; }
        public string? IssueSummary { get; set; }
        public string? ReasonForRejection { get; set; }
        public string Status { get; set; }
        public List<Collaborator> Collaborators { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public List<InternalControlActionInputted> ActionToResolve { get; set; }
        public List<ActionOwnerResponse> Response { get; set; }
        public List<GetAttachedReportResponse> Attachments { get; set; }
    }

    public record Collaborator(string? Name, string Email);

    public class InternalControlActionInputted
    {
        public string? ActionToBeResolved { get; set; }
        public List<GetInternalControlActionOwnerResp> ActionOwners { get; set; }
    }

    public class ActionOwnerResponse
    {
        public string? ActionToResolve { get; set; }
        public List<ActionOwnerDetail> Details { get; set; }
    }

    public class ActionOwnerDetail
    {
        public Guid ActionOwerId { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string ActionOwnerStatus { get; set; }
        public string? ResponseSummary { get; set; }
        public DateTime? ResponseTime { get; set; }
        public List<GetAttachedReportResponse> ActionOwnerAttachments { get; set; }
    }

    public record ApproveInternalControlRequest(Guid ActionOwnerId);
    public record SupervisorApproveExceptionRequest(Guid exceptionTrackerId);
    public class SupervisorApproveExceptionRequestValidation : AbstractValidator<SupervisorApproveExceptionRequest>
    {
        public SupervisorApproveExceptionRequestValidation()
        {
            RuleFor(r => r.exceptionTrackerId).NotEmpty();
        }
    }


    public record ApproveCallOverReportRequest(Guid CallOverId);

    public class ApproveCallOverReportRequestValidator: AbstractValidator<ApproveCallOverReportRequest>
    {
        public ApproveCallOverReportRequestValidator()
        {
            RuleFor(r => r.CallOverId).NotEmpty();
        }
    }

    public record RejectInternalControlRequest(Guid ActionOwnerId, string ReasonForRejection);

    public class RejectInternalControlRequestValidation : AbstractValidator<RejectInternalControlRequest>
    {
        public RejectInternalControlRequestValidation()
        {
            RuleFor(r => r.ActionOwnerId).NotEmpty();
            RuleFor(r => r.ReasonForRejection).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }



    public record RejectCallOverReportRequest(Guid CallOverId, string ReasonForRejection);

    public class RejectCallOverReportRequestValidation : AbstractValidator<RejectCallOverReportRequest>
    {
        public RejectCallOverReportRequestValidation()
        {
            RuleFor(r => r.CallOverId).NotEmpty();
            RuleFor(r => r.ReasonForRejection).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record SupervisorRejectExceptionRequest(Guid exceptionTrackerId, string ReasonForRejection);

    public class SupervisorRejectExceptionRequestValidation : AbstractValidator<SupervisorRejectExceptionRequest>
    {
        public SupervisorRejectExceptionRequestValidation()
        {
            RuleFor(r => r.exceptionTrackerId).NotEmpty();
            RuleFor(r => r.ReasonForRejection).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }


}
