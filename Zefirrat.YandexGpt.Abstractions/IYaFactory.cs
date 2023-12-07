namespace Zefirrat.YandexGpt.Abstractions
{
    public interface IYaFactory
    {
        IYaChatter CreateChatter();
        IYaPrompter CreatePrompter();
        IYaSummarizer CreateSummarizer();
    }
}