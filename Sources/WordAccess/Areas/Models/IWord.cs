using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface IWord
    {
        ICharacters Characters { get; }
    }
}