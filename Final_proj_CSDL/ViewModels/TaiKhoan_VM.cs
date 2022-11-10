using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class TaiKhoan_VM : baseVM
    {
        List<TaiKhoan_Models> _DanhSachTaiKhoan;
        TaiKhoan_Models _SelectedUser;
        private Boolean _QL;
        private Boolean _NV;

        private string _tenTK;
        private string _MK;
        private string _hoten;
        private string _Status;
        public ICommand LoginCommand { get; set; }


        public bool QL { get => _QL; set { _QL = value; OnPropertyChanged("QL"); } }
        public bool NV { get => _NV; set { _NV = value; OnPropertyChanged("NV"); } }
        public string TenTK { get => _tenTK; set { _tenTK = value; OnPropertyChanged("UserName"); } }
        public string MK { get => _MK; set { _MK = value; OnPropertyChanged("Passw"); } }
        public string Hoten { get => _hoten; set { _hoten = value; OnPropertyChanged("Hoten"); } }
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged("Status"); } }

        internal List<TaiKhoan_Models> DanhSachTaiKhoan { get => _DanhSachTaiKhoan; set { _DanhSachTaiKhoan = value; OnPropertyChanged("DanhSachTaiKhoan"); } }
        TaiKhoan_Models SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }

        public TaiKhoan_VM()
        {
            TK_md.tk_md.Id_user = 123;
            TK_md.tk_md.Hoten = "Bá Phước";
            TK_md.tk_md.Chucvu = "QL";
            LoginCommand = new RelayCommand<PasswordBox>(o => 
            {
                if (o.Password == "123")
                {
                    Main_Window trangchu = new Main_Window();
                    trangchu.phanquyen(TK_md.tk_md.Chucvu);
                    Login_Window.login.Close();
                    trangchu.ShowDialog();
                }
            });
        }
    }
}
