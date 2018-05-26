using moaui.ViewModels;
using System.Windows;

namespace moaui.Views
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window, IAddUserView
    {
        public AddUserView() {
            InitializeComponent();

            (DataContext as AddUserViewModel).AddUserView = this as IAddUserView;
        }

        public void AddUserToDb() {
            int.TryParse(TxtAge.Text, out int age);
            int.TryParse(TxtYears.Text, out int years);

            // Is this acceptable?
            var newUserViewModel = new UserViewModel(TxtName.Text, age, TxtBands.Text,
               TxtSkills.Text, years);
        }
    }
}
