namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface ICharacter
    {
        IFont Font { get; }
        string Text { get; }
    }
}