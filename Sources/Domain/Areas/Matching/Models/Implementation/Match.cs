using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.Domain.Areas.Matching.Models.Implementation
{
    public class Match : IMatch
    {
        public Match(string value, IReadOnlyCollection<IMatchGroup> groups)
        {
            Guard.ObjectNotNull(() => value);
            Guard.ObjectNotNull(() => groups);

            Value = value;
            Groups = groups;
        }

        public IReadOnlyCollection<IMatchGroup> Groups { get; }
        public string Value { get; }
    }
}