using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chess.Base
{
    /// <summary>
    /// This class provides some base functions for classes that can notify subscribed classes when a property is changed.
    /// </summary>
    public abstract class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// This method could be called inside a particular property.
        /// The name of the specific property must be provided.
        /// </summary>
        /// <param name="propertyName">The name of the property that will change</param>
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This method could be called inside a particular property.
        /// The name of the specific property is optional, it will be taken automatically.
        /// </summary>
        /// <param name="propertyName">The name of the property that will change</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
