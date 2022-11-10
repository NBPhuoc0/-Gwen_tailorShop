using System.Data.SqlTypes;

namespace Final_proj_CSDL.Models
{
    internal class PhanCong_Models
    {
        private int _id_HD;
        private int _id_QL;
        private int _id_NV;
        private string _mota_CV;
        private string _trangthai;
        private SqlDateTime _ngaytao;

        public int Id_HD { get => _id_HD; set => _id_HD = value; }
        public int Id_QL { get => _id_QL; set => _id_QL = value; }
        public int Id_NV { get => _id_NV; set => _id_NV = value; }
        public string Mota_CV { get => _mota_CV; set => _mota_CV = value; }
        public string Trangthai { get => _trangthai; set => _trangthai = value; }
        public SqlDateTime Ngaytao { get => _ngaytao; set => _ngaytao = value; }
    }
}
