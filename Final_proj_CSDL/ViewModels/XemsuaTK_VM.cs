using Final_proj_CSDL.Models;
using Final_proj_CSDL.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class XemsuaTK_VM:baseVM
    {
        private TaiKhoan_Models _tk_xem ;
        private string tieude;
        private bool mode_them;
        private bool _them;
        private bool _sua;
        private bool _ql;
        public ICommand mode_sua { get; set; }
        public ICommand luu_Command{ get; set; }
        public ICommand sua_Command { get; set; }
        public ICommand close_W { get; set; }
        DateTime min_date = new DateTime(1000, 1, 1);
        DateTime max_date = new DateTime(9999, 1, 1);

        public TaiKhoan_Models Tk_xem { get => _tk_xem; set => _tk_xem = value; }
        public bool Sua { get => _sua; set { _sua = value; OnPropertyChanged("Sua"); } }
        public bool Ql { get => _ql; set { _ql = value; OnPropertyChanged("QL"); } }
        public string Tieude { get => tieude; set { tieude = value; OnPropertyChanged("Tieude"); } }
        public bool Them { get => _them; set { _them = value; OnPropertyChanged("Them"); } }

        public XemsuaTK_VM()
        {
            if (data_temp.tk_sua != null)
            {
                Sua = false;
                mode_them = false;
                Tk_xem = data_temp.tk_sua;
                Tieude = "Thông tin chi tiết tài khoản";
                Ql = Tk_xem.Chucvu == "QL" ? true : false;
            }
            else
            {
                Tk_xem = new TaiKhoan_Models();
                Sua = true;
                mode_them = true;
                Tieude = "Tạo mới tài khoản";
            }
            Them = mode_them;
            mode_sua = new RelayCommand<object>(p =>
            {
                if (mode_them)
                {
                    Them = Sua;
                }            
                //Them = Sua && mode_them;

            });
            luu_Command = new RelayCommand<object>(p =>
            {
                ThongBao_W tb = new ThongBao_W("Bạn có thật sự muốn lưu những thay đổi", 'x');
                tb.ShowDialog();
                if (tb.yes)
                {
                    if (Tk_xem.TenTK == "" || Tk_xem.TenTK == null)
                    {
                        ThongBao_W tb1 = new ThongBao_W("Thiếu tên Tài Khoản", 'l');
                        tb1.ShowDialog();
                        Sua = !Sua;
                        mode_sua.Execute(p);
                    }
                    else if (Tk_xem.MK == "" || Tk_xem.MK == null)
                    {
                        ThongBao_W tb1 = new ThongBao_W("Thiếu Mật Khẩu", 'l');
                        tb1.ShowDialog();
                        Sua = !Sua;
                        mode_sua.Execute(p);
                    }
                    else if (Tk_xem.Hoten == "" || Tk_xem.Hoten == null)
                    {
                        ThongBao_W tb1 = new ThongBao_W("Thiếu họ và tên", 'l');
                        tb1.ShowDialog();
                        Sua = !Sua;
                        mode_sua.Execute(p);

                    }
                    else if (Tk_xem.Ngaysinh <= min_date || Tk_xem.Ngaysinh >= max_date )
                    {
                        ThongBao_W tb1 = new ThongBao_W("Ngày sinh không hợp lệ", 'l');
                        tb1.ShowDialog();
                        Sua = !Sua;
                        mode_sua.Execute(p);
                    }
                    else
                    {
                        data_temp.tk_sua = Tk_xem;
                        data_temp.tk_sua.Chucvu = Ql ? "QL" : "NV";
                    }
                }
            });
            sua_Command = new RelayCommand<object>(p =>
            {
            });
            close_W = new RelayCommand<Window>(p =>
            {
                if (Tk_xem==null)
                {
                    MessageBox.Show("ố đè không ổn r");
                } 
                else
                {
                    p.Close();
                }
            });

        }


    }
}
