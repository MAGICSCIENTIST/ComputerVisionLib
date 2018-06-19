using System.ComponentModel;
using VisionLibrary.Attributes;

namespace VisionLibrary.Enum
{
    public enum FileType
    {

        [Description("图片文件")]
        [ExName(".jpg", ".png", ".bmp", ".gif", ".jpeg")]
        image = 1,

        [Description("视频文件")]
        [ExName(".mp4",".avi")]
        video = 2,

        [Description("音频文件")]
        [ExName(".mp3")]
        audio = 3,
    }
}
