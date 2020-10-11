using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Characters : ICharacters
    {
        public Characters(IReadOnlyCollection<ICharacter> entries)
        {
            Guard.ObjectNotNull(() => entries);

            Entries = entries;
        }

        public IReadOnlyCollection<ICharacter> Entries { get; }

        public string Text
        {
            get
            {
                return string.Join(string.Empty, Entries.Select(f => f.Text));
            }
        }
    }
}