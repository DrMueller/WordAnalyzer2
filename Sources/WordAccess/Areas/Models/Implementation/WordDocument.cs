using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class WordDocument : IWordDocument
    {
        public WordDocument(
            IReadOnlyCollection<IExternalHyperLink> externalHyperLinks,
            ICharacters characters,
            IReadOnlyCollection<IWord> words,
            IReadOnlyCollection<ITable> tables,
            IReadOnlyCollection<IShape> shapes)
        {
            Guard.ObjectNotNull(() => externalHyperLinks);
            Guard.ObjectNotNull(() => characters);
            Guard.ObjectNotNull(() => words);
            Guard.ObjectNotNull(() => tables);
            Guard.ObjectNotNull(() => shapes);

            ExternalHyperLinks = externalHyperLinks;
            Characters = characters;
            Words = words;
            Tables = tables;
            Shapes = shapes;
        }

        public ICharacters Characters { get; }
        public IReadOnlyCollection<IExternalHyperLink> ExternalHyperLinks { get; }
        public IReadOnlyCollection<IShape> Shapes { get; }
        public IReadOnlyCollection<ITable> Tables { get; }
        public IReadOnlyCollection<IWord> Words { get; }
    }
}