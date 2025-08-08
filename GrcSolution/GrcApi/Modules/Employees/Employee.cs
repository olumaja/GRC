
namespace Arm.GrcTool.Domain.Employee
{
    public class Employee
    {
        public string UserName { get; private set; } = null!;
        public string Department { get; private set; } = null!;
        public string Password { get; private set; } = null!;

        private Employee() { 
        }

        public static Employee Create(string userName,string password,string department)
        {
            return new Employee
            {
                UserName = userName,
                Department = department,
                Password = password
            };
        }

    }
}
