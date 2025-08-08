using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 26/04/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class ViewArmIMAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMIM Audit Execution By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armimauditUniverse"></param>
        /// <param name="imunit"></param>
        /// <param name="commenceEng"></param>
        /// <param name="operationControl"></param>
        /// <param name="fundAdmin"></param>
        /// <param name="registrar"></param>
        /// <param name="bDPWMIAMIMRetail"></param>
        /// <param name="operationSettlement"></param>
        /// <param name="retailOperation"></param>
        /// <param name="fundAccount"></param>
        /// <param name="armim"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMIMAuditUniverse> armimauditUniverse, IRepository<AuditUniverseARMIMIMUnit> imunit, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditUniverseARMIMOperationControl> operationControl, IRepository<AuditUniverseARMIMFundAdmin> fundAdmin, IRepository<AuditProgramAuditExecution> auditProgram,
            IRepository<AuditUniverseARMIMRegistrar> registrar, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bDPWMIAMIMRetail,
            IRepository<AuditUniverseARMIMOperationSettlement> operationSettlement, IRepository<AuditUniverseARMIMRetailOperation> retailOperation,
            IRepository<AuditUniverseARMIMResearch> research, IRepository<AuditUniverseARMIMFundAccount> fundAccount, ICurrentUserService currentUserService,
            ClaimsPrincipal user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getcommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == anualAuditUniverseId).FirstOrDefault();
                if (getcommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement must be done first");
                }
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMIM");
                }

                Guid getcommenceEngIdIM = Guid.Empty;
                var workPaperIM = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusIM = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngIM = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "IMUnit").FirstOrDefault();
                if (getCommenceEngIM != null)
                {
                    workPaperIM = getCommenceEngIM.WorkPaper.ToString();
                    findingStatusIM = getCommenceEngIM.Findingstatus.ToString();
                    getcommenceEngIdIM = getCommenceEngIM.Id;
                }

                Guid getcommenceEngIdOPC = Guid.Empty;
                var workPaperOPC = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusOPC = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngOPC = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Operation Control").FirstOrDefault();
                if (getCommenceEngOPC != null)
                {
                    workPaperOPC = getCommenceEngOPC.WorkPaper.ToString();
                    findingStatusOPC = getCommenceEngOPC.Findingstatus.ToString();
                    getcommenceEngIdOPC = getCommenceEngOPC.Id; 
                }

                Guid getcommenceEngIdReg = Guid.Empty;
                var workPaperReg = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusReg = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngReg = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Registrar").FirstOrDefault();
                if (getCommenceEngReg != null)
                {
                    workPaperReg = getCommenceEngReg.WorkPaper.ToString();
                    findingStatusReg = getCommenceEngReg.Findingstatus.ToString();
                    getcommenceEngIdReg = getCommenceEngReg.Id; 
                }

                Guid getcommenceEngIdBD = Guid.Empty;
                var workPaperBD = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusBD = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngBD = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "BDPWMIAMIMRetail").FirstOrDefault();
                if (getCommenceEngBD != null)
                {
                    workPaperBD = getCommenceEngBD.WorkPaper.ToString();
                    findingStatusBD = getCommenceEngBD.Findingstatus.ToString();
                    getcommenceEngIdBD = getCommenceEngBD.Id;
                }

                Guid getcommenceEngIdOPS = Guid.Empty;
                var workPaperOPS = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusOPS = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngOPS = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Operation Settlement").FirstOrDefault();
                if (getCommenceEngOPS != null)
                {
                    workPaperOPS = getCommenceEngOPS.WorkPaper.ToString();
                    findingStatusOPS = getCommenceEngOPS.Findingstatus.ToString();
                    getcommenceEngIdOPS = getCommenceEngOPS.Id;
                }

                Guid getcommenceEngIdFACC = Guid.Empty;
                var workPaperFACC = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusFACC = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngFACC = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Fund Account").FirstOrDefault();
                if (getCommenceEngFACC != null)
                {
                    workPaperFACC = getCommenceEngFACC.WorkPaper.ToString();
                    findingStatusFACC = getCommenceEngFACC.Findingstatus.ToString();
                    getcommenceEngIdFACC = getCommenceEngFACC.Id;
                }

                Guid getcommenceEngIdFAD = Guid.Empty;
                var workPaperFAD = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusFAD = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngFAD = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Fund Admin").FirstOrDefault();
                if (getCommenceEngFAD != null)
                {
                    workPaperFAD = getCommenceEngFAD.WorkPaper.ToString();
                    findingStatusFAD = getCommenceEngFAD.Findingstatus.ToString();
                    getcommenceEngIdFAD = getCommenceEngFAD.Id;
                }

                Guid getcommenceEngIdROP = Guid.Empty;
                var workPaperROP = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusROP = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngROP = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Retail Operation").FirstOrDefault();
                if (getCommenceEngROP != null)
                {
                    workPaperROP = getCommenceEngROP.WorkPaper.ToString();
                    findingStatusROP = getCommenceEngROP.Findingstatus.ToString();
                    getcommenceEngIdROP = getCommenceEngROP.Id;
                }

                Guid getcommenceEngIdResearch = Guid.Empty;
                var workPaperResearch = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusResearch = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngResearch = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Research").FirstOrDefault();
                if (getCommenceEngResearch != null)
                {
                    workPaperResearch = getCommenceEngResearch.WorkPaper.ToString();
                    findingStatusResearch = getCommenceEngResearch.Findingstatus.ToString();
                    getcommenceEngIdResearch = getCommenceEngResearch.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "IMUnit")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Operation Control")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Registrar")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }              
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "BDPWMIAMIMRetail")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Operation Settlement")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Fund Admin")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Fund Account")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Retail Operation")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "IMUnit")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Operation Control")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Registrar")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "BDPWMIAMIMRetail")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Operation Settlement")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Fund Admin")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Fund Account")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Retail Operation")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Research")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Research")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                var getimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getbDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getfundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getfundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getresearch = research.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getimunit.January))
                {
                    month = "January";
                    recommendation = getimunit.January;
                }
                if (!string.IsNullOrEmpty(getimunit.February))
                {
                    month = "February";
                    recommendation = getimunit.February;
                }
                if (!string.IsNullOrEmpty(getimunit.March))
                {
                    month = "March";
                    recommendation = getimunit.March;
                }
                if (!string.IsNullOrEmpty(getimunit.April))
                {
                    month = "April";
                    recommendation = getimunit.April;
                }
                if (!string.IsNullOrEmpty(getimunit.May))
                {
                    month = "May";
                    recommendation = getimunit.May;
                }
                if (!string.IsNullOrEmpty(getimunit.June))
                {
                    month = "June";
                    recommendation = getimunit.June;
                }
                if (!string.IsNullOrEmpty(getimunit.July))
                {
                    month = "July";
                    recommendation = getimunit.July;
                }
                if (!string.IsNullOrEmpty(getimunit.August))
                {
                    month = "August";
                    recommendation = getimunit.August;
                }
                if (!string.IsNullOrEmpty(getimunit.September))
                {
                    month = "September";
                    recommendation = getimunit.September;
                }
                if (!string.IsNullOrEmpty(getimunit.October))
                {
                    month = "October";
                    recommendation = getimunit.October;
                }
                if (!string.IsNullOrEmpty(getimunit.November))
                {
                    month = "November";
                    recommendation = getimunit.November;
                }
                if (!string.IsNullOrEmpty(getimunit.December))
                {
                    month = "December";
                    recommendation = getimunit.December;
                }
                string monthOp = null;
                string recommendationOp = null;
                if (!string.IsNullOrEmpty(getoperationControl.January))
                {
                    monthOp = "January";
                    recommendationOp = getoperationControl.January;
                }
                if (!string.IsNullOrEmpty(getoperationControl.February))
                {
                    monthOp = "February";
                    recommendationOp = getoperationControl.February;
                }
                if (!string.IsNullOrEmpty(getoperationControl.March))
                {
                    monthOp = "March";
                    recommendationOp = getoperationControl.March;
                }
                if (!string.IsNullOrEmpty(getoperationControl.April))
                {
                    monthOp = "April";
                    recommendationOp = getoperationControl.April;
                }
                if (!string.IsNullOrEmpty(getoperationControl.May))
                {
                    monthOp = "May";
                    recommendationOp = getoperationControl.May;
                }
                if (!string.IsNullOrEmpty(getoperationControl.June))
                {
                    monthOp = "June";
                    recommendationOp = getoperationControl.June;
                }
                if (!string.IsNullOrEmpty(getoperationControl.July))
                {
                    monthOp = "July";
                    recommendationOp = getoperationControl.July;
                }
                if (!string.IsNullOrEmpty(getoperationControl.August))
                {
                    monthOp = "August";
                    recommendationOp = getoperationControl.August;
                }
                if (!string.IsNullOrEmpty(getoperationControl.September))
                {
                    monthOp = "September";
                    recommendationOp = getoperationControl.September;
                }
                if (!string.IsNullOrEmpty(getoperationControl.October))
                {
                    monthOp = "October";
                    recommendationOp = getoperationControl.October;
                }
                if (!string.IsNullOrEmpty(getoperationControl.November))
                {
                    monthOp = "November";
                    recommendationOp = getoperationControl.November;
                }
                if (!string.IsNullOrEmpty(getoperationControl.December))
                {
                    monthOp = "December";
                    recommendationOp = getoperationControl.December;
                }

                string monthReg = null;
                string recommendationReg = null;
                if (!string.IsNullOrEmpty(getregistrar.January))
                {
                    monthReg = "January";
                    recommendationReg = getregistrar.January;
                }
                if (!string.IsNullOrEmpty(getregistrar.February))
                {
                    monthReg = "February";
                    recommendationReg = getregistrar.February;
                }
                if (!string.IsNullOrEmpty(getregistrar.March))
                {
                    monthReg = "March";
                    recommendationReg = getregistrar.March;
                }
                if (!string.IsNullOrEmpty(getregistrar.April))
                {
                    monthReg = "April";
                    recommendationReg = getregistrar.April;
                }
                if (!string.IsNullOrEmpty(getregistrar.May))
                {
                    monthReg = "May";
                    recommendationReg = getregistrar.May;
                }
                if (!string.IsNullOrEmpty(getregistrar.June))
                {
                    monthReg = "June";
                    recommendationReg = getregistrar.June;
                }
                if (!string.IsNullOrEmpty(getregistrar.July))
                {
                    monthReg = "July";
                    recommendationReg = getregistrar.July;
                }
                if (!string.IsNullOrEmpty(getregistrar.August))
                {
                    monthReg = "August";
                    recommendationReg = getregistrar.August;
                }
                if (!string.IsNullOrEmpty(getregistrar.September))
                {
                    monthReg = "September";
                    recommendationReg = getregistrar.September;
                }
                if (!string.IsNullOrEmpty(getregistrar.October))
                {
                    monthReg = "October";
                    recommendationReg = getregistrar.October;
                }
                if (!string.IsNullOrEmpty(getregistrar.November))
                {
                    monthReg = "November";
                    recommendationReg = getregistrar.November;
                }
                if (!string.IsNullOrEmpty(getregistrar.December))
                {
                    monthReg = "December";
                    recommendationReg = getregistrar.December;
                }

                string monthBD = null;
                string recommendationBD = null;
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.January))
                {
                    monthBD = "January";
                    recommendationBD = getbDPWMIAMIMRetail.January;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.February))
                {
                    monthBD = "February";
                    recommendationBD = getbDPWMIAMIMRetail.February;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.March))
                {
                    monthBD = "March";
                    recommendationBD = getbDPWMIAMIMRetail.March;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.April))
                {
                    monthBD = "April";
                    recommendationBD = getbDPWMIAMIMRetail.April;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.May))
                {
                    monthBD = "May";
                    recommendationBD = getbDPWMIAMIMRetail.May;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.June))
                {
                    monthBD = "June";
                    recommendationBD = getbDPWMIAMIMRetail.June;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.July))
                {
                    monthBD = "July";
                    recommendationBD = getbDPWMIAMIMRetail.July;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.August))
                {
                    monthBD = "August";
                    recommendationBD = getbDPWMIAMIMRetail.August;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.September))
                {
                    monthBD = "September";
                    recommendationBD = getbDPWMIAMIMRetail.September;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.October))
                {
                    monthBD = "October";
                    recommendationBD = getbDPWMIAMIMRetail.October;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.November))
                {
                    monthBD = "November";
                    recommendationBD = getbDPWMIAMIMRetail.November;
                }
                if (!string.IsNullOrEmpty(getbDPWMIAMIMRetail.December))
                {
                    monthBD = "December";
                    recommendationBD = getbDPWMIAMIMRetail.December;
                }

                string monthSet = null;
                string recommendationSet = null;
                if (!string.IsNullOrEmpty(getoperationSettlement.January))
                {
                    monthSet = "January";
                    recommendationSet = getoperationSettlement.January;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.February))
                {
                    monthSet = "February";
                    recommendationSet = getoperationSettlement.February;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.March))
                {
                    monthSet = "March";
                    recommendationSet = getoperationSettlement.March;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.April))
                {
                    monthSet = "April";
                    recommendationSet = getoperationSettlement.April;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.May))
                {
                    monthSet = "May";
                    recommendationSet = getoperationSettlement.May;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.June))
                {
                    monthSet = "June";
                    recommendationSet = getoperationSettlement.June;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.July))
                {
                    monthSet = "July";
                    recommendationSet = getoperationSettlement.July;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.August))
                {
                    monthSet = "August";
                    recommendationSet = getoperationSettlement.August;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.September))
                {
                    monthSet = "September";
                    recommendationSet = getoperationSettlement.September;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.October))
                {
                    monthSet = "October";
                    recommendationSet = getoperationSettlement.October;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.November))
                {
                    monthSet = "November";
                    recommendationSet = getoperationSettlement.November;
                }
                if (!string.IsNullOrEmpty(getoperationSettlement.December))
                {
                    monthSet = "December";
                    recommendationSet = getoperationSettlement.December;
                }

                string monthAdm = null;
                string recommendationAdm = null;
                if (!string.IsNullOrEmpty(getfundAdmin.January))
                {
                    monthAdm = "January";
                    recommendationAdm = getfundAdmin.January;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.February))
                {
                    monthAdm = "February";
                    recommendationAdm = getfundAdmin.February;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.March))
                {
                    monthAdm = "March";
                    recommendationAdm = getfundAdmin.March;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.April))
                {
                    monthAdm = "April";
                    recommendationAdm = getfundAdmin.April;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.May))
                {
                    monthAdm = "May";
                    recommendationAdm = getfundAdmin.May;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.June))
                {
                    monthAdm = "June";
                    recommendationAdm = getfundAdmin.June;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.July))
                {
                    monthAdm = "July";
                    recommendationAdm = getfundAdmin.July;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.August))
                {
                    monthAdm = "August";
                    recommendationAdm = getfundAdmin.August;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.September))
                {
                    monthAdm = "September";
                    recommendationAdm = getfundAdmin.September;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.October))
                {
                    monthAdm = "October";
                    recommendationAdm = getfundAdmin.October;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.November))
                {
                    monthAdm = "November";
                    recommendationAdm = getfundAdmin.November;
                }
                if (!string.IsNullOrEmpty(getfundAdmin.December))
                {
                    monthAdm = "December";
                    recommendationAdm = getfundAdmin.December;
                }
                string monthAcct = null;
                string recommendationAcct = null;
                if (!string.IsNullOrEmpty(getfundAccount.January))
                {
                    monthAcct = "January";
                    recommendationAcct = getfundAccount.January;
                }
                if (!string.IsNullOrEmpty(getfundAccount.February))
                {
                    monthAcct = "February";
                    recommendationAcct = getfundAccount.February;
                }
                if (!string.IsNullOrEmpty(getfundAccount.March))
                {
                    monthAcct = "March";
                    recommendationAcct = getfundAccount.March;
                }
                if (!string.IsNullOrEmpty(getfundAccount.April))
                {
                    monthAcct = "April";
                    recommendationAcct = getfundAccount.April;
                }
                if (!string.IsNullOrEmpty(getfundAccount.May))
                {
                    monthAcct = "May";
                    recommendationAcct = getfundAccount.May;
                }
                if (!string.IsNullOrEmpty(getfundAccount.June))
                {
                    monthAcct = "June";
                    recommendationAcct = getfundAccount.June;
                }
                if (!string.IsNullOrEmpty(getfundAccount.July))
                {
                    monthAcct = "July";
                    recommendationAcct = getfundAccount.July;
                }
                if (!string.IsNullOrEmpty(getfundAccount.August))
                {
                    monthAcct = "August";
                    recommendationAcct = getfundAccount.August;
                }
                if (!string.IsNullOrEmpty(getfundAccount.September))
                {
                    monthAcct = "September";
                    recommendationAcct = getfundAccount.September;
                }
                if (!string.IsNullOrEmpty(getfundAccount.October))
                {
                    monthAcct = "October";
                    recommendationAcct = getfundAccount.October;
                }
                if (!string.IsNullOrEmpty(getfundAccount.November))
                {
                    monthAcct = "November";
                    recommendationAcct = getfundAccount.November;
                }
                if (!string.IsNullOrEmpty(getfundAccount.December))
                {
                    monthAcct = "December";
                    recommendationAcct = getfundAccount.December;
                }

                string monthRetail = null;
                string recommendationRetail = null;
                if (!string.IsNullOrEmpty(getretailOperation.January))
                {
                    monthRetail = "January";
                    recommendationRetail = getretailOperation.January;
                }
                if (!string.IsNullOrEmpty(getretailOperation.February))
                {
                    monthRetail = "February";
                    recommendationRetail = getretailOperation.February;
                }
                if (!string.IsNullOrEmpty(getretailOperation.March))
                {
                    monthRetail = "March";
                    recommendationRetail = getretailOperation.March;
                }
                if (!string.IsNullOrEmpty(getretailOperation.April))
                {
                    monthRetail = "April";
                    recommendationRetail = getretailOperation.April;
                }
                if (!string.IsNullOrEmpty(getretailOperation.May))
                {
                    monthRetail = "May";
                    recommendationRetail = getretailOperation.May;
                }
                if (!string.IsNullOrEmpty(getretailOperation.June))
                {
                    monthRetail = "June";
                    recommendationRetail = getretailOperation.June;
                }
                if (!string.IsNullOrEmpty(getretailOperation.July))
                {
                    monthRetail = "July";
                    recommendationRetail = getretailOperation.July;
                }
                if (!string.IsNullOrEmpty(getretailOperation.August))
                {
                    monthRetail = "August";
                    recommendationRetail = getretailOperation.August;
                }
                if (!string.IsNullOrEmpty(getretailOperation.September))
                {
                    monthRetail = "September";
                    recommendationRetail = getretailOperation.September;
                }
                if (!string.IsNullOrEmpty(getretailOperation.October))
                {
                    monthRetail = "October";
                    recommendationRetail = getretailOperation.October;
                }
                if (!string.IsNullOrEmpty(getretailOperation.November))
                {
                    monthRetail = "November";
                    recommendationRetail = getretailOperation.November;
                }
                if (!string.IsNullOrEmpty(getretailOperation.December))
                {
                    monthRetail = "December";
                    recommendationRetail = getretailOperation.December;
                }

                string monthRes = null;
                string recommendationRes = null;
                if (!string.IsNullOrEmpty(getresearch.January))
                {
                    monthRes = "January";
                    recommendationRes = getresearch.January;
                }
                if (!string.IsNullOrEmpty(getresearch.February))
                {
                    monthRes = "February";
                    recommendationRes = getresearch.February;
                }
                if (!string.IsNullOrEmpty(getresearch.March))
                {
                    monthRes = "March";
                    recommendationRes = getresearch.March;
                }
                if (!string.IsNullOrEmpty(getresearch.April))
                {
                    monthRes = "April";
                    recommendationRes = getresearch.April;
                }
                if (!string.IsNullOrEmpty(getresearch.May))
                {
                    monthRes = "May";
                    recommendationRes = getresearch.May;
                }
                if (!string.IsNullOrEmpty(getresearch.June))
                {
                    monthRes = "June";
                    recommendationRes = getresearch.June;
                }
                if (!string.IsNullOrEmpty(getresearch.July))
                {
                    monthRes = "July";
                    recommendationRes = getresearch.July;
                }
                if (!string.IsNullOrEmpty(getresearch.August))
                {
                    monthRes = "August";
                    recommendationRes = getresearch.August;
                }
                if (!string.IsNullOrEmpty(getresearch.September))
                {
                    monthRes = "September";
                    recommendationRes = getresearch.September;
                }
                if (!string.IsNullOrEmpty(getresearch.October))
                {
                    monthRes = "October";
                    recommendationRes = getresearch.October;
                }
                if (!string.IsNullOrEmpty(getresearch.November))
                {
                    monthRes = "November";
                    recommendationRes = getresearch.November;
                }
                if (!string.IsNullOrEmpty(getresearch.December))
                {
                    monthRes = "December";
                    recommendationRes = getresearch.December;
                }


                ViewARMIMAudiPlanExecutionByIdResp resp = new ViewARMIMAudiPlanExecutionByIdResp
                {                   
                    IMUnit = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "IMUnit",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperIM,
                        FindingStatus = findingStatusIM,
                        CommenceEngagementId = getcommenceEngIdIM
                    },
                    OperationControl = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthOp,
                        Team = "Operation Control",
                        Recommendation = recommendationOp,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperOPC,
                        FindingStatus = findingStatusOPC,
                        CommenceEngagementId = getcommenceEngIdOPC
                    },
                    Registrar = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthReg,
                        Team = "Registrar",
                        Recommendation = recommendationReg,
                        EngagementPlan = getAuditRating.EngagementPlan.ToString(),
                        WorkPaper = workPaperReg,
                        FindingStatus = findingStatusReg,
                        CommenceEngagementId = getcommenceEngIdReg
                    },
                    BDPWMIAMIMRetail = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthBD,
                        Team = "BDPWMIAMIMRetail",
                        Recommendation = recommendationBD,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperBD,
                        FindingStatus = findingStatusBD,
                        CommenceEngagementId = getcommenceEngIdBD
                    },
                    OperationSettlement = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthSet,
                        Team = "Operation Settlement",
                        Recommendation = recommendationSet,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperOPS,
                        FindingStatus = findingStatusOPS,
                        CommenceEngagementId = getcommenceEngIdOPS
                    },
                    FundAdmin = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthAdm,
                        Team = "Fund Admin",
                        Recommendation = recommendationAdm,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperFAD,
                        FindingStatus = findingStatusFAD,
                        CommenceEngagementId = getcommenceEngIdFAD
                    },
                    FundAccount = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthAcct,
                        Team = "Fund Account",
                        Recommendation = recommendationAcct,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperFACC,
                        FindingStatus = findingStatusFACC,
                        CommenceEngagementId = getcommenceEngIdFACC
                    },
                    RetailOperation = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthRetail,
                        Team = "Retail Operation",
                        Recommendation = recommendationRetail,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperROP,
                        FindingStatus = findingStatusROP,
                        CommenceEngagementId = getcommenceEngIdROP
                    },
                    Research = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthRes,
                        Team = "Research",
                        Recommendation = recommendationRes,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperResearch,
                        FindingStatus = findingStatusResearch,
                        CommenceEngagementId = getcommenceEngIdResearch
                    }
                };

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
