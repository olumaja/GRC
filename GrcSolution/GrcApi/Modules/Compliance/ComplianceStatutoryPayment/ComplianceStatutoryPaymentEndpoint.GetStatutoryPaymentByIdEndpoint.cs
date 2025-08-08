using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/08/2024
       * Development Group: GRCTools
       * Get Statutory Payment By Id Endpoint.     
       */
    public class GetStatutoryPaymentByIdEndpoint
    {
        /// <summary>
        /// Get compliance statutory Payment by id Endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserService"></param>
        /// <param name="repository"></param>
        /// <param name="docRep"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid id, ICurrentUserService currentUserService, IRepository<ComplianceStatutoryPayment> repository, IRepository<Document> docRep
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var getById = repository.GetContextByConditon(x => x.Id == id).FirstOrDefault();

            if (getById is null) return TypedResults.NotFound($"Compliance statutory payment was not found");

            var documents = docRep.GetContextByConditon(d => d.ModuleItemId == id && d.ModuleItemType == ModuleType.ComplianceStatutoryPaymentHCM) 
                                .ToList();

            var documentsProcessedForPayment = docRep.GetContextByConditon(d => d.ModuleItemId == id && d.ModuleItemType == ModuleType.ComplianceStatutoryPaymentFINCON)
                              .ToList();

            var documentsEvidenceOfPayment = docRep.GetContextByConditon(d => d.ModuleItemId == id && d.ModuleItemType == ModuleType.ComplianceStatutoryPaymentPayingUnit)
                              .ToList();

            var attachments = documents.Select(a => new GetAttachedReportResponse
            {
                DocumentId = a.Id,
                DocumentName = a.Name,
                DateCreated = a.CreatedOnUtc,
            }).ToList();

            var attachmentsProcessedForPayment = documentsProcessedForPayment.Select(c => new GetAttachedReportResponse
            {
                DocumentId = c.Id,
                DocumentName = c.Name,
                DateCreated = c.CreatedOnUtc,
            }).ToList();

            var attachmentsEvidence = documentsEvidenceOfPayment.Select(c => new GetAttachedReportResponse
            {
                DocumentId = c.Id,
                DocumentName = c.Name,
                DateCreated = c.CreatedOnUtc,
            }).ToList();
            

            GetStatutoryPaymentByIdResp response = new GetStatutoryPaymentByIdResp
            {                
                StatutoryPaymentId = getById.Id,
                BusinessEntity = getById.BusinessEntity,
                PayingUnit = getById.PayingUnit,
                Regulator = getById.Regulator,
                StatutoryPayment = getById.StatutoryPayment,
                PaymentFrequency = getById.PaymentFrequency,
                Purpose = getById.Purpose,
                PeriodFrom = getById.PeriodFrom,
                PeriodTo = getById.PeriodTo,
                Status = getById.Status.ToString(),                
                ReasonForRejection = getById.ReasonForRejection,
                CashRemittanceStatus = getById.CashRemittanceStatus,
                SubmissionToStatutoryBody = getById.SubmissionToStatutoryBody,
                Comments = getById.Comments,
                ComplianceLevel = getById.ComplianceLevel.ToString(),
                DateOfPayment = getById.DateOfPayment,
                DateCreated = getById.CreatedOnUtc,
                CreatedBy = getById.Initiator,
                ProcessOfficer = getById.ProcessOfficer,
                ProcessedDate = getById.ProcessedDate,
                ModifiedBy = getById.LastUpdatedBy,
                ModifiedDate = getById.ModifiedOnUtc,
                ApprovedBy = getById.ApprovedBy,
                ApprovalDate = getById.ApprovalDate,
                Attachments = attachments,
                ProcessedAttachments = attachmentsProcessedForPayment,
                EvidenceOfPayment = attachmentsEvidence
            };

            return TypedResults.Ok(response);
        }
    }
}
