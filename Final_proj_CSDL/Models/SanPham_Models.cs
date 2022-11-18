namespace Final_proj_CSDL.Models
{
    public class SanPham_Models
    {
        private int _SP_id;
        private string _tenSP;
        private string _mota;
        private byte[] _anh;
        private int _gia;
            
        public int SP_id { get => _SP_id; set => _SP_id = value; }
        public string TenSP { get => _tenSP; set => _tenSP = value; }
        public string Mota { get => _mota; set => _mota = value; }
        public byte[] Anh { get => _anh; set => _anh = value; }
        public int Gia { get => _gia; set => _gia = value; }
    }
}
