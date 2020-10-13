using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class ListOfTables : IListOfTables
    {
        public ListOfTables(IReadOnlyCollection<ICharacters> entries)
        {
            Guard.ObjectNotNull(() => entries);

            Entries = entries;
        }

        public IReadOnlyCollection<ICharacters> Entries { get; }
    }
}