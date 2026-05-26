using System.ComponentModel;

namespace PoissaHR.Domain.Enums
{
    public enum AbsenceType
    {
        Loma,
        Sairausloma,
        [Description("Henkilökohtainen Loma")]
        HenkilökohtainenLoma,
        Äitiysloma,
        Isyysloma,
        Suruloma,
        [Description("Palkaton Loma")]
        PalkatonLoma,
        Muu
    }
}
