using BusinessLogic.Repositories;
using Caliburn.Micro;
using GroupManager.Core.Context;
using GroupManager.Core.Model;
using GroupManager.Core.Models;
using GroupManager.Models;
using GroupManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GroupManager
{
    public class MainBootsrapper:BootstrapperBase
    {
        private SimpleContainer container;
        public MainBootsrapper() {

            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();

            container.PerRequest<MainViewModel, MainViewModel>();
            container.PerRequest<ShellViewModel, ShellViewModel>();
            container.PerRequest<StudentsListViewModel, StudentsListViewModel>();
            container.PerRequest<AboutStudentViewModel, AboutStudentViewModel>();
            container.PerRequest<CharacteristicFormViewModel, CharacteristicFormViewModel>();
            container.PerRequest<RadioCharacteristicFormViewModel,RadioCharacteristicFormViewModel>();
            container.PerRequest<DeleteRequestViewModel,DeleteRequestViewModel>();
            container.PerRequest<ListCertificatesViewModel,ListCertificatesViewModel>();
            container.PerRequest<DeleteRequestCertificateViewModel, DeleteRequestCertificateViewModel>();
            container.PerRequest<AboutCertificateViewModel,AboutCertificateViewModel>();
            container.PerRequest<ChooseCharacteristicViewModel,ChooseCharacteristicViewModel>();
            container.PerRequest<AboutViewModel,AboutViewModel>();

            container.PerRequest<IRepository<Student>, StudentRepository>();
            container.PerRequest<IStudentsRepository, StudentRepository>();

            container.PerRequest<IRepository<Certificate>, CertificateRepository>();
            container.PerRequest<IRepository<Characteristic>, CharacteristicsRepository>();

            container.PerRequest<IRepository<Group>, GroupRepository>();
            container.PerRequest<IRepository<Parents>, ParentsRepository>();
            container.PerRequest<IRepository<Privilege>, PrivilegeRepository>();
            container.PerRequest<CharacteristicManager, CharacteristicManager>();



            container.Singleton<DbContext, ApplicationContext>();
            Initialize();
        }
        protected override void Configure()
        {
            base.Configure();
           
        }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            var settings = new Dictionary<string, object>{
                 { "Icon", new BitmapImage(new Uri("pack://application:,,,/GroupManager;component/unitup.ico"))},
                 
            };
            await DisplayRootViewForAsync<ShellViewModel>(settings);
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            return instance;
            //throw new InvalidOperationException("Could not locate any instances.");
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
