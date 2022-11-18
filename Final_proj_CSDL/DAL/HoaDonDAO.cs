using Final_proj_CSDL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_proj_CSDL.DAL
{
    internal class HoaDonDAO : XuLySqlServer
    {
        public List<HoaDon_Models> vw_load_hoadon_tt()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_hoadon_tt"));
            return JsonConvert.DeserializeObject<List<HoaDon_Models>>(json);

        }
        public List<SanPham_Models> vw_load_sanpham()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_sanpham"));
            return JsonConvert.DeserializeObject<List<SanPham_Models>>(json);
        }
        public List<TaiKhoan_Models> vw_load_id_ql()
        {
            string json = JsonConvert.SerializeObject(LoadData_vw("vw_load_id_ql"));
            return JsonConvert.DeserializeObject<List<TaiKhoan_Models>>(json);

        }
        public bool sp_themhd(HoaDon_Models hd_md)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tenKH";
            name[1] = "@SDT_KH";
            name[2] = "@QL_id";
            name[3] = "@mota";
            name[4] = "@ngaytao";
            values[0] = hd_md.TenKH;
            values[1] = hd_md.Sdt_KH;
            values[2] = hd_md.Ql_id;
            values[3] = hd_md.Mota;
            values[4] = hd_md.Ngaytao;
            return Execute_sp("sp_themhd", name, values, parameter);
        }
        public bool sp_xoahd(int hd_id)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            values[0] = hd_id;
            return Execute_sp("sp_xoahd", name, values, parameter);
        }
        public bool sp_suahd(HoaDon_Models hd_md)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HD_id";
            name[1] = "@tenKH";
            name[2] = "@SDT_KH";
            name[3] = "@mota";
            values[0] = hd_md.Hd_id;
            values[1] = hd_md.TenKH;
            values[2] = hd_md.Sdt_KH;
            values[3] = hd_md.Mota;
            return Execute_sp("sp_suahd", name, values, parameter);
        }

    }
}
