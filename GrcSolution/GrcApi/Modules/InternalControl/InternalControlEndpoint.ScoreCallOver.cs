using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class ScoreCallOverEndpoint
    {
        public static async Task<IResult> HandleAsync(
            ScoreCallOverDto payload, IRepository<InternalControlCallOver> calloverRepo, ICurrentUserService currentUserService
        )
        {
            if (payload.CalloverAsWhenDue != 0 && payload.CalloverAsWhenDue != 25)
                return TypedResults.BadRequest("Call over as  when due can only be 0 or 25");

            if (payload.CallOverDoneScore != 0 && payload.CallOverDoneScore != 25)
                return TypedResults.BadRequest("Call over done score can only be 0 or 25");

            var callover = await calloverRepo.GetByIdAsync(payload.CalloverId);

            if (callover is null)
                return TypedResults.NotFound("Record not found");

            var errorFreeScore = payload.IsErrorSpotted ? 0 : 50;
            var score = payload.CallOverDoneScore + payload.CalloverAsWhenDue + errorFreeScore;
            callover.UpdateScore(score, payload.Comment);
            callover.UpdateStatus(CallOverStatus.Saved);
            callover.SetModifiedBy(currentUserService.CurrentUserFullName);
            callover.SetModifiedOnUtc(DateTime.Now);
            calloverRepo.SaveChanges();

            return TypedResults.Ok("Call over score saved successfully");
        }
    }
}
