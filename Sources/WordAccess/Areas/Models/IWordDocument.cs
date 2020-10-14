using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IWordDocument
    {
        IReadOnlyCollection<IExternalHyperLink> ExternalHyperLinks { get; }
        ISections Sections { get; }
        IListOfShapes ListOfShapes { get; }
        IListOfTables ListOfTables { get; }
        IReadOnlyCollection<IShape> Shapes { get; }
        IReadOnlyCollection<ITable> Tables { get; }
        IReadOnlyCollection<IWord> Words { get; }
    }
}