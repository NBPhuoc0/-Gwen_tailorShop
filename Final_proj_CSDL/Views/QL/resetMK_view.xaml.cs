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

namespace Final_proj_CSDL.Views.QL
{
    /// <summary>
    /// Interaction logic for resetMK_view.xaml
    /// </summary>
    public partial class resetMK_view : Window
    {
        public bool check = false;
        public string pw_temp = "";
        public resetMK_view()
        {
            InitializeComponent();
        }

        private void checkmk2(object sender, RoutedEventArgs e)
        {
            if (mk1.Password != mk2.Password )
            {
                lbCanhbao.Visibility = Visibility.Visible;
            }
            else
            {
                lbCanhbao.Visibility = Visibility.Collapsed;
            }
        }

        private void xacnhan(object sender, RoutedEventArgs e)
        {
            ThongBao_W tb = new ThongBao_W("Xác nhận thay đổi mật khẩu ?", 'x');
            tb.ShowDialog();
            if (tb.yes)
            {
                pw_temp = mk1.Password;
                check = true;
                this.Close();
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            check = false;
            this.Close();
        }
    }
}
