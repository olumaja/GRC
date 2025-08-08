using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/20/2024
       * Development Group: GRCTools
       * Compliance Regulator Payment: Provides Regulators and Business entities options     
       */
    public class RegulatoryOptionsEndpoint
    {       
        public static async Task<IResult> HandleAsync()
        {           
            var businessEntities = new string[] { "ARM IM", "ARM Securities", "ARM Capital Partner", "ARM Trustees", "ARM Holding Company", "ARM TAM", "ARM Hill", "ARM Agribusiness", "ARM Shared Service"};
            var regulatoryBody = new string[] { "SEC", "FMAN", "NCCG", "FRCN", "CAC", "Newspaper Publication", "INSURANCE", "CSCS", "Custodian & Allied Insurance", "LexisNexis", "NASD", "FMDQ", "ACT", "SYSTEMS/APP SUBSCRIPTIONS", "NGX", };

            return TypedResults.Ok(new { businessEntities, regulatoryBody });

        }
    }

}
