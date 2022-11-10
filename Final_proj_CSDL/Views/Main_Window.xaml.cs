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

namespace Final_proj_CSDL.Views
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        public static Main_Window trangchu;
        public Main_Window()
        {
            InitializeComponent();
            trangchu = this;
        }
        public void phanquyen(string quyen)
        {
            if (quyen == "QL")
            {
                trangchu.SideBarQL.Visibility = Visibility.Visible;
            }
            else trangchu.SideBarNV.Visibility = Visibility.Visible;
        }

        private void closeW_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maxW_btn(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }

        private void miniW_btn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Main_W_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
