using Final_proj_CSDL.Models;
using Final_proj_CSDL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ql_nhansu_xemct_view.xaml
    /// </summary>
    public partial class ql_nhansu_xemct_view : Window
    {
        public ql_nhansu_xemct_view()
        {
            InitializeComponent();         
        }

        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        => System.Diagnostics.Debug.WriteLine($"Card is flipped = {e.NewValue}");
    }
}
