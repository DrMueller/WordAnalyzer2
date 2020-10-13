using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Section : ISection
    {
        public Section(IReadOnlyCollection<IPageNumberDefinition> pageNumberDefinitions)
        {
            Guard.ObjectNotNull(() => pageNumberDefinitions);

            PageNumberDefinitions = pageNumberDefinitions;
        }

        public IReadOnlyCollection<IPageNumberDefinition> PageNumberDefinitions { get; }
    }
}