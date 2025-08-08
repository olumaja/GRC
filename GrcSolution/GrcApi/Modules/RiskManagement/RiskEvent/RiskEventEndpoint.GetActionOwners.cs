using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Enums;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.RiskEvent
{
    public class RiskEventEndpointGetActionOwners
    {
        public static async Task<IResult> HandleAsync(IRestHelper restHelper, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));
            var email = currentUserService.CurrentUserEmail;

            if (string.IsNullOrWhiteSpace(email))
            {
                return TypedResults.Unauthorized();
            }

            var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

            if (unitIdValue is null)
            {
                return TypedResults.Ok("Unit was not found");
            }

            Guid unitId = new Guid(unitIdValue.Value);
            var payload = new
            {
                searchQuery = " ",
                searcherEmail = "noemail@arm.com.ng",
            };
            
            var staffList = await restHelper.ConsumeApi<List<StaffNameEmail>>("getStaffClient", config["ArmADStaffSearch"], payload, HttpVerb.Post);
            
            if(staffList.Content == null )
            {
                return TypedResults.BadRequest("Couldn't fetch staff records");
            }

            IList<StaffNameEmail> staff = staffList.Content.Select(s => new StaffNameEmail { Name = s.Name, EmailAddress = s.EmailAddress, Department = s.Department }).ToList();

            return TypedResults.Ok(staff);
        }
    }


    public class StaffNameEmail
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Department { get; set; }
    }
}
