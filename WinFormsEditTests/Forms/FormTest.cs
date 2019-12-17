using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsEditTests.Data;

namespace WinFormsEditTests.Forms
{
    public partial class FormTest : Form
    {
        private DataContext _data;

        public FormTest()
        {
            InitializeComponent();

            _openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
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

        /// <summary>
        /// Меню-Файл-Открыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            _data = new DataContext(_openFileDialog.FileName);
        }
    }
}
