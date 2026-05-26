using System.ComponentModel;

namespace PoissaHR.Domain.Enums
{
    public enum EmploymentStatus
    {
        Aktiivinen,
        [Description("Ei Aktiivinen")]
        EiAktiivinen,
        Irtisanottu,
        Lomalla,
        Eläkkeellä
    }
}
