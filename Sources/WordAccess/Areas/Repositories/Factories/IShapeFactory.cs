﻿using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface IShapeFactory
    {
        IReadOnlyCollection<IShape> CreateAll(Document document);
    }
}