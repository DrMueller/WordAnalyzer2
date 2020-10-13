using System.Threading.Tasks;

namespace Mmu.WordAnalyzer2.Console.Areas.Services
{
    public interface IRuleVisualizer
    {
        Task CheckRulesAsync();
    }
}