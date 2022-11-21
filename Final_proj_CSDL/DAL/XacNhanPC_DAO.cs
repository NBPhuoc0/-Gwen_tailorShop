using Final_proj_CSDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.DAL
{
    internal class XacNhanPC_DAO:XuLySqlServer
    {
        public bool sp_XacNhanPC_kiemtra(XacNhanPC_Models xnpc)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@PC_id";
            name[1] = "@QL_id";
            name[2] = "@kq";
            name[3] = "@LoiNhan";
            name[4] = "@ngaytao";
            values[0] = xnpc.PC_id;
            values[1] = xnpc.QL_id;
            values[2] = xnpc.Kq;
            values[3] = xnpc.Loinhan;
            values[4] = xnpc.Ngaytao;
            return Execute_sp("sp_XacNhanPC_kiemtra", name, values, parameter);
        }
    }
}
