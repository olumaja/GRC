using System.ComponentModel;

namespace GrcApi.Modules.Shared.Extensions
{
    public static class Extension
    {
        /// <summary>
        /// This method is an extention method that help get enum description as a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetEnumDestription(this Enum value){
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            if (name != null)
            {
                var field = type.GetField(name);

                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                        return attr.Description;
                    else
                        return value.ToString();
                }
            }

            return null;
        }
    }
}
