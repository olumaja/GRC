using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Domain;
using Microsoft.EntityFrameworkCore;



namespace Arm.GrcApi.Modules.OperationControl
{
    /*
         * Original Author: Sodiq Quadre
         * Date Created: 23/11/2024
         * Development Group: GRCTools
         * Get operation exception by Id Endpoint.
         */
    public class GetOperationExceptionByIdEndpoint
    {
        /// <summary>
        /// Get operation exception detail 
        /// </summary>
        /// <param name="actionOwnerId"></param>
        /// <param name="repository"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid operationExecptionId, IRepository<OperationControl> repository,
             IRepository<Document> docRepo, ICurrentUserService currentUserService
        )
        {
            var exception = repository.GetContextByConditon(r => r.Id == operationExecptionId).FirstOrDefault();

            if (exception is null)
                return TypedResults.NotFound("Record not found");
                       

            var actionAttachments = await docRepo.GetContextByConditon(d => d.ModuleItemId == exception.Id && d.ModuleItemType == ModuleType.OperationControl)
                                    .Select(d => new GetAttachedReportResponse
                                    {
                                        DocumentId = d.Id,
                                        DateCreated = d.CreatedOnUtc,
                                        DocumentName = d.Name
                                    }).ToListAsync();
            var actionowneractionAttachments = await docRepo.GetContextByConditon(d => d.ModuleItemId == exception.Id && d.ModuleItemType == ModuleType.ActionOwnerOperationControl)
                                   .Select(d => new GetAttachedReportResponse
                                   {
                                       DocumentId = d.Id,
                                       DateCreated = d.CreatedOnUtc,
                                       DocumentName = d.Name
                                   }).ToListAsync();

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
