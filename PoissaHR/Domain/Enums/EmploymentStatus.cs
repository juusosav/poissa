using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PoissaHR.Domain.Enums
{
    public enum EmploymentStatus
    {
        Aktiivinen,
        [Display(Name = "Ei Aktiivinen")]
        EiAktiivinen,
        Irtisanottu,
        Lomalla,
        Eläkkeellä
    }
}
