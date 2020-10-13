using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Sections : ISections
    {
        public Sections(IReadOnlyCollection<ISection> entries)
        {
            Guard.ObjectNotNull(() => entries);
            Entries = entries;
        }

        public IReadOnlyCollection<ISection> Entries { get; }
    }
}