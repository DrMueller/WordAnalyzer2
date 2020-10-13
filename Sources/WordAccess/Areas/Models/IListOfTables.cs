using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IListOfTables
    {
        IReadOnlyCollection<ICharacters> Entries { get; }
    }
}