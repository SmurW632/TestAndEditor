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
    public partial class WelcomForm : Form
    {
        public WelcomForm()
        {
            InitializeComponent();
        }
        

        private void label2_MouseEnter(object sender, EventArgs e)
        {
           label2.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
           label2.ForeColor = Color.White;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            fm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTest ft = new FormTest();
            ft.Show();
            Hide();
        }
    }
}
