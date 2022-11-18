using Final_proj_CSDL.Models;
using Final_proj_CSDL.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final_proj_CSDL.Views.QL
{
    /// <summary>
    /// Interaction logic for ql_sp_themsp_view.xaml
    /// </summary>
    public partial class ql_sp_themsp_view : Window
    {
        SanPham_Models _sp = new SanPham_Models();
        public bool luu = false;
        public SanPham_Models sp { get => _sp; set => _sp = value; }
        public ql_sp_themsp_view(SanPham_Models sp_sua = null)
        {
            InitializeComponent();
            if (sp_sua == null)
            {
                var temp = new BitmapImage(new Uri("pack://application:,,,/UIresources/default.jpg"));
                anh.Source = temp;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(temp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    sp.Anh = ms.ToArray();
                }
                mota.Text = "";
            }
            else
            {
                sp = sp_sua;
                tensp.Text = sp_sua.TenSP;
                mota.Text = sp_sua.Mota;
                giasp.Text = sp_sua.Gia.ToString();
                BitmapImage bim = new BitmapImage();
                MemoryStream ms = new MemoryStream(sp.Anh);
                bim.BeginInit();
                bim.StreamSource = ms;
                bim.EndInit();
                anh.Source = bim;
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (tensp.Text=="" ||tensp.Text==null||giasp.Text==""||giasp.Text==null)
            {
                ThongBao_W tb = new ThongBao_W("Vui lòng điền đầy đủ thông tin", 'l');
                tb.ShowDialog();
            }
            else
            {
                luu = true;
                sp.TenSP = tensp.Text;
                sp.Mota = mota.Text;
                sp.Gia = int.Parse(giasp.Text);
                this.Close();
            }
        }
        private void click_anh(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image file|*.png;*.jpg;*jfif;*jpge";
            op.FilterIndex = 1;
            op.ShowDialog();
            if (op.FileName != "" && op.FileName != null)
            {
                var temp = new BitmapImage(new Uri(op.FileName));
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(temp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    sp.Anh = ms.ToArray();
                }
                anh.Source = temp;
            }
        }

        private void isnumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
