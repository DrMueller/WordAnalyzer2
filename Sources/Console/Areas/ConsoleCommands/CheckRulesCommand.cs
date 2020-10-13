using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.WordAnalyzer2.Console.Areas.Services;

namespace Mmu.WordAnalyzer2.Console.Areas.ConsoleCommands
{
    public class CheckRulesCommand : IConsoleCommand
    {
        private readonly IRuleVisualizer _ruleVisualizer;

        public CheckRulesCommand(IRuleVisualizer ruleVisualizer)
        {
            _ruleVisualizer = ruleVisualizer;
        }

        public string Description { get; } = "Run rules";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public async Task ExecuteAsync()
        {
            await _ruleVisualizer.CheckRulesAsync();
        }
    }
}