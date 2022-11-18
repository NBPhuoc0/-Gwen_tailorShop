using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class TaiKhoan_VM : baseVM
    {
        List<TaiKhoan_Models> _DanhSachTaiKhoan;
        TaiKhoan_Models _SelectedTaiKhoan;
        TaiKhoanDAO tkdao = new TaiKhoanDAO();
        private Boolean _QL;
        private Boolean _NV;

        private string _tenTK;
        private string _MK;
        private string _hoten;
        private string _Status;
        public ICommand LoginCommand { get; set; }
        public ICommand load_ns_Command { get; set; }
        public ICommand them_tk_Command { get; set; }
        public ICommand xoa_tk_Command { get; set; }
        public ICommand xem_cttk_Command { get; set; }
        public ICommand sua_tk_Command { get; set; }
        public ICommand thangchuc_Command { get; set; }
        public ICommand giangchuc_Command { get; set; }
        public ICommand resetMK_Command { get; set; }


        public bool QL { get => _QL; set { _QL = value; OnPropertyChanged("QL"); } }
        public bool NV { get => _NV; set { _NV = value; OnPropertyChanged("NV"); } }
        public string TenTK { get => _tenTK; set { _tenTK = value; OnPropertyChanged("TenTK"); } }
        public string MK { get => _MK; set { _MK = value; OnPropertyChanged("MK"); } }
        public string Hoten { get => _hoten; set { _hoten = value; OnPropertyChanged("Hoten"); } }
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged("Status"); } }

        public List<TaiKhoan_Models> DanhSachTaiKhoan { get => _DanhSachTaiKhoan; set { _DanhSachTaiKhoan = value; OnPropertyChanged("DanhSachTaiKhoan"); } }

        public TaiKhoan_Models SelectedTaiKhoan { get => _SelectedTaiKhoan; set => _SelectedTaiKhoan = value; }

        public TaiKhoan_VM()
        {
            TenTK = "phuoc12";
            LoginCommand = new RelayCommand<PasswordBox>(p => 
            {
                if (TenTK == null || TenTK == "")
                {
                    Status = " Tên đăng nhập bị thiếu ";
                }
                else if (p == null || p.Password == "")
                {
                    Status = " Chưa điền mật khẩu ";
                }
                else 
                {
                    List<TaiKhoan_Models> tk_lg = tkdao.sp_check_login(TenTK, p.Password);
                    if (tk_lg.Count > 0)
                    {
                        data_temp.tk_md = tk_lg.First();
                        Main_Window trangchu = new Main_Window();
                        trangchu.phanquyen(data_temp.tk_md.Chucvu);
                        Login_Window.login.Close();
                        trangchu.ShowDialog();
                    }
                    else
                    {
                        Status = " Sai tên đăng nhập hoặc mật khẩu ";
                    }
                }
            });
            load_ns_Command = new RelayCommand<object>(p =>
            {
                DanhSachTaiKhoan = tkdao.vw_load_TaiKhoan();
            });
            them_tk_Command = new RelayCommand<object>(p =>
            {
                ql_nhansu_xemct_view ql = new ql_nhansu_xemct_view();
                ql.ShowDialog();
                if (data_temp.tk_sua!=null)
                {
                    tkdao.sp_themtk(data_temp.tk_sua);
                    data_temp.tk_sua = null;
                    load_ns_Command.Execute(null);
                }
            });
            xoa_tk_Command = new RelayCommand<object>(p =>
            {
                if (SelectedTaiKhoan == null )
                {
                    ThongBao_W tb = new ThongBao_W("Vui lòng chọn tài khoản bạn muốn xoá",'l');
                    tb.ShowDialog();
                }
                else
                {
                    string str = "Bạn có thật sự muốn xoá tài khoản ID: " + SelectedTaiKhoan.TK_id;
                    ThongBao_W tb = new ThongBao_W(str, 'x');
                    tb.ShowDialog();
                    if (tb.yes)
                    {
                        tkdao.sp_xoatk(SelectedTaiKhoan);
                    }
                }
                load_ns_Command.Execute(null);
            });
            xem_cttk_Command = new RelayCommand<object>(p =>
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao_W tb = new ThongBao_W("Xin hãy chọn tài khoản cần xem", 'l');
                    tb.ShowDialog();
                }
                else
                {
                    data_temp.tk_sua = SelectedTaiKhoan;
                    ql_nhansu_xemct_view ql = new ql_nhansu_xemct_view();
                    ql.ShowDialog();
                    tkdao.sp_suatk_thongtincanhan(data_temp.tk_sua);
                    data_temp.tk_sua = null;
                }
                load_ns_Command.Execute(null);
            });
            thangchuc_Command = new RelayCommand<object>(p =>
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao_W tb = new ThongBao_W("Xin hãy chọn tài khoản", 'l');
                    tb.ShowDialog();
                }
                else
                {
                    ThongBao_W tb = new ThongBao_W("Bạn thật sự muốn thăng chức cho " + SelectedTaiKhoan.Hoten + " ?", 'x');
                    tb.ShowDialog();
                    if (tb.yes)
                    {
                        SelectedTaiKhoan.Chucvu = "QL";
                        tkdao.sp_suatk_chucvu(SelectedTaiKhoan);
                        load_ns_Command.Execute(null);
                    }

                }
            });
            giangchuc_Command = new RelayCommand<object>(p =>
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao_W tb = new ThongBao_W("Xin hãy chọn tài khoản", 'l');
                    tb.ShowDialog();
                }
                else
                {
                    ThongBao_W tb = new ThongBao_W("Bạn thật sự muốn giáng chức của " + SelectedTaiKhoan.Hoten + " ?", 'x');
                    tb.ShowDialog();
                    if (tb.yes)
                    {
                        SelectedTaiKhoan.Chucvu = "NV";
                        tkdao.sp_suatk_chucvu(SelectedTaiKhoan);
                        load_ns_Command.Execute(null);
                    }

                }
            });
            resetMK_Command = new RelayCommand<object>(p =>
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao_W tb = new ThongBao_W("Xin hãy chọn tài khoản", 'l');
                    tb.ShowDialog();
                }
                else
                {
                    resetMK_view rs = new resetMK_view();
                    rs.ShowDialog();
                    if (rs.check)
                    {
                        tkdao.sp_suatk_MK(SelectedTaiKhoan.TK_id, rs.pw_temp);
                        load_ns_Command.Execute(null);
                    }
                }

            });
        }
    }
}
