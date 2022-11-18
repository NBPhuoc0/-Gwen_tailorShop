using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Final_proj_CSDL.DAL
{
    internal class PhanCongDAO :XuLySqlServer
    {
        public List<PhanCong_Models> vw_load_phancong()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_phancong"));
            return JsonConvert.DeserializeObject<List<PhanCong_Models>>(json);
        }
        public bool sp_phancongcongviec(PhanCong_Models pc)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            name[1] = "@QL_id";
            name[2] = "@NV_id";
            name[3] = "@mota";
            name[4] = "@ngaytao";
            values[0] = pc.HD_id;
            values[1] = pc.QL_id;
            values[2] = pc.NV_id;
            values[3] = pc.Mota;
            values[4] = pc.Ngaytao;
            return Execute_sp("sp_phancongcongviec", name, values, parameter);
        }
        public bool sp_suaphancong(PhanCong_Models pc)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@NV_id";
            name[1] = "@mota";
            values[0] = pc.NV_id;
            values[1] = pc.Mota;
            return Execute_sp("sp_suaphancong", name, values, parameter);
        }
        public bool sp_xoaphancong(int PC_id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@PC_id";
            values[0] = PC_id;
            return Execute_sp("sp_xoaphancong", name, values, parameter);
        }


    }
}
