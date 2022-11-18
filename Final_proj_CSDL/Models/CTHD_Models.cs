using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.Models
{
    public class CTHD_Models
    {
        private int _CTHD_id;
        private int _HD_id;
        private int _SP_id;
        private int _soluong;


        public int CTHD_id { get => _CTHD_id; set => _CTHD_id = value; }
        public int HD_id { get => _HD_id; set => _HD_id = value; }
        public int SP_id { get => _SP_id; set => _SP_id = value; }
        public int Soluong { get => _soluong; set => _soluong = value; }
    }
}
