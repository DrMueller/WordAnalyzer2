using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class WordDocument : IWordDocument
    {
        public WordDocument(IReadOnlyCollection<IWord> words)
        {
            Guard.ObjectNotNull(() => words);

            Words = words;
        }

        public IReadOnlyCollection<IWord> Words { get; }
    }
}