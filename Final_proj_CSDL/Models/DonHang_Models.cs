using System.Data.SqlTypes;

namespace Final_proj_CSDL.Models
{
    internal class DonHang_Models
    {
        private int _id_HD;
        private string _tenKH;
        private string _SDT_KH;
        private string _mota;
        private int _tongtien;
        private SqlDateTime _ngaytao;
        private SqlDateTime _ngaygiao;

        public int Id_HD { get => _id_HD; set => _id_HD = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string SDT_KH { get => _SDT_KH; set => _SDT_KH = value; }
        public string Mota { get => _mota; set => _mota = value; }
        public int Tongtien { get => _tongtien; set => _tongtien = value; }
        public SqlDateTime Ngaytao { get => _ngaytao; set => _ngaytao = value; }
        public SqlDateTime Ngaygiao { get => _ngaygiao; set => _ngaygiao = value; }
    }
}
