using System.Collections.Generic;
using System.Linq;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class ElementDescription : IElementDescription
    {
        public ElementDescription(Position position, IReadOnlyCollection<IWord> description)
        {
            Position = position;
            Words = description;
        }

        public string PlainDescription
        {
            get
            {
                return string.Join(string.Empty, Words.Select(f => f.Characters.Text));
            }
        }

        public Position Position { get; }

        public IReadOnlyCollection<IWord> Words { get; }
    }
}