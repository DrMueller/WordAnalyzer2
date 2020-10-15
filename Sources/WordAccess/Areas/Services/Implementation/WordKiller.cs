using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Services.Implementation
{
    public class WordKiller : IWordKiller
    {
        public void KillAllInstances()
        {
            Process
                .GetProcesses()
                .Where(f => f.ProcessName.ToUpper(CultureInfo.CurrentCulture).Contains("WINWORD"))
                .ForEach(proc => proc.Kill());
        }
    }
}