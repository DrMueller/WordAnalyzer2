using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.Domain.Areas.Matching.Models
{
    public interface IMatch
    {
        IReadOnlyCollection<IMatchGroup> Groups { get; }

        string Value { get; }
    }
}