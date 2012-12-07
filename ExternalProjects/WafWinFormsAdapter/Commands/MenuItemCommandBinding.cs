using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    internal class MenuItemCommandBinding : CommandBindingBase
    {
        private ToolStripMenuItem menuItem;
        private Func<object> commandParameterCallback;


        public MenuItemCommandBinding(ToolStripMenuItem menuItem, ICommand command, Func<object> commandParameterCallback)
            : base(menuItem, command)
        {
            this.menuItem = menuItem;
            this.commandParameterCallback = commandParameterCallback;
            UpdateEnabledProperty();
            this.menuItem.Click += ButtonClick;
        }


        protected override void OnCommandCanExecuteChanged()
        {
            UpdateEnabledProperty();
        }

        protected override void OnComponentDisposed()
        {
            menuItem.Click -= ButtonClick;
            menuItem = null;
            commandParameterCallback = null;
        }

        private void UpdateEnabledProperty()
        {
            menuItem.Enabled = Command.CanExecute(commandParameterCallback());
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Command.Execute(commandParameterCallback());
        }
    }
}
