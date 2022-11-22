using Final_proj_CSDL.DAL;
using Final_proj_CSDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final_proj_CSDL.ViewModels
{
    internal class PhanCong_VM : baseVM
    {
        List<PhanCong_Models> _DanhsachPhanCong;
        PhanCong_Models _selectedPhanCong;
        PhanCongDAO pcDao = new PhanCongDAO();
        List<XacNhanPC_Models> _danhsachXNPC;


        public ICommand Load_dsPC_Command { get; set; }
        public ICommand Load_dsXNPC_Command { get; set; }
        public ICommand XNhoanthanh_cv_Command { get; set; }



        public List<PhanCong_Models> DanhsachPhanCong { get => _DanhsachPhanCong; set { _DanhsachPhanCong = value; OnPropertyChanged("DanhsachPhanCong"); } }
        public PhanCong_Models SelectedPhanCong { get => _selectedPhanCong; 
            set 
            { 
                _selectedPhanCong = value; 
                OnPropertyChanged("SelectedPhanCong");
                Load_dsXNPC_Command.Execute(value.PC_id);
            } }
        public List<XacNhanPC_Models> DanhsachXNPC { get => _danhsachXNPC; set { _danhsachXNPC = value; OnPropertyChanged("DanhsachXNPC"); } }

        public PhanCong_VM()
        {
            int id_nv = data_temp.tk_md.TK_id;
            Load_dsPC_Command = new RelayCommand<object>(p =>
            {
                DanhsachPhanCong = pcDao.fn_pcBy_NV_id(id_nv);
            });
            Load_dsXNPC_Command = new RelayCommand<int>(p =>
            {
                DanhsachXNPC = pcDao.fn_xnBy_PC_id(p);
            });
            XNhoanthanh_cv_Command = new RelayCommand<PhanCong_Models>(p =>
            {
                pcDao.sp_xacnhanCV_hoanthanh(p.PC_id);
                Load_dsPC_Command.Execute(null);
            });

        }

    }
}
