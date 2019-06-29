using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliveHookManager
{
    public partial class FixedFloatHelper : Form
    {
        public FixedFloatHelper()
        {
            InitializeComponent();
        }

        private void textBox_RawHex_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(textBox_RawHex.Text, System.Globalization.NumberStyles.HexNumber, null, out value))
            {
                textBox_RawInt.Text = value.ToString();
                textBox_ResultFloat.Text = (value / (float)0x10000).ToString();
            }
        }

        private void textBox_RawInt_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(textBox_RawInt.Text, System.Globalization.NumberStyles.Any, null, out value))
            {
                textBox_RawHex.Text = value.ToString("X");
                textBox_ResultFloat.Text = (value / (float)0x10000).ToString();
            }
        }

        private void textBox_ResultFloat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
