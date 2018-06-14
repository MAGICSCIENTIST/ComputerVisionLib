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

        //Task<AnalysisResult> UploadAndAnalyzeImage(string imageFilePath, params System.Enum[] features);
    }
}
