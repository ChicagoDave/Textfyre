#pragma checksum "D:\Subversion\TextFyre\TFDev\silverlight\trunk\Textfyre.UI\Controls\BookCover.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EB08E5BB04A509C1A14E9D4D4EA2B547"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Textfyre.UI.Controls;


namespace Textfyre.UI.Controls {
    
    
    public partial class BookCover : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard FlipCoverStoryboard;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image PageSide;
        
        internal Textfyre.UI.Controls.Art BookCoverImage;
        
        internal System.Windows.Shapes.Rectangle HideBook;
        
        internal System.Windows.Controls.TextBlock LoadingText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Textfyre.UI;component/Controls/BookCover.xaml", System.UriKind.Relative));
            this.FlipCoverStoryboard = ((System.Windows.Media.Animation.Storyboard)(this.FindName("FlipCoverStoryboard")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PageSide = ((System.Windows.Controls.Image)(this.FindName("PageSide")));
            this.BookCoverImage = ((Textfyre.UI.Controls.Art)(this.FindName("BookCoverImage")));
            this.HideBook = ((System.Windows.Shapes.Rectangle)(this.FindName("HideBook")));
            this.LoadingText = ((System.Windows.Controls.TextBlock)(this.FindName("LoadingText")));
        }
    }
}
