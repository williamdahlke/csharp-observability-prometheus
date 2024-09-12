using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace wpfPocAPI.Resources
{
    public static class AttributeExtensions
    {
        public static string GetDescription(this System.Enum value)
        {
            DescriptionAttribute attribute = value.GetAttribute<DescriptionAttribute>();
            string description = attribute == null ? value.ToString() : attribute.Description;
            return description;
        }

        private static T GetAttribute<T>(this object value) where T : System.Attribute
        {
            MemberInfo memberInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (memberInfo != null)
            {
                return (T)memberInfo.GetCustomAttribute<T>();
            }
            return null;
        }
    }
}
