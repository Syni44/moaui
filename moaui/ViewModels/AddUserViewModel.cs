using Caliburn.Micro;
using moaui.Models;
using moaui.Views;
using System.Windows;

namespace moaui.ViewModels
{
    internal class AddUserViewModel : Screen
    {        
        public IAddUserView AddUserView { get; set; }
        public User NewUser { get; set; }

        protected override void OnViewAttached(object view, object context) {
            AddUserView = view as IAddUserView;
        }

        // Caliburn Micro: this method shares the x:Name of Button and occurs on a Click event
        public void BtnAddUser() {
            if (AddUserView == null) {
                return;
            }

            // TODO: rather than routing around this way, it seems like it would probably be better to use databinding
            // on the Text properties in the .xaml and utilize INotifyPropertyChanged.
            AddUserView.AddUserToDb();

            TryClose();
        }

        public void BtnCancelUser() {
            var choice = MessageBox.Show("Are you sure you want to close this dialog?\nAll progress will be lost.",
                "Warning", MessageBoxButton.YesNo);

            if (choice == MessageBoxResult.Yes) {
                TryClose();
            }
        }
    }
}
