using System.Threading.Tasks;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories
{
    public interface IWordDocumentRepository
    {
        Task<IWordDocument> LoadAsync(string filePath);
    }
}