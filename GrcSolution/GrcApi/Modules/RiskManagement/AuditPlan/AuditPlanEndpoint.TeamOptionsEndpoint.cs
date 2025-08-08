namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/20/2024
       * Development Group: GRCTools
       * Audit Execution: Team options     
       */
    public class TeamOptionsEndpoint
    {
        public static async Task<IResult> HandleAsync()
        {
            var ARMHoldingCompany = new string[] { "ARM Holding Company", "Treasury Sale"};
            var ARMIM = new string[] { "IMUnit", "Operation Control", "Registrar", "BDPWMIAMIMRetail", "Operation Settlement", "Fund Admin", "Fund Account", "Retail Operation"};
            var ARMSecurity = new string[] { "Stock Broking" };
            var ARMTrustee = new string[] { "Private Trust", "Commercial Trust" };
            var ARMHill = new string[] { "ARMHill" };
            var ARMCapital = new string[] { "ARMCapital" };
            var ARMTAM = new string[] { "ARMTAM" };
            var DigitalFinancialService = new string[] { "Digital Financial Service" };
            var ARMAgribusness = new string[] { "RFL", "AAFML" };
            var ARMShareService = new string[] { "HCM", "Financial Control", "Compliance", "Legal", "IT", "Internal Control", "CTO", "Risk Management", "Corporate Strategy", "Academy", "Data Analytic", "Procurement and Admin", "Customer Experience", "MCC", "Information Security", "Treasury" };

            return TypedResults.Ok(new { ARMHoldingCompany, ARMIM, ARMSecurity, ARMTrustee, ARMHill, ARMCapital, ARMTAM, DigitalFinancialService, ARMAgribusness, ARMShareService });

        }
    }

}
