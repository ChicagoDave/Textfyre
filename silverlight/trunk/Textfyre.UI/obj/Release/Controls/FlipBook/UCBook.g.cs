#pragma checksum "D:\Subversion\TextFyre\TFDev\silverlight\trunk\Textfyre.UI\Controls\FlipBook\UCBook.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "47B72A807E7ACBB747C0DBBD18608987"
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
using Textfyre.UI.Controls.FlipBook;


namespace Textfyre.UI.Controls.FlipBook {
    
    
    public partial class UCBook : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Textfyre.UI.Controls.FlipBook.UCPage leftPage;
        
        internal Textfyre.UI.Controls.FlipBook.UCPage rightPage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Textfyre.UI;component/Controls/FlipBook/UCBook.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.leftPage = ((Textfyre.UI.Controls.FlipBook.UCPage)(this.FindName("leftPage")));
            this.rightPage = ((Textfyre.UI.Controls.FlipBook.UCPage)(this.FindName("rightPage")));
        }
    }
}
