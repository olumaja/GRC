using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 10/11/2024
        * Development Group: GRCTools
        * Get internal control exception tracker by Id Endpoint.     
        */
    public class GetExceptionTrackerByIdEndpoint
    {
        /// <summary>
        /// Get exception tracker by id Endpoint
        /// </summary>
        /// <param name="exceptionTrackerId"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid exceptionTrackerId, IRepository<InternalControlExceptionTracker> repository, ICurrentUserService currentUserService)
        {
            var getById = repository.GetContextByConditon(x => x.Id == exceptionTrackerId && x.ExceptionTrackerStatus != ExceptionTrackerStatus.Deleted).FirstOrDefault();

            if (getById is null) return TypedResults.NotFound($"Internal Control was not found");
          
            var response = new GetExceptionTrackerByIdResp
            {
                ExceptionTrackerId = getById.Id,
                Exception = getById.Exception,
                Unit = getById.Unit,
                Status = getById.ExceptionTrackerStatus.ToString(),
                ActivityImpacted = getById.ActivityImpacted,
                TransactionCount = getById.TransactionCount,
                ControlImpact = getById.ControlImpact,
                ImpactRating = getById.ImpactRating,
                ApprovalDate = getById.ApprovalDate,
                ApprovedBy = getById.ApprovedBy,
                ManagementResponse = getById.ManagementResponse,
                DateUpdated = getById.ModifiedOnUtc,
                ProposedDeadline = getById.Deadline,
                NatureOfException = getById.NatureOfException,
                Recommendation = getById.Recommendation,
                ResponsibleOfficer = getById.ResponsibleOfficer,
                UpdatedBy = getById.ModifiedBy,
                ReasonForReject = getById.ReasonForReject,           
                DateCreated = getById.CreatedOnUtc           
            };

            return TypedResults.Ok(response);
        }
    }
}
