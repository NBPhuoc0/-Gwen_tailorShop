
using System;

namespace Final_proj_CSDL.Models
{
    public class TaiKhoan_Models
    {
        private int _TK_id;
        private string _tenTK;
        private string _MK;
        private string _hoten;
        private bool _gioitinh;
        private Nullable<DateTime> _ngaysinh;
        private string _SDT = "";
        private string _diachi = "";
        private string _email = "";
        private string _chucvu;
        private bool _nghiviec;

        public int TK_id { get => _TK_id; set => _TK_id = value; }
        public string TenTK { get => _tenTK; set => _tenTK = value; }
        public string MK { get => _MK; set => _MK = value; }
        public string Hoten { get => _hoten; set => _hoten = value; }
        public bool Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public Nullable<DateTime> Ngaysinh { get => _ngaysinh; set => _ngaysinh = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Email { get => _email; set => _email = value; }
        public string Chucvu { get => _chucvu; set => _chucvu = value; }
        public bool Nghiviec { get => _nghiviec; set => _nghiviec = value; }

        public bool Hoatdong { get => !_nghiviec;}
    }
}
