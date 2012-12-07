using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    public abstract class CommandBindingFactory
    {
        public bool CanCreate(Component component)
        {
            if (component == null) { throw new ArgumentNullException("component"); }
            return CanCreateCore(component);
        }

        public CommandBindingBase Create(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            if (component == null) { throw new ArgumentNullException("component"); }
            if (command == null) { throw new ArgumentNullException("command"); }
            if (commandParameterCallback == null) { throw new ArgumentNullException("commandParameterCallback"); }
            return CreateCore(component, command, commandParameterCallback);
        }

        protected abstract bool CanCreateCore(Component component);

        protected abstract CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback);
    }
}
