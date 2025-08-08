using Arm.GrcTool.Domain.Employee;
using Arm.Ad.Users;

namespace Arm.GrcTool.Infrastructure.Services
{
    public class EmployeeServiceActiveDirectory : IEmployeeService
    {
     
        private readonly ISOAPADHelperService sOAPADHelperServiceClient;

        public EmployeeServiceActiveDirectory(ISOAPADHelperService sOAPADHelperServiceClient)
        {
            this.sOAPADHelperServiceClient = sOAPADHelperServiceClient;
        }
        public  async Task<Employee?> Authenticate(string userName, string password)
        {
            // remeber to get rid of this block of code when moving to production
            #region TestUSers
            EmployeeService employeeService = new EmployeeService();
            Employee? employee = await employeeService.Authenticate(userName, password);
            if (employee != null)
            {
                return employee;
            }
            #endregion

            bool isUserAuthenticated = await sOAPADHelperServiceClient.AuthenticateUserAsync(userName, password);
            Task<ADUserDetail> aDUserDetailTask=  sOAPADHelperServiceClient.GetUserByEmailAddressAsync(userName);
            if (isUserAuthenticated) {
                ADUserDetail aDUserDetail = await aDUserDetailTask;
                if (aDUserDetail != null)
                {
                    return Employee.Create(aDUserDetail.EmailAddress, "", aDUserDetail.Department);
                }
            }
            return null;

        }
    }
}
