using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface ITable
    {
        IReadOnlyCollection<ICell> Cells { get; }
        IElementDescription Description { get; }
    }
}