using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;



namespace Final_proj_CSDL.DAL
{
    internal class SanPhamDAO :XuLySqlServer
    {
        public List<SanPham_Models> vw_load_sanpham()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_sanpham"));
            return JsonConvert.DeserializeObject<List<SanPham_Models>>(json);
        }
        public bool sp_themsp(SanPham_Models sp)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tenSP";
            name[1] = "@mota";
            name[2] = "@anh";
            name[3] = "@gia";
            values[0] = sp.TenSP;
            values[1] = sp.Mota;
            values[2] = sp.Anh;
            values[3] = sp.Gia;
            return Execute_sp("sp_themsp", name, values, parameter);
        }
        public bool sp_xoasp(int id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@SP_id";
            values[0] = id;
            return Execute_sp("sp_xoasp", name, values, parameter);
        }
        public bool sp_suasp(SanPham_Models sp)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@SP_id";
            name[1] = "@tenSP";
            name[2] = "@mota";
            name[3] = "@anh";
            name[4] = "@gia";
            values[0] = sp.SP_id;
            values[1] = sp.TenSP;
            values[2] = sp.Mota;
            values[3] = sp.Anh;
            values[4] = sp.Gia;
            return Execute_sp("sp_suasp", name, values, parameter);
        }


    }
}
