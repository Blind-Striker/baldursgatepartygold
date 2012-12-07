using System.ComponentModel.Composition;
using System.Globalization;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows;
using System.Windows.Forms;

namespace System.Waf.Presentation.WinForms.Services
{
    [Export(typeof(IMessageService))]
    public class MessageService : IMessageService
    {
        private static MessageBoxOptions MessageBoxOptions
        {
            get
            {
                return (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft) ? MessageBoxOptions.RtlReading : MessageBoxOptions.DefaultDesktopOnly;
            }
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="owner">The window that owns this Message Window.</param>
        /// <param name="message">The message.</param>
        public void ShowMessage(object owner, string message)
        {
            IWin32Window win32Window = owner as IWin32Window;
            if (win32Window != null)
            {
                MessageBox.Show(win32Window, message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
            else
            {
                MessageBox.Show(message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
        }

        /// <summary>
        /// Shows the message as warning.
        /// </summary>
        /// <param name="owner">The window that owns this Message Window.</param>
        /// <param name="message">The message.</param>
        public void ShowWarning(object owner, string message)
        {
            IWin32Window win32Window = owner as IWin32Window;
            if (win32Window != null)
            {
                MessageBox.Show(win32Window, message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
            else
            {
                MessageBox.Show(message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
        }

        /// <summary>
        /// Shows the message as error.
        /// </summary>
        /// <param name="owner">The window that owns this Message Window.</param>
        /// <param name="message">The message.</param>
        public void ShowError(object owner, string message)
        {
            IWin32Window win32Window = owner as IWin32Window;
            if (win32Window != null)
            {
                MessageBox.Show(win32Window, message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
            else
            {
                MessageBox.Show(message, ApplicationInfo.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
        }

        /// <summary>
        /// Shows the specified question.
        /// </summary>
        /// <param name="owner">The window that owns this Message Window.</param>
        /// <param name="message">The question.</param>
        /// <returns><c>true</c> for yes, <c>false</c> for no and <c>null</c> for cancel.</returns>
        public bool? ShowQuestion(object owner, string message)
        {
            IWin32Window win32Window = owner as IWin32Window;
            DialogResult result;
            if (win32Window != null)
            {
                result = MessageBox.Show(win32Window, message, ApplicationInfo.ProductName,
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
            else
            {
                result = MessageBox.Show(message, ApplicationInfo.ProductName, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }

            if (result == DialogResult.Yes) { return true; }
            if (result == DialogResult.No) { return false; }

            return null;
        }

        /// <summary>
        /// Shows the specified yes/no question.
        /// </summary>
        /// <param name="owner">The window that owns this Message Window.</param>
        /// <param name="message">The question.</param>
        /// <returns><c>true</c> for yes and <c>false</c> for no.</returns>
        public bool ShowYesNoQuestion(object owner, string message)
        {
            IWin32Window win32Window = owner as IWin32Window;
            DialogResult result;
            if (win32Window != null)
            {
                result = MessageBox.Show(win32Window, message, ApplicationInfo.ProductName, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }
            else
            {
                result = MessageBox.Show(message, ApplicationInfo.ProductName, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions);
            }

            return result == DialogResult.Yes;
        }
    }
}
