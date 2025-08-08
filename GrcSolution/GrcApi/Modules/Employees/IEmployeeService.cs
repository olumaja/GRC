
namespace Arm.GrcTool.Domain.Employee
{
    public interface IEmployeeService
    {
        public Task<Employee?> Authenticate(string userName,string password);
    }
}
