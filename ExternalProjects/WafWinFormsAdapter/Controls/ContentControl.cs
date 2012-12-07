using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace System.Waf.Presentation.WinForms.Controls
{
    [Designer(typeof(ContentControl.ContentControlDesigner), typeof(IDesigner))]
    [Docking(DockingBehavior.Ask)]
    [ToolboxBitmap(typeof(Panel))]
    public class ContentControl : Panel
    {
        private Control content;


        [Bindable(true), DefaultValue((object)null), Category("Data")]
        public object Content
        {
            get { return content; }
            set
            {
                Control control = value as Control;

                if (content == control) { return; }

                Controls.Clear();

                content = control;

                Controls.Add(content);
                content.Dock = DockStyle.Fill;
                OnContentChanged(EventArgs.Empty);
            }
        }

        protected override Padding DefaultMargin
        {
            get { return Padding.Empty; }
        }


        public event EventHandler ContentChanged;


        protected virtual void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null) { ContentChanged(this, e); }
        }


        private class ContentControlDesigner : ControlDesigner
        {
            protected override void OnPaintAdornments(PaintEventArgs paint)
            {
                Bitmap bitmap = new Bitmap(Control.Width, Control.Height);
                Graphics graphics = Graphics.FromImage(bitmap);

                using (Pen pen = new Pen(Control.ForeColor))
                {
                    pen.DashStyle = DashStyle.Dash;

                    Rectangle deck = new Rectangle(0, 0, Control.Width - 1, Control.Height - 1);
                    graphics.DrawRectangle(pen, deck);
                }

                paint.Graphics.DrawImage(bitmap, 0, 0);
            }

            protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
            {
                base.OnGiveFeedback(new GiveFeedbackEventArgs(DragDropEffects.None, e.UseDefaultCursors));
            }

            protected override void OnDragDrop(DragEventArgs de)
            {
                // Do not allow drops.
            }
        }
    }
}
