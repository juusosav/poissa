using System.ComponentModel;

namespace PoissaHR.Domain.Enums
{
    public enum EmploymentType
    {
        Kokoaikainen,
        [Description("Osa-aikainen")]
        OsaAikainen,
        Sopimus,
        Määräaikainen,
        Harjoittelu
    }
}
