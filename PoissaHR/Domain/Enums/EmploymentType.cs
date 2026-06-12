using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PoissaHR.Domain.Enums
{
    public enum EmploymentType
    {
        Kokoaikainen,
        [Display(Name = "Osa-aikainen")]
        OsaAikainen,
        Oppisopimus,
        Määräaikainen,
        Harjoittelu
    }
}
