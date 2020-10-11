using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Shape : IShape
    {
        public Shape(IElementDescription description)
        {
            Guard.ObjectNotNull(() => description);

            Description = description;
        }

        public IElementDescription Description { get; }
    }
}