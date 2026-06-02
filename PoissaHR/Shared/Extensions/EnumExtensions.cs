using System.ComponentModel.DataAnnotations;

namespace PoissaHR.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()?
                .GetCustomAttributes(false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();
            return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }
    }
}
