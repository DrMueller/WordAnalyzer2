using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Word : IWord
    {
        public Word(ICharacters characters)
        {
            Guard.ObjectNotNull(() => characters);
            Characters = characters;
        }

        public ICharacters Characters { get; }
    }
}