﻿using System;
using System.Windows;
using System.Windows.Media;

namespace Application.Client.Dialogs.FontDialog.Models.Result
{
    public class FontResult
    {
        private readonly string _fontFamilyName;
        public string FontFamilyName
        {
            private get
            {
                if (string.IsNullOrWhiteSpace(_fontFamilyName))
                {
                    throw new ArgumentNullException(nameof(FontFamilyName), "The value cannot be null!");
                }

                return _fontFamilyName;
            }

            init => _fontFamilyName = value;
        }

        private readonly float? _drawingFontSize;
        public float DrawingFontSize
        {
            private get => _drawingFontSize ?? throw new ArgumentNullException(nameof(DrawingFontSize), "The value cannot be null!");
            init => _drawingFontSize = value;
        }

        private readonly System.Drawing.FontStyle? _drawingFontStyle;
        public System.Drawing.FontStyle DrawingFontStyle
        {
            private get => _drawingFontStyle ?? throw new ArgumentNullException(nameof(DrawingFontStyle), "The value cannot be null!");
            init => _drawingFontStyle = value;
        }

        public FontFamily FontFamily => new(FontFamilyName);

        public float FontSize => (float)(DrawingFontSize * 96.0 / 72.0);

        public FontStyle FontStyle => (DrawingFontStyle & System.Drawing.FontStyle.Italic) != 0 ? FontStyles.Italic : FontStyles.Normal;

        public FontWeight FontWeight => (DrawingFontStyle & System.Drawing.FontStyle.Bold) != 0 ? FontWeights.Bold : FontWeights.Regular;

        public TextDecorationCollection TextDecorations
        {
            get
            {
                TextDecorationCollection result = new();

                if ((DrawingFontStyle & System.Drawing.FontStyle.Strikeout) != 0)
                {
                    result.Add(System.Windows.TextDecorations.Strikethrough);
                }

                if ((DrawingFontStyle & System.Drawing.FontStyle.Underline) != 0)
                {
                    result.Add(System.Windows.TextDecorations.Underline);
                }

                return result;
            }
        }
    }
}
