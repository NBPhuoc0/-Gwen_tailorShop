 using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Final_proj_CSDL.ViewModels
{
    internal class baseVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
