#pragma checksum "D:\Subversion\TextFyre\TFDev\silverlight\trunk\Textfyre.UI\Controls\TextfyreBookPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "690FA4E13BC22FBCF1FF6AACA704213C"
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
    
    
    public partial class TextfyreBookPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Textfyre.UI.Controls.Art BookPage1;
        
        internal Textfyre.UI.Controls.Art BookPage2;
        
        internal System.Windows.Controls.TextBlock LocationChannel;
        
        internal System.Windows.Controls.TextBlock TimeChannel;
        
        internal System.Windows.Controls.ScrollViewer PageScrollViewer;
        
        internal Textfyre.UI.Controls.More ctrlMore;
        
        internal Textfyre.UI.Controls.FlipButton ctrlFlipButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Textfyre.UI;component/Controls/TextfyreBookPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.BookPage1 = ((Textfyre.UI.Controls.Art)(this.FindName("BookPage1")));
            this.BookPage2 = ((Textfyre.UI.Controls.Art)(this.FindName("BookPage2")));
            this.LocationChannel = ((System.Windows.Controls.TextBlock)(this.FindName("LocationChannel")));
            this.TimeChannel = ((System.Windows.Controls.TextBlock)(this.FindName("TimeChannel")));
            this.PageScrollViewer = ((System.Windows.Controls.ScrollViewer)(this.FindName("PageScrollViewer")));
            this.ctrlMore = ((Textfyre.UI.Controls.More)(this.FindName("ctrlMore")));
            this.ctrlFlipButton = ((Textfyre.UI.Controls.FlipButton)(this.FindName("ctrlFlipButton")));
        }
    }
}
