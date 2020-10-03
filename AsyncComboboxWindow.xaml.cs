using Async.ViewModel;
using System;
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

namespace Async
{
    /// <summary>
    /// Interaction logic for AsyncComboboxWindow.xaml
    /// </summary>
    public partial class AsyncComboboxWindow : Window
    {
        
        public AsyncComboboxWindow()
        {
            DataContext = new ComboboxAsyncDataSource();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var my = (ComboboxAsyncDataSource)DataContext;
               label.Content = my.TypeGender.Value;

            
        }
    }
}
