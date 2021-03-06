﻿using System.Collections.Generic;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models
{
    public interface ICell
    {
        int ColumnIndex { get; }
        int RowIndex { get; }
        IReadOnlyCollection<IWord> Words { get; }
    }
}