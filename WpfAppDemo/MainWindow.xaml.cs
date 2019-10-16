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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDemo.ViewModels;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainContent.Content = new IndexViewModel();
        }

        private void ButtonIndex_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new IndexViewModel();
        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new ProductViewModel();
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new OrderViewModel();
        }
    }
}
