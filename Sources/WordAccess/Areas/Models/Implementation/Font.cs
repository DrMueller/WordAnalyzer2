using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Font : IFont
    {
        public Font(string name)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Name = name;
        }

        public string Name { get; }
    }
}