﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WinFormsEditTests.Data;
using WinFormsEditTests.Models;
using WinFormsEditTests.UserControls;

namespace WinFormsEditTests.Forms
{
    public partial class FormMain : Form
    {
        //контекст данных приложения
        private readonly DataContext _data;
        //для определения типа ноды кот.выделили
        private const string _Challenge_Node_Name = "Challenge";
        private const string _Question_Node_Name = "Question";
        //текущее задание и вопрос
        private Challenge _currentChallenge; 
        private Question _currentQuestion;
        //список типов вопросов
        private List<QuestionTypeView> _types;
        //источники привязок
        private BindingSource _bsQuestion;
        private BindingSource _bsAnswers;
        

        public FormMain()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Редактор тестов";

            //инициализация контекста данных
            _data = new DataContext("Data/challenges.xml");
            //привязки
            SetBindings();

            //подписка на события
            this.Load += FormMain_Load;
            _treeView.AfterSelect += TreeView_AfterSelect;
            _buttonSave.Click += ButtonSave_Click;
            _buttonQuestionAdd.Click += ButtonQuestionAdd_Click;
            _buttonQuestionDelete.Click += ButtonQuestionDelete_Click;
            _buttonChallengeAdd.Click += ButtonChallengeAdd_Click;
            _buttonChallengeDelete.Click += ButtonChallengeDelete_Click;
            _buttonX.Click += ButtonClose_Click;
            _buttonX.MouseEnter += ButtonClose_MouseEnter;
            _buttonX.MouseLeave += ButtonClose_MouseLeave;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            _buttonX.ForeColor = Color.White;
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            _buttonX.ForeColor = Color.FromArgb(22,47, 78);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            WelcomForm wf = new WelcomForm();
            wf.Show();
            Close();
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            //вопрос
            _bsQuestion = new BindingSource();
            _bsQuestion.DataSource = typeof(Question);
            //текстбоксы
            _textBoxTitle.DataBindings.Add("Text", _bsQuestion,
                nameof(Question.Title), true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxQuestion.DataBindings.Add("Text", _bsQuestion,
                nameof(Question.Value), true, DataSourceUpdateMode.OnPropertyChanged);
            _numericScore.DataBindings.Add("Value", _bsQuestion,
                nameof(Question.Score), true, DataSourceUpdateMode.OnPropertyChanged);

            //варианты ответов
            _bsAnswers = new BindingSource();
            _bsAnswers.DataSource = typeof(List<Answer>);
        }

        /// <summary>
        /// Форма загружена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            SetComboBox();
            LoadChallenges();
        }

        /// <summary>
        /// Заполнение Комбобокса
        /// </summary>
        private void SetComboBox()
        {
            //комбобокс типов
            _types = QuestionTypeView.GetListTypes();
            _types.ForEach(t => _comboBoxType.Items.Add(t.Name));
        }

        /// <summary>
        /// Загрузка списка заданий
        /// </summary>
        private void LoadChallenges()
        {
            //читаем файл заданий
            var challenges = _data.GetAll();
            if (challenges.Count > 0)
            {
                _currentChallenge = challenges[0];
                ShowChallenges(challenges);
            }
        }

        /// <summary>
        /// Отображение заданий в TreeView
        /// </summary>
        /// <param name="challenges">список задач</param>
        private void ShowChallenges(List<Challenge> challenges)
        {
            //очищаем ранее отображаемое
            _treeView.Nodes.Clear();
            _currentQuestion = new Question(QuestionType.None);
            _bsQuestion.DataSource = new Question(QuestionType.None);
            _panel.Controls.Clear();

            foreach (Challenge challenge in challenges)
            {
                //создаем ноду задачи
                var node = new TreeNode(challenge.Name);
                node.Name = challenge.Name;
                node.Tag = _Challenge_Node_Name;
                foreach (Question question in challenge.Questions)
                {
                    //создаем ноду вопроса
                    var subNode = new TreeNode(question.Title);
                    subNode.Name = question.Title;
                    subNode.Tag = _Question_Node_Name;
                    //добавляем в ноду задачи ноду вопроса
                    node.Nodes.Add(subNode);
                }
                //добавляем ноду задачи в дерево
                _treeView.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Выбрана нода в TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.ToString().Equals(_Challenge_Node_Name))
            {
                //получаем из контекста задание
                _currentChallenge = _data.GetChallenge(e.Node.Name);
                //убираем вопрос
                _bsQuestion.DataSource = new Question(QuestionType.None);
                _panel.Controls.Clear();
                return;
            }

            //извелкаем имена нод
            var challengeName = e.Node.Parent.Name;
            var questionName = e.Node.Name;
            //получаем из контекста задание
            _currentChallenge = _data.GetChallenge(challengeName);
            //получаем из контекста нужный вопрос
            _currentQuestion = _data.GetQuestion(challengeName, questionName);
            _bsQuestion.DataSource = _currentQuestion;
            _bsAnswers.DataSource = _currentQuestion.Answers;
            //отображаем этот вопрос
            ShowQuestion(_currentQuestion.Type);
        }

        /// <summary>
        /// Отобразить вопрос
        /// </summary>
        /// <param name="question">экземпляр вопроса</param>
        private void ShowQuestion(QuestionType type)
        {
            _panel.Controls.Clear();

            UserControl uc = new UserControl();
            if (type == QuestionType.SingleSelect)
            {
                uc = new UserControlSingle(_bsAnswers);
                label5.Text = "Выбирите правильный ответ";
            }
            if (type == QuestionType.MultipleSelect)
            {
                uc = new UserControlMulti(_bsAnswers);
                label5.Text = "Выбирите правильные ответы";
            }

            _panel.Controls.Add(uc);
        }

        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentQuestion.Type == QuestionType.None)
                    return;

                //сохраняем в файл
                _data.Save();
                //перезагружаем задания
                LoadChallenges();
            }
            catch (Exception ex){ MessageBox.Show("Создайте вопрос и введите содержимое",ex.Message); }
        }
        
        /// <summary>
        /// Кнопка Вопрос добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuestionAdd_Click(object sender, EventArgs e)
        {
            if (_currentChallenge is null)
                return;

            //получаем выбранный тип вопроса
            var selection = _comboBoxType.SelectedItem?.ToString();
            if (selection is null)
            {
                var message = "Выберите тип вопроса.";
                MessageBox.Show(message, "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var type = _types.First(t => t.Name.Equals(selection)).Type;

            //новый вопрос добавляем в текущее задание
            var qTitle = "Новый вопрос";
            var question = GetNewQuestion(type, qTitle);
            _currentChallenge.Questions.Add(question);

            //запоминаем имя текущего задания
            var challengeName = _currentChallenge.Name;
            //перезагружаем задания
            LoadChallenges();
            SelectAddedNode(qTitle, challengeName);
        }

        /// <summary>
        /// Создание нового вопроса для добавления
        /// </summary>
        /// <param name="title">заголовок для вопроса</param>
        /// <returns>экземпляр вопроса</returns>
        private Question GetNewQuestion(QuestionType type, string title)
        {
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < 6; i++)
            {
                answers.Add(new Answer());
            }

            var result = new Question(type);
            result.Answers.AddRange(answers);
            result.Title = title;

            return result;
        }

        /// <summary>
        /// Выделение только что добавленной ноды вопроса
        /// </summary>
        /// <param name="title">заголовок вопроса</param>
        /// <param name="challengeName">имя задания</param>
        private void SelectAddedNode(string title, string challengeName)
        {
            //находим прежнюю ноду задания по названию
            var nodeChallenge = _treeView.Nodes.Find(challengeName, false).First();
            //находим ноду только что созданного вопроса и выделяем его
            var node = nodeChallenge.Nodes.Find(title, false).First();
            _treeView.SelectedNode = node;
            //выделяем текстбокс названия вопроса
            _textBoxTitle.Focus();
            _textBoxTitle.SelectAll();
        }

        /// <summary>
        /// Кнопка Вопрос удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuestionDelete_Click(object sender, EventArgs e)
        {
            if (_currentQuestion is null || _currentQuestion.Type == QuestionType.None)
                return;

            var isAgreed = UserAgreedDeleteQuestion();
            if (!isAgreed) return;
            //удаляем
            _currentChallenge.Questions.Remove(_currentQuestion);
            //сохраняем в файл
            _data.Save();
            //перезагружаем задания
            LoadChallenges();
        }

        /// <summary>
        /// Получение разрешения на удаление вопроса
        /// </summary>
        /// <returns>true если согласен</returns>
        private bool UserAgreedDeleteQuestion()
        {
            var message = $"Вы согласны удалить {_currentQuestion.Title}?";
            var caption = "Запрос на удаление вопроса";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = DialogResult.Yes;

            return result == MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Получение разрешения на удаление задания
        /// </summary>
        /// <returns>true если согласен</returns>
        private bool UserAgreedDeleteChallenge()
        {
            var message = $"Вы согласны удалить { _currentChallenge.Name}?";
            var caption = "Запрос на удаление задания";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = DialogResult.Yes;

            return result == MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Кнопка Добавить задание
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChallengeAdd_Click(object sender, EventArgs e)
        {
            var str = "Наименование задания";
            var form = new FormChallenge();
            form.Owner = this;
            form.ChallengeName = str;
            if (form.ShowDialog() != DialogResult.OK)
                return;

            if (String.IsNullOrWhiteSpace(form.ChallengeName)
                || form.ChallengeName.Equals(str))
            {
                var message = "Для создания нового задания \nнеобходимо ввести его наименование.";
                MessageBox.Show(message, "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var challenge = new Challenge();
            challenge.Name = form.ChallengeName;

            //coхраняем в файл
            _data.AddChallenge(challenge);
            //перезагружаем задания
            LoadChallenges();
        }
        /// <summary>
        /// Кнопка Задание удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChallengeDelete_Click(object sender, EventArgs e)
        {
            if (_currentChallenge is null)
                return;

            var isAgreed = UserAgreedDeleteChallenge();
            if (!isAgreed) return;
            //удаляем
            _data.GetAll().Remove(_currentChallenge);
            _treeView.Nodes.Remove(_treeView.SelectedNode);
            //сохраняем в файл
            _data.Save();
            //перезагружаем задания
            LoadChallenges();
        }


        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Копировать
            if (_textBoxTitle.SelectionLength > 0)
                _textBoxTitle.Copy();
            if (_textBoxQuestion.SelectionLength > 0)
                _textBoxQuestion.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вырезать
            if (_textBoxTitle.SelectionLength > 0)
            {
                _textBoxTitle.Cut();
            }
            if (_textBoxQuestion.SelectionLength > 0)
            {
                _textBoxQuestion.Cut();
            }
                
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вставить
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) && _textBoxTitle.Focused)
            {
                _textBoxTitle.Paste();
            }
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) && _textBoxQuestion.Focused)
            {
                _textBoxQuestion.Paste();
            }

        }

        private void selectedAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Выделить все
            if (_textBoxTitle.TextLength > 0)
            {
                _textBoxTitle.SelectAll();
            }
            if (_textBoxQuestion.TextLength > 0)
            {
                _textBoxQuestion.SelectAll();
            }
        }

        private void DeletetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Удалить
            if (_textBoxTitle.TextLength > 0)
            {
                _textBoxTitle.Clear();
            }
            if (_textBoxQuestion.TextLength > 0)
            {
                _textBoxQuestion.Clear();
            }
        }

        private void UpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Обновить
            LoadChallenges();
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создать новый файл
            var createFile = File.Create("Data/new_file.xml");
        }

        private void SaveKakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сохранить как...
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //сохранить 
        }
    }
}