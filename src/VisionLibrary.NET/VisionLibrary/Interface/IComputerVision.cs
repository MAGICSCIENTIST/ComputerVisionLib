using System.Drawing;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using VisionLibrary.Enum;

namespace VisionLibrary.Interface
{
    public interface IComputerVision
    {
        /// <summary>
        /// API的网址
        /// </summary>
        string API { get; set; }
        /// <summary>
        /// key
        /// </summary>
        string Key { get; set; }       
        string SecretKey { get; set; }
        Task<IAnalyzeResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] features);
        Task<IAnalyzeResult> UploadAndAnalyzeImage(Bitmap image, params System.Enum[] features);
    }
}
