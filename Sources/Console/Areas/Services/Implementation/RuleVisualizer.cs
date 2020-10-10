using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.WordAnalyzer2.Domain.Areas.Services;

namespace Mmu.WordAnalyzer2.Console.Areas.Services.Implementation
{
    public class RuleVisualizer : IRuleVisualizer
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IRuleChecker _ruleChecker;

        public RuleVisualizer(IRuleChecker ruleChecker, IConsoleWriter consoleWriter)
        {
            _ruleChecker = ruleChecker;
            _consoleWriter = consoleWriter;
        }

        public async Task CheckRulesAsync()
        {
            var ruleResults = await _ruleChecker.CheckAllRulesAsync();

            ruleResults.ForEach(
                ruleResult =>
                {
                    if (ruleResult.RulePassed)
                    {
                        _consoleWriter.WriteLine($"{ruleResult.RuleName} passed", foregroundColor: ConsoleColor.Green);
                    }
                    else
                    {
                        _consoleWriter.WriteLine($"{ruleResult.RuleName} failed: {ruleResult.ErrorMessage}", foregroundColor: ConsoleColor.Red);
                    }
                });
        }
    }
}