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
    /// Interaction logic for ql_CTHD_view.xaml
    /// </summary>
    public partial class ql_CTHD_view : Window
    {
        List<bang_CTHD_Models> _dsCTHD;
        ChiTietHD_DAO ctDAO = new ChiTietHD_DAO();
        int hd_xem;
        public bang_CTHD_Models selectedCTHD;

        public List<bang_CTHD_Models> DsCTHD { get => _dsCTHD; set => _dsCTHD = value; }

        public ql_CTHD_view(int hd_id)
        {
            hd_xem = hd_id;
            load_CTHD(hd_id);
            DataContext = this;
            InitializeComponent();
            dataG.ItemsSource = DsCTHD;
            
        }

        private void load_CTHD(int hd_id)
        {
            DsCTHD = ctDAO.fn_vw_cthd(hd_id);

        }

        private void exit_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void them_click(object sender, RoutedEventArgs e)
        {
            CTHD_Models cthd = new CTHD_Models();
            cthd.HD_id = hd_xem;
            cthd.SP_id = int.Parse(them_id.Text);
            cthd.Soluong = int.Parse(them_soluong.Text);
            ctDAO.sp_themcthd(cthd);
            load_CTHD(hd_xem);
            dataG.ItemsSource = DsCTHD;

        }

        private void xoa_cthd(object sender, RoutedEventArgs e)
        {
            ctDAO.sp_xoacthd(selectedCTHD.CTHD_id);
            load_CTHD(hd_xem);
            dataG.ItemsSource = DsCTHD;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCTHD = ((sender as DataGrid).SelectedItem as bang_CTHD_Models);
        }
    }
}
