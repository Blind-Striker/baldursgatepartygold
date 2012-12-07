using System.Reflection;
using System.Windows;
using Castle.MicroKernel.Registration;
using MvpVmSample.Core.Bootstrapper;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Installers;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly BootstrapContainer _partyGoldEditorContainer = new BootstrapContainer();

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureContainer();

            IPresenterFactory presenterFactory = _partyGoldEditorContainer.Container.Resolve<IPresenterFactory>();
            IPartyGoldEditorPresenter partyGoldEditorPresenter = presenterFactory.CreatePresenter<IPartyGoldEditorPresenter>();

            Window mainWindow = partyGoldEditorPresenter.View as Window;

            mainWindow.ShowDialog();
        }


        private void ConfigureContainer()
        {
            _partyGoldEditorContainer.Container.Install(new DefaultInstaller());
            _partyGoldEditorContainer.Container.Install(new PartyGoldEditorInstaller());
            _partyGoldEditorContainer.Container.Register(Component.For<IPartyGoldEditorView>().ImplementedBy<PartyGoldEditorView>().LifestyleTransient());
        }
    }
}
