using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
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
    /// Interaction logic for ql_banXNCV_view.xaml
    /// </summary>
    public partial class ql_banXNCV_view : Window
    {
        public ql_banXNCV_view(int pc_id)
        {
            PhanCongDAO pcDao = new PhanCongDAO();
            List<XacNhanPC_Models> dspc;
            InitializeComponent();
            dspc = pcDao.fn_vw_baocao_pc(pc_id);
            dataG.ItemsSource = dspc; 
        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
