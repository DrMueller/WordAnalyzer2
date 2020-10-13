using System.Collections.Generic;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Matching.Services
{
    public interface IWordMatcher
    {
        IReadOnlyCollection<IMatch> MatchWords(IWordDocument document, string elementPrefix);
    }
}