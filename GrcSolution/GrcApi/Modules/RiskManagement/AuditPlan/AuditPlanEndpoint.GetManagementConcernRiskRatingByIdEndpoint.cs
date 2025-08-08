using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using System.Security.Claims;
using System;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 01/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get management concern risk rating by bussiness name or get all management concern risk rating
*/
    public class GetManagementConcernRiskRatingByIdEndpoint
    {

        /// <summary>
        /// Get management concern risk rating by bussiness name or get all management concern risk rating
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armim"></param>
        /// <param name="armimbusiness"></param>
        /// <param name="arminshareservice"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armtrusteebusiness"></param>
        /// <param name="armtrusteeshareservice"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armsecuritybusiness"></param>
        /// <param name="armsecurityshareservice"></param>
        /// <param name="armhill"></param>
        /// <param name="armhillbusiness"></param>
        /// <param name="armhillshareservice"></param>
        /// <param name="armagri"></param>
        /// <param name="armagribusiness"></param>
        /// <param name="armargrishareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMIM> armim, IRepository<ManagementConcernBusinessUnitARMIMRating> armimbusiness, IRepository<ManagementConcernSharedServiceARMIMRating> arminshareservice,
            IRepository<ManagementConcernARMTrustee> armtrustee, IRepository<ManagementConcernBusinessUnitARMTrusteeRating> armtrusteebusiness, IRepository<ManagementConcernSharedServiceARTrusteeRating> armtrusteeshareservice,
            IRepository<ManagementConcernARMSecurity> armsecurity, IRepository<ManagementConcernBusinessUnitARMSecurityRating> armsecuritybusiness, IRepository<ManagementConcernSharedServiceARMSecurityRating> armsecurityshareservice,
            IRepository<ManagementConcernARMHill> armhill, IRepository<ManagementConcernBusinessUnitARMHillRating> armhillbusiness, IRepository<ManagementConcernSharedServiceARMHillRating> armhillshareservice,
            IRepository<ManagementConcernARMAgribusiness> armagri, IRepository<ManagementConcernBusinessUnitARMAgribusinessRating> armagribusiness, IRepository<ManagementConcernSharedServiceARMAgribusinessRating> armargrishareservice,
            IRepository<ManagementConcernDFS> dfs, IRepository<ManagementConcernBusinessUnitDFSRating> dfsbusiness, IRepository<ManagementConcernSharedServiceDFSRating> dfshareservice,
            IRepository<ManagementConcernARMCapital> armCapital, IRepository<ManagementConcernBusinessUnitARMCapitalRating> armCapitalbusiness, IRepository<ManagementConcernSharedServiceARMCapitalRating> armCapitalShareservice,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getmanagementoncernRating = managementConcernRating.GetContextByConditon(x => x.Id == id).FirstOrDefault();
               // var getmanagementoncernRating = managementConcernRating.GetContextByConditon(x => x.Id == id).FirstOrDefault();
                if (id != default && getmanagementoncernRating != null)
                {
                    //var getarmagriRating = armagri.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmagriBusinessRating = armagribusiness.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getarmagriRating.Id).FirstOrDefault();
                    //var getarmagriSharedserviceRating = armargrishareservice.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getarmagriRating.Id).FirstOrDefault();

                    //var getarmhillRating = armhill.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmhillBusinessRating = armhillbusiness.GetContextByConditon(x => x.ManagementConcernARMHillId == getarmhillRating.Id).FirstOrDefault();
                    //var getarmhillSharedserviceRating = armhillshareservice.GetContextByConditon(x => x.ManagementConcernARMHillId == getarmhillRating.Id).FirstOrDefault();

                    //var getarmsecurityRating = armsecurity.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmsecurityBusinessRating = armsecuritybusiness.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getarmsecurityRating.Id).FirstOrDefault();
                    //var getarmsecuritysharedserviceRating = armsecurityshareservice.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getarmsecurityRating.Id).FirstOrDefault();

                    //var getarmtrusteeRating = armtrustee.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmtrusteebusinessRating = armtrusteebusiness.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getarmtrusteeRating.Id).FirstOrDefault();
                    //var getarmtrusteeShareserviceRating = armtrusteeshareservice.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getarmtrusteeRating.Id).FirstOrDefault();

                    //var getarmimRating = armim.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmimBusinessRating = armimbusiness.GetContextByConditon(x => x.ManagementConcernARMIMId == getarmimRating.Id).FirstOrDefault();
                    //var getarmimShareserviceRating = arminshareservice.GetContextByConditon(x => x.ManagementConcernARMIMId == getarmimRating.Id).FirstOrDefault();

                    //var geDFSRating = dfs.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getDFSBusinessRating = dfsbusiness.GetContextByConditon(x => x.ManagementConcernDFSId == geDFSRating.Id).FirstOrDefault();
                    //var getDFSShareserviceRating = dfshareservice.GetContextByConditon(x => x.ManagementConcernDFSId == geDFSRating.Id).FirstOrDefault();

                    //var getarmCapital = armCapital.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    //var getarmCapitalbusiness = armCapitalbusiness.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getarmCapital.Id).FirstOrDefault();
                    //var getarmCapitalShareservice = armCapitalShareservice.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getarmCapital.Id).FirstOrDefault();



                    //  //mc rating

                    var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == getmanagementoncernRating.BusinessRiskRatingId).ToList();
                    var allDFSBusiness = new List<decimal>();
                    var allARMCapital = new List<decimal>();
                    var allARMHill = new List<decimal>();
                    var allCommercialTrust = new List<decimal>();
                    var allPrivateTrust = new List<decimal>();
                    var allStockBroking = new List<decimal>();
                    var allRFL = new List<decimal>();
                    var allAAFML = new List<decimal>();
                    var allARMIM = new List<decimal>();
                    var allARMRegistrar = new List<decimal>();
                    var allFundAccount = new List<decimal>();
                    var allFundAdmin = new List<decimal>();
                    var allBDOrIMRetail = new List<decimal>();
                    var allIMUnit = new List<decimal>();
                    var allOperationControl = new List<decimal>();
                    var allOperationSettlement = new List<decimal>();
                    var allRetailOperation = new List<decimal>();
                    var allResearch = new List<decimal>();

                    var allDFSDharedHCM = new List<decimal>();
                    var allDFSDharedIT = new List<decimal>();
                    var allDFSDharedCTO = new List<decimal>();
                    var allDFSDharedProcurementAndAdmin = new List<decimal>();
                    var allDFSDharedCorporateStrategy = new List<decimal>();
                    var allDFSDharedLegal = new List<decimal>();
                    var allDFSDharedMCC = new List<decimal>();
                    var allDFSDharedInternalControl = new List<decimal>();
                    var allDFSDharedInformationSecurity = new List<decimal>();
                    var allDFSDharedCustomerExperience = new List<decimal>();
                    var allDFSDharedTreasury = new List<decimal>();
                    var allDFSDharedRiskManagement = new List<decimal>();
                    var allDFSDharedDataAnalytic = new List<decimal>();
                    var allDFSDharedCompliance = new List<decimal>();
                    var allDFSDharedFinancialControl = new List<decimal>();
                    var allDFSDharedAcademy = new List<decimal>();

                    //armim

                    var allARMIMDharedHCM = new List<decimal>();
                    var allARMIMDharedIT = new List<decimal>();
                    var allARMIMDharedCTO = new List<decimal>();
                    var allARMIMDharedProcurementAndAdmin = new List<decimal>();
                    var allARMIMDharedCorporateStrategy = new List<decimal>();
                    var allARMIMDharedLegal = new List<decimal>();
                    var allARMIMDharedMCC = new List<decimal>();
                    var allARMIMDharedInternalControl = new List<decimal>();
                    var allARMIMDharedInformationSecurity = new List<decimal>();
                    var allARMIMDharedCustomerExperience = new List<decimal>();
                    var allARMIMDharedTreasury = new List<decimal>();
                    var allARMIMDharedRiskManagement = new List<decimal>();
                    var allARMIMDharedDataAnalytic = new List<decimal>();
                    var allARMIMDharedCompliance = new List<decimal>();
                    var allARMIMDharedFinancialControl = new List<decimal>();
                    var allARMIMDharedAcademy = new List<decimal>();
                    //agri
                    var allARMAgribusinessDharedHCM = new List<decimal>();
                    var allARMAgribusinessDharedIT = new List<decimal>();
                    var allARMAgribusinessDharedCTO = new List<decimal>();
                    var allARMAgribusinessDharedProcurementAndAdmin = new List<decimal>();
                    var allARMAgribusinessDharedCorporateStrategy = new List<decimal>();
                    var allARMAgribusinessDharedLegal = new List<decimal>();
                    var allARMAgribusinessDharedMCC = new List<decimal>();
                    var allARMAgribusinessDharedInternalControl = new List<decimal>();
                    var allARMAgribusinessDharedInformationSecurity = new List<decimal>();
                    var allARMAgribusinessDharedCustomerExperience = new List<decimal>();
                    var allARMAgribusinessDharedTreasury = new List<decimal>();
                    var allARMAgribusinessDharedRiskManagement = new List<decimal>();
                    var allARMAgribusinessDharedDataAnalytic = new List<decimal>();
                    var allARMAgribusinessDharedCompliance = new List<decimal>();
                    var allARMAgribusinessDharedFinancialControl = new List<decimal>();
                    var allARMAgribusinessDharedAcademy = new List<decimal>();
                    //capital
                    var allARMCapitalDharedHCM = new List<decimal>();
                    var allARMCapitalDharedIT = new List<decimal>();
                    var allARMCapitalDharedCTO = new List<decimal>();
                    var allARMCapitalDharedProcurementAndAdmin = new List<decimal>();
                    var allARMCapitalDharedCorporateStrategy = new List<decimal>();
                    var allARMCapitalDharedLegal = new List<decimal>();
                    var allARMCapitalDharedMCC = new List<decimal>();
                    var allARMCapitalDharedInternalControl = new List<decimal>();
                    var allARMCapitalDharedInformationSecurity = new List<decimal>();
                    var allARMCapitalDharedCustomerExperience = new List<decimal>();
                    var allARMCapitalDharedTreasury = new List<decimal>();
                    var allARMCapitalDharedRiskManagement = new List<decimal>();
                    var allARMCapitalDharedDataAnalytic = new List<decimal>();
                    var allARMCapitalDharedCompliance = new List<decimal>();
                    var allARMCapitalDharedFinancialControl = new List<decimal>();
                    var allARMCapitalDharedAcademy = new List<decimal>();

                    //security
                    var allARMSecurityDharedHCM = new List<decimal>();
                    var allARMSecurityDharedIT = new List<decimal>();
                    var allARMSecurityDharedCTO = new List<decimal>();
                    var allARMSecurityDharedProcurementAndAdmin = new List<decimal>();
                    var allARMSecurityDharedCorporateStrategy = new List<decimal>();
                    var allARMSecurityDharedLegal = new List<decimal>();
                    var allARMSecurityDharedMCC = new List<decimal>();
                    var allARMSecurityDharedInternalControl = new List<decimal>();
                    var allARMSecurityDharedInformationSecurity = new List<decimal>();
                    var allARMSecurityDharedCustomerExperience = new List<decimal>();
                    var allARMSecurityDharedTreasury = new List<decimal>();
                    var allARMSecurityDharedRiskManagement = new List<decimal>();
                    var allARMSecurityDharedDataAnalytic = new List<decimal>();
                    var allARMSecurityDharedCompliance = new List<decimal>();
                    var allARMSecurityDharedFinancialControl = new List<decimal>();
                    var allARMSecurityDharedAcademy = new List<decimal>();
                    //ARMTrustee
                    var allARMTrusteeDharedHCM = new List<decimal>();
                    var allARMTrusteeDharedIT = new List<decimal>();
                    var allARMTrusteeDharedCTO = new List<decimal>();
                    var allARMTrusteeDharedProcurementAndAdmin = new List<decimal>();
                    var allARMTrusteeDharedCorporateStrategy = new List<decimal>();
                    var allARMTrusteeDharedLegal = new List<decimal>();
                    var allARMTrusteeDharedMCC = new List<decimal>();
                    var allARMTrusteeDharedInternalControl = new List<decimal>();
                    var allARMTrusteeDharedInformationSecurity = new List<decimal>();
                    var allARMTrusteeDharedCustomerExperience = new List<decimal>();
                    var allARMTrusteeDharedTreasury = new List<decimal>();
                    var allARMTrusteeDharedRiskManagement = new List<decimal>();
                    var allARMTrusteeDharedDataAnalytic = new List<decimal>();
                    var allARMTrusteeDharedCompliance = new List<decimal>();
                    var allARMTrusteeDharedFinancialControl = new List<decimal>();
                    var allARMTrusteeDharedAcademy = new List<decimal>();
                    //Hill
                    var allARMHillDharedHCM = new List<decimal>();
                    var allARMHillDharedIT = new List<decimal>();
                    var allARMHillDharedCTO = new List<decimal>();
                    var allARMHillDharedProcurementAndAdmin = new List<decimal>();
                    var allARMHillDharedCorporateStrategy = new List<decimal>();
                    var allARMHillDharedLegal = new List<decimal>();
                    var allARMHillDharedMCC = new List<decimal>();
                    var allARMHillDharedInternalControl = new List<decimal>();
                    var allARMHillDharedInformationSecurity = new List<decimal>();
                    var allARMHillDharedCustomerExperience = new List<decimal>();
                    var allARMHillDharedTreasury = new List<decimal>();
                    var allARMHillDharedRiskManagement = new List<decimal>();
                    var allARMHillDharedDataAnalytic = new List<decimal>();
                    var allARMHillDharedCompliance = new List<decimal>();
                    var allARMHillDharedFinancialControl = new List<decimal>();
                    var allARMHillDharedAcademy = new List<decimal>();
                    foreach (var item2 in getMCRating)
                    {
                        var getMCConcern = dfs.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmCapitalRate = armCapital.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmhill = armhill.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmtrustee = armtrustee.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmsecurity = armsecurity.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmagri = armagri.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        var getarmim = armim.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                                                
                        if (getMCConcern.Any())
                        {
                            //ARM IM
                            var getallOperationControl = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.OperationControl).ToList();
                            allOperationControl.AddRange(getallOperationControl);
                            var getOperationSettlement = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.OperationSettlement).ToList();
                            allOperationSettlement.AddRange(getOperationSettlement);
                            var getallRetailOperation = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.RetailOperation).ToList();
                            allRetailOperation.AddRange(getallRetailOperation);
                            var getResearch = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Research).ToList();
                            allResearch.AddRange(getResearch);
                            var getallARMIM = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.ARMIM).ToList();
                            allARMIM.AddRange(getallARMIM);
                            var getallARMRegistrar = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.ARMRegistrar).ToList();
                            allARMRegistrar.AddRange(getallARMRegistrar);
                            var getallFundAccount = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.FundAccount).ToList();
                            allFundAccount.AddRange(getallFundAccount);
                            var getallFundAdmin = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.FundAdmin).ToList();
                            allFundAdmin.AddRange(getallFundAdmin);
                            var getallBDOrIMRetail = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.BDOrIMRetail).ToList();
                            allBDOrIMRetail.AddRange(getallBDOrIMRetail);
                            var getallIMUnit = armimbusiness.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.IMUnit).ToList();
                            allIMUnit.AddRange(getallIMUnit);

                            var getallARMIMShareHCM = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.HCM).ToList();
                            allARMIMDharedHCM.AddRange(getallARMIMShareHCM);

                            var getallARMIMShareIT = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.IT).ToList();
                            allARMIMDharedIT.AddRange(getallARMIMShareIT);

                            var getallARMIMShareCTO = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.CTO).ToList();
                            allARMIMDharedCTO.AddRange(getallARMIMShareCTO);

                            var getallARMIMShareProcurementAndAdmin = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMIMDharedProcurementAndAdmin.AddRange(getallARMIMShareProcurementAndAdmin);

                            var getallARMIMShareCorporateStrategy = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.CorporateStrategy).ToList();
                            allARMIMDharedCorporateStrategy.AddRange(getallARMIMShareCorporateStrategy);

                            var getallARMIMShareLegal = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Legal).ToList();
                            allARMIMDharedLegal.AddRange(getallARMIMShareLegal);

                            var getallARMIMShareMCC = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.MCC).ToList();
                            allARMIMDharedMCC.AddRange(getallARMIMShareMCC);

                            var getallARMIMShareInformationSecurity = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.InformationSecurity).ToList();
                            allARMIMDharedInformationSecurity.AddRange(getallARMIMShareInformationSecurity);

                            var getallARMIMShareInternalControl = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.InternalControl).ToList();
                            allARMIMDharedInternalControl.AddRange(getallARMIMShareInternalControl);

                            var getallARMIMShareCustomerExperience = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.CustomerExperience).ToList();
                            allARMIMDharedCustomerExperience.AddRange(getallARMIMShareCustomerExperience);

                            var getallARMIMShareTreasury = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Treasury).ToList();
                            allARMIMDharedTreasury.AddRange(getallARMIMShareTreasury);

                            var getallARMIMShareDataAnalytic = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.DataAnalytic).ToList();
                            allARMIMDharedDataAnalytic.AddRange(getallARMIMShareDataAnalytic);

                            var getallARMIMShareRiskManagement = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.RiskManagement).ToList();
                            allARMIMDharedRiskManagement.AddRange(getallARMIMShareRiskManagement);

                            var getallARMIMShareCompliance = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Compliance).ToList();
                            allARMIMDharedCompliance.AddRange(getallARMIMShareCompliance);

                            var getallARMIMShareFinancialControl = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.FinancialControl).ToList();
                            allARMIMDharedFinancialControl.AddRange(getallARMIMShareFinancialControl);

                            var getallARMIMShareAcademy = arminshareservice.GetContextByConditon(x => getarmim.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Academy).ToList();
                            allARMIMDharedAcademy.AddRange(getallARMIMShareAcademy);


                            //DFS
                            var getallDFS = dfsbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.DigitalFinancialService).ToList();
                            allDFSBusiness.AddRange(getallDFS);
                            //
                            var getallDFSShareHCM = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.HCM).ToList();
                            allDFSDharedHCM.AddRange(getallDFSShareHCM);

                            var getallDFSShareIT = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.IT).ToList();
                            allDFSDharedIT.AddRange(getallDFSShareIT);

                            var getallDFSShareCTO = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.CTO).ToList();
                            allDFSDharedCTO.AddRange(getallDFSShareCTO);

                            var getallDFSShareProcurementAndAdmin = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allDFSDharedProcurementAndAdmin.AddRange(getallDFSShareProcurementAndAdmin);

                            var getallDFSShareCorporateStrategy = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.CorporateStrategy).ToList();
                            allDFSDharedCorporateStrategy.AddRange(getallDFSShareCorporateStrategy);

                            var getallDFSShareLegal = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.Legal).ToList();
                            allDFSDharedLegal.AddRange(getallDFSShareLegal);

                            var getallDFSShareMCC = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.MCC).ToList();
                            allDFSDharedMCC.AddRange(getallDFSShareMCC);

                            var getallDFSShareInformationSecurity = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.InformationSecurity).ToList();
                            allDFSDharedInformationSecurity.AddRange(getallDFSShareInformationSecurity);

                            var getallDFSShareInternalControl = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.InternalControl).ToList();
                            allDFSDharedInternalControl.AddRange(getallDFSShareInternalControl);

                            var getallDFSShareCustomerExperience = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.CustomerExperience).ToList();
                            allDFSDharedCustomerExperience.AddRange(getallDFSShareCustomerExperience);

                            var getallDFSShareTreasury = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.Treasury).ToList();
                            allDFSDharedTreasury.AddRange(getallDFSShareTreasury);

                            var getallDFSShareDataAnalytic = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.DataAnalytic).ToList();
                            allDFSDharedDataAnalytic.AddRange(getallDFSShareDataAnalytic);

                            var getallDFSShareRiskManagement = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.RiskManagement).ToList();
                            allDFSDharedRiskManagement.AddRange(getallDFSShareRiskManagement);

                            var getallDFSShareCompliance = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.Compliance).ToList();
                            allDFSDharedCompliance.AddRange(getallDFSShareCompliance);

                            var getallDFSShareFinancialControl = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.FinancialControl).ToList();
                            allDFSDharedFinancialControl.AddRange(getallDFSShareFinancialControl);

                            var getallDFSShareAcademy = dfshareservice.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernDFSId)).Select(x => x.Academy).ToList();
                            allDFSDharedAcademy.AddRange(getallDFSShareAcademy);

                         

                            //Capital
                            var getCapital = armCapitalbusiness.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.ARMCapital).ToList();
                            allARMCapital.AddRange(getCapital);

                            var getallARMCapitalShareHCM = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.HCM).ToList();
                            allARMCapitalDharedHCM.AddRange(getallARMCapitalShareHCM);

                            var getallARMCapitalShareIT = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.IT).ToList();
                            allARMCapitalDharedIT.AddRange(getallARMCapitalShareIT);

                            var getallARMCapitalShareCTO = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.CTO).ToList();
                            allARMCapitalDharedCTO.AddRange(getallARMCapitalShareCTO);

                            var getallARMCapitalShareProcurementAndAdmin = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMCapitalDharedProcurementAndAdmin.AddRange(getallARMCapitalShareProcurementAndAdmin);

                            var getallARMCapitalShareCorporateStrategy = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.CorporateStrategy).ToList();
                            allARMCapitalDharedCorporateStrategy.AddRange(getallARMCapitalShareCorporateStrategy);

                            var getallARMCapitalShareLegal = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.Legal).ToList();
                            allARMCapitalDharedLegal.AddRange(getallARMCapitalShareLegal);

                            var getallARMCapitalShareMCC = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.MCC).ToList();
                            allARMCapitalDharedMCC.AddRange(getallARMCapitalShareMCC);

                            var getallARMCapitalShareInformationSecurity = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.InformationSecurity).ToList();
                            allARMCapitalDharedInformationSecurity.AddRange(getallARMCapitalShareInformationSecurity);

                            var getallARMCapitalShareInternalControl = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.InternalControl).ToList();
                            allARMCapitalDharedInternalControl.AddRange(getallARMCapitalShareInternalControl);

                            var getallARMCapitalShareCustomerExperience = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.CustomerExperience).ToList();
                            allARMCapitalDharedCustomerExperience.AddRange(getallARMCapitalShareCustomerExperience);

                            var getallARMCapitalShareTreasury = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.Treasury).ToList();
                            allARMCapitalDharedTreasury.AddRange(getallARMCapitalShareTreasury);

                            var getallARMCapitalShareDataAnalytic = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.DataAnalytic).ToList();
                            allARMCapitalDharedDataAnalytic.AddRange(getallARMCapitalShareDataAnalytic);

                            var getallARMCapitalShareRiskManagement = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.RiskManagement).ToList();
                            allARMCapitalDharedRiskManagement.AddRange(getallARMCapitalShareRiskManagement);

                            var getallARMCapitalShareCompliance = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.Compliance).ToList();
                            allARMCapitalDharedCompliance.AddRange(getallARMCapitalShareCompliance);

                            var getallARMCapitalShareFinancialControl = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.FinancialControl).ToList();
                            allARMCapitalDharedFinancialControl.AddRange(getallARMCapitalShareFinancialControl);

                            var getallARMCapitalShareAcademy = armCapitalShareservice.GetContextByConditon(x => getarmCapitalRate.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.Academy).ToList();
                            allARMCapitalDharedAcademy.AddRange(getallARMCapitalShareAcademy);


                            //ARMHill
                            var getallARMHill = armhillbusiness.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.ARMHill).ToList();
                            allARMHill.AddRange(getallARMHill);

                            var getallARMHillShareHCM = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.HCM).ToList();
                            allARMHillDharedHCM.AddRange(getallARMHillShareHCM);

                            var getallARMHillShareIT = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.IT).ToList();
                            allARMHillDharedIT.AddRange(getallARMHillShareIT);

                            var getallARMHillShareCTO = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.CTO).ToList();
                            allARMHillDharedCTO.AddRange(getallARMHillShareCTO);

                            var getallARMHillShareProcurementAndAdmin = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMHillDharedProcurementAndAdmin.AddRange(getallARMHillShareProcurementAndAdmin);

                            var getallARMHillShareCorporateStrategy = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.CorporateStrategy).ToList();
                            allARMHillDharedCorporateStrategy.AddRange(getallARMHillShareCorporateStrategy);

                            var getallARMHillShareLegal = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.Legal).ToList();
                            allARMHillDharedLegal.AddRange(getallARMHillShareLegal);

                            var getallARMHillShareMCC = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.MCC).ToList();
                            allARMHillDharedMCC.AddRange(getallARMHillShareMCC);

                            var getallARMHillShareInformationSecurity = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.InformationSecurity).ToList();
                            allARMHillDharedInformationSecurity.AddRange(getallARMHillShareInformationSecurity);

                            var getallARMHillShareInternalControl = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.InternalControl).ToList();
                            allARMHillDharedInternalControl.AddRange(getallARMHillShareInternalControl);

                            var getallARMHillShareCustomerExperience = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.CustomerExperience).ToList();
                            allARMHillDharedCustomerExperience.AddRange(getallARMHillShareCustomerExperience);

                            var getallARMHillShareTreasury = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.Treasury).ToList();
                            allARMHillDharedTreasury.AddRange(getallARMHillShareTreasury);

                            var getallARMHillShareDataAnalytic = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.DataAnalytic).ToList();
                            allARMHillDharedDataAnalytic.AddRange(getallARMHillShareDataAnalytic);

                            var getallARMHillShareRiskManagement = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.RiskManagement).ToList();
                            allARMHillDharedRiskManagement.AddRange(getallARMHillShareRiskManagement);

                            var getallARMHillShareCompliance = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.Compliance).ToList();
                            allARMHillDharedCompliance.AddRange(getallARMHillShareCompliance);

                            var getallARMHillShareFinancialControl = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.FinancialControl).ToList();
                            allARMHillDharedFinancialControl.AddRange(getallARMHillShareFinancialControl);

                            var getallARMHillShareAcademy = armhillshareservice.GetContextByConditon(x => getarmhill.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.Academy).ToList();
                            allARMHillDharedAcademy.AddRange(getallARMHillShareAcademy);


                            //ARMtrustee
                            var getallCommercialTrust = armtrusteebusiness.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.CommercialTrust).ToList();
                            allCommercialTrust.AddRange(getallCommercialTrust);
                            var getallPrivateTrust = armtrusteebusiness.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.PrivateTrust).ToList();
                            allPrivateTrust.AddRange(getallPrivateTrust);

                            var getallARMTrusteeShareHCM = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.HCM).ToList();
                            allARMTrusteeDharedHCM.AddRange(getallARMTrusteeShareHCM);

                            var getallARMTrusteeShareIT = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.IT).ToList();
                            allARMTrusteeDharedIT.AddRange(getallARMTrusteeShareIT);

                            var getallARMTrusteeShareCTO = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.CTO).ToList();
                            allARMTrusteeDharedCTO.AddRange(getallARMTrusteeShareCTO);

                            var getallARMTrusteeShareProcurementAndAdmin = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMTrusteeDharedProcurementAndAdmin.AddRange(getallARMTrusteeShareProcurementAndAdmin);

                            var getallARMTrusteeShareCorporateStrategy = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.CorporateStrategy).ToList();
                            allARMTrusteeDharedCorporateStrategy.AddRange(getallARMTrusteeShareCorporateStrategy);

                            var getallARMTrusteeShareLegal = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.Legal).ToList();
                            allARMTrusteeDharedLegal.AddRange(getallARMTrusteeShareLegal);

                            var getallARMTrusteeShareMCC = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.MCC).ToList();
                            allARMTrusteeDharedMCC.AddRange(getallARMTrusteeShareMCC);

                            var getallARMTrusteeShareInformationSecurity = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.InformationSecurity).ToList();
                            allARMTrusteeDharedInformationSecurity.AddRange(getallARMTrusteeShareInformationSecurity);

                            var getallARMTrusteeShareInternalControl = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.InternalControl).ToList();
                            allARMTrusteeDharedInternalControl.AddRange(getallARMTrusteeShareInternalControl);

                            var getallARMTrusteeShareCustomerExperience = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.CustomerExperience).ToList();
                            allARMTrusteeDharedCustomerExperience.AddRange(getallARMTrusteeShareCustomerExperience);

                            var getallARMTrusteeShareTreasury = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.Treasury).ToList();
                            allARMTrusteeDharedTreasury.AddRange(getallARMTrusteeShareTreasury);

                            var getallARMTrusteeShareDataAnalytic = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.DataAnalytic).ToList();
                            allARMTrusteeDharedDataAnalytic.AddRange(getallARMTrusteeShareDataAnalytic);

                            var getallARMTrusteeShareRiskManagement = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.RiskManagement).ToList();
                            allARMTrusteeDharedRiskManagement.AddRange(getallARMTrusteeShareRiskManagement);

                            var getallARMTrusteeShareCompliance = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.Compliance).ToList();
                            allARMTrusteeDharedCompliance.AddRange(getallARMTrusteeShareCompliance);

                            var getallARMTrusteeShareFinancialControl = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.FinancialControl).ToList();
                            allARMTrusteeDharedFinancialControl.AddRange(getallARMTrusteeShareFinancialControl);

                            var getallARMTrusteeShareAcademy = armtrusteeshareservice.GetContextByConditon(x => getarmtrustee.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.Academy).ToList();
                            allARMTrusteeDharedAcademy.AddRange(getallARMTrusteeShareAcademy);


                            //Security
                            var getallStockBroking = armsecuritybusiness.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.StockBroking).ToList();
                            allStockBroking.AddRange(getallStockBroking);

                            var getallARMSecurityShareHCM = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.HCM).ToList();
                            allARMSecurityDharedHCM.AddRange(getallARMSecurityShareHCM);

                            var getallARMSecurityShareIT = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.IT).ToList();
                            allARMSecurityDharedIT.AddRange(getallARMSecurityShareIT);

                            var getallARMSecurityShareCTO = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.CTO).ToList();
                            allARMSecurityDharedCTO.AddRange(getallARMSecurityShareCTO);

                            var getallARMSecurityShareProcurementAndAdmin = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMSecurityDharedProcurementAndAdmin.AddRange(getallARMSecurityShareProcurementAndAdmin);

                            var getallARMSecurityShareCorporateStrategy = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.CorporateStrategy).ToList();
                            allARMSecurityDharedCorporateStrategy.AddRange(getallARMSecurityShareCorporateStrategy);

                            var getallARMSecurityShareLegal = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.Legal).ToList();
                            allARMSecurityDharedLegal.AddRange(getallARMSecurityShareLegal);

                            var getallARMSecurityShareMCC = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.MCC).ToList();
                            allARMSecurityDharedMCC.AddRange(getallARMSecurityShareMCC);

                            var getallARMSecurityShareInformationSecurity = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.InformationSecurity).ToList();
                            allARMSecurityDharedInformationSecurity.AddRange(getallARMSecurityShareInformationSecurity);

                            var getallARMSecurityShareInternalControl = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.InternalControl).ToList();
                            allARMSecurityDharedInternalControl.AddRange(getallARMSecurityShareInternalControl);

                            var getallARMSecurityShareCustomerExperience = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.CustomerExperience).ToList();
                            allARMSecurityDharedCustomerExperience.AddRange(getallARMSecurityShareCustomerExperience);

                            var getallARMSecurityShareTreasury = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.Treasury).ToList();
                            allARMSecurityDharedTreasury.AddRange(getallARMSecurityShareTreasury);

                            var getallARMSecurityShareDataAnalytic = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.DataAnalytic).ToList();
                            allARMSecurityDharedDataAnalytic.AddRange(getallARMSecurityShareDataAnalytic);

                            var getallARMSecurityShareRiskManagement = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.RiskManagement).ToList();
                            allARMSecurityDharedRiskManagement.AddRange(getallARMSecurityShareRiskManagement);

                            var getallARMSecurityShareCompliance = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.Compliance).ToList();
                            allARMSecurityDharedCompliance.AddRange(getallARMSecurityShareCompliance);

                            var getallARMSecurityShareFinancialControl = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.FinancialControl).ToList();
                            allARMSecurityDharedFinancialControl.AddRange(getallARMSecurityShareFinancialControl);

                            var getallARMSecurityShareAcademy = armsecurityshareservice.GetContextByConditon(x => getarmsecurity.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.Academy).ToList();
                            allARMSecurityDharedAcademy.AddRange(getallARMSecurityShareAcademy);


                            //Agri
                            var getallRFL = armagribusiness.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.RFL).ToList();
                            allRFL.AddRange(getallRFL);
                            var getallAAFML = armagribusiness.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.AAFML).ToList();
                            allAAFML.AddRange(getallAAFML);

                            var getallARMAgribusinessShareHCM = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.HCM).ToList();
                            allARMAgribusinessDharedHCM.AddRange(getallARMAgribusinessShareHCM);

                            var getallARMAgribusinessShareIT = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.IT).ToList();
                            allARMAgribusinessDharedIT.AddRange(getallARMAgribusinessShareIT);

                            var getallARMAgribusinessShareCTO = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.CTO).ToList();
                            allARMAgribusinessDharedCTO.AddRange(getallARMAgribusinessShareCTO);

                            var getallARMAgribusinessShareProcurementAndAdmin = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.ProcurementAndAdmin).ToList();
                            allARMAgribusinessDharedProcurementAndAdmin.AddRange(getallARMAgribusinessShareProcurementAndAdmin);

                            var getallARMAgribusinessShareCorporateStrategy = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.CorporateStrategy).ToList();
                            allARMAgribusinessDharedCorporateStrategy.AddRange(getallARMAgribusinessShareCorporateStrategy);

                            var getallARMAgribusinessShareLegal = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.Legal).ToList();
                            allARMAgribusinessDharedLegal.AddRange(getallARMAgribusinessShareLegal);

                            var getallARMAgribusinessShareMCC = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.MCC).ToList();
                            allARMAgribusinessDharedMCC.AddRange(getallARMAgribusinessShareMCC);

                            var getallARMAgribusinessShareInformationSecurity = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.InformationSecurity).ToList();
                            allARMAgribusinessDharedInformationSecurity.AddRange(getallARMAgribusinessShareInformationSecurity);

                            var getallARMAgribusinessShareInternalControl = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.InternalControl).ToList();
                            allARMAgribusinessDharedInternalControl.AddRange(getallARMAgribusinessShareInternalControl);

                            var getallARMAgribusinessShareCustomerExperience = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.CustomerExperience).ToList();
                            allARMAgribusinessDharedCustomerExperience.AddRange(getallARMAgribusinessShareCustomerExperience);

                            var getallARMAgribusinessShareTreasury = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.Treasury).ToList();
                            allARMAgribusinessDharedTreasury.AddRange(getallARMAgribusinessShareTreasury);

                            var getallARMAgribusinessShareDataAnalytic = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.DataAnalytic).ToList();
                            allARMAgribusinessDharedDataAnalytic.AddRange(getallARMAgribusinessShareDataAnalytic);

                            var getallARMAgribusinessShareRiskManagement = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.RiskManagement).ToList();
                            allARMAgribusinessDharedRiskManagement.AddRange(getallARMAgribusinessShareRiskManagement);

                            var getallARMAgribusinessShareCompliance = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.Compliance).ToList();
                            allARMAgribusinessDharedCompliance.AddRange(getallARMAgribusinessShareCompliance);

                            var getallARMAgribusinessShareFinancialControl = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.FinancialControl).ToList();
                            allARMAgribusinessDharedFinancialControl.AddRange(getallARMAgribusinessShareFinancialControl);

                            var getallARMAgribusinessShareAcademy = armargrishareservice.GetContextByConditon(x => getarmagri.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.Academy).ToList();
                            allARMAgribusinessDharedAcademy.AddRange(getallARMAgribusinessShareAcademy);

                        }

                    }
                    var recordDFSBusiness = allDFSBusiness.ToList();
                    var recordARMCapital = allARMCapital.ToList();
                    var recordARMHill = allARMHill.ToList();
                    var recordCommercialTrust = allCommercialTrust.ToList();
                    var recordPrivateTrust = allPrivateTrust.ToList();
                    var recordStockBroking = allStockBroking.ToList();
                    var recordRFL = allRFL.ToList();
                    var recordAAFML = allAAFML.ToList();
                    var recordARMIM = allARMIM.ToList();
                    var recordARMRegistrar = allARMRegistrar.ToList();
                    var recordFundAccount = allFundAccount.ToList();
                    var recordFundAdmin = allFundAdmin.ToList();
                    var recordBDOrIMRetail = allBDOrIMRetail.ToList();
                    var recordIMUnit = allIMUnit.ToList();
                    var recordOperationControl = allOperationControl.ToList();
                    var recordOperationSettlement = allOperationSettlement.ToList();
                    var recordRetailOperation = allRetailOperation.ToList();
                    var recordResearch = allResearch.ToList();

                    var recordallDFSDharedHCM = allDFSDharedHCM.ToList();
                    var recordallDFSDharedIT = allDFSDharedIT.ToList();
                    var recordallDFSDharedCTO = allDFSDharedCTO.ToList();
                    var recordallDFSDharedProcurementAndAdmin = allDFSDharedProcurementAndAdmin.ToList();
                    var recordallDFSDharedCorporateStrategy = allDFSDharedCorporateStrategy.ToList();
                    var recordallDFSDharedLegal = allDFSDharedLegal.ToList();
                    var recordallDFSDharedMCC = allDFSDharedMCC.ToList();
                    var recordallDFSDharedInternalControl = allDFSDharedInternalControl.ToList();
                    var recordallDFSDharedInformationSecurity = allDFSDharedInformationSecurity.ToList();
                    var recordallDFSDharedCustomerExperience = allDFSDharedCustomerExperience.ToList();
                    var recordallDFSDharedTreasury = allDFSDharedTreasury.ToList();
                    var recordallDFSDharedRiskManagement = allDFSDharedRiskManagement.ToList();
                    var recordallDFSDharedDataAnalytic = allDFSDharedDataAnalytic.ToList();
                    var recordallDFSDharedCompliance = allDFSDharedCompliance.ToList();
                    var recordallDFSDharedFinancialControl = allDFSDharedFinancialControl.ToList();
                    var recordallDFSDharedAcademy = allDFSDharedAcademy.ToList();
                    //armim
                    var recordallARMIMDharedHCM = allARMIMDharedHCM.ToList();
                    var recordallARMIMDharedIT = allARMIMDharedIT.ToList();
                    var recordallARMIMDharedCTO = allARMIMDharedCTO.ToList();
                    var recordallARMIMDharedProcurementAndAdmin = allARMIMDharedProcurementAndAdmin.ToList();
                    var recordallARMIMDharedCorporateStrategy = allARMIMDharedCorporateStrategy.ToList();
                    var recordallARMIMDharedLegal = allARMIMDharedLegal.ToList();
                    var recordallARMIMDharedMCC = allARMIMDharedMCC.ToList();
                    var recordallARMIMDharedInternalControl = allARMIMDharedInternalControl.ToList();
                    var recordallARMIMDharedInformationSecurity = allARMIMDharedInformationSecurity.ToList();
                    var recordallARMIMDharedCustomerExperience = allARMIMDharedCustomerExperience.ToList();
                    var recordallARMIMDharedTreasury = allARMIMDharedTreasury.ToList();
                    var recordallARMIMDharedRiskManagement = allARMIMDharedRiskManagement.ToList();
                    var recordallARMIMDharedDataAnalytic = allARMIMDharedDataAnalytic.ToList();
                    var recordallARMIMDharedCompliance = allARMIMDharedCompliance.ToList();
                    var recordallARMIMDharedFinancialControl = allARMIMDharedFinancialControl.ToList();
                    var recordallARMIMDharedAcademy = allARMIMDharedAcademy.ToList();

                    //agri
                    var recordallARMAgribusinessDharedHCM = allARMAgribusinessDharedHCM.ToList();
                    var recordallARMAgribusinessDharedIT = allARMAgribusinessDharedIT.ToList();
                    var recordallARMAgribusinessDharedCTO = allARMAgribusinessDharedCTO.ToList();
                    var recordallARMAgribusinessDharedProcurementAndAdmin = allARMAgribusinessDharedProcurementAndAdmin.ToList();
                    var recordallARMAgribusinessDharedCorporateStrategy = allARMAgribusinessDharedCorporateStrategy.ToList();
                    var recordallARMAgribusinessDharedLegal = allARMAgribusinessDharedLegal.ToList();
                    var recordallARMAgribusinessDharedMCC = allARMAgribusinessDharedMCC.ToList();
                    var recordallARMAgribusinessDharedInternalControl = allARMAgribusinessDharedInternalControl.ToList();
                    var recordallARMAgribusinessDharedInformationSecurity = allARMAgribusinessDharedInformationSecurity.ToList();
                    var recordallARMAgribusinessDharedCustomerExperience = allARMAgribusinessDharedCustomerExperience.ToList();
                    var recordallARMAgribusinessDharedTreasury = allARMAgribusinessDharedTreasury.ToList();
                    var recordallARMAgribusinessDharedRiskManagement = allARMAgribusinessDharedRiskManagement.ToList();
                    var recordallARMAgribusinessDharedDataAnalytic = allARMAgribusinessDharedDataAnalytic.ToList();
                    var recordallARMAgribusinessDharedCompliance = allARMAgribusinessDharedCompliance.ToList();
                    var recordallARMAgribusinessDharedFinancialControl = allARMAgribusinessDharedFinancialControl.ToList();
                    var recordallARMAgribusinessDharedAcademy = allARMAgribusinessDharedAcademy.ToList();

                    //capital
                    var recordallARMCapitalDharedHCM = allARMCapitalDharedHCM.ToList();
                    var recordallARMCapitalDharedIT = allARMCapitalDharedIT.ToList();
                    var recordallARMCapitalDharedCTO = allARMCapitalDharedCTO.ToList();
                    var recordallARMCapitalDharedProcurementAndAdmin = allARMCapitalDharedProcurementAndAdmin.ToList();
                    var recordallARMCapitalDharedCorporateStrategy = allARMCapitalDharedCorporateStrategy.ToList();
                    var recordallARMCapitalDharedLegal = allARMCapitalDharedLegal.ToList();
                    var recordallARMCapitalDharedMCC = allARMCapitalDharedMCC.ToList();
                    var recordallARMCapitalDharedInternalControl = allARMCapitalDharedInternalControl.ToList();
                    var recordallARMCapitalDharedInformationSecurity = allARMCapitalDharedInformationSecurity.ToList();
                    var recordallARMCapitalDharedCustomerExperience = allARMCapitalDharedCustomerExperience.ToList();
                    var recordallARMCapitalDharedTreasury = allARMCapitalDharedTreasury.ToList();
                    var recordallARMCapitalDharedRiskManagement = allARMCapitalDharedRiskManagement.ToList();
                    var recordallARMCapitalDharedDataAnalytic = allARMCapitalDharedDataAnalytic.ToList();
                    var recordallARMCapitalDharedCompliance = allARMCapitalDharedCompliance.ToList();
                    var recordallARMCapitalDharedFinancialControl = allARMCapitalDharedFinancialControl.ToList();
                    var recordallARMCapitalDharedAcademy = allARMCapitalDharedAcademy.ToList();
                    //Security
                    var recordallARMSecurityDharedHCM = allARMSecurityDharedHCM.ToList();
                    var recordallARMSecurityDharedIT = allARMSecurityDharedIT.ToList();
                    var recordallARMSecurityDharedCTO = allARMSecurityDharedCTO.ToList();
                    var recordallARMSecurityDharedProcurementAndAdmin = allARMSecurityDharedProcurementAndAdmin.ToList();
                    var recordallARMSecurityDharedCorporateStrategy = allARMSecurityDharedCorporateStrategy.ToList();
                    var recordallARMSecurityDharedLegal = allARMSecurityDharedLegal.ToList();
                    var recordallARMSecurityDharedMCC = allARMSecurityDharedMCC.ToList();
                    var recordallARMSecurityDharedInternalControl = allARMSecurityDharedInternalControl.ToList();
                    var recordallARMSecurityDharedInformationSecurity = allARMSecurityDharedInformationSecurity.ToList();
                    var recordallARMSecurityDharedCustomerExperience = allARMSecurityDharedCustomerExperience.ToList();
                    var recordallARMSecurityDharedTreasury = allARMSecurityDharedTreasury.ToList();
                    var recordallARMSecurityDharedRiskManagement = allARMSecurityDharedRiskManagement.ToList();
                    var recordallARMSecurityDharedDataAnalytic = allARMSecurityDharedDataAnalytic.ToList();
                    var recordallARMSecurityDharedCompliance = allARMSecurityDharedCompliance.ToList();
                    var recordallARMSecurityDharedFinancialControl = allARMSecurityDharedFinancialControl.ToList();
                    var recordallARMSecurityDharedAcademy = allARMSecurityDharedAcademy.ToList();

                    //ARMTrustee
                    var recordallARMTrusteeDharedHCM = allARMTrusteeDharedHCM.ToList();
                    var recordallARMTrusteeDharedIT = allARMTrusteeDharedIT.ToList();
                    var recordallARMTrusteeDharedCTO = allARMTrusteeDharedCTO.ToList();
                    var recordallARMTrusteeDharedProcurementAndAdmin = allARMTrusteeDharedProcurementAndAdmin.ToList();
                    var recordallARMTrusteeDharedCorporateStrategy = allARMTrusteeDharedCorporateStrategy.ToList();
                    var recordallARMTrusteeDharedLegal = allARMTrusteeDharedLegal.ToList();
                    var recordallARMTrusteeDharedMCC = allARMTrusteeDharedMCC.ToList();
                    var recordallARMTrusteeDharedInternalControl = allARMTrusteeDharedInternalControl.ToList();
                    var recordallARMTrusteeDharedInformationSecurity = allARMTrusteeDharedInformationSecurity.ToList();
                    var recordallARMTrusteeDharedCustomerExperience = allARMTrusteeDharedCustomerExperience.ToList();
                    var recordallARMTrusteeDharedTreasury = allARMTrusteeDharedTreasury.ToList();
                    var recordallARMTrusteeDharedRiskManagement = allARMTrusteeDharedRiskManagement.ToList();
                    var recordallARMTrusteeDharedDataAnalytic = allARMTrusteeDharedDataAnalytic.ToList();
                    var recordallARMTrusteeDharedCompliance = allARMTrusteeDharedCompliance.ToList();
                    var recordallARMTrusteeDharedFinancialControl = allARMTrusteeDharedFinancialControl.ToList();
                    var recordallARMTrusteeDharedAcademy = allARMTrusteeDharedAcademy.ToList();

                    //Hill
                    var recordallARMHillDharedHCM = allARMHillDharedHCM.ToList();
                    var recordallARMHillDharedIT = allARMHillDharedIT.ToList();
                    var recordallARMHillDharedCTO = allARMHillDharedCTO.ToList();
                    var recordallARMHillDharedProcurementAndAdmin = allARMHillDharedProcurementAndAdmin.ToList();
                    var recordallARMHillDharedCorporateStrategy = allARMHillDharedCorporateStrategy.ToList();
                    var recordallARMHillDharedLegal = allARMHillDharedLegal.ToList();
                    var recordallARMHillDharedMCC = allARMHillDharedMCC.ToList();
                    var recordallARMHillDharedInternalControl = allARMHillDharedInternalControl.ToList();
                    var recordallARMHillDharedInformationSecurity = allARMHillDharedInformationSecurity.ToList();
                    var recordallARMHillDharedCustomerExperience = allARMHillDharedCustomerExperience.ToList();
                    var recordallARMHillDharedTreasury = allARMHillDharedTreasury.ToList();
                    var recordallARMHillDharedRiskManagement = allARMHillDharedRiskManagement.ToList();
                    var recordallARMHillDharedDataAnalytic = allARMHillDharedDataAnalytic.ToList();
                    var recordallARMHillDharedCompliance = allARMHillDharedCompliance.ToList();
                    var recordallARMHillDharedFinancialControl = allARMHillDharedFinancialControl.ToList();
                    var recordallARMHillDharedAcademy = allARMHillDharedAcademy.ToList();
                    //  decimal sumMC = recordMC.Sum();
                    decimal averageFundAccount = recordFundAccount.Any() ? recordFundAccount.Average() : 0;
                    decimal averageFundAdmin = recordFundAdmin.Any() ? recordFundAdmin.Average() : 0;
                    decimal averageBDOrIMRetail = recordBDOrIMRetail.Any() ? recordBDOrIMRetail.Average() : 0;
                    decimal averageIMUnit = recordIMUnit.Any() ? recordIMUnit.Average() : 0;
                    decimal averageOperationControl = recordOperationControl.Any() ? recordOperationControl.Average() : 0;
                    decimal averageOperationSettlement = recordOperationSettlement.Any() ? recordOperationSettlement.Average() : 0;
                    decimal averageResearch = recordResearch.Any() ? recordResearch.Average() : 0;
                    decimal averageRetailOperation = recordRetailOperation.Any() ? recordRetailOperation.Average() : 0;
                    decimal averageStockBroking = recordStockBroking.Any() ? recordStockBroking.Average() : 0;
                    decimal averageDFSBusiness = recordDFSBusiness.Any() ? recordDFSBusiness.Average() : 0;
                    decimal averageARMCapital = recordARMCapital.Any() ? recordARMCapital.Average() : 0;
                    decimal averageARMHill = recordARMHill.Any() ? recordARMHill.Average() : 0;
                    decimal averageCommercialTrust = recordCommercialTrust.Any() ? recordCommercialTrust.Average() : 0;
                    decimal averagePrivateTrust = recordPrivateTrust.Any() ? recordPrivateTrust.Average() : 0;
                    decimal averageRFL = recordRFL.Any() ? recordRFL.Average() : 0;
                    decimal averageAAFML = recordAAFML.Any() ? recordAAFML.Average() : 0;
                    decimal averageARMIM = recordARMIM.Any() ? recordARMIM.Average() : 0;
                    decimal averageARMRegistrar = recordARMRegistrar.Any() ? recordARMRegistrar.Average() : 0;
                    
                    //DFS
                    decimal averageDFSDharedHCM = recordallDFSDharedHCM.Any() ? recordallDFSDharedHCM.Average() : 0;
                    decimal averageDFSDharedIT = recordallDFSDharedIT.Any() ? recordallDFSDharedIT.Average() : 0;
                    decimal averageDFSDharedCTO = recordallDFSDharedCTO.Any() ? recordallDFSDharedCTO.Average() : 0;
                    decimal averageDFSDharedProcurementAndAdmin = recordallDFSDharedProcurementAndAdmin.Any() ? recordallDFSDharedProcurementAndAdmin.Average() : 0;
                    decimal averageDFSDharedCorporateStrategy = recordallDFSDharedCorporateStrategy.Any() ? recordallDFSDharedCorporateStrategy.Average() : 0;
                    decimal averageDFSDharedLegal = recordallDFSDharedLegal.Any() ? recordallDFSDharedLegal.Average() : 0;
                    decimal averageDFSDharedMCC = recordallDFSDharedMCC.Any() ? recordallDFSDharedMCC.Average() : 0;
                    decimal averageDFSDharedInternalControl = recordallDFSDharedInternalControl.Any() ? recordallDFSDharedInternalControl.Average() : 0;
                    decimal averageDFSDharedInformationSecurity = recordallDFSDharedInformationSecurity.Any() ? recordallDFSDharedInformationSecurity.Average() : 0;
                    decimal averageDFSDharedCustomerExperience = recordallDFSDharedCustomerExperience.Any() ? recordallDFSDharedCustomerExperience.Average() : 0;
                    decimal averageDFSDharedTreasury = recordallDFSDharedTreasury.Any() ? recordallDFSDharedTreasury.Average() : 0;
                    decimal averageDFSDharedRiskManagement = recordallDFSDharedRiskManagement.Any() ? recordallDFSDharedRiskManagement.Average() : 0;
                    decimal averageDFSDharedDataAnalytic = recordallDFSDharedDataAnalytic.Any() ? recordallDFSDharedDataAnalytic.Average() : 0;
                    decimal averageDFSDharedCompliance = recordallDFSDharedCompliance.Any() ? recordallDFSDharedCompliance.Average() : 0;
                    decimal averageDFSDharedFinancialControl = recordallDFSDharedFinancialControl.Any() ? recordallDFSDharedFinancialControl.Average() : 0;
                    decimal averageDFSDharedAcademy = recordallDFSDharedAcademy.Any() ? recordallDFSDharedAcademy.Average() : 0;
                   
                    //ARMHILL
                    decimal averageARMHillDharedHCM = recordallARMHillDharedHCM.Any() ? recordallARMHillDharedHCM.Average() : 0;
                    decimal averageARMHillDharedIT = recordallARMHillDharedIT.Any() ? recordallARMHillDharedIT.Average() : 0;
                    decimal averageARMHillDharedCTO = recordallARMHillDharedCTO.Any() ? recordallARMHillDharedCTO.Average() : 0;
                    decimal averageARMHillDharedProcurementAndAdmin = recordallARMHillDharedProcurementAndAdmin.Any() ? recordallARMHillDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMHillDharedCorporateStrategy = recordallARMHillDharedCorporateStrategy.Any() ? recordallARMHillDharedCorporateStrategy.Average() : 0;
                    decimal averageARMHillDharedLegal = recordallARMHillDharedLegal.Any() ? recordallARMHillDharedLegal.Average() : 0;
                    decimal averageARMHillDharedMCC = recordallARMHillDharedMCC.Any() ? recordallARMHillDharedMCC.Average() : 0;
                    decimal averageARMHillDharedInternalControl = recordallARMHillDharedInternalControl.Any() ? recordallARMHillDharedInternalControl.Average() : 0;
                    decimal averageARMHillDharedInformationSecurity = recordallARMHillDharedInformationSecurity.Any() ? recordallARMHillDharedInformationSecurity.Average() : 0;
                    decimal averageARMHillDharedCustomerExperience = recordallARMHillDharedCustomerExperience.Any() ? recordallARMHillDharedCustomerExperience.Average() : 0;
                    decimal averageARMHillDharedTreasury = recordallARMHillDharedTreasury.Any() ? recordallARMHillDharedTreasury.Average() : 0;
                    decimal averageARMHillDharedRiskManagement = recordallARMHillDharedRiskManagement.Any() ? recordallARMHillDharedRiskManagement.Average() : 0;
                    decimal averageARMHillDharedDataAnalytic = recordallARMHillDharedDataAnalytic.Any() ? recordallARMHillDharedDataAnalytic.Average() : 0;
                    decimal averageARMHillDharedCompliance = recordallARMHillDharedCompliance.Any() ? recordallARMHillDharedCompliance.Average() : 0;
                    decimal averageARMHillDharedFinancialControl = recordallARMHillDharedFinancialControl.Any() ? recordallARMHillDharedFinancialControl.Average() : 0;
                    decimal averageARMHillDharedAcademy = recordallARMHillDharedAcademy.Any() ? recordallARMHillDharedAcademy.Average() : 0;
                    //ARMTrustee
                    decimal averageARMTrusteeDharedHCM = recordallARMTrusteeDharedHCM.Any() ? recordallARMTrusteeDharedHCM.Average() : 0;
                    decimal averageARMTrusteeDharedIT = recordallARMTrusteeDharedIT.Any() ? recordallARMTrusteeDharedIT.Average() : 0;
                    decimal averageARMTrusteeDharedCTO = recordallARMTrusteeDharedCTO.Any() ? recordallARMTrusteeDharedCTO.Average() : 0;
                    decimal averageARMTrusteeDharedProcurementAndAdmin = recordallARMTrusteeDharedProcurementAndAdmin.Any() ? recordallARMTrusteeDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMTrusteeDharedCorporateStrategy = recordallARMTrusteeDharedCorporateStrategy.Any() ? recordallARMTrusteeDharedCorporateStrategy.Average() : 0;
                    decimal averageARMTrusteeDharedLegal = recordallARMTrusteeDharedLegal.Any() ? recordallARMTrusteeDharedLegal.Average() : 0;
                    decimal averageARMTrusteeDharedMCC = recordallARMTrusteeDharedMCC.Any() ? recordallARMTrusteeDharedMCC.Average() : 0;
                    decimal averageARMTrusteeDharedInternalControl = recordallARMTrusteeDharedInternalControl.Any() ? recordallARMTrusteeDharedInternalControl.Average() : 0;
                    decimal averageARMTrusteeDharedInformationSecurity = recordallARMTrusteeDharedInformationSecurity.Any() ? recordallARMTrusteeDharedInformationSecurity.Average() : 0;
                    decimal averageARMTrusteeDharedCustomerExperience = recordallARMTrusteeDharedCustomerExperience.Any() ? recordallARMTrusteeDharedCustomerExperience.Average() : 0;
                    decimal averageARMTrusteeDharedTreasury = recordallARMTrusteeDharedTreasury.Any() ? recordallARMTrusteeDharedTreasury.Average() : 0;
                    decimal averageARMTrusteeDharedRiskManagement = recordallARMTrusteeDharedRiskManagement.Any() ? recordallARMTrusteeDharedRiskManagement.Average() : 0;
                    decimal averageARMTrusteeDharedDataAnalytic = recordallARMTrusteeDharedDataAnalytic.Any() ? recordallARMTrusteeDharedDataAnalytic.Average() : 0;
                    decimal averageARMTrusteeDharedCompliance = recordallARMTrusteeDharedCompliance.Any() ? recordallARMTrusteeDharedCompliance.Average() : 0;
                    decimal averageARMTrusteeDharedFinancialControl = recordallARMTrusteeDharedFinancialControl.Any() ? recordallARMTrusteeDharedFinancialControl.Average() : 0;
                    decimal averageARMTrusteeDharedAcademy = recordallARMTrusteeDharedAcademy.Any() ? recordallARMTrusteeDharedAcademy.Average() : 0;

                    //Security
                    decimal averageARMSecurityDharedHCM = recordallARMSecurityDharedHCM.Any() ? recordallARMSecurityDharedHCM.Average() : 0;
                    decimal averageARMSecurityDharedIT = recordallARMSecurityDharedIT.Any() ? recordallARMSecurityDharedIT.Average() : 0;
                    decimal averageARMSecurityDharedCTO = recordallARMSecurityDharedCTO.Any() ? recordallARMSecurityDharedCTO.Average() : 0;
                    decimal averageARMSecurityDharedProcurementAndAdmin = recordallARMSecurityDharedProcurementAndAdmin.Any() ? recordallARMSecurityDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMSecurityDharedCorporateStrategy = recordallARMSecurityDharedCorporateStrategy.Any() ? recordallARMSecurityDharedCorporateStrategy.Average() : 0;
                    decimal averageARMSecurityDharedLegal = recordallARMSecurityDharedLegal.Any() ? recordallARMSecurityDharedLegal.Average() : 0;
                    decimal averageARMSecurityDharedMCC = recordallARMSecurityDharedMCC.Any() ? recordallARMSecurityDharedMCC.Average() : 0;
                    decimal averageARMSecurityDharedInternalControl = recordallARMSecurityDharedInternalControl.Any() ? recordallARMSecurityDharedInternalControl.Average() : 0;
                    decimal averageARMSecurityDharedInformationSecurity = recordallARMSecurityDharedInformationSecurity.Any() ? recordallARMSecurityDharedInformationSecurity.Average() : 0;
                    decimal averageARMSecurityDharedCustomerExperience = recordallARMSecurityDharedCustomerExperience.Any() ? recordallARMSecurityDharedCustomerExperience.Average() : 0;
                    decimal averageARMSecurityDharedTreasury = recordallARMSecurityDharedTreasury.Any() ? recordallARMSecurityDharedTreasury.Average() : 0;
                    decimal averageARMSecurityDharedRiskManagement = recordallARMSecurityDharedRiskManagement.Any() ? recordallARMSecurityDharedRiskManagement.Average() : 0;
                    decimal averageARMSecurityDharedDataAnalytic = recordallARMSecurityDharedDataAnalytic.Any() ? recordallARMSecurityDharedDataAnalytic.Average() : 0;
                    decimal averageARMSecurityDharedCompliance = recordallARMSecurityDharedCompliance.Any() ? recordallARMSecurityDharedCompliance.Average() : 0;
                    decimal averageARMSecurityDharedFinancialControl = recordallARMSecurityDharedFinancialControl.Any() ? recordallARMSecurityDharedFinancialControl.Average() : 0;
                    decimal averageARMSecurityDharedAcademy = recordallARMSecurityDharedAcademy.Any() ? recordallARMSecurityDharedAcademy.Average() : 0;

                    //capital
                    decimal averageARMCapitalDharedHCM = recordallARMCapitalDharedHCM.Any() ? recordallARMCapitalDharedHCM.Average() : 0;
                    decimal averageARMCapitalDharedIT = recordallARMCapitalDharedIT.Any() ? recordallARMCapitalDharedIT.Average() : 0;
                    decimal averageARMCapitalDharedCTO = recordallARMCapitalDharedCTO.Any() ? recordallARMCapitalDharedCTO.Average() : 0;
                    decimal averageARMCapitalDharedProcurementAndAdmin = recordallARMCapitalDharedProcurementAndAdmin.Any() ? recordallARMCapitalDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMCapitalDharedCorporateStrategy = recordallARMCapitalDharedCorporateStrategy.Any() ? recordallARMCapitalDharedCorporateStrategy.Average() : 0;
                    decimal averageARMCapitalDharedLegal = recordallARMCapitalDharedLegal.Any() ? recordallARMCapitalDharedLegal.Average() : 0;
                    decimal averageARMCapitalDharedMCC = recordallARMCapitalDharedMCC.Any() ? recordallARMCapitalDharedMCC.Average() : 0;
                    decimal averageARMCapitalDharedInternalControl = recordallARMCapitalDharedInternalControl.Any() ? recordallARMCapitalDharedInternalControl.Average() : 0;
                    decimal averageARMCapitalDharedInformationSecurity = recordallARMCapitalDharedInformationSecurity.Any() ? recordallARMCapitalDharedInformationSecurity.Average() : 0;
                    decimal averageARMCapitalDharedCustomerExperience = recordallARMCapitalDharedCustomerExperience.Any() ? recordallARMCapitalDharedCustomerExperience.Average() : 0;
                    decimal averageARMCapitalDharedTreasury = recordallARMCapitalDharedTreasury.Any() ? recordallARMCapitalDharedTreasury.Average() : 0;
                    decimal averageARMCapitalDharedRiskManagement = recordallARMCapitalDharedRiskManagement.Any() ? recordallARMCapitalDharedRiskManagement.Average() : 0;
                    decimal averageARMCapitalDharedDataAnalytic = recordallARMCapitalDharedDataAnalytic.Any() ? recordallARMCapitalDharedDataAnalytic.Average() : 0;
                    decimal averageARMCapitalDharedCompliance = recordallARMCapitalDharedCompliance.Any() ? recordallARMCapitalDharedCompliance.Average() : 0;
                    decimal averageARMCapitalDharedFinancialControl = recordallARMCapitalDharedFinancialControl.Any() ? recordallARMCapitalDharedFinancialControl.Average() : 0;
                    decimal averageARMCapitalDharedAcademy = recordallARMCapitalDharedAcademy.Any() ? recordallARMCapitalDharedAcademy.Average() : 0;

                    //agribusiness
                    decimal averageARMAgribusinessDharedHCM = recordallARMAgribusinessDharedHCM.Any() ? recordallARMAgribusinessDharedHCM.Average() : 0;
                    decimal averageARMAgribusinessDharedIT = recordallARMAgribusinessDharedIT.Any() ? recordallARMAgribusinessDharedIT.Average() : 0;
                    decimal averageARMAgribusinessDharedCTO = recordallARMAgribusinessDharedCTO.Any() ? recordallARMAgribusinessDharedCTO.Average() : 0;
                    decimal averageARMAgribusinessDharedProcurementAndAdmin = recordallARMAgribusinessDharedProcurementAndAdmin.Any() ? recordallARMAgribusinessDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMAgribusinessDharedCorporateStrategy = recordallARMAgribusinessDharedCorporateStrategy.Any() ? recordallARMAgribusinessDharedCorporateStrategy.Average() : 0;
                    decimal averageARMAgribusinessDharedLegal = recordallARMAgribusinessDharedLegal.Any() ? recordallARMAgribusinessDharedLegal.Average() : 0;
                    decimal averageARMAgribusinessDharedMCC = recordallARMAgribusinessDharedMCC.Any() ? recordallARMAgribusinessDharedMCC.Average() : 0;
                    decimal averageARMAgribusinessDharedInternalControl = recordallARMAgribusinessDharedInternalControl.Any() ? recordallARMAgribusinessDharedInternalControl.Average() : 0;
                    decimal averageARMAgribusinessDharedInformationSecurity = recordallARMAgribusinessDharedInformationSecurity.Any() ? recordallARMAgribusinessDharedInformationSecurity.Average() : 0;
                    decimal averageARMAgribusinessDharedCustomerExperience = recordallARMAgribusinessDharedCustomerExperience.Any() ? recordallARMAgribusinessDharedCustomerExperience.Average() : 0;
                    decimal averageARMAgribusinessDharedTreasury = recordallARMAgribusinessDharedTreasury.Any() ? recordallARMAgribusinessDharedTreasury.Average() : 0;
                    decimal averageARMAgribusinessDharedRiskManagement = recordallARMAgribusinessDharedRiskManagement.Any() ? recordallARMAgribusinessDharedRiskManagement.Average() : 0;
                    decimal averageARMAgribusinessDharedDataAnalytic = recordallARMAgribusinessDharedDataAnalytic.Any() ? recordallARMAgribusinessDharedDataAnalytic.Average() : 0;
                    decimal averageARMAgribusinessDharedCompliance = recordallARMAgribusinessDharedCompliance.Any() ? recordallARMAgribusinessDharedCompliance.Average() : 0;
                    decimal averageARMAgribusinessDharedFinancialControl = recordallARMAgribusinessDharedFinancialControl.Any() ? recordallARMAgribusinessDharedFinancialControl.Average() : 0;
                    decimal averageARMAgribusinessDharedAcademy = recordallARMAgribusinessDharedAcademy.Any() ? recordallARMAgribusinessDharedAcademy.Average() : 0;
                    //ARMIM
                    decimal averageARMIMDharedHCM = recordallARMIMDharedHCM.Any() ? recordallARMIMDharedHCM.Average() : 0;
                    decimal averageARMIMDharedIT = recordallARMIMDharedIT.Any() ? recordallARMIMDharedIT.Average() : 0;
                    decimal averageARMIMDharedCTO = recordallARMIMDharedCTO.Any() ? recordallARMIMDharedCTO.Average() : 0;
                    decimal averageARMIMDharedProcurementAndAdmin = recordallARMIMDharedProcurementAndAdmin.Any() ? recordallARMIMDharedProcurementAndAdmin.Average() : 0;
                    decimal averageARMIMDharedCorporateStrategy = recordallARMIMDharedCorporateStrategy.Any() ? recordallARMIMDharedCorporateStrategy.Average() : 0;
                    decimal averageARMIMDharedLegal = recordallARMIMDharedLegal.Any() ? recordallARMIMDharedLegal.Average() : 0;
                    decimal averageARMIMDharedMCC = recordallARMIMDharedMCC.Any() ? recordallARMIMDharedMCC.Average() : 0;
                    decimal averageARMIMDharedInternalControl = recordallARMIMDharedInternalControl.Any() ? recordallARMIMDharedInternalControl.Average() : 0;
                    decimal averageARMIMDharedInformationSecurity = recordallARMIMDharedInformationSecurity.Any() ? recordallARMIMDharedInformationSecurity.Average() : 0;
                    decimal averageARMIMDharedCustomerExperience = recordallARMIMDharedCustomerExperience.Any() ? recordallARMIMDharedCustomerExperience.Average() : 0;
                    decimal averageARMIMDharedTreasury = recordallARMIMDharedTreasury.Any() ? recordallARMIMDharedTreasury.Average() : 0;
                    decimal averageARMIMDharedRiskManagement = recordallARMIMDharedRiskManagement.Any() ? recordallARMIMDharedRiskManagement.Average() : 0;
                    decimal averageARMIMDharedDataAnalytic = recordallARMIMDharedDataAnalytic.Any() ? recordallARMIMDharedDataAnalytic.Average() : 0;
                    decimal averageARMIMDharedCompliance = recordallARMIMDharedCompliance.Any() ? recordallARMIMDharedCompliance.Average() : 0;
                    decimal averageARMIMDharedFinancialControl = recordallARMIMDharedFinancialControl.Any() ? recordallARMIMDharedFinancialControl.Average() : 0;
                    decimal averageARMIMDharedAcademy = recordallARMIMDharedAcademy.Any() ? recordallARMIMDharedAcademy.Average() : 0;


                    GetManagementConcernRatingResponse resp = new GetManagementConcernRatingResponse
                    {
                        Id = id,
                        ARMIM = new ManagementConcernARMIMResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMIMRatingARMIMResp
                            {
                                ARMIM = averageARMIM,
                                ARMRegistrar = averageARMRegistrar,
                                FundAccount = averageFundAccount,
                                FundAdmin = averageFundAdmin,
                                BDOrIMRetail = averageBDOrIMRetail,
                                IMUnit = averageIMUnit,
                                OperationControl = averageOperationControl,
                                OperationSettlement = averageOperationSettlement,
                                RetailOperation = averageRetailOperation,
                                Research = averageResearch
                            },
                            SharedService = new SharedServiceARMIMRatingARMIMResp
                            {
                                HCM = averageARMIMDharedHCM,
                                IT = averageARMIMDharedIT,
                                CTO = averageARMIMDharedCTO,
                                ProcurementAndAdmin = averageARMIMDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMIMDharedCorporateStrategy,
                                CustomerExperience = averageARMIMDharedCustomerExperience,
                                InformationSecurity = averageARMIMDharedInformationSecurity,
                                Legal = averageARMIMDharedLegal,
                                InternalControl = averageARMIMDharedInternalControl,
                                MCC = averageARMIMDharedMCC,
                                RiskManagement = averageARMIMDharedRiskManagement,
                                Treasury = averageARMIMDharedTreasury,
                                DataAnalytic = averageARMIMDharedDataAnalytic,
                                FinancialControl = averageARMIMDharedFinancialControl,
                                Compliance = averageARMIMDharedCompliance,
                                Academy = averageARMIMDharedAcademy,
                            },
                        },
                        DigitalFinancialService = new ManagementConcernDFSResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitDFSResp
                            {
                                DigitalFinancialService = averageDFSBusiness
                            },
                            SharedService = new SharedServiceDFSResp
                            {
                                HCM = averageDFSDharedHCM,
                                IT = averageDFSDharedIT,
                                CTO = averageDFSDharedCTO,
                                ProcurementAndAdmin = averageDFSDharedProcurementAndAdmin,
                                CorporateStrategy = averageDFSDharedCorporateStrategy,
                                CustomerExperience = averageDFSDharedCustomerExperience,
                                InformationSecurity = averageDFSDharedInformationSecurity,
                                Legal = averageDFSDharedLegal,
                                InternalControl = averageDFSDharedInternalControl,
                                MCC = averageDFSDharedMCC,
                                RiskManagement = averageDFSDharedRiskManagement,
                                Treasury = averageDFSDharedTreasury,
                                DataAnalytic = averageDFSDharedDataAnalytic,
                                Compliance = averageDFSDharedCompliance,
                                FinancialControl = averageDFSDharedFinancialControl,
                                Academy = averageDFSDharedAcademy
                            },
                        },
                        ARMCapital = new ManagementConcernARMCapitalResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMCapitalResp
                            {
                                ARMCapital = averageARMCapital
                            },
                            SharedService = new SharedServiceARMCapitalResp
                            {
                                HCM = averageARMCapitalDharedHCM,
                                IT = averageARMCapitalDharedIT,
                                CTO = averageARMCapitalDharedCTO,
                                ProcurementAndAdmin = averageARMCapitalDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMCapitalDharedCorporateStrategy,
                                CustomerExperience = averageARMCapitalDharedCustomerExperience,
                                InformationSecurity = averageARMCapitalDharedInformationSecurity,
                                Legal = averageARMCapitalDharedLegal,
                                InternalControl = averageARMCapitalDharedInternalControl,
                                MCC = averageARMCapitalDharedMCC,
                                RiskManagement = averageARMCapitalDharedRiskManagement,
                                Treasury = averageARMCapitalDharedTreasury,
                                DataAnalytic = averageARMCapitalDharedDataAnalytic,
                                Compliance = averageARMCapitalDharedCompliance,
                                FinancialControl = averageARMCapitalDharedFinancialControl,
                                Academy = averageARMCapitalDharedAcademy
                            },
                        },
                        ARMHill = new ManagementConcernARMHillResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMHillRatingARMHillResp
                            {
                                ARMHill = averageARMHill
                            },
                            SharedService = new SharedServiceARMHillRatingARMHillResp
                            {
                                HCM = averageARMHillDharedHCM,
                                IT = averageARMHillDharedIT,
                                CTO = averageARMHillDharedCTO,
                                ProcurementAndAdmin = averageARMHillDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMHillDharedCorporateStrategy,
                                CustomerExperience = averageARMHillDharedCustomerExperience,
                                InformationSecurity = averageARMHillDharedInformationSecurity,
                                Legal = averageARMHillDharedLegal,
                                InternalControl = averageARMHillDharedInternalControl,
                                MCC = averageARMHillDharedMCC,
                                RiskManagement = averageARMHillDharedRiskManagement,
                                Treasury = averageARMHillDharedTreasury,
                                DataAnalytic = averageARMHillDharedDataAnalytic,
                                Compliance = averageARMHillDharedCompliance,
                                FinancialControl = averageARMHillDharedFinancialControl,
                                Academy = averageARMHillDharedAcademy
                            },
                        },
                        ARMTrustee = new ManagementConcernARMTrusteeResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeResp
                            {
                                CommercialTrust = averageCommercialTrust,
                                PrivateTrust = averagePrivateTrust
                            },
                            SharedService = new SharedServiceARTrusteeRatingARMTrusteeResp
                            {
                                HCM = averageARMTrusteeDharedHCM,
                                IT = averageARMTrusteeDharedIT,
                                CTO = averageARMTrusteeDharedCTO,
                                ProcurementAndAdmin = averageARMTrusteeDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMTrusteeDharedCorporateStrategy,
                                CustomerExperience = averageARMTrusteeDharedCustomerExperience,
                                InformationSecurity = averageARMTrusteeDharedInformationSecurity,
                                Legal = averageARMTrusteeDharedLegal,
                                InternalControl = averageARMTrusteeDharedInternalControl,
                                MCC = averageARMTrusteeDharedMCC,
                                RiskManagement = averageARMTrusteeDharedRiskManagement,
                                Treasury = averageARMTrusteeDharedTreasury,
                                DataAnalytic = averageARMTrusteeDharedDataAnalytic,
                                FinancialControl = averageARMTrusteeDharedFinancialControl,
                                Academy = averageARMTrusteeDharedAcademy,
                                Compliance = averageARMTrusteeDharedCompliance
                            },
                        },
                        ARMSecurity = new ManagementConcernARMSecurityResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMSecurityRatingARMSecurityResp
                            {
                                StockBroking = averageStockBroking
                            },
                            SharedService = new SharedServiceARMSecurityRatingARMSecurityResp
                            {
                                HCM = averageARMSecurityDharedHCM,
                                IT = averageARMSecurityDharedIT,
                                CTO = averageARMSecurityDharedCTO,
                                ProcurementAndAdmin = averageARMSecurityDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMSecurityDharedCorporateStrategy,
                                CustomerExperience = averageARMSecurityDharedCustomerExperience,
                                InformationSecurity = averageARMSecurityDharedInformationSecurity,
                                Legal = averageARMSecurityDharedLegal,
                                InternalControl = averageARMSecurityDharedInternalControl,
                                MCC = averageARMSecurityDharedMCC,
                                RiskManagement = averageARMSecurityDharedRiskManagement,
                                Treasury = averageARMSecurityDharedTreasury,
                                DataAnalytic = averageARMSecurityDharedDataAnalytic,
                                FinancialControl = averageARMSecurityDharedFinancialControl,
                                Academy = averageARMSecurityDharedAcademy,
                                Compliance = averageARMSecurityDharedCompliance
                            },
                        },
                        ARMAgribusiness = new ManagementConcernARMAgribusinessResp
                        {
                            BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessResp
                            {
                                RFL = averageRFL,
                                AAFML = averageAAFML
                            },
                            SharedService = new SharedServiceARMAgribusinessRatingArmAgribusinessResp
                            {
                                HCM = averageARMAgribusinessDharedHCM,
                                IT = averageARMAgribusinessDharedIT,
                                CTO = averageARMAgribusinessDharedCTO,
                                ProcurementAndAdmin = averageARMAgribusinessDharedProcurementAndAdmin,
                                CorporateStrategy = averageARMAgribusinessDharedCorporateStrategy,
                                CustomerExperience = averageARMAgribusinessDharedCustomerExperience,
                                InformationSecurity = averageARMAgribusinessDharedInformationSecurity,
                                Legal = averageARMAgribusinessDharedLegal,
                                InternalControl = averageARMAgribusinessDharedInternalControl,
                                MCC = averageARMAgribusinessDharedMCC,
                                RiskManagement = averageARMAgribusinessDharedRiskManagement,
                                Treasury = averageARMAgribusinessDharedTreasury,
                                DataAnalytic = averageARMAgribusinessDharedDataAnalytic,
                                Compliance = averageARMAgribusinessDharedCompliance,
                                Academy = averageARMAgribusinessDharedAcademy,
                                FinancialControl = averageARMAgribusinessDharedFinancialControl
                            },
                        },

                    };
                    return TypedResults.Ok(resp);

                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }

    }

}
