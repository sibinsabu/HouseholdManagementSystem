using System.ComponentModel;
using System.Runtime.CompilerServices;
using HouseholdManagementSystem.ViewModels;

namespace HouseholdManagementSystem.ViewModels
{
    /// <summary>
    /// A base class that implements INotifyPropertyChanged to support data binding.
    /// This ensures that UI elements update automatically when property values change.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the UI that a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets a property's value and notifies the UI if the value has changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">Reference to the backing field.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns true if the value changed, otherwise false.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
