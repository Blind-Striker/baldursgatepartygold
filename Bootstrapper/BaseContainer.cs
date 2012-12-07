using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace MvpVmSample.Core.Bootstrapper
{
    public abstract class BaseContainer
    {
        private readonly IWindsorContainer _container;

        protected BaseContainer()
        {
            _container = new WindsorContainer();
        }

        protected BaseContainer(params IWindsorInstaller[] windsorInstaller)
            : this()
        {
            _container.Install(windsorInstaller);
        }

        public IWindsorContainer Container
        {
            get { return _container; }
        }
    }
}
