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

namespace Final_proj_CSDL.Views.NV
{
    /// <summary>
    /// Interaction logic for phancong_nv_view.xaml
    /// </summary>
    public partial class phancong_nv_view : UserControl
    {
        public static phancong_nv_view phancongNV;
        public phancong_nv_view()
        {
            InitializeComponent();
            phancongNV = this;
        }
    }
}
