using System.ComponentModel;

namespace wpfPocAPI.Models.Enums
{
    public enum WegUnities
    {
        [Description("GLOBAL")]
        GLOBAL = 0,
        [Description("WTD-BNU")]
        WTD_BNU = 1,
        [Description("WTD-GCV")]
        WTD_GCV = 2,
        [Description("WTD-TIZ")]
        WTD_TIZ = 4,
        [Description("WTD-HUE")]
        WTD_HUE = 8,
    }
}
