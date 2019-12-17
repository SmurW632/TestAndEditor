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
using WinFormsEditTests.Models;

namespace WinFormsEditTests.Forms
{
    public partial class FormTest : Form
    {
        private DataContext _data;
        private BindingSource _bsChallenges;
        private BindingSource _bsQuestions;

        public FormTest()
        {
            InitializeComponent();

            SetBindings();

            _openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
        }

        private void SetBindings()
        {
            _bsChallenges = new BindingSource();
            _bsChallenges.DataSource = typeof(List<Challenge>);
            _labelChallenge.DataBindings.Add("Text", _bsChallenges, nameof(Challenge.Name));

            _bsQuestions = new BindingSource();
            _bsQuestions.DataSource = typeof(List<Question>);
            _labelQTitle.DataBindings.Add("Text", _bsQuestions, nameof(Question.Title));
            _textBoxQuestion.DataBindings.Add("Text", _bsQuestions, nameof(Question.Value));
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
            var challenges = _data.GetAll();

            _bsChallenges.Clear();
            challenges.ForEach(c => _bsChallenges.Add(c));

            _bsQuestions.Clear();
            var currentChallenge = _bsChallenges.Current as Challenge;
            currentChallenge.Questions.ForEach(q => _bsQuestions.Add(q));
        }
    }
}
