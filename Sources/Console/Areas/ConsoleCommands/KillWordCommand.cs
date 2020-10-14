using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Services;

namespace Mmu.WordAnalyzer2.Console.Areas.ConsoleCommands
{
    public class KillWordCommand : IConsoleCommand
    {
        private readonly IWordKiller _wordKiller;

        public KillWordCommand(IWordKiller wordKiller)
        {
            _wordKiller = wordKiller;
        }

        public string Description { get; } = "Kill all Word instances";
        public ConsoleKey Key { get; } = ConsoleKey.F2;

        public Task ExecuteAsync()
        {
            _wordKiller.KillAllInstances();

            return Task.CompletedTask;
        }
    }
}