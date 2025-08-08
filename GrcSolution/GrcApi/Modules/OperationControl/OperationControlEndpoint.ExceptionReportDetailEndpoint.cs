using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class ExceptionReportDetailEndpoint
    {
        public static async Task<IResult> HandleAsync(
            Guid exceptionId, IRepository<OperationControl> operationRepo, IRepository<Document> docRepo, 
            ICurrentUserService currentUserService
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
            {
                return TypedResults.Unauthorized();
            }

            var exception = await operationRepo.GetByIdAsync(exceptionId);

            if(exception is null)
                return TypedResults.NotFound("No record found");

            var actionAttachments = docRepo.GetContextByConditon(d => d.ModuleItemId == exception.Id && d.ModuleItemType == ModuleType.OperationControl)
                                    .Select(d => new GetAttachedReportResponse
                                    {
                                        DocumentId = d.Id,
                                        DateCreated = d.CreatedOnUtc,
                                        DocumentName = d.Name
                                    }).ToList();

            var actionowneractionAttachments = docRepo.GetContextByConditon(d => d.ModuleItemId == exception.Id && d.ModuleItemType == ModuleType.ActionOwnerOperationControl)
                                   .Select(d => new GetAttachedReportResponse
                                   {
                                       DocumentId = d.Id,
                                       DateCreated = d.CreatedOnUtc,
                                       DocumentName = d.Name
                                   }).ToList();

            return TypedResults.Ok(new GetOperationExceptionsByIdResp(
                OpearationExceptionId: exception.Id,
                DateRaised: exception.CreatedOnUtc,
                OperationActivity: exception.OperationActivity,
                Unit: exception.Unit,
                Actionowner: exception.ActionOwner,
                ActionOwnerEmail: exception.ActionOwnerEmail,
                ExceptionDescription: exception.ExceptionDescription,
                ActionPoint: exception.ActionPoint,
                Loggedby: exception.CreatedBy,
                LoggedbyEmailAddress: exception.RequestedEmailAddress,
                ExceptionCategory: exception.ExceptionCategory.ToString(),
                ProposedCompletionDate: exception.CompletionDate,
                TransactionCallOverType: exception.TransactionCallOverType,
                TransactionDate: exception.TransactionDate,
                TransactionAmount: exception.TransactionAmount,
                Comment: exception.Comment,
                ResolutionStatusForActionOwner: exception.Status.ToString(),
                ResolutionStatus: exception.ResolutionStatus.ToString(),
                DateResolved: exception.DateResolved,
                ActionOwnerResponse: exception.ActionOwnerComment,
                ActionOwnerResponseDate: exception.ActionOwnerResponseDate,
                ReAssignedOfficer: exception.ReAssignedOfficer,
                ApprovalProcess: exception.ApprovalProcess,
                ReAssignedDate: exception.ReAssignedDate,
                ApprovalName: exception.ApprovalName,
                SupervisorName: exception.SupervisorName,
                ReasonForRejection: exception.ReasonForRejection,
                Attachments: actionAttachments,
                ActionOwnerAttachments: actionowneractionAttachments
            ));
        }
    }
}
