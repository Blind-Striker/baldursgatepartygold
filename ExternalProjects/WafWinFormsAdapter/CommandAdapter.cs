using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace System.Waf.Presentation.WinForms
{
    public class CommandAdapter
    {
        private static readonly IList<CommandBindingFactory> factories = new List<CommandBindingFactory>()
        {
            new ButtonCommandBindingFactory(),
            new MenuItemCommandBindingFactory(),
            new ToolStripButtonCommandBindingFactory()
        };

        private readonly IList<CommandBindingBase> bindings = new List<CommandBindingBase>();


        public static void AddCommandBindingFactory(CommandBindingFactory factory)
        {
            if (factory == null) { throw new ArgumentNullException("factory"); }
            factories.Add(factory);
        }

        public static void RemoveCommandBindingFactory(CommandBindingFactory factory)
        {
            if (factory == null) { throw new ArgumentNullException("factory"); }
            if (!factories.Remove(factory))
            {
                throw new ArgumentException("The factory to remove wasn't found.");
            }
        }

        public CommandAdapter AddCommandBinding(Component component, ICommand command)
        {
            return AddCommandBinding(component, command, () => null);
        }

        public CommandAdapter AddCommandBinding(Component component, ICommand command, object commandParameter)
        {
            return AddCommandBinding(component, command, () => commandParameter);
        }

        public CommandAdapter AddCommandBinding(Component component, ICommand command, Func<object> commandParameterCallback)
        {
            if (component == null) { throw new ArgumentNullException("component"); }
            if (command == null) { throw new ArgumentNullException("command"); }
            if (commandParameterCallback == null) { throw new ArgumentNullException("commandParameterCallback"); }

            foreach (CommandBindingFactory factory in factories.Reverse())
            {
                if (factory.CanCreate(component))
                {
                    bindings.Add(factory.Create(component, command, commandParameterCallback));
                    return this;
                }
            }

            throw new NotSupportedException("This component type '" + component.GetType().Name + "' is not supported. Please provide an adapter for this component.");
        }

        public void RemoveCommandBinding(Component component)
        {
            if (component == null) { throw new ArgumentNullException("component"); }
            CommandBindingBase binding = bindings.FirstOrDefault(b => b.Component == component);
            if (binding == null) { throw new ArgumentException("The binding to remove wasn't found."); }
            bindings.Remove(binding);
        }
    }
}
