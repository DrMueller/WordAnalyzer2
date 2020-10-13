using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.Domain.Areas.Matching.Models.Implementation
{
    public class MatchGroup : IMatchGroup
    {
        public MatchGroup(string name, string value)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => value);

            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}