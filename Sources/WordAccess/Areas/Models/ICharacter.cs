using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface ICharacter
    {
        string Text { get; }
        IFont Font { get; }
    }
}
