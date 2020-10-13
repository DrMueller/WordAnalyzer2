using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Cell : ICell
    {
        public Cell(
            int columnIndex,
            int rowIndex,
            IReadOnlyCollection<IWord> words)
        {
            Guard.ObjectNotNull(() => words);

            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            Words = words;
        }

        public int ColumnIndex { get; }
        public int RowIndex { get; }
        public IReadOnlyCollection<IWord> Words { get; }
    }
}