﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsEditTests.Models;

namespace WinFormsEditTests.UserControls
{
    public partial class UserControlMulti : UserControl
    {
        private readonly BindingSource _bs;

        public UserControlMulti(BindingSource bindingSource)
        {
            InitializeComponent();

            _bs = bindingSource ?? throw new ArgumentNullException(nameof(bindingSource));
            SetBindings();
        }

        private void SetBindings()
        {
            for (int i = 0; i < _bs.Count; i++)
            {
                //привязка текстбоксов
                var textBox = _panelMulti.Controls
                    .OfType<TextBox>().First(t => t.Name.EndsWith((i + 1).ToString()));
                textBox.DataBindings.Add("Text", _bs[i],
                   nameof(Answer.Value), true, DataSourceUpdateMode.OnPropertyChanged);

                //привязка чекбоксов
                var checkbox = _panelMulti.Controls
                    .OfType<CheckBox>().First(t => t.Name.EndsWith((i + 1).ToString()));
                checkbox.DataBindings.Add("Checked", _bs[i], nameof(Answer.IsCorrect));
            }
        }
    }
}