﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kneebruh
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void Manual_Price_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Tekstfelt = 6;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SendVareNR(Manual_Price.Text);
        }
        void SendVareNR(string Varenr)
        {
            MainWindow Main = new MainWindow();
            Main.VareNR.Text = Varenr;
        }
    }
}
