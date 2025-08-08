using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/06/2024
       * Development Group: GRCTools
       * Compliance Regulator Payment: Initiate compliance Payment Endpoint.     
       */
    public class GetRegulatorPaymentByIdEndpoint
    {
        /// <summary>
        /// Get regulator Payment by id Endpoint
        /// </summary>
        /// <param name="ComplianceReportId"></param>
        /// <param name="currentUserService"></param>
        /// <param name="repository"></param>
        /// <param name="docRep"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid regulatorPaymentId, ICurrentUserService currentUserService, IRepository<ComplianceRegulatoryPayment> repository, IRepository<Document> docRep
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var getById = await repository.GetByIdAsync(regulatorPaymentId);

            if (getById is null) return TypedResults.NotFound($"Regulator payment was not found");

            var attachments = new List<GetAttachedReportResponse>();
            var documents = docRep.GetContextByConditon(d => d.ModuleItemId == regulatorPaymentId && d.ModuleItemType == ModuleType.ComplianceRegulatoryPayment)
                                .ToList();

            if (documents.Count > 0)
            {
                attachments = documents.Select(a => new GetAttachedReportResponse
                {
                    DocumentId = a.Id,
                    DocumentName = a.Name,
                }).ToList();
            }

            GetComplianceRegulatorPaymentById response = new GetComplianceRegulatorPaymentById
            {
                RegulatorPaymentId = getById.Id,
                Regulator = getById.Regulator,
                Amount = getById.Amount,
                PaymentDetail = getById.PaymentDetail,
                MeansOfPaymentAmount = getById.MeansOfPaymentAmount,
                BusinessEntity = getById.BusinessEntity,
                DeadLine = getById.DeadLine,
                ProcessOfficer = getById.ProcessOfficer,
                Status = getById.Status.ToString(),
                AmountPaid = getById.AmountPaid,
                DateOfPayment = getById.DateOfPayment,
                TransactionReference = getById.TransactionReference,
                ReasonForRejection = getById.ReasonForRejection,
                DateCreated = getById.CreatedOnUtc,
                CreatedBy = getById.Initiator,
                ModifiedBy = getById.LastUpdatedBy,
                ModifiedDate = getById.ModifiedOnUtc,
                ApprovedBy = getById.ApprovedBy,
                ApprovalDate = getById.ApprovalDate,
                Attachments = attachments
            };

            return TypedResults.Ok(response);
        }
    }
}
