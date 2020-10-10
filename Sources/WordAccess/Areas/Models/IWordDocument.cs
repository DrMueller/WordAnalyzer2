using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IWordDocument
    {
        IReadOnlyCollection<IWord> Words { get; }
    }
}
