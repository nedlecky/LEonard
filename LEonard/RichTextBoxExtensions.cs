// File: RichTextBoxExtensions.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Dependable replacement for RTB.GetFirstCharIndexFromLine

namespace LEonard
{
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// Dependable replacement for RTB.GetFirstCharIndexFromLine. Actually adds up the previous lines plus terminator.
        /// When you don't do this, you get odd behavior with line wrapping and if you toggle it off, you get flashing of the control.
        /// </summary>
        /// <param name="n">0-indexed line number to examine</param>
        /// <returns></returns>
        public static (int start, int length) GetLineExtents(this System.Windows.Forms.RichTextBox richTextBox, int n)
        {
            int start = 0;
            for (int i = 0; i < n; i++)
                start += richTextBox.Lines[i].Length + 1;

            return (start, richTextBox.Lines[n].Length);
        }
    }
}
