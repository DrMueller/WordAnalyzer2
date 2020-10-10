﻿using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface IWordFactory
    {
        IReadOnlyCollection<IWord> CreateAll(Document document);
    }
}