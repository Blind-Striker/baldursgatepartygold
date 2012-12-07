using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    internal class MenuItemCommandBindingFactory : CommandBindingFactory
    {
        protected override bool CanCreateCore(Component component)
        {
            return component is ToolStripMenuItem;
        }

        protected override CommandBindingBase CreateCore(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            ToolStripMenuItem menuItem = component as ToolStripMenuItem;
            if (menuItem == null) { throw new ArgumentException("This factory cannot create a CommandBindingBase for the passed component."); }
            return new MenuItemCommandBinding(menuItem, command, commandParameterCallback);
        }
    }
}
