using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IElementDescription
    {
        string PlainDescription { get; }
        Position Position { get; }
        IReadOnlyCollection<IWord> Words { get; }
    }
}