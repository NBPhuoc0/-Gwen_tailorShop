using Final_proj_CSDL.Views;
using Final_proj_CSDL.Views.NV;
using Final_proj_CSDL.Views.QL;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class Main_VM : baseVM
    {
		private object _currentView;
        private string _tenUser;
        public ICommand Load_home_Command { get; set; }
		public ICommand Logout { get; set; }
		public ICommand Load_QLNS_Command { get; set; }
		public ICommand Load_QLDon_Command { get; set; }
		public ICommand Load_SPmau_Command { get; set; }
		public ICommand Load_phancong_nv_Command { get; set; }

		public object currentview
		{
			get { return _currentView; }
			set 
			{ 
				_currentView = value;
                OnPropertyChanged("currentview");
            }
        }

        public string TenUser { get => _tenUser; set => _tenUser = value; }

        public Main_VM()
		{
			TenUser = TK_md.tk_md.Hoten;
			//tới trang chủ command
			Load_home_Command = new RelayCommand<object>(o =>
			{
				home_view Trangchu = new home_view();
				currentview = Trangchu;
			});
			//đăng xuất command
			Logout = new RelayCommand<object>(o =>
			{
				Login_Window login = new Login_Window();
				Main_Window.trangchu.Close();
                login.ShowDialog();
            });
			// đến trang quản lý nhân sự - QL
			Load_QLNS_Command = new RelayCommand<object>(o =>
			{
				ql_nhansu_view Nhansu = new ql_nhansu_view();
				currentview = Nhansu;
			});
			//đến trang quản lý đơn hàng - QL
			Load_QLDon_Command = new RelayCommand<object>(o =>
			{
				ql_don_view Qldon = new ql_don_view();
				currentview = Qldon;
			});
			//đến trang xem mẫu thiết kế - QL
			Load_SPmau_Command = new RelayCommand<object>(o =>
			{
				ql_sp_view Sp = new ql_sp_view();
				currentview = Sp;
			});
			//đến trang xem phân công công việc - NV
			Load_phancong_nv_Command = new RelayCommand<object>(o =>
			{
				phancong_nv_view PhancongNV = new phancong_nv_view();
				currentview = PhancongNV;
			});
        }
	}
}
