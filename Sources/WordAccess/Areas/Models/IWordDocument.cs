using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IWordDocument
    {
        ICharacters Characters { get; }
        IReadOnlyCollection<IExternalHyperLink> ExternalHyperLinks { get; }
        IReadOnlyCollection<IShape> Shapes { get; }
        IReadOnlyCollection<ITable> Tables { get; }
        IReadOnlyCollection<IWord> Words { get; }
    }
}