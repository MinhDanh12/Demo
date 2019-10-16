using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfAppDemo.Views;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainHomeWindow.xaml
    /// </summary>
    public partial class MainHomeWindow : Window
    {
        public MainHomeWindow()
        {
            InitializeComponent();
            
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            //var Login = new Login();
            //this.Close();
            //Login.Show();
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    mainContent.Content = new IndexView();                    
                    break;
                case 1:
                    mainContent.Content = new DrinkView();
                    break;
                case 2:
                    mainContent.Content = new ProductView();
                    break;
                case 3:
                    mainContent.Content = new OrderView();
                    break;
                default:
                    break;

            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void BtnFb_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
