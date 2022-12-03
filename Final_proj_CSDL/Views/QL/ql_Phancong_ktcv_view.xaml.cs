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
    /// Interaction logic for ql_Phancong_ktcv_view.xaml
    /// </summary>
    public partial class ql_Phancong_ktcv_view : Window
    {
        private bool? _kq;
        private string _loinhan;
        public bool? Kq { get => _kq; set => _kq = value; }
        public string Loinhan { get => _loinhan; set => _loinhan = value; }
        public static ql_Phancong_ktcv_view ql_ktcv;

        public ql_Phancong_ktcv_view()
        {
            ql_ktcv = this;
            InitializeComponent();
        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_btn(object sender, RoutedEventArgs e)
        {
            Kq = kq_cb.IsChecked;
            Loinhan = loinhan_tb.Text;
            this.Close();
        }
    }
}
