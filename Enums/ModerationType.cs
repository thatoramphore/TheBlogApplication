using System.ComponentModel;

namespace TheBlogApplication.Enums
{
    public enum ModerationType
    {
        [Description("Political propaganda")]
        Political,
        [Description("Offensive language")]
        Language,
        [Description("Drug references")]
        Drug,
        [Description("Threating speech")]
        Threating,
        [Description("Sexual content")]
        Sexual,
        [Description("Hate speech")]
        HateSpeech,
        [Description("Targeted shaming")]
        Shaming,
    }
}
