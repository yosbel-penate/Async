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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext=new MainViewModel();
            InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await MyStaticService.AddUsingEntity(new Blog { BlogId = 1, Name = "Nona", Posts = new List<Post> { new Post { Title = "pota", Content = "miky"}}});
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win= new AsyncComboboxWindow();
            win.Show();
        }
    }
}
