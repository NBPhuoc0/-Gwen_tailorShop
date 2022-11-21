using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Final_proj_CSDL.DAL
{
    public class PhanCongDAO :XuLySqlServer
    {
        public List<PhanCong_Models> vw_load_phancong()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_phancong"));
            return JsonConvert.DeserializeObject<List<PhanCong_Models>>(json);
        }
        public List<HoaDon_Models> vw_load_HD_id()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_HD_id"));
            return JsonConvert.DeserializeObject<List<HoaDon_Models>>(json);
        }
        public List<TaiKhoan_Models> vw_load_TK_QL()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_TK_QL"));
            return JsonConvert.DeserializeObject<List<TaiKhoan_Models>>(json);
        }
        public List<TaiKhoan_Models> vw_load_TK_NV()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_TK_NV"));
            return JsonConvert.DeserializeObject<List<TaiKhoan_Models>>(json);
        }


        public List<PhanCong_Models> fn_pcBy_HD_id(int HD_id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            values[0] = HD_id;
            string json = JsonConvert.SerializeObject(Execute_fn("fn_pcBy_HD_id", name, values, parameter));
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
