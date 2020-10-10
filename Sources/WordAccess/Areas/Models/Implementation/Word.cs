using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Word : IWord
    {
        public Word(string text, IFont font)
        {
            Guard.StringNotNullOrEmpty(() => text);
            Guard.ObjectNotNull(() => font);

            Text = text;
            Font = font;
        }

        public string Text { get; }
        public IFont Font { get; }
    }
}