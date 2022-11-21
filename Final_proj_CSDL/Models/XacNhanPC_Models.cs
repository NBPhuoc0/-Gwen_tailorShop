using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.Models
{
    public class XacNhanPC_Models
    {
        private int _baocao_id;
        private int _PC_id;
        private int _QL_id;
        private bool _kq;
        private string _loinhan;
        private DateTime _ngaytao;

        public int Baocao_id { get => _baocao_id; set => _baocao_id = value; }
        public int PC_id { get => _PC_id; set => _PC_id = value; }
        public int QL_id { get => _QL_id; set => _QL_id = value; }
        public bool Kq { get => _kq; set => _kq = value; }
        public string Loinhan { get => _loinhan; set => _loinhan = value; }
        public DateTime Ngaytao { get => _ngaytao; set => _ngaytao = value; }
    }
}
