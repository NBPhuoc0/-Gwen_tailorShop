using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class DonHang_VM : baseVM
    {
        HoaDonDAO hdDao = new HoaDonDAO();
        PhanCongDAO pcDao = new PhanCongDAO();
        List<HoaDon_Models> _danhsachHoaDon;
        HoaDon_Models _selectedHoaDon;
        List<SanPham_Models> _DanhSachSanPham;
        List<PhanCong_Models> _DanhsachPhanCong;
        PhanCong_Models _selectedPhanCong;
        private string _nguoitao;

        public ICommand Load_dsHD_Command { get; set; }
        public ICommand Load_dsHD_dapc_Command { get; set; }
        public ICommand Load_dsHD_chuapc_Command { get; set; }
        public ICommand Load_dsHD_chogiao_Command { get; set; }
        public ICommand Load_dsHD_dagiao_Command { get; set; }
        public ICommand Load_taodon_Command { get; set; }
        public ICommand Load_dsPC_theoHD_Command { get; set; }
        public ICommand Tao_don_Command { get; set; }
        public ICommand them_hd_Command { get; set; }
        public ICommand them_cthd_Command { get; set; }
        public ICommand Xoa_HD_Command { get; set; }
        public ICommand PhanCongCV_Command { get; set; }
        public ICommand Xoa_PC_Command { get; set; }
        public ICommand XN_giao_Command { get; set; }
        public ICommand Phancong_ktcv_commnad { get; set; }




        public List<HoaDon_Models> DanhsachHoaDon { get => _danhsachHoaDon; set { _danhsachHoaDon = value; OnPropertyChanged("DanhsachHoaDon"); } }
        public HoaDon_Models SelectedHoaDon { get => _selectedHoaDon; 
            set 
            { 
                _selectedHoaDon = value; 
                OnPropertyChanged("SelectedHoaDon");
                Load_dsPC_theoHD_Command.Execute(SelectedHoaDon);
            } }
        public List<SanPham_Models> DanhSachSanPham { get => _DanhSachSanPham; set => _DanhSachSanPham = value; }
        public string Nguoitao { get => _nguoitao; set => _nguoitao = value; }
        public List<PhanCong_Models> DanhsachPhanCong { get => _DanhsachPhanCong; set { _DanhsachPhanCong = value; OnPropertyChanged("DanhsachPhanCong"); } }
        public PhanCong_Models SelectedPhanCong { get => _selectedPhanCong; set { _selectedPhanCong = value; OnPropertyChanged("SelectedPhanCong"); } }

        public DonHang_VM()
        {
            Nguoitao = data_temp.tk_md.Hoten;
            Load_dsHD_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hoadon_tt();
            });
            Load_dsHD_dapc_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hd_dapc();
            });
            Load_dsHD_chuapc_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hd_chuapc();
            });
            Load_dsHD_chogiao_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hd_chogiao();
            });
            Load_dsHD_dagiao_Command = new RelayCommand<object>(p =>
            {
                DanhsachHoaDon = hdDao.vw_load_hd_dagiao();
            });
            Load_dsPC_theoHD_Command = new RelayCommand<HoaDon_Models>(p =>
            {
                DanhsachPhanCong = pcDao.fn_pcBy_HD_id(SelectedHoaDon.Hd_id);
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
            them_hd_Command = new RelayCommand<Window>(p =>
            {
                ThongBao_W tb = new ThongBao_W("bạn có thật sự muốn thêm đơn hàng này ?", 'x');
                tb.ShowDialog();
                if (tb.yes)
                {
                    SelectedHoaDon.Ngaytao = DateTime.Now;
                    SelectedHoaDon.Ql_id = data_temp.tk_md.TK_id;
                    hdDao.sp_themhd(SelectedHoaDon);
                    p.Close();
                    ql_CTHD_view cthd = new ql_CTHD_view(SelectedHoaDon.Hd_id);
                    cthd.ShowDialog();
                }
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

            PhanCongCV_Command = new RelayCommand<object>(p =>
            {
                if (SelectedHoaDon!=null)
                {
                    ql_PhancongCV_view pc = new ql_PhancongCV_view(SelectedHoaDon.Hd_id);
                    pc.ShowDialog();
                }
            });
            Xoa_PC_Command = new RelayCommand<object>(p =>
            {
                if (SelectedPhanCong != null)
                {
                    pcDao.sp_xoaphancong(SelectedPhanCong.PC_id);
                }
            });
            XN_giao_Command = new RelayCommand<object>(p =>
            {
                if (SelectedHoaDon != null)
                {
                    ThongBao_W tb = new ThongBao_W("Xác nhận đã giao đơn hàng ?", 'x');
                    tb.ShowDialog();
                    if (tb.yes)
                    {
                        hdDao.sp_XN_giao_hd(SelectedHoaDon.Hd_id);
                    }
                }
            });
            Phancong_ktcv_commnad = new RelayCommand<object>(p =>
            {
                ql_Phancong_ktcv_view ktcv = new ql_Phancong_ktcv_view();
                ktcv.ShowDialog();
                if (ktcv.Kq != null && ktcv.Loinhan != null)
                {
                    XacNhanPC_Models xn = new XacNhanPC_Models();
                    xn.QL_id = data_temp.tk_md.TK_id;
                    xn.PC_id = SelectedPhanCong.PC_id;
                    xn.Kq = (bool)ktcv.Kq;
                    xn.Loinhan = ktcv.Loinhan;
                    xn.Ngaytao = DateTime.Now;
                    pcDao.sp_XacNhanPC_kiemtra(xn);
                }
            });
            
        }
    }
}
