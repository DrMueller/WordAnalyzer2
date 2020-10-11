using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface ICharacters
    {
        IReadOnlyCollection<ICharacter> Entries { get; }

        string Text { get; }
    }
}