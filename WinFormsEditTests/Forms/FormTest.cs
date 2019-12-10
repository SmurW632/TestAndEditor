using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEditTests.Forms
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void _buttonX_Click(object sender, EventArgs e)
        {
            WelcomForm wf = new WelcomForm();
            wf.Show();
            Close();
        }

        private void _buttonX_MouseEnter(object sender, EventArgs e)
        {
            _buttonX.ForeColor = Color.FromArgb(22,47,78);
        }

        private void _buttonX_MouseLeave(object sender, EventArgs e)
        {
           _buttonX.ForeColor = Color.White;
        }
    }
}
