using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using Arm.GrcTool.Domain;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 06/28/2025
       * Development Group: GRCTools
       * Infosec Get Antivirus Assessment by Id Endpoint.
       */
    public class GetAntivirusAssessmentByIdEndpoint
    {
        /// <summary>
        /// Get Antivirus Assessmentby Id Endpoint.
        /// </summary>
        /// <param name="antivirusAssessmentFileId"></param>
        /// <param name="repository"></param>
        /// <param name="inactive"></param>
        /// <param name="reduceFunc"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid antivirusAssessmentFileId, IRepository<AntivirusAssessmentModel> repository, IRepository<Document> docRepo, IRepository<InactiveSensors> inactive, IRepository<ReducedFunctionalityMode> reduceFunc, ICurrentUserService currentUserService)
        {            
            try
            {
                var loggedAnti = await repository.GetContextByConditon(r => r.Id == antivirusAssessmentFileId).FirstOrDefaultAsync();
                if (loggedAnti is null) return TypedResults.NotFound("Antivirus Assessment Record not found");


                var getinactive = inactive.GetContextByConditon(a => a.AntivirusAssessmentModelId == loggedAnti.Id);
               
                var getinactiveList = await getinactive.ToListAsync();
                var responseList = new List<InactiveSensorsByIdResp>();

                foreach (var q in getinactiveList)
                {
                    var attachment = await docRepo
                        .GetContextByConditon(d =>
                            d.ModuleItemId == q.Id &&
                            d.ModuleItemType == ModuleType.InfoSecAntivirusInactiveSensor)
                        .Select(d => new GetAttachedReportResponse
                        {
                            DocumentId = d.Id,
                            DateCreated = d.CreatedOnUtc,
                            DocumentName = d.Name
                        })
                        .ToListAsync();

                    responseList.Add(new InactiveSensorsByIdResp
                    {
                        InactiveSensorsId = q.Id,
                        ComputerName = q.ComputerName,
                        LastSeenOnCrowdStrike = q.LastSeenOnCrowdStrike,
                        MACAddress = q.MACAddress,
                        SystemProductName = q.SystemProductName,
                        SystemVersion = q.SystemVersion,
                        LoggedOnUser = q.LoggedOnUser,
                        LastSeenOnManageEngine = q.LastSeenOnManageEngine,
                        InfosecComment = q.Comment,
                        ActionOwnerComment = q.ActionOwnerComment,
                        Status = q.Status.ToString(),
                        Action = q.Action.ToString(),
                        Evidence = attachment
                    });
                }


                var getreduceFunc = reduceFunc.GetContextByConditon(a => a.AntivirusAssessmentModelId == loggedAnti.Id);
                var getreduceFuncList = await getreduceFunc.ToListAsync();
                var responseRedList = new List<ReducedFunctionalityModeByIdResp>();

                foreach (var p in getreduceFuncList)
                {
                    var attachments = await docRepo
                        .GetContextByConditon(d =>
                            d.ModuleItemId == p.Id &&
                            d.ModuleItemType == ModuleType.InfoSecAntivirusReduceFunctionality)
                        .Select(d => new GetAttachedReportResponse
                        {
                            DocumentId = d.Id,
                            DateCreated = d.CreatedOnUtc,
                            DocumentName = d.Name
                        })
                        .ToListAsync();

                    responseRedList.Add(new ReducedFunctionalityModeByIdResp
                    {
                        ReducedFunctionalityModeId = p.Id,
                        ComputerName = p.ComputerName,
                        LastSeenOnCrowdStrike = p.LastSeenOnCrowdStrike,
                        MACAddress = p.MACAddress,
                        SystemVersion = p.SystemVersion,
                        LoggedOnUser = p.LoggedOnUser,
                        LastSeenOnManageEngine = p.LastSeenOnManageEngine,
                        InfosecComment = p.Comment,
                        ActionOwnerComment = p.ActionOwnerComment,
                        Status = p.Status.ToString(),
                        Action = p.Action.ToString(),
                        Evidence = attachments
                    });
                }


                var result = new GetAntivirusAssessmentById(
                   AntivirusAssessmentFileId: antivirusAssessmentFileId,
                   AssessmentType: loggedAnti.AssessmentType,
                   DocumentTitle: loggedAnti.TitleOfAssessment,
                   ActionOwner: loggedAnti.ActionOwner,
                   ActionOwnerUnit: loggedAnti.ActionOwnerUnit,
                   ProposeEndDate: loggedAnti.ProposeEndDate,
                   ApprovedBy: loggedAnti.ApprovedBy,
                   DateApproved: loggedAnti.DateApproved,
                   InactiveSensors: responseList,
                   ReducedFunctionalityMode: responseRedList
                );

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Unable to get the vulnerability detail");
            }





        }
    }
}
