using Castle.MicroKernel.Registration;

namespace MvpVmSample.Core.Bootstrapper
{
    public class BootstrapContainer : BaseContainer
    {
        public BootstrapContainer()
            : base()
        {
            
        }

        public BootstrapContainer(params IWindsorInstaller[] windsorInstaller)
            :base(windsorInstaller)
        {
            
        }
    }
}
