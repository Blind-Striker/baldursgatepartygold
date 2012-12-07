using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    internal class ToolStripButtonCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
            return component is ToolStripButton;
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            ToolStripButton button = component as ToolStripButton;
            if (button == null) { throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component."); }
            return new ToolStripButtonCommandBinding(button, command, commandParameterCallback);
        }
    }
}
