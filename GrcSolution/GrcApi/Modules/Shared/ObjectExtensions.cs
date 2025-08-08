using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace GrcApi.Modules.Shared
{
    public static class ObjectExtensions
    {
        public static string ToJsonString(this object obj)
        {
            if (obj == null) { return string.Empty; }
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static DocumentRSCAProcessLog ConvertToDocumentRSCAProcessLog(this DocumentRSCAProcess documentRSCAProcess)
        {
            if (documentRSCAProcess == null) { throw new ArgumentNullException(); }
            return DocumentRSCAProcessLog.Create(documentRSCAProcess.Id, ToJsonString(documentRSCAProcess));
        }

        /// <summary>
        /// Get paginated list of the entity
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetAllPagedAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize) where T : AuditEntity
        {
            if (pageNumber == 0) pageNumber = 1;
            if (pageSize == 0) pageSize = 10;

            var skip = (pageNumber - 1) * pageSize;
            return await query.Skip(skip).Take(pageSize).ToListAsync();
        }
    }
}
