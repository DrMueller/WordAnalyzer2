using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class WordDocument : IWordDocument
    {
        public WordDocument(
            IReadOnlyCollection<IExternalHyperLink> externalHyperLinks,
            IReadOnlyCollection<IWord> words)
        {
            Guard.ObjectNotNull(() => externalHyperLinks);
            Guard.ObjectNotNull(() => words);

            ExternalHyperLinks = externalHyperLinks;
            Words = words;
        }

        public IReadOnlyCollection<IExternalHyperLink> ExternalHyperLinks { get; }
        public IReadOnlyCollection<IWord> Words { get; }
    }
}