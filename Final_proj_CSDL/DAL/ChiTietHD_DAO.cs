using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.DAL
{
    internal class ChiTietHD_DAO : XuLySqlServer
    {
        public List<bang_CTHD_Models> fn_vw_cthd(int id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            values[0] = id;
            string json = JsonConvert.SerializeObject(Execute_fn("fn_vw_cthd", name, values, parameter));
            return JsonConvert.DeserializeObject<List<bang_CTHD_Models>>(json);
        }
        public bool sp_themcthd(CTHD_Models cthd_md)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            name[1] = "@SP_id";
            name[2] = "@soluong";
            values[0] = cthd_md.HD_id;
            values[1] = cthd_md.SP_id;
            values[2] = cthd_md.Soluong;
            return Execute_sp("sp_themcthd", name, values, parameter);
        }
        public bool sp_xoacthd(int id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@CTHD_id";
            values[0] = id;
            return Execute_sp("sp_xoacthd", name, values, parameter);
        }
        
    }
}
