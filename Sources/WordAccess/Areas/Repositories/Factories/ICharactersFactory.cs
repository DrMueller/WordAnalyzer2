using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface ICharactersFactory
    {
        ICharacters CreateAll(Document document);

        ICharacters CreateFromRange(Range range);
    }
}