using System.Collections.Generic;
using System.Linq;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class TableFactory : ITableFactory
    {
        private readonly IWordFactory _wordFactory;
        private readonly IElementDescriptionFactory _descFactory;

        private const string TableDescriptionPrefix = "Tabelle";

        public TableFactory(
            IWordFactory wordFactory,
            IElementDescriptionFactory descFactory)
        {
            _wordFactory = wordFactory;
            _descFactory = descFactory;
        }

        public IReadOnlyCollection<ITable> CreateAll(nat.Document document)
        {
            return document
                .Tables
                .Cast<nat.Table>()
                .Select(CreateTable)
                .ToList();
        }


        private ICell CreateCell(nat.Cell cell)
        {
            var words = _wordFactory.CreateFromRange(cell.Range);

            return new Cell(
                cell.ColumnIndex,
                cell.RowIndex,
                words);
        }

        private ITable CreateTable(nat.Table table)
        {
            var tableRange = table.Range;
            var cells = tableRange
                .Cells
                .Cast<nat.Cell>()
                .Select(CreateCell)
                .ToList();

            var description = _descFactory.CreateFromRange(tableRange, TableDescriptionPrefix);

            return new Table(cells, description);
        }
    }
}