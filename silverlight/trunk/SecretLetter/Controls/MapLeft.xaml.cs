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

namespace SecretLetter.Controls
{
    public partial class MapLeft : UserControl
    {
        public MapLeft()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MapLeft_Loaded);
        }

        void MapLeft_Loaded(object sender, RoutedEventArgs e)
        {
            mapArt.ID = "Map1Left";
        }

        //private void RectCtrl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    RectText.Text = "Clicked!";
        //}
    }
}
