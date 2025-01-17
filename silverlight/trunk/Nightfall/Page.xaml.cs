﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Nightfall
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Textfyre.UI.Current.Application.GameAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Textfyre.UI.Current.Application.AppResources = App.Current.Resources;

            StoryPage.LoadStory(GameFiles.GameFile.Nightfall_r12, "Nightfall_r12", new StoryHandle());
        }
    }
}
