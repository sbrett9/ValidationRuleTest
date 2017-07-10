

namespace MvvmLight22.ViewModel
{
    #region Using Declarations

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;
    using Model;

    #endregion

    public class ViewModelLocator
    {
        protected static ViewModelLocator instance;
        public static ViewModelLocator Instance
        {
            get { return instance; }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public ViewModelLocator()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        public static void Cleanup()
        {
        }
    }
}