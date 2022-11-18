using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.Models
{
    public class bang_CTHD_Models
    {
        private int _CTHD_id;
        private int _soluong;
        private string _tenSP;
        private int _Gia;
        private int _thanhtien;


        public int Soluong { get => _soluong; set => _soluong = value; }
        public string TenSP { get => _tenSP; set => _tenSP = value; }
        public int Gia { get => _Gia; set => _Gia = value; }
        public int Thanhtien { get => _thanhtien; set => _thanhtien = value; }
        public int CTHD_id { get => _CTHD_id; set => _CTHD_id = value; }
    }
}
