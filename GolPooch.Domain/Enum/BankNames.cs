using System.ComponentModel;

namespace GolPooch.Domain.Enum
{
    public enum BankNames
    {
        [Description("زرین پال")]
        ZarinPal = 2,

        [Description("پی")]
        Pay = 4,

        [Description("بانک ملی")]
        Melli = 6,

        [Description("بانک ملت")]
        Mellat = 8,
    }
}
