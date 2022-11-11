using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.NV;
using Final_proj_CSDL.Views.QL;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class Main_VM : baseVM
    {
        private string _tenUser;
        public ICommand Load_home_Command { get; set; }
		public ICommand Logout { get; set; }
		public ICommand Load_QLNS_Command { get; set; }
		public ICommand Load_QLDon_Command { get; set; }
		public ICommand Load_SPmau_Command { get; set; }
		public ICommand Load_phancong_nv_Command { get; set; }

        public string TenUser { get => _tenUser; set => _tenUser = value; }

        public Main_VM()
		{
			TenUser = data_temp.tk_md.Hoten;
			//tới trang chủ command
			Load_home_Command = new RelayCommand<object>(o =>
			{
				Main_Window.main_w.currentview.Content = new home_view();
			});
			//đăng xuất command
			Logout = new RelayCommand<object>(o =>
			{
				Login_Window login = new Login_Window();
				Main_Window.main_w.Close();
                login.ShowDialog();
            });
			// đến trang quản lý nhân sự - QL
			Load_QLNS_Command = new RelayCommand<object>(o =>
			{
				ql_nhansu_view nhansu = new ql_nhansu_view();
                Main_Window.main_w.currentview.Content = nhansu;
			});
			//đến trang quản lý đơn hàng - QL
			Load_QLDon_Command = new RelayCommand<object>(o =>
			{
				Main_Window.main_w.currentview.Content = new ql_don_view();
			});
			//đến trang xem mẫu thiết kế - QL
			Load_SPmau_Command = new RelayCommand<object>(o =>
			{
                Main_Window.main_w.currentview.Content = new ql_sp_view();
			});
			//đến trang xem phân công công việc - NV
			Load_phancong_nv_Command = new RelayCommand<object>(o =>
			{
                Main_Window.main_w.currentview.Content = new phancong_nv_view();
			});
        }
	}
}
