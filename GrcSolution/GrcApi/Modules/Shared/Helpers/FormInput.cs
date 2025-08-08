using Newtonsoft.Json;

namespace GrcApi.Modules.Shared.Helpers
{
    public class FormInput
    {
        public static List<T> ConvertToObject<T>(string value)
        {
            var firstIndex = value.IndexOf("}");
            var lastIndex = value.LastIndexOf("}");
            var result = new List<T>();

            while (firstIndex < lastIndex)
            {
                var strValue = value.Substring(0, firstIndex + 1);
                var obj = JsonConvert.DeserializeObject<T>(strValue);
                result.Add(obj);
                value = value.Substring(firstIndex + 2);
                firstIndex = value.IndexOf("}");
                lastIndex = value.LastIndexOf("}");
            }

            if (!string.IsNullOrWhiteSpace(value))
                result.Add(JsonConvert.DeserializeObject<T>(value));

            return result;
        }
    }
}
