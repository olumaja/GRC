namespace GrcApi.Modules.Shared.Helpers
{
    public class ConvertDictionaryToCustomClass
    {
        public static T ConvertToClass<T>(Dictionary<string, string> dictionary) where T : new()
        {
            T obj = new T();
            foreach (var key in dictionary.Keys)
            {
                var property = typeof(T).GetProperty(key);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(obj, Convert.ChangeType(dictionary[key], property.PropertyType));
                }
            }
            return obj;
        }
    }
}
