using Caliburn.Micro;
using moaui.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace moaui
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper() {
            Initialize();
        }

        protected override void Configure() {
            // allows us to use Caliburn's WindowManager to open secondary windows in the app
            _container.Instance<IWindowManager>(new WindowManager());
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.PerRequest<LaunchViewModel>();
        }

        protected override object GetInstance(Type service, string key) {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<LaunchViewModel>();
        }
    }
}
