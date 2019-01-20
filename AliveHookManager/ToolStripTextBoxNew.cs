using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliveHookManager
{
    class ToolStripTextBoxNew : ToolStripTextBox
    {
        public ToolStripTextBoxNew()
        {
            Enter += ToolStripTextBoxNew_Enter;
            Leave += ToolStripTextBoxNew_Leave;
            this.Paint += ToolStripTextBoxNew_Paint;
            mPlaceholderShowing = (Text == "");
        }

        private void ToolStripTextBoxNew_Paint(object sender, PaintEventArgs e)
        {
            if (mPlaceholderShowing)
            {
                base.Text = Placeholder;
                base.ForeColor = Color.Gray;
            }
            else
            {
                base.ForeColor = Color.Black;
            }
        }

        private void ToolStripTextBoxNew_Leave(object sender, EventArgs e)
        {
            if (base.Text == "")
            {
                mPlaceholderShowing = true;
                base.Text = Placeholder;
            }
        }

        private void ToolStripTextBoxNew_Enter(object sender, EventArgs e)
        {
            if (mPlaceholderShowing == true)
            {
                mPlaceholderShowing = false;
                Text = "";
            }
        }

        bool mPlaceholderShowing = false;

        public override string Text { get => (mPlaceholderShowing) ? "" : base.Text; set => base.Text = value; }
        public string Placeholder { get; set; }
    }
}
