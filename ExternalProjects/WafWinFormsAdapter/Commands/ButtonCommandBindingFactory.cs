using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    internal class ButtonCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
            return component is ButtonBase;
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            ButtonBase button = component as ButtonBase;
            if (button == null) { throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component."); }
            return new ButtonCommandBinding(button, command, commandParameterCallback);
        }
    }
}
