﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Windows.Resources;

namespace Textfyre.UI.Current
{
    public static class Font
    {        
        public enum FontType
        {
            Headline,
            Main,
            MainItalic,
            Header,
            Footer,
            Input,
            Conversation
        }
        
        public class FontDefinition
        {
            public string FontSourcePath;
            public string FontFamilyName;
            public double FontSize;
            

            #region :: Color ::
            private SolidColorBrush _color = null;
            public SolidColorBrush Color
            {
                get
                {
                    return _color;
                }
                set
                {
                    _color = value;
                }
            }
            #endregion

            #region :: FontWeight ::
            private bool _isFontWeightSet = false;
            private FontWeight _fontWeight = FontWeights.Normal;
            public FontWeight FontWeight
            {
                get
                {
                    return _fontWeight;
                }
                set
                {
                    _isFontWeightSet = true;
                    _fontWeight = value;
                }
            }
            #endregion

            #region :: FontStyle ::
            private bool _isFontStyleSet = false;
            private FontStyle _fontStyle = FontStyles.Normal;
            public FontStyle FontStyle
            {
                get
                {
                    return _fontStyle;
                }
                set
                {
                    _isFontStyleSet = true;
                    _fontStyle = value;
                }
            }
            #endregion

            System.Collections.Generic.Dictionary<string, Stream> _fontsources
                = new System.Collections.Generic.Dictionary<string, Stream>();

            public FontSource FontSource
            {
                get
                {                    
                    if (FontSourcePath.Length > 0)
                    {
                        if (_fontsources.ContainsKey(FontSourcePath))
                        {
                            return new FontSource( _fontsources[FontSourcePath]);
                        }

                        
                        Stream fontStream = Current.Application.GameAssembly.GetManifestResourceStream(Current.Application.EntryPointAssemblyName + ".Fonts." + FontSourcePath);
                        _fontsources.Add(FontSourcePath, fontStream);
                        return new FontSource(fontStream);
                    }

                    return null;
                }
            }


            public FontFamily FontFamily
            {
                get
                {
                    return new FontFamily(FontFamilyName);
                }
            }

            public FontDefinition()
            {
            }

            public FontDefinition(string fontdef)
            {
                SetDef(fontdef);
            }

            public FontDefinition(string fontSource, string fontFamily, double fontSize)
            {
                SetDef(fontSource + "|" + fontFamily + "|" + fontSize.ToString());
            }

            public FontDefinition(string fontFamily, double fontSize) : this ( String.Empty, fontFamily, fontSize)
            {

            }

            public string GetDef()
            {
                return FontSourcePath + "|" + FontFamilyName + "|" + FontSize.ToString();
            }

            public void SetDef(string fontdef)
            {
                try {
                    string[] defParts = fontdef.Split('|');
                    FontSourcePath = defParts[0];
                    FontFamilyName = defParts[1];
                    FontSize = System.Convert.ToDouble(defParts[2]);
                } catch {
                    MessageBox.Show("Error splitting fontdef - {" + fontdef + "}");
                }
            }

            public void Apply(TextBlock textBlock)
            {
                if (FontSourcePath.Length > 0)
                {
                    textBlock.FontSource = FontSource;
                }

                textBlock.FontFamily = FontFamily;
                textBlock.FontSize = FontSize;

                if (_isFontWeightSet)
                    textBlock.FontWeight = _fontWeight;

                if (_isFontStyleSet)
                    textBlock.FontStyle = _fontStyle;

                if (_color != null)
                    textBlock.Foreground = _color;

            }
            public void Apply(TextBox textBox)
            {
                if (FontSourcePath.Length > 0)
                {
                    textBox.FontSource = FontSource;
                }

                textBox.FontFamily = FontFamily;
                textBox.FontSize = FontSize;

                if (_isFontWeightSet)
                    textBox.FontWeight = _fontWeight;

                if (_isFontStyleSet)
                    textBox.FontStyle = _fontStyle;

                if (_color != null)
                    textBox.Foreground = _color;

            }
        }


        #region :: Header ::
        private static FontDefinition _header;
        public static FontDefinition Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new FontDefinition(Storage.Settings.Get("HeaderFontDef"));
                }

                return _header;
            }

            set
            {
                _header = value;
                Storage.Settings.Set("HeaderFontDef", _header.GetDef());
            }
        }
        #endregion

        #region :: Footer ::
        private static FontDefinition _footer;
        public static FontDefinition Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer = new FontDefinition(Storage.Settings.Get("FooterFontDef"));
                }

                return _footer;
            }

            set
            {
                _footer = value;
                Storage.Settings.Set("FooterFontDef", _footer.GetDef());
            }
        }
        #endregion

        #region :: Headline ::
        private static FontDefinition _headline;
        public static FontDefinition Headline
        {
            get
            {
                if (_headline == null)
                {
                    _headline = new FontDefinition(Storage.Settings.Get("HeadlineFontDef"));
                }

                return _headline;
            }

            set
            {
                _headline = value;
                Storage.Settings.Set("HeadlineFontDef", _headline.GetDef());
            }
        }
        #endregion


        #region :: Main ::
        private static FontDefinition _main;
        public static FontDefinition Main
        {
            get
            {
                if (_main == null)
                {
                    _main = new FontDefinition(Storage.Settings.Get("MainFontDef"));
                }

                return _main;
            }

            set
            {
                _main = value;
                Storage.Settings.Set("MainFontDef", _main.GetDef());
            }
        }
        #endregion

        #region :: MainItalic ::
        private static FontDefinition _mainItalic;
        public static FontDefinition MainItalic
        {
            get
            {
                if (_mainItalic == null)
                {
                    _mainItalic = new FontDefinition(Storage.Settings.Get("MainItalicFontDef"));
                }

                return _mainItalic;
            }

            set
            {
                _mainItalic = value;
                Storage.Settings.Set("MainItalicFontDef", _mainItalic.GetDef());
            }
        }
        #endregion

        #region :: Input ::
        private static FontDefinition _input;
        public static FontDefinition Input
        {
            get
            {
                if (_input == null)
                {
                    _input = new FontDefinition(Storage.Settings.Get("InputFontDef"));
                }

                return _input;
            }

            set
            {
                _input = value;
                Storage.Settings.Set("InputFontDef", _input.GetDef());
            }
        }
        #endregion


        #region :: Conversation ::
        private static FontDefinition _conversation;
        public static FontDefinition Conversation {
            get {
                if (_conversation == null) {
                    _conversation = new FontDefinition(Storage.Settings.Get("ConversationFontDef"));
                }

                return _conversation;
            }

            set {
                _conversation = value;
                Storage.Settings.Set("ConversationFontDef", _conversation.GetDef());
            }
        }
        #endregion

        #region :: ApplyFont ::
        public static void ApplyFont( FontType fontType, TextBlock textBlock )
        {
            GetFontDef(fontType).Apply(textBlock);
        }
        public static void ApplyFont(FontType fontType, TextBox textBox)
        {
            GetFontDef(fontType).Apply(textBox);
        }
        private static FontDefinition GetFontDef(FontType fontType)
        {
            FontDefinition fd = null;
            switch (fontType)
            {
                case FontType.Main:
                    fd = Main;
                    break;
                case FontType.Headline:
                    fd = Headline;
                    break;
                case FontType.MainItalic:
                    fd = MainItalic;
                    break;
                case FontType.Header:
                    fd = Header;
                    break;
                case FontType.Footer:
                    fd = Footer;
                    break;
                case FontType.Input:
                    fd = Input;
                    break;
                case FontType.Conversation:
                    fd = Conversation;
                    break;
            }

            return fd;
        }
        #endregion


    }
}
