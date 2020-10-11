﻿using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Character : ICharacter
    {
        public Character(string text, IFont font)
        {
            Guard.StringNotNullOrEmpty(() => text);
            Guard.ObjectNotNull(() => font);

            Text = text;
            Font = font;
        }

        public IFont Font { get; }

        public string Text { get; }
    }
}