using System.Collections.Generic;
using System.Linq;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class ElementDescriptionFactory : IElementDescriptionFactory
    {
        private readonly IWordFactory _wordFactory;

        public ElementDescriptionFactory(IWordFactory wordFactory)
        {
            _wordFactory = wordFactory;
        }

        public IElementDescription CreateFromRange(nat.Range range, string anchorElement)
        {
            var sentenceNext = GetNextRange(range);
            var sentenceBefore = GetPreviousRange(range);

            Position position;
            IReadOnlyCollection<IWord> description;

            if (sentenceNext.Text.Contains(anchorElement))
            {
                position = Position.Below;
                description = _wordFactory.CreateFromRange(sentenceNext);
            }
            else if (sentenceBefore.Text.Contains(anchorElement))
            {
                position = Position.Above;
                description = _wordFactory.CreateFromRange(sentenceBefore);
            }
            else
            {
                position = Position.None;
                description = new List<Word>();
            }

            return new ElementDescription(position, description);
        }

        private static nat.Range GetNextRange(nat.Range range)
        {
            var r = range;

            while (true)
            {
                var next = r.Next();

                if (next == null)
                {
                    return r;
                }

                if (next.Text != "\r")
                {
                    var descriptionRange = next.Sentences.Cast<nat.Range>().Single();

                    return descriptionRange;
                }

                r = next;
            }
        }

        private static nat.Range GetPreviousRange(nat.Range range)
        {
            var r = range;

            while (true)
            {
                var prev = r.Previous();

                if (prev == null)
                {
                    return r;
                }

                if (prev.Text != "\r")
                {
                    var descriptionRange = prev.Sentences.Cast<nat.Range>().Single();

                    return descriptionRange;
                }

                r = prev;
            }
        }
    }
}