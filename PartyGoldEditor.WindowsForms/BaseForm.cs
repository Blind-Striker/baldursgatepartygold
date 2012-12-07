using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Waf.Presentation.WinForms;
using System.Windows.Forms;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    public partial class BaseForm : Form
    {
        private readonly CommandAdapter _commandAdapter;

        protected CommandAdapter CommandAdapter { get { return _commandAdapter; } }

        public BaseForm()
        {
            //InitializeComponent();
            _commandAdapter = new CommandAdapter();
        }

        public void ShowDialog(object owner)
        {
            base.ShowDialog(owner as IWin32Window);
        }
    }
}
