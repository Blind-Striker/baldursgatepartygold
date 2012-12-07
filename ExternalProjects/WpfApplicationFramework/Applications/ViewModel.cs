using System.Threading;
using System.Windows.Threading;

namespace System.Waf.Applications
{
    /// <summary>
    /// Abstract base class for a ViewModel implementation.
    /// </summary>
    public abstract class ViewModel : DataModel
    {
        private readonly IView view;


        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class and
        /// attaches itself as <c>DataContext</c> to the view.
        /// </summary>
        /// <param name="view">The view.</param>
        protected ViewModel(IView view) : this(view, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="isChild">if set to <c>true</c> then this object is a child of another ViewModel.</param>
        protected ViewModel(IView view, bool isChild)
        {
            if (view == null) { throw new ArgumentNullException("view"); }
            this.view = view;
            if (!isChild)
            {
                // Check if the code is running within the WPF application model
                if (SynchronizationContext.Current is DispatcherSynchronizationContext)
                {
                    // Set DataContext of the view has to be delayed so that the ViewModel can initialize the internal data (e.g. Commands)
                    // before the view starts with DataBinding.
                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate()
                    {
                        this.view.DataContext = this;
                    });
                }
                else
                {
                    // When the code runs outside of the WPF application model then we set the DataContext immediately.
                    view.DataContext = this;
                }
            }
        }


        /// <summary>
        /// Gets the associated view.
        /// </summary>
        public object View { get { return view; } }
    }
}
