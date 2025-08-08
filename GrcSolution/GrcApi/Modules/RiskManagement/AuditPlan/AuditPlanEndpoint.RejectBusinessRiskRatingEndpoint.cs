using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 04/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to reject business risk rating
*/
    public class RejectBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to reject business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] RejectBusinessRiskRatingDto payload, IRepository<BusinessRiskRating> repo,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.Id == payload.BusinessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.NotFound();
                }
                if (getBusinessRiskRating != null)
                {
                    getBusinessRiskRating.RejectBusinessRiskRatingStatus(payload.Reason);
                    repo.SaveChanges();

                    return TypedResults.Ok("Rejected successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }

    public record RejectBusinessRiskRatingDto(Guid BusinessriskratingId, string Reason);

    public class RejectBusinessRiskRatingDtoValidation : AbstractValidator<RejectBusinessRiskRatingDto>
    {
        public RejectBusinessRiskRatingDtoValidation()
        {
            RuleFor(x => x.BusinessriskratingId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
