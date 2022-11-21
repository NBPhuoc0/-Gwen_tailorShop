using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<CTHD_Models> _dsCTHD;
        List<SanPham_Models> _dsSanPham;
        ChiTietHD_DAO ctDAO = new ChiTietHD_DAO();
        CTHD_Models cthd;
        CTHD_Models selectedCTHD;
        SanPham_Models selectedSanPham;

        public List<CTHD_Models> DsCTHD { get => _dsCTHD; set => _dsCTHD = value; }
        public CTHD_Models Cthd { get => cthd; set => cthd = value; }
        public List<SanPham_Models> DsSanPham { get => _dsSanPham; set => _dsSanPham = value; }
        public CTHD_Models SelectedCTHD { get => selectedCTHD; set => selectedCTHD = value; }
        public SanPham_Models SelectedSanPham { get => selectedSanPham; set => selectedSanPham = value; }

        public ql_CTHD_view(int hd_id)
        {
            DsSanPham = ctDAO.vw_load_sanpham();
            Cthd = new CTHD_Models();
            Cthd.HD_id = hd_id;
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
            Cthd.SP_id = selectedSanPham.SP_id;
            Cthd.Soluong = int.Parse(them_soluong.Text);
            ctDAO.sp_themcthd(Cthd);
            load_CTHD(Cthd.HD_id);
            dataG.ItemsSource = DsCTHD;
        }

        private void xoa_cthd(object sender, RoutedEventArgs e)
        {
            ctDAO.sp_xoacthd(SelectedCTHD.CTHD_id);
            load_CTHD(Cthd.HD_id);
            dataG.ItemsSource = DsCTHD;
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCTHD = ((sender as DataGrid).SelectedItem as CTHD_Models);
        }

        private void Select_SP(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedSanPham != null)
            {
                BitmapImage bim = new BitmapImage();
                MemoryStream ms = new MemoryStream(SelectedSanPham.Anh);
                bim.BeginInit();
                bim.StreamSource = ms;
                bim.EndInit();
                anhSP.Source = bim;
            }
            else
            {
                anhSP.Source = new BitmapImage(new Uri("pack://application:,,,/UIresources/default.jpg"));
            }
        }
    }
}
