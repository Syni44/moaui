using Caliburn.Micro;
using System;

namespace moaui.ViewModels
{
    internal class LaunchViewModel : Screen
    {
        public WindowManager windowManager;

        public LaunchViewModel(IWindowManager wm) {
            this.windowManager = wm as WindowManager;
        }
        
        public void BtnAdd() {
            var addUserViewModel = new AddUserViewModel();

            // result is true if user presses "OK"
            bool? result = this.windowManager.ShowDialog(addUserViewModel);
        }

        public void BtnRemove() {
            throw new NotImplementedException();
        }

        public void BtnDownload() {
            throw new NotImplementedException();
        }
    }
}
