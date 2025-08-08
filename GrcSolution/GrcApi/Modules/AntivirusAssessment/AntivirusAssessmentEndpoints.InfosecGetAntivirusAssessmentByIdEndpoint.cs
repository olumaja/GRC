using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 06/28/2025
       * Development Group: GRCTools
       * Infosec Get Antivirus Assessment by Id Endpoint.
       */
    public class InfosecGetAntivirusAssessmentByIdEndpoint
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
        public static async Task<IResult> HandleAsync(Guid antivirusAssessmentFileId, IRepository<AntivirusAssessmentModel> repository, IRepository<InactiveSensors> inactive, IRepository<ReducedFunctionalityMode> reduceFunc, ICurrentUserService currentUserService)
        {
            try 
            {
                var loggedAnti = repository.GetContextByConditon(r => r.Id == antivirusAssessmentFileId).FirstOrDefault();

                if (loggedAnti is null)
                    return TypedResults.NotFound("Record not found");
                var getinactive = inactive.GetContextByConditon(a => a.AntivirusAssessmentModelId == loggedAnti.Id);
                var getinactiveResp = getinactive.Select(p => new InactiveSensorsGetByIdResp 
                {
                    InactiveSensorsId = p.Id,
                    ComputerName = p.ComputerName,
                    LastSeenOnCrowdStrike = p.LastSeenOnCrowdStrike,
                    MACAddress = p.MACAddress,
                    SystemProductName = p.SystemProductName,
                    SystemVersion = p.SystemVersion,
                    LoggedOnUser = p.LoggedOnUser,
                    LastSeenOnManageEngine = p.LastSeenOnManageEngine
                }).ToList();
                var getreduceFunc = reduceFunc.GetContextByConditon(a => a.AntivirusAssessmentModelId == loggedAnti.Id);
                var getreduceFuncResp = getreduceFunc.Select(p => new ReducedFunctionalityModeGetByIdResp 
                {
                    ReducedFunctionalityModeId = p.Id,
                    ComputerName = p.ComputerName,
                    LastSeenOnCrowdStrike = p.LastSeenOnCrowdStrike,
                    MACAddress = p.MACAddress,
                    SystemVersion = p.SystemVersion,
                    LoggedOnUser = p.LoggedOnUser,
                    LastSeenOnManageEngine = p.LastSeenOnManageEngine
                }).ToList();

                return TypedResults.Ok(new InfosecGetAntivirusAssessmentByIdDetail(
                    AntivirusAssessmentFileId: antivirusAssessmentFileId,
                    DocumentTitle: loggedAnti.TitleOfAssessment,
                    InactiveSensors: getinactiveResp,
                    ReducedFunctionalityMode: getreduceFuncResp
                ));
            }
            catch (Exception ex)
            {

                return TypedResults.Problem("Unable to get the Antivirus Assessment detail");
            }
        }
    }
}
