namespace MvvmLight22
{
    #region Using Declarations

    using System.Windows;
    using GalaSoft.MvvmLight.Threading;

    #endregion

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
