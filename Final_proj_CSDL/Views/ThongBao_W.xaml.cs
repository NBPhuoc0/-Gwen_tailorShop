using System.Windows;

namespace Final_proj_CSDL.Views
{
    /// <summary>
    /// Interaction logic for ThongBao_W.xaml
    /// </summary>
    public partial class ThongBao_W : Window
    {
        public bool yes = false;

        public ThongBao_W(string nd, char loai)
        {
            InitializeComponent();
            switch (loai)
            {
                case 'x':
                    tb_yn.Visibility = Visibility.Visible;
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertOutline;
                    break;
                case 't':
                    tb_close.Visibility = Visibility.Visible;
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckOutline;
                    break;
                case 'l':
                    tb_close.Visibility = Visibility.Visible;
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircleOutline;
                    break;
            }
            ndTB.Text = nd;
        }

        private void yes_checked(object sender, RoutedEventArgs e)
        {
            yes = true;
            this.Close();
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
