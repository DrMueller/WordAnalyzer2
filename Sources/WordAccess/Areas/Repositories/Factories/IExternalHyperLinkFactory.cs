using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface IExternalHyperLinkFactory
    {
        Task<IReadOnlyCollection<IExternalHyperLink>> CreateAllAsync(Document document);
    }
}