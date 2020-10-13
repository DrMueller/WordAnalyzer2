namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IPageNumberDefinition
    {
        bool RestartNumberingAtSection { get; }
        bool ShowFirstPageNumber { get; }
        int StartingNumber { get; }
    }
}