using System.Reflection;
using System.Waf.Applications;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Installers
{
    public class PartyGoldEditorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                //AllTypes.FromAssembly(_viewsAssebly).BasedOn<IPresenteredView<IPresenter>>()
                //    .WithService.FromInterface()
                //    .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)),
                //AllTypes.FromThisAssembly().BasedOn<IPresenter>()
                //    .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)),
                // Aslında mevcut senaryoda Custom ComponentSelector yazmaya gerek yok.
                //Component.For<IPresenterFactory>().AsFactory(configuration => configuration.SelectedWith<PartyGoldEditorViewComponentSelector>()),
                //Component.For<ITypedFactoryComponentSelector>().ImplementedBy<PartyGoldEditorViewComponentSelector>().LifestyleSingleton()
                Component.For<IPresenterFactory>().AsFactory().LifestyleTransient(),
                Component.For<IPartyGoldEditorPresenter>().ImplementedBy<PartyGoldEditorPresenter>().LifestyleTransient(),
                Component.For<ISelectSaveFolderPresenter>().ImplementedBy<SelectSaveFolderPresenter>().LifestyleTransient(),
                Component.For<ISelectSaveGamePresenter>().ImplementedBy<SelectSaveGamePresenter>().LifestyleTransient()
                );
        }
    }
}
