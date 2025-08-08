using Arm.GrcTool.Domain.Employee;

namespace Arm.GrcTool.Infrastructure.Services
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 07/12/2023
     * Development Group: GRCTools
     * The service authenticate employee
     */
    public class EmployeeService : IEmployeeService
    {
        private readonly IList<Employee> _employeeList;
        public EmployeeService() { 
            _employeeList = new List<Employee>();
            _employeeList.Add(Employee.Create("staff@arm.com.ng","staff", "Information Security")); // compliance officer / FINCONTreasury
            _employeeList.Add(Employee.Create("risk_staff@arm.com.ng", "risk_staff", "Risk Management"));
            _employeeList.Add(Employee.Create("risk_champ@arm.com.ng", "risk_champ", "Risk Management"));
            _employeeList.Add(Employee.Create("grctool_test@arm.com.ng", "grctest", "Risk Management")); // compliance officer
            _employeeList.Add(Employee.Create("grctool_staff@arm.com.ng", "gcrstaff", "Risk Management")); // compliance user
            _employeeList.Add(Employee.Create("segun_sup@arm.com.ng", "testuser12345", "Information Security")); // compliance user /HR officer

            _employeeList.Add(Employee.Create("qa_tester@arm.com.ng", "testuser12345", "Securities Operations")); //SuperAdmin
            _employeeList.Add(Employee.Create("qa_tester1@arm.com.ng", "testuser12345", "Securities Operations")); // Financial Control // FINCONTreasury
            _employeeList.Add(Employee.Create("qa_tester2@arm.com.ng", "testuser12345", "Securities Operations")); // Treasury // FINCONTreasury
            _employeeList.Add(Employee.Create("qa_tester3@arm.com.ng", "testuser12345", "Securities Operations")); // compliance user
            _employeeList.Add(Employee.Create("qa_tester4@arm.com.ng", "testuser12345", "Securities Operations")); // compliance officier
            _employeeList.Add(Employee.Create("qa_tester5@arm.com.ng", "testuser12345", "Securities Operations")); // Internal Control officier
            _employeeList.Add(Employee.Create("qa_tester6@arm.com.ng", "testuser12345", "Securities Operations")); // Internal Control supervisor
            _employeeList.Add(Employee.Create("qa_sup@arm.com.ng", "testuser12345", "Securities Operations")); //HR officer
            _employeeList.Add(Employee.Create("qa_OPofficer@arm.com.ng", "testuser12345", "Securities Operations")); //Operation control officer
            _employeeList.Add(Employee.Create("qa_OPsupervisor@arm.com.ng", "testuser12345", "Securities Operations")); //Operation control supervisor

            _employeeList.Add(Employee.Create("treasuryofficer@arm.com.ng", "testuser12345", "Securities Operations")); //Callover officer
            _employeeList.Add(Employee.Create("treasurysupervisor@arm.com.ng", "testuser12345", "Securities Operations")); //Callover supervisor
            _employeeList.Add(Employee.Create("privatetrusteesofficer@arm.com.ng", "testuser12345", "Securities Operations")); //Callover officer
            _employeeList.Add(Employee.Create("privatetrusteessupervisor@arm.com.ng", "testuser12345", "Securities Operations")); //Callover supervisor

            _employeeList.Add(Employee.Create("dennis1@arm.com.ng", "dennis12345", "Securities Operations")); // Financial Control // FINCONTreasury
            _employeeList.Add(Employee.Create("dennis2@arm.com.ng", "dennis12345", "Securities Operations")); // Treasury // FINCONTreasury
            _employeeList.Add(Employee.Create("dennis3@arm.com.ng", "dennis12345", "Securities Operations")); // compliance user
            _employeeList.Add(Employee.Create("dennis4@arm.com.ng", "dennis12345", "Securities Operations")); // compliance officier
            _employeeList.Add(Employee.Create("dennis5@arm.com.ng", "dennis12345", "Securities Operations")); //HR officer
            _employeeList.Add(Employee.Create("dennis6@arm.com.ng", "dennis12345", "Securities Operations")); //Internal Control officer
            _employeeList.Add(Employee.Create("dennis7@arm.com.ng", "dennis12345", "Securities Operations")); //Internal Control supervisor

            _employeeList.Add(Employee.Create("finconofficer@arm.com.ng", "frontend12345", "Securities Operations")); //Callover officer
            _employeeList.Add(Employee.Create("finconsupervisor@arm.com.ng", "frontend12345", "Securities Operations")); //Callover supervisor
            _employeeList.Add(Employee.Create("customerofficer@arm.com.ng", "frontend12345", "Securities Operations")); //Callover officer
            _employeeList.Add(Employee.Create("customersupervisor@arm.com.ng", "frontend12345", "Securities Operations")); //Callover supervisor

            _employeeList.Add(Employee.Create("matthew@arm.com.ng", "matthew12345", "Securities Operations")); // Super Admin
            _employeeList.Add(Employee.Create("matthew1@arm.com.ng", "matthew12345", "Securities Operations")); // Financial Control // FINCONTreasury
            _employeeList.Add(Employee.Create("matthew2@arm.com.ng", "matthew12345", "Securities Operations")); // Treasury // FINCONTreasury
            _employeeList.Add(Employee.Create("matthew3@arm.com.ng", "matthew12345", "Securities Operations")); // compliance user
            _employeeList.Add(Employee.Create("matthew4@arm.com.ng", "matthew12345", "Securities Operations")); // compliance officier
            _employeeList.Add(Employee.Create("matthew5@arm.com.ng", "matthew12345", "Securities Operations")); //HR officer
            _employeeList.Add(Employee.Create("matthew6@arm.com.ng", "matthew12345", "Securities Operations")); //Internal Control officer
            _employeeList.Add(Employee.Create("matthew7@arm.com.ng", "matthew12345", "Securities Operations")); //Internal Control supervisor

            _employeeList.Add(Employee.Create("auditofficer@arm.com.ng", "audit12345", "Internal Audit")); // Internal Audit
            _employeeList.Add(Employee.Create("auditsup@arm.com.ng", "audit12345", "Internal Audit")); // Internal Audit unit head
                       
            _employeeList.Add(Employee.Create("vapt1@arm.com.ng", "infosec123", "Information Security")); // information security staff

        }
        public Task<Employee?> Authenticate(string userName, string password)
        {
            return Task.FromResult(_employeeList
                    .FirstOrDefault(e => e.UserName == userName && e.Password == password));  
        }
    }
}
