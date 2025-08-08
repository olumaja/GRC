using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 07/28/2024
      * Development Group: GRCTools
      * Compliance Planning: Get all regulator payment initiated     
      */
    public class ViewInitiatedRegulatorPaymentAsBusinessUnitEndpoint
    {
        /// <summary>
        /// This endpoint is the view for the business unit to see regulator payment initiated
        /// </summary>
        /// <param name="comPayment"></param>
        /// <param name="currentUserService"></param>
        /// <param name="userRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ComplianceRegulatoryPayment> comPayment, ICurrentUserService currentUserService, IRepository<User> userRepo, IRepository<UserRole> userRoleRepo,
            IRepository<UserRoleMap> userRoleMapRepo
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var response = new List<GetComplianceRegulatorPayment>();
            var roles = currentUserService.CurrentUserRoles;

            if (!roles.Contains(GRCUserRole.OtherComplianceUser))
                return TypedResults.Ok(response);

            var roleId = userRoleRepo.GetContextByConditon(r => r.Name == GRCUserRole.OtherComplianceUser)
                                    .Select(r => r.Id)
                                    .FirstOrDefault();

            var userIds = userRoleMapRepo.GetContextByConditon(m => m.RoleId == roleId)
                                                .Select(m => m.UserId);

            var businessName = userRepo.GetContextByConditon(u => u.Email == currentUserService.CurrentUserEmail && userIds.Contains(u.Id))
                                    .Select(u => u.Business)
                                    .FirstOrDefault();

            //var businessName = userRepo.GetContextByConditon(u => u.Email == currentUserService.CurrentUserEmail && u.UserRoleId == roleId)
            //                        .Select(u => u.Business)
            //                        .FirstOrDefault();

            var query = comPayment.GetContextByConditon(q => q.BusinessEntity == businessName)
                                .OrderByDescending(q => q.CreatedOnUtc);
           
            response = query.Select(r => new GetComplianceRegulatorPayment
            {
                RegulatorPaymentId = r.Id,
                Regulator = r.Regulator,
                BusinessEntity = r.BusinessEntity,
                DeadLine = r.DeadLine,
                MeansOfPayment = r.MeansOfPaymentAmount,
                Amount = r.Amount,
                DateOfPayment = r.DateOfPayment,
                ProcessOfficer = r.ProcessOfficer,
                Status = r.Status.ToString(),
                DateCreated = r.CreatedOnUtc,
                CreatedBy = r.Initiator,
                ModifiedBy = r.LastUpdatedBy,
                LastModifiedDate = r.ModifiedOnUtc,
                ApprovedBy = r.ApprovedBy,
                ApprovalDate = r.ApprovalDate
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
