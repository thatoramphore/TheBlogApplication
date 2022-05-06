using System.ComponentModel;

namespace TheBlogApplication.Enums
{
    public enum ReadyStatus
    {
        [Description("Incomplete")]
        Incomplete,
        [Description("Production Ready")]
        ProductionReady,
        [Description("Preview Ready")]
        PreviewReady
    }
}
