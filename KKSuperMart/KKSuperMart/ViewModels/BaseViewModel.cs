using System;
using System.ComponentModel;

namespace KKSuperMart.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
