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

namespace Final_proj_CSDL.Views.QL
{
    /// <summary>
    /// Interaction logic for ql_nhansu_view.xaml
    /// </summary>
    public partial class ql_nhansu_view : UserControl
    {
        public static ql_nhansu_view nhansu;
        public ql_nhansu_view()
        {
            InitializeComponent();
            nhansu = this;         
        }
    }
}
