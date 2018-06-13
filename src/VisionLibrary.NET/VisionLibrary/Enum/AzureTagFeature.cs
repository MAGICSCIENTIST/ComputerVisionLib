using System.ComponentModel;

namespace VisionLibrary.Enum
{
    public enum AzureTagFeature
    {
        [Description("ImageType")]
        ImageType = 0,
        [Description("Color")]
        Color = 1,
        [Description("Tags")]
        Faces = 2,
        [Description("Adult")]
        Adult = 3,
        [Description("Categories")]
        Categories = 4,
        [Description("Tags")]
        Tags = 5,
        [Description("Description")]
        Description = 6
    }
}