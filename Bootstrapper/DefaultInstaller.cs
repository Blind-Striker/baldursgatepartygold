using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using MvpVmSample.Core.Foundation;
using MvpVmSample.Infinity.ResourceRepository;

namespace MvpVmSample.Core.Bootstrapper
{
    public class DefaultInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHeaderRepository>().ImplementedBy<HeaderRepository>());
        }
    }
}
