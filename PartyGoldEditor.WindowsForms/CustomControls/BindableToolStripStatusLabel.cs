using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.CustomControls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
        private BindingContext _context = null;
        public BindingContext BindingContext
        {
            get { return _context ?? (_context = new BindingContext()); }
            set { _context = value; }
        }
        private ControlBindingsCollection _bindings;
        public ControlBindingsCollection DataBindings
        {
            get { return _bindings ?? (_bindings = new ControlBindingsCollection(this)); }
            set { _bindings = value; }
        }
    }
 
}
