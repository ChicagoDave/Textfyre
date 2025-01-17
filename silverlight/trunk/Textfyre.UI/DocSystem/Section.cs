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

namespace Textfyre.UI.DocSystem
{
    public class Section
    {
        FyreXmlElementCollection _fyreXmlElements;
        TextFormat _textFormat = new TextFormat();
        SectionTextBlockProxy _txtBlk;

        public Grid HostGrid
        {
            get
            {
                return _txtBlk.HostGrid;
            }
        }

        public Grid HostGridScroll
        {
            get
            {
                return _txtBlk.HostGridScroll;
            }
        }


        #region :: Sequence ::
        int _sequence;
        public int Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                _sequence = value;
            }
        }
        #endregion

        #region :: PageNumber ::
        int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
            }
        }
        #endregion

        #region :: IsEmpty ::
        public bool IsEmpty
        {
            get
            {
                if( _txtBlk == null )
                    return true;

                return _txtBlk.IsEmpty;
            }
        }
        #endregion

        #region :: Text ::
        private string _text;
        public string Text
        {
            get
            {
                if (_sectionType == SectionType.Prompt)
                {
                    return _text;
                }

                if (_txtBlk == null)
                    return String.Empty;
                return _txtBlk.Text;
            }
        }
        #endregion

        #region :: Data ::
        private object _data;
        public object Data
        {
            get
            {
                return _data;
            }
        }
        #endregion

        #region :: Height ::
        private double _height = 0;
        public double Height
        {
            get
            {
                return _height;
            }
        }
        #endregion

        #region :: ContentMode ::
        private ContentMode _contentMode = ContentMode.None;
        public ContentMode ContentMode
        {
            get
            {
                return _contentMode;
            }
        }
        #endregion

        #region :: SectionType ::
        private SectionType _sectionType = SectionType.Content;
        public SectionType SectionType
        {
            get
            {
                return _sectionType;
            }
        }
        #endregion

        public FyreXmlElementCollection Process(FyreXmlElementCollection fyreXmlElements)
        {
            return Process(fyreXmlElements, null);
        }
        public FyreXmlElementCollection Process(FyreXmlElementCollection fyreXmlElements, SectionTextBlockProxy.StackPanels stackPanels )
        {
            _txtBlk = new SectionTextBlockProxy();
            _fyreXmlElements = fyreXmlElements;
            _txtBlk.IsWordDefMode = _fyreXmlElements.IsWordDefMode;
            _txtBlk.WordDefID = _fyreXmlElements.WordDefID;

            _textFormat = _fyreXmlElements.TextFormat;
            _contentMode = _fyreXmlElements.ContentMode;

            if (_fyreXmlElements.Image != null)
            {
                DoImage();
                return _fyreXmlElements;
            }

            if (_fyreXmlElements.ArtRegister != null)
            {
                DoArt();
                return _fyreXmlElements;
            }

            bool _processElements = true;
            while (_fyreXmlElements.Count > 0 && _processElements)
            {
                FyreXmlElement element = _fyreXmlElements[0];
                _fyreXmlElements.RemoveAt(0);
                if (element == null)
                    break;
                switch (element.OpCode)
                {
                    case FyreXml.OpCode.PrologueMode:
                        _fyreXmlElements.ContentMode = ContentMode.Prologue;
                        break;

                    case FyreXml.OpCode.StoryMode:
                        _fyreXmlElements.ContentMode = ContentMode.Story;
                        break;

                    case FyreXml.OpCode.HeaderBegin :
                        _fyreXmlElements.MaxWidth = _fyreXmlElements.MaxWidth - Settings.HeadlineOffset;
                        SetTextFormatToHeadline();
                        break;

                    case FyreXml.OpCode.HeaderEnd :
                        SetTextFormatToNormal();
                        _fyreXmlElements.MaxWidth = _fyreXmlElements.MaxWidth + Settings.HeadlineOffset;
                        EndOfSection();
                        return _fyreXmlElements;

                    case FyreXml.OpCode.BoldOn:
                        _textFormat.IsBold = true;
                        break;
                    case FyreXml.OpCode.BoldOff:
                        _textFormat.IsBold = false;
                        break;

                    case FyreXml.OpCode.ItalicOn:
                        _textFormat.IsItalic = true;
                        break;
                    case FyreXml.OpCode.ItalicOff:
                        _textFormat.IsItalic = false;
                        break;

                    case FyreXml.OpCode.TextBlockBegin:
                        SetTextFormatToNormal();
                        break;
                    case FyreXml.OpCode.ParagraphBegin :
                        SetTextFormatToNormal();
                        if (Settings.UseIndents && _textFormat.Align == TextFormat.AlignType.Left)
                            AddTextToFyreXmlElements("    ");
                        break;

                    case FyreXml.OpCode.TextBlockEnd:
                    case FyreXml.OpCode.ParagraphEnd:
                        EndOfSection();
                        return _fyreXmlElements;

                    case FyreXml.OpCode.LineBreak:
                        if (_txtBlk.IsEmpty)
                        {
                            AddTextToFyreXmlElements(" ");
                            AddLineBreakToFyreXmlElements();
                        }
                        else
                        {
                            EndOfSection();
                            return _fyreXmlElements;
                        }
                        break;

                    case FyreXml.OpCode.PageBreak:
                    case FyreXml.OpCode.FullPageBreak:
                        if (_txtBlk.IsEmpty)
                        {
                            _sectionType = SectionType.PageBreak;
                        }
                        else
                        {
                            AddPageBreakToFyreXmlElements(); 
                        }
                        EndOfSection();
                        return _fyreXmlElements;

                    case FyreXml.OpCode.PromptBegin:
                        _sectionType = SectionType.Prompt;
                        break;

                    case FyreXml.OpCode.PromptEnd:
                        EndOfSection();
                        return _fyreXmlElements;

                    case FyreXml.OpCode.Text:
                        string text = element.Data;

                        if (_sectionType == SectionType.Prompt)
                        {
                            _text = text;
                            break;
                        }
                        
                        if (text == null || text.Length == 0)
                            break;

                        //if (textFormat.Format == TextFormat.Formats.Normal)
                        //{
                        //    if (_txtBlk.IsEmpty && Settings.UseIndents)
                        //        text = "    " + text;
                        //}

                        text = _txtBlk.AddText(text, _textFormat, _fyreXmlElements.MaxWidth, stackPanels);
                        _contentMode = _fyreXmlElements.ContentMode;

                        if (text.Length > 0)
                        {
                            AddTextToFyreXmlElements(text);
                            // Bør overveje om man ikke skal breake og oprette ny Section
                            // Med mindre man er inde i et image wrap???
                            EndOfSection();
                            return _fyreXmlElements;
                        }

                        break;

                    case FyreXml.OpCode.Image:
                        //RegImage( "Images/SpotArt/Crates.png", 80, 70 );
                        if (_txtBlk.IsEmpty)
                        {
                            DoImage();
                            return _fyreXmlElements;
                        }
                        break;

                    case FyreXml.OpCode.Art:
                        RegArt( element.Data );
                        if (_txtBlk.IsEmptyTrim)
                        {
                            if( _txtBlk.IsEmpty == false )
                                AddTextToFyreXmlElements(_txtBlk.Text);
                            
                            DoArt();
                            return _fyreXmlElements;
                        }
                        break;

                    case FyreXml.OpCode.TopicList:
                        FyreXmlElementTopicList eleTopicList = element as FyreXmlElementTopicList;
                        _sectionType = SectionType.TopicList;
                        _text = element.Data;
                        _data = eleTopicList;
                        EndOfSection();
                        return _fyreXmlElements;

                    case FyreXml.OpCode.WordDefOn:
                        string id = element.Data;
                        _fyreXmlElements.IsWordDefMode = true;
                        _txtBlk.IsWordDefMode = true;
                        _fyreXmlElements.WordDefID = id;
                        _txtBlk.WordDefID = id;
                        //_txtBlk.ClearRun();
                        break;
                    case FyreXml.OpCode.WordDefOff:
                        _fyreXmlElements.IsWordDefMode = false;
                        _txtBlk.IsWordDefMode = false;
                        _fyreXmlElements.WordDefID = String.Empty;
                        _txtBlk.WordDefID = String.Empty;
                        //_txtBlk.ClearRun();
                        break;
                }
            }
            EndOfSection();
            return _fyreXmlElements;
        }

        private void RegImage(string imgUrl, double width, double height)
        {
            Image img = new Image();
            img.ImgUrl = imgUrl;
            img.ImgAlign = ImageAlign.Right;
            img.Width = width;
            img.Height = height;
            _fyreXmlElements.Image = img;

        }
        private void DoImage()
        {
            Image img = _fyreXmlElements.Image;
            if (img == null)
                return;

            _fyreXmlElements.Image = null;

            double maxWidthForText = _fyreXmlElements.PageWidth - img.Width;
            _fyreXmlElements.MaxWidth = maxWidthForText;
            SectionTextBlockProxy.StackPanels sps = _txtBlk.AddImage(img, maxWidthForText);

            int count = 0;
            double totalHeight=0;
            while (_fyreXmlElements.Count > 0 && totalHeight < img.Height)
            {
                Section section = new Section();
                _fyreXmlElements = section.Process(_fyreXmlElements, sps);

                if (section.IsEmpty == false)
                {
                    section.Sequence = count++;
                    totalHeight += section.Height;
                }
            }

            if (totalHeight < img.Height)
                totalHeight = img.Height;

            _fyreXmlElements.MaxWidth = _fyreXmlElements.PageWidth;

            EndOfSection();
            // Override height
            _height = totalHeight;
        }

        private void RegArt(string artID )
        {
            ArtRegister areg = new ArtRegister();
            areg.ArtID = artID;
            double[] size = Controls.Art.WidthAndHeight(artID);
            areg.Width = size[0];
            areg.Height = size[1];

            _fyreXmlElements.ArtRegister = areg;

        }
        private void DoArt()
        {
            ArtRegister areg = _fyreXmlElements.ArtRegister;
            if (areg == null)
                return;

            _fyreXmlElements.ArtRegister = null;

            double maxWidthForText = _fyreXmlElements.PageWidth - areg.Width;
            _fyreXmlElements.MaxWidth = maxWidthForText;
            SectionTextBlockProxy.StackPanels sps = _txtBlk.AddArt(areg, maxWidthForText);

            if (sps.StackPanelScroll == null)
            {
                _fyreXmlElements.MaxWidth = _fyreXmlElements.PageWidth;
                _sectionType = SectionType.ArtOnly;
                EndOfSection();
                // Override height
                _height = areg.Height;
                return;
            }

            int count = 0;
            double totalHeight = 0;
            while (_fyreXmlElements.Count > 0 && totalHeight < areg.Height)
            {
                Section section = new Section();
                _fyreXmlElements = section.Process(_fyreXmlElements, sps);

                if (section.IsEmpty == false)
                {
                    section.Sequence = count++;
                    totalHeight += section.Height;
                }
            }

            if (totalHeight < areg.Height)
                totalHeight = areg.Height;

            _fyreXmlElements.MaxWidth = _fyreXmlElements.PageWidth;

            EndOfSection();
            // Override height
            _height = totalHeight;
        }



        private void EndOfSection()
        {
            // Calculate Final Height
            _height = _txtBlk.Height;
        }

        private void SetTextFormatToHeadline()
        {
            _textFormat.Format = TextFormat.Formats.Headline;
            _textFormat.IsBold = false;
            _textFormat.IsItalic = false;
            _textFormat.Align = Settings.CenterHeadline ? TextFormat.AlignType.Center : TextFormat.AlignType.Left;
        }

        private void SetTextFormatToNormal()
        {
            _textFormat.Format = TextFormat.Formats.Normal;
            _textFormat.IsBold = false;
            _textFormat.IsItalic = false;
            _textFormat.Align = TextFormat.AlignType.Left;
        }

        private void AddTextToFyreXmlElements(string text)
        {
            _fyreXmlElements.Insert(0, new FyreXmlElement(FyreXml.OpCode.Text, text));
        }
        private void AddLineBreakToFyreXmlElements()
        {
            _fyreXmlElements.Insert(0, new FyreXmlElement(FyreXml.OpCode.LineBreak));
        }
        private void AddPageBreakToFyreXmlElements()
        {
            _fyreXmlElements.Insert(0, new FyreXmlElement(FyreXml.OpCode.PageBreak));
        }

        public void ShowWordDefs()
        {
            _txtBlk.ShowWordDefs();
        }

        public void HideWordDefs()
        {
            _txtBlk.HideWordDefs();
        }
    }
}
