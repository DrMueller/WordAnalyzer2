using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Word : IWord
    {
        public Word(string text)
        {
            Guard.StringNotNullOrEmpty(() => text);

            Text = text;
        }

        public string Text { get; }
    }
}