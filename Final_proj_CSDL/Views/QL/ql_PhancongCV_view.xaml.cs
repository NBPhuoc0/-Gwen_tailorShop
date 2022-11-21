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
    /// Interaction logic for ql_PhancongCV_view.xaml
    /// </summary>
    public partial class ql_PhancongCV_view : Window
    {
        public PhanCongDAO pcDao = new PhanCongDAO();
        List<TaiKhoan_Models> _dsQL_id;
        List<TaiKhoan_Models> _dsNV_id;
        PhanCong_Models pc_md;


        public List<TaiKhoan_Models> DsQL_id { get => _dsQL_id; set => _dsQL_id = value; }
        public List<TaiKhoan_Models> DsNV_id { get => _dsNV_id; set => _dsNV_id = value; }
        public PhanCong_Models Pc_md { get => pc_md; set => pc_md = value; }

        public ql_PhancongCV_view(int HD_id)
        {
            Pc_md = new PhanCong_Models();
            Pc_md.HD_id = HD_id;
            Pc_md.Ngaytao = DateTime.Now;
            DsNV_id = pcDao.vw_load_TK_NV();
            DsQL_id = pcDao.vw_load_TK_QL();
            DataContext = this;
            InitializeComponent();
        }
        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void save_btn(object sender, RoutedEventArgs e)
        {
            pc_md.Mota = tb_mota.Text;
            pcDao.sp_phancongcongviec(pc_md);
            this.Close();
        }
    }
}
