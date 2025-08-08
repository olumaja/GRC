using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 10/11/2024
       * Development Group: GRCTools
       * Action owner get internal control by Id Endpoint.     
       */
    public class ActionOwnerGetInternalControlDashboardByIdEndpoint
    {
        /// <summary>
        /// Action owner get internal control dashboard by id Endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid id, IRepository<InternalControlDashboard> repository, ICurrentUserService currentUserService)
        {
            try
            {
                var getById = repository.GetContextByConditon(x => x.Id == id && x.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower()).FirstOrDefault();

                if (getById is null) return TypedResults.NotFound($"Internal control dashboard record is not for this action owner");

                var response = new GetControlDashboardByIdResp
                {
                    InternalControlDashboardId = getById.Id,
                    ActivityIntervals = getById.ActivityIntervals.ToString(),
                    Activity = getById.Activity,
                    Comment = getById.Comment,
                    CompletionDate = getById.ProposedCompletionDate,
                    DateInitiated = getById.CreatedOnUtc,
                    ActionOwner = getById.ActionOwner,
                    ActionOwnerEmail = getById.ActionOwnerEmail,
                    Remarks = getById.Remarks,
                    NumberOfTransactionsReviewed = getById.NumberOfTransactionsReviewed,
                    Status = getById.Status.ToString(),
                    CreatedBy = getById.CreatedBy,
                    ModifiedBy = getById.ModifiedBy
                };

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }

        }
    }
}
