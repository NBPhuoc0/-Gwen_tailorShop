using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.Models
{
    public class HoaDon_Models
    {
        private int _hd_id;
        private string _tenKH;
        private string _sdt_KH;
        private int _ql_id;
        private string _mota;
        private int _tongtien;
        private DateTime _ngaytao;
        private Nullable<DateTime> _ngaygiao;

        public int Hd_id { get => _hd_id; set => _hd_id = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string Sdt_KH { get => _sdt_KH; set => _sdt_KH = value; }
        public int Ql_id { get => _ql_id; set => _ql_id = value; }
        public string Mota { get => _mota; set => _mota = value; }
        public int Tongtien { get => _tongtien; set => _tongtien = value; }
        public DateTime Ngaytao { get => _ngaytao; set => _ngaytao = value; }
        public Nullable<DateTime> Ngaygiao { get => _ngaygiao; set => _ngaygiao = value; }
    }
}
