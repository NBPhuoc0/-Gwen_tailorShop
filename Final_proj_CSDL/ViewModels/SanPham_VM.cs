using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.QL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Final_proj_CSDL.ViewModels
{
    internal class SanPham_VM: baseVM
    {
        List<SanPham_Models> _danhsachSanPham;
        SanPham_Models _SelectedSanPham;
        SanPhamDAO spdao = new SanPhamDAO();

        public ICommand load_sp_Command { get; set; }
        public ICommand load_anh_Command { get; set; }
        public ICommand Them_sp_Command { get; set; }
        public ICommand xoa_sp_Command { get; set; }
        public ICommand sua_sp_Command { get; set; }


        public List<SanPham_Models> DanhsachSanPham { get => _danhsachSanPham; set { _danhsachSanPham = value; OnPropertyChanged("DanhsachSanPham"); } }
        public SanPham_Models SelectedSanPham { get => _SelectedSanPham; set => _SelectedSanPham = value; }

        public SanPham_VM()
        {
            load_sp_Command = new RelayCommand<object>(p =>
            {
                DanhsachSanPham = spdao.vw_load_sanpham();
            });
            load_anh_Command = new RelayCommand<Image>(p =>
            {
                if (SelectedSanPham != null)
                {
                    BitmapImage bim = new BitmapImage();
                    MemoryStream ms = new MemoryStream(SelectedSanPham.Anh);
                    bim.BeginInit();
                    bim.StreamSource = ms;
                    bim.EndInit();
                    p.Source = bim;
                }
                else
                {
                    p.Source= new BitmapImage(new Uri("pack://application:,,,/UIresources/default.jpg"));
                }
            });
            Them_sp_Command = new RelayCommand<object>(p =>
            {
                ql_sp_themsp_view themsp = new ql_sp_themsp_view();
                themsp.ShowDialog();
                if (themsp.luu)
                {
                    spdao.sp_themsp(themsp.sp);
                    load_sp_Command.Execute(null);
                }
            });
            xoa_sp_Command = new RelayCommand<object>(p =>
            {
                spdao.sp_xoasp(SelectedSanPham.SP_id);
                load_sp_Command.Execute(null);
            });
            sua_sp_Command = new RelayCommand<object>(p =>
            {
                if (SelectedSanPham == null)
                {
                    ThongBao_W tb = new ThongBao_W("Xin hãy chọn sản phẩm cần sửa", 'l');
                    tb.ShowDialog();
                }
                else
                {
                    ql_sp_themsp_view themsp = new ql_sp_themsp_view(SelectedSanPham);
                    themsp.ShowDialog();
                    if (themsp.luu)
                    {
                        spdao.sp_suasp(themsp.sp);
                        load_sp_Command.Execute(null);
                    }
                }
            });
        }
    }
}
