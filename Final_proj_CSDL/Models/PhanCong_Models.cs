using System;
    
namespace Final_proj_CSDL.Models
{
    public class PhanCong_Models
    {
        private int _PC_id;
        private int _HD_id;
        private int _QL_id;
        private int _NV_id;
        private string _mota;
        private bool _trangthai;
        private DateTime _ngaytao;

        public int PC_id { get => _PC_id; set => _PC_id = value; }
        public int HD_id { get => _HD_id; set => _HD_id = value; }
        public int QL_id { get => _QL_id; set => _QL_id = value; }
        public int NV_id { get => _NV_id; set => _NV_id = value; }
        public string Mota { get => _mota; set => _mota = value; }
        public bool Trangthai { get => _trangthai; set => _trangthai = value; }
        public DateTime Ngaytao { get => _ngaytao; set => _ngaytao = value; }
    }
}
