using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chess.Base
{
    /// <summary>
    /// Deze klasse biedt de basis voor klasses die gesubscribede klasses kunnen notificeren wanneer een property wordt gewijzigd.
    /// </summary>
    public abstract class Observable : INotifyPropertyChanged
    {
        /// <summary>
        /// Dit event zorgt ervoor dat de gesubscribede klassen op de hoogte worden gesteld van wijzigingen.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Deze methode kan worden aangeroepen in een bepaalde property, waarbij de naam van deze property 
        /// moet worden vermeld. Hierdoor wordt de PropertyChanged event afgevuurd.
        /// </summary>
        /// <param name="propertyName">De naam van de property die is veranderd</param>
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Deze methode kan worden aangeroepen in een bepaalde property, waarbij de naam van deze property 
        /// niet meer hoeft te worden vermeld. Hierdoor wordt de PropertyChanged event afgevuurd.
        /// </summary>
        /// <param name="propertyName">De naam van de property die is veranderd.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
