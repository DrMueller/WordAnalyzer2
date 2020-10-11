using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Table : ITable
    {
        public Table(IReadOnlyCollection<ICell> cells, IElementDescription description)
        {
            Guard.ObjectNotNull(() => cells);

            Cells = cells;
            Description = description;
        }

        public IReadOnlyCollection<ICell> Cells { get; }
        public IElementDescription Description { get; }
    }
}