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
using System.Collections.Generic;

namespace Textfyre.UI.DocSystem
{
    public class SectionTextBlock
    {

        public SectionTextBlock()
        {
            _txtBlk = new TextBlock();

            WordDefs wds = new WordDefs();
            _txtBlk.Tag = wds;
            //_curLineHeight = 0;

            _txtBlk.MouseMove += new MouseEventHandler(_curTB_MouseMove);
            _txtBlk.MouseLeave += new MouseEventHandler(_curTB_MouseLeave);
            _txtBlk.MouseLeftButtonUp += new MouseButtonEventHandler(_curTB_MouseLeftButtonUp);
            _txtBlk.MouseLeftButtonDown += new MouseButtonEventHandler(_txtBlk_MouseLeftButtonDown);
        }

        private Grid _hostGrid = new Grid();
        private TextBlock _txtBlk;
        private Run _run = new Run();
        private TextFormat _currentTextFormat = new TextFormat();
        private double _maxWidth;

        public Grid HostGrid
        {
            get
            {
                return _hostGrid;
            }
        }

        private StackPanel _stackPanel;
        public StackPanel StackPanel
        {
            set
            {
                _stackPanel = value;
            }

            get
            {
                return _stackPanel;
            }
        }

        private bool _centerDone = false;
        public void Center()
        {
            if (_centerDone)
                return;

            _centerDone = true;

            _txtBlk.HorizontalAlignment = HorizontalAlignment.Center;
            _txtBlk.Margin = new Thickness(0, 0, Settings.HeadlineOffset, 0);
            
        }

        public StackPanel AddImage(Image img, double maxWidth)
        {
            _stackPanel = img.AddImageContainer(_hostGrid, maxWidth);
            return _stackPanel;
        }

        public StackPanel AddArt(ArtRegister artRegister, double maxWidth)
        {
            _stackPanel = artRegister.AddArtContainer(_hostGrid, maxWidth);
            return _stackPanel;
        }

        public string AddText(string text, TextFormat tf, double maxWidth, StackPanel sp )
        {
            _stackPanel = sp;

            if (_stackPanel == null && _hostGrid.Children.Count == 0)
            {
                _hostGrid.Children.Add(_txtBlk);
                
                // Debug: Show section border.
                //Rectangle rt = new Rectangle();
                //rt.Stroke = new SolidColorBrush( Colors.Gray);
                //rt.StrokeThickness = 1;
                //_hostGrid.Children.Add(rt);
            }
            
            _maxWidth = maxWidth;

            if (_stackPanel != null)
            {
                if( _stackPanel.Children.Contains( _txtBlk ) == false)
                    _stackPanel.Children.Add(_txtBlk);

                //_txtBlk = new TextBlock();
                _currentTextFormat = tf.Copy();
                CreateFormat();
            }
            else if (!tf.IsEqual(_currentTextFormat))
            {
                _currentTextFormat = tf.Copy();
                CreateFormat();
            }

            int pointer = 0;
            bool cont = true;
            string word = String.Empty;
            while (cont)
            {                
                int nextSpace = text.IndexOf(' ', pointer);

                if (nextSpace > -1)
                {
                    // More words.
                    word = text.Substring(pointer, nextSpace - pointer + 1);

                    if (AddWord(word) == false)
                    {
                        string newText = text.Substring(pointer);
                        return newText;
                    }

                    pointer += word.Length;
                }
                else
                {   // One word.
                    word = text.Substring(pointer);
                    if (AddWord(word) == false)
                    {
                        return word;
                    }
                    cont = false;
                }

                DoWordDef(word);

                if (pointer >= text.Length)
                    cont = false;
            }

            return string.Empty;
        }

        private Point _lastWordMeassure = new Point(0,0);
        private bool AddWord(string word)
        {
            double leftpoint = _txtBlk.ActualWidth;

            string runText = _run.Text;
            _run.Text += word;

            if( _txtBlk.ActualWidth > _maxWidth )
            {
                _run.Text = runText;
                return false;
            }

            _lastWordMeassure = new Point(_txtBlk.ActualWidth - leftpoint, _txtBlk.ActualHeight);

            return true;
        }

        private void CreateFormat()
        {
            if (_currentTextFormat.Format == TextFormat.Formats.Normal)
                Current.Font.ApplyFont(Textfyre.UI.Current.Font.FontType.Main, _txtBlk);
            else if( _currentTextFormat.Format == TextFormat.Formats.Headline )
                Current.Font.ApplyFont(Textfyre.UI.Current.Font.FontType.Headline, _txtBlk);

            if (IsWordDefMode)
            {
                if (_run == null)
                    _run = new Run();
                WordDefRuns.Add(_run);
            }

            _run = new Run();

            if (_currentTextFormat.IsBold)
                _run.FontWeight = FontWeights.Bold;

            if (_currentTextFormat.IsItalic)
                _run.FontStyle = FontStyles.Italic;

            if (_currentTextFormat.Align == TextFormat.AlignType.Center)
                Center();

            _txtBlk.Inlines.Add(_run);
        }

        public bool IsEmpty
        {
            get
            {
                if (_stackPanel != null)
                    return false;
                
                return _txtBlk.Text.Length == 0;
            }
        }

        public bool IsEmptyTrim
        {
            get
            {
                if (_stackPanel != null)
                    return false;

                return _txtBlk.Text.Trim().Length == 0;
            }
        }


        public string Text
        {
            get
            {
                return _txtBlk.Text;
            }
        }

        public double Height
        {
            get
            {
                return _txtBlk.ActualHeight;
            }
        }

        #region :: WordDef Handle ::
        public class WordDefs : List<WordDef>
        {
        }

        public List<Run> WordDefRuns = new List<Run>();

        private bool _isWordDefMode = false;
        public bool IsWordDefMode
        {
            get
            {
                return _isWordDefMode;
            }
            set
            {
                CreateFormat();
                _isWordDefMode = value;
            }
        }

        private string _wordDefID = String.Empty;
        public string WordDefID
        {
            get
            {
                return _wordDefID;
            }
            set
            {
                _wordDefID = value;
            }
        }

        private DocSystem.BrushStorage _brushes;
        private bool _isShowingWordDefs = false;
        public void ShowWordDefs()
        {
            if (_isShowingWordDefs)
                return;

            _isShowingWordDefs = true;

            if (_brushes == null)
                _brushes = new BrushStorage();
            _brushes.Init();

            Color wordDefColor = new Color();
            wordDefColor.A = 255;
            wordDefColor.R = 200;
            wordDefColor.G = 80;
            wordDefColor.B = 55;
            foreach (Run run in WordDefRuns)
            {               
                _brushes.Add(run.Foreground);
                run.Foreground = new SolidColorBrush(wordDefColor);
            }
        }

        public void HideWordDefs()
        {
            if (_isShowingWordDefs == false)
                return;

            _isShowingWordDefs = false;

            
            Color wordDefColor = new Color();
            wordDefColor.A = 255;
            wordDefColor.R = 0;
            wordDefColor.G = 0;
            wordDefColor.B = 0;
            foreach (Run run in WordDefRuns)
            {
                run.Foreground = _brushes.GetBrush();
                //run.Foreground = new SolidColorBrush(wordDefColor);
            }
            _brushes.Clear();
        }

        void _curTB_MouseLeave(object sender, MouseEventArgs e)
        {
            Current.Game.TextfyreBook.WordDefBubble.Hide();
            TextBlock tb = sender as TextBlock;
            tb.Cursor = null;
        }

        private string _activeWord = String.Empty;
        void _curTB_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            WordDefs wds = tb.Tag as WordDefs;

            //Current.Game.TextfyreBook.WordDefBubble.Hide();
            Point pos = e.GetPosition(tb);
            string activeWord = String.Empty;
            foreach (WordDef wd in wds)
            {
                if (pos.X >= wd.PointBegin.X && pos.Y >= wd.PointBegin.Y &&
                    pos.X <= wd.PointEnd.X && pos.Y <= wd.PointEnd.Y)
                {
                    tb.Cursor = Cursors.Hand;
                    activeWord = wd.ID;
                    break;
                }
                else
                {
                    tb.Cursor = null;
                }
            }
            _activeWord = activeWord;
        }

        void _txtBlk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_activeWord.Length > 0)
            {
                Point pos = e.GetPosition(Current.Game.TextfyreBook);
                Current.Game.TextfyreBook.WordDefBubble.Show(_activeWord, pos.X, pos.Y);
            }
        }


        private void _curTB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Current.Game.TextfyreBook.WordDefBubble.Hide();

        }

        public void DoWordDef(string word)
        {
            if (word.Length > 0 && word != " ")
            {
                if (IsWordDefMode)
                {
                    Point wordMeassure = _lastWordMeassure;
                    double actHeight = _txtBlk.ActualHeight;
                    double actWidth = _txtBlk.ActualWidth;

                    WordDef wd = new WordDef();
                    wd.ID = WordDefID;
                    wd.Run = _run;
                    wd.PointBegin = new Point(System.Math.Max(0, (actWidth - wordMeassure.X)), System.Math.Max(0d, actHeight - wordMeassure.Y));
                    wd.PointEnd = new Point(actWidth, actHeight);
                    (_txtBlk.Tag as WordDefs).Add(wd);
                }
            }
        }


        #endregion :: WordDef Handle ::
    }
}
