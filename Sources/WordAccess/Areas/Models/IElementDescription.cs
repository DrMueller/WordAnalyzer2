using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IElementDescription
    {
        Position Position { get; }
        string PlainDescription { get; }
        IReadOnlyCollection<IWord> Words { get; }
    }
}