using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Enums;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.RiskEvent
{
    public class RiskEventEndpointPostSpecifiedActionOwners
    {
        public static async Task<IResult> HandleAsync(ActionOwnerDto actionOwner, IRestHelper restHelper, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var payload = new
            {
                searchQuery = actionOwner.SearchName,
                searcherEmail = "noemail@arm.com.ng",
            };

            var staffList = await restHelper.ConsumeApi<List<StaffNameEmail>>("getStaffClient", config["ArmADStaffSearch"], payload, HttpVerb.Post);

            if (staffList.Content == null)
            {
                return TypedResults.BadRequest("Couldn't fetch staff records");
            }

            IList<StaffNameEmail> staff = staffList.Content.Select(s => new StaffNameEmail { Name = s.Name, EmailAddress = s.EmailAddress, Department = s.Department }).ToList();

            return TypedResults.Ok(staff);
        }
    }
}

public record ActionOwnerDto(string SearchName);

public class ActionOwnerDtoValidator : AbstractValidator<ActionOwnerDto>
{
    public ActionOwnerDtoValidator()
    {
        RuleFor(x => x.SearchName).Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
    }
}