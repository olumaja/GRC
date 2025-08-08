using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class RejectOperationExceptionEndpoint
    {
        public static async Task<IResult> HandleAsync(RejectExceptionDto payload, IRepository<OperationControl> repository,
           ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;
                if (!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
                {
                    return TypedResults.Unauthorized();
                }
                var getById = repository.GetContextByConditon(x => x.Id == payload.OperationExceptionId && x.Status != ExceptionStatus.Approved && x.ActionOwnerComment != null).FirstOrDefault();
                if (getById is null)
                {
                    return TypedResults.BadRequest("Operation control exception does not exist or action owner has not responded");
                }

                if (string.IsNullOrEmpty(getById.ReAssignedOfficer) && getById.RequestedEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                {
                    getById.RejectOperationException(payload.ReasonForRejection, requesterName);
                    repository.SaveChanges();
                    return TypedResults.Ok("Operation exception rejected");
                }
                if (!string.IsNullOrEmpty(getById.ReAssignedOfficer) && getById.ReassignOfficerEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                {
                    getById.RejectOperationException(payload.ReasonForRejection, requesterName);
                    repository.SaveChanges();
                    return TypedResults.Ok("Operation exception rejected");
                }

                if (currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
                {
                    getById.RejectOperationException(payload.ReasonForRejection, requesterName);
                    repository.SaveChanges();
                    return TypedResults.Ok("Operation exception rejected");
                }
                return TypedResults.BadRequest("This exception has been reassigned to another officer or does not exist");

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record RejectExceptionDto(Guid OperationExceptionId, string ReasonForRejection);

    public class RejectExceptionDtoValidation : AbstractValidator<RejectExceptionDto>
    {
        public RejectExceptionDtoValidation()
        {
            RuleFor(x => x.OperationExceptionId).NotEmpty();           
            RuleFor(x => x.ReasonForRejection).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
