using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Services
{
    public class WpfFormDialogService : IDialogService 
    {
        public string ShowFolderDialog(object owner)
        {
            IWin32Window win32Window = owner as IWin32Window;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = win32Window != null ? dialog.ShowDialog(win32Window) : dialog.ShowDialog();

            return result == DialogResult.OK ? dialog.SelectedPath : string.Empty;
        }
    }
}
