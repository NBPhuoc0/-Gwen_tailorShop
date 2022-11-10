
namespace Final_proj_CSDL.Models
{
    internal class TaiKhoan_Models
    {
        private int _id_user;
        private string _tenTK;
        private string _MK;
        private string _hoten;
        private string _SDT;
        private string _diachi;
        private string _mail;
        private string _chucvu;

        public int Id_user { get => _id_user; set => _id_user = value; }
        public string TenTK { get => _tenTK; set => _tenTK = value; }
        public string MK { get => _MK; set => _MK = value; }
        public string Hoten { get => _hoten; set => _hoten = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Chucvu { get => _chucvu; set => _chucvu = value; }
    }
}
