using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.DAL
{
    internal class TaiKhoanDAO:XuLySqlServer
    {
        public List<TaiKhoan_Models> vw_load_TaiKhoan()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_TaiKhoan"));
            return JsonConvert.DeserializeObject<List<TaiKhoan_Models>>(json);
        }
        public bool sp_themtk(TaiKhoan_Models tk_md)
        {
            int parameter = 7;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tenTK";
            name[1] = "@MK";
            name[2] = "@hoten";
            name[3] = "@SDT";
            name[4] = "@diachi";
            name[5] = "@email";
            name[6] = "@chucvu";
            values[0] = tk_md.TenTK;
            values[1] = tk_md.MK;
            values[2] = tk_md.Hoten;
            values[3] = tk_md.SDT;
            values[4] = tk_md.Diachi;
            values[5] = tk_md.Mail;
            values[6] = tk_md.Chucvu;
            return Execute_sp("sp_themtk", name, values, parameter);
        }
        public bool sp_xoatk(TaiKhoan_Models tk_md)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TK_id";
            values[0] = tk_md.TK_id;
            return Execute_sp("sp_xoatk", name, values, parameter);
        }
        public bool sp_suatk_MK(TaiKhoan_Models tk_md)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TK_id";
            name[1] = "@MK";
            values[0] = tk_md.TK_id;
            values[1] = tk_md.MK;
            return Execute_sp("sp_suatk_MK", name, values, parameter);
        }
        public bool sp_suatk_thongtincanhan(TaiKhoan_Models tk_md)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TK_id";
            name[1] = "@hoten";
            name[2] = "@SDT";
            name[3] = "@diachi";
            name[4] = "@email";
            values[0] = tk_md.TK_id;
            values[1] = tk_md.Hoten;
            values[2] = tk_md.SDT;
            values[3] = tk_md.Diachi;
            values[4] = tk_md.Mail;
            return Execute_sp("sp_suatk_thongtincanhan", name, values, parameter);
        }
        public bool sp_suatk_chucvu(TaiKhoan_Models tk_md)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TK_id";
            name[1] = "@chucvu";
            values[0] = tk_md.TK_id;
            values[1] = tk_md.Chucvu;
            return Execute_sp("sp_suatk_chucvu", name, values, parameter);
        }
        public List<TaiKhoan_Models> sp_check_login(string tk, string mk)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tenTK";
            name[1] = "@MK";
            values[0] = tk;
            values[1] = mk;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_check_login", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TaiKhoan_Models>>(json);
        }

    }
}
