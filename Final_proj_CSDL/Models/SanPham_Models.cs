
namespace Final_proj_CSDL.Models
{
    internal class SanPham_Models
    {
        private int _id_SP;
        private string _motaSP;
        private object _anhmau;
        private int _gia;

        public int Id_SP { get => _id_SP; set => _id_SP = value; }
        public string MotaSP { get => _motaSP; set => _motaSP = value; }
        public object Anhmau { get => _anhmau; set => _anhmau = value; }
        public int Gia { get => _gia; set => _gia = value; }
    }
}
