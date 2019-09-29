using VisionLibrary.Module;

namespace VisionLibrary.Interface
{
    public interface IAnalyzeResultConclusion
    {
        bool IsAnimal();
        Score GetTop();
    }
}