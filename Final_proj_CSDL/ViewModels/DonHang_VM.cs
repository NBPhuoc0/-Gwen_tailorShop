using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class DonHang_VM : baseVM
    {
        HoaDonDAO hdDao = new HoaDonDAO();
        List<HoaDon_Models> _danhsachHoaDon;
        HoaDon_Models _selectedHoaDon;
        List<SanPham_Models> _DanhSachSanPham;
        private string _nguoitao;

        public ICommand Load_dsHD_Command { get; set; }
        public ICommand Load_taodon_Command { get; set; }
        public ICommand Tao_don_Command { get; set; }
        public ICommand them_hd_Command { get; set; }
        public ICommand them_cthd_Command { get; set; }
        public ICommand Xoa_HD_Command { get; set; }



        public List<HoaDon_Models> DanhsachHoaDon { get => _danhsachHoaDon; set { _danhsachHoaDon = value; OnPropertyChanged("DanhsachHoaDon"); } }
        public HoaDon_Models SelectedHoaDon { get => _selectedHoaDon; set { _selectedHoaDon = value; OnPropertyChanged("SelectedHoaDon"); } }
        public List<SanPham_Models> DanhSachSanPham { get => _DanhSachSanPham; set => _DanhSachSanPham = value; }
        public string Nguoitao { get => _nguoitao; set => _nguoitao = value; }

        public DonHang_VM()
        {
            Nguoitao = data_temp.tk_md.Hoten;
            Load_dsHD_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hoadon_tt();
            });
            Load_taodon_Command = new RelayCommand<object>(o =>
            {
                SelectedHoaDon = new HoaDon_Models();
                DanhSachSanPham = hdDao.vw_load_sanpham();
            });
            Tao_don_Command = new RelayCommand<object>(p =>
            {
                ql_taodon_view td = new ql_taodon_view();
                td.ShowDialog();
                Load_dsHD_Command.Execute(null);
            });
            them_hd_Command = new RelayCommand<object>(p =>
            {
                SelectedHoaDon.Ngaytao = DateTime.Now;
                SelectedHoaDon.Ql_id = data_temp.tk_md.TK_id;
                hdDao.sp_themhd(SelectedHoaDon);
            });
            them_cthd_Command = new RelayCommand<object>(p =>
            {
                if (SelectedHoaDon!=null)
                {
                    ql_CTHD_view cthd = new ql_CTHD_view(SelectedHoaDon.Hd_id);
                    cthd.ShowDialog();
                }
            });
            Xoa_HD_Command = new RelayCommand<object>(p =>
            {
                if (SelectedHoaDon != null)
                {
                    hdDao.sp_xoahd(SelectedHoaDon.Hd_id);
                    Load_dsHD_Command.Execute(null);
                }
            });
            
        }
    }
}
