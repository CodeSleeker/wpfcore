using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WpfCore
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        protected void OnPropertyChanged(int propertyValue)
        {
            VerifyPropertyName(propertyValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue.ToString()));
        }
        [Conditional("DEBUG")]
        private void VerifyPropertyName(int propertyValue)
        {
            if (TypeDescriptor.GetProperties(this)[propertyValue] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyValue.ToString());
        }
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue()) return;
            updatingFlag.SetPropertyValue(true);
            try { await action(); }
            finally { updatingFlag.SetPropertyValue(false); }
        }
    }
}
