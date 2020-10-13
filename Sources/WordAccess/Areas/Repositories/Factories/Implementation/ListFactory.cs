using System.Collections.Generic;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class ListFactory : IListFactory
    {
        private readonly ICharactersFactory _charFactory;

        public ListFactory(ICharactersFactory charFactory)
        {
            _charFactory = charFactory;
        }

        public IListOfShapes CreateListOfShapes(nat.Document document)
        {
            var entries = CreateEntries(document, "Abbildung");

            return new ListOfShapes(entries);
        }

        public IListOfTables CreateListOfTables(nat.Document document)
        {
            var entries = CreateEntries(document, "Tabelle");

            return new ListOfTables(entries);
        }

        private IReadOnlyCollection<ICharacters> CreateEntries(nat.Document document, string entryPrefix)
        {
            var entries = new List<ICharacters>();

            for (var i = 1; i <= document.TablesOfFigures.Count; i++)
            {
                var figureEntry = document.TablesOfFigures[i];

                if (figureEntry.Range.Text.StartsWith(entryPrefix))
                {
                    var entry = _charFactory.CreateFromRange(figureEntry.Range);
                    entries.Add(entry);
                }
            }

            return new List<ICharacters>(entries);
        }
    }
}