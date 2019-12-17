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
using WinFormsEditTests.UserControls;

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
            _buttonNext.Click += ButtonNext_Click;
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
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
            LoadQuestions();
        }

        /// <summary>
        /// Загрузка вопросов текущего задания
        /// </summary>
        private void LoadQuestions()
        {
            _bsQuestions.Clear();
            var currentChallenge = _bsChallenges.Current as Challenge;
            currentChallenge.Questions.ForEach(q => _bsQuestions.Add(q));
            LoadAnswers();
        }

        /// <summary>
        /// Загрузка ответов к текущему вопросу
        /// </summary>
        private void LoadAnswers()
        {
            var currentQuestion = _bsQuestions.Current as Question;
            var bs = new BindingSource();
            bs.DataSource = currentQuestion.Answers;

            UserControl uc = new UserControl();
            if (currentQuestion.Type == QuestionType.SingleSelect)
            {
                uc = new UserControlSingle(bs);
            }
            else
            {
                uc = new UserControlMulti(bs);
            }
            _panel.Controls.Clear();
            _panel.Controls.Add(uc);
        }

        /// <summary>
        /// Кнопка Дальше
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (_bsChallenges.Count == 0)
            {
                var message = "Сначала откройте файл заданий";
                var caption = "Сообщение";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenNextQuestion();
        }

        /// <summary>
        /// Открытие следующего вопроса из текущего задания
        /// </summary>
        private void OpenNextQuestion()
        {
            var prevPosition = _bsQuestions.Position;
            _bsQuestions.MoveNext();
            if (prevPosition == _bsQuestions.Position)
            {
                OpenNextChallenge();
            }
            LoadAnswers();
        }

        /// <summary>
        /// Открытие следующего задания из текущего файла
        /// </summary>
        private void OpenNextChallenge()
        {
            var prevPosition = _bsChallenges.Position;
            _bsChallenges.MoveNext();
            if (prevPosition == _bsChallenges.Position)
            {
                ShowTestResults();
                return;
            }
            LoadQuestions();
        }

        /// <summary>
        /// Отображение результатов прохождения всех заданий
        /// из текущего файла
        /// </summary>
        private void ShowTestResults()
        {
            var message = "Поздравляю вы прошли все задания!";
            var caption = "Последнее задание пройдено";
            MessageBox.Show(message, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
