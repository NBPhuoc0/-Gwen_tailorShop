using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
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
            DanhSachTaiKhoan = tkdao.vw_load_TaiKhoan();
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

        }
    }
}
