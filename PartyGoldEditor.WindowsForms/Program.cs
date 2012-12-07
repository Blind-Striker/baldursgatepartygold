using System;
using System.Configuration;
using System.Reflection;
using System.Waf.Applications.Services;
using System.Waf.Presentation.WinForms.Services;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvpVmSample.Core.Bootstrapper;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Installers;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Services;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;
using MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    static class Program
    {
        public static readonly BootstrapContainer PartyGoldEditorContainer = new BootstrapContainer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureContainer();

            IPresenterFactory presenterFactory = PartyGoldEditorContainer.Container.Resolve<IPresenterFactory>();
            IPartyGoldEditorPresenter partyGoldEditorPresenter = presenterFactory.CreatePresenter<IPartyGoldEditorPresenter>();

            Application.Run(partyGoldEditorPresenter.View as Form);
           // Application.Run(new SelectSaveFolderView());
        }

        private static void ConfigureContainer()
        {
            PartyGoldEditorContainer.Container.Install(new DefaultInstaller());
            PartyGoldEditorContainer.Container.Install(new PartyGoldEditorInstaller());

            PartyGoldEditorContainer.Container.Register(Component.For<ApplicationSettingsBase>().ImplementedBy<Settings>().LifestyleTransient());
            
            PartyGoldEditorContainer.Container.Register(Component.For<IMessageService>().ImplementedBy<MessageService>().LifestyleTransient());
            PartyGoldEditorContainer.Container.Register(Component.For<IDialogService>().ImplementedBy<WindowsFormDialogService>().LifestyleTransient());

            PartyGoldEditorContainer.Container.Register(Component.For<IPartyGoldEditorView>().ImplementedBy<PartyGoldEditorView>().LifestyleTransient());
            PartyGoldEditorContainer.Container.Register(Component.For<ISelectSaveFolderView>().ImplementedBy<SelectSaveFolderView>().LifestyleTransient());
        }
    }
}
