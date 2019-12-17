namespace WinFormsEditTests.Forms
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.panel1 = new System.Windows.Forms.Panel();
            this._buttonX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._labelQTitle = new System.Windows.Forms.Label();
            this._labelCounter = new System.Windows.Forms.Label();
            this._buttonNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._panel = new System.Windows.Forms.Panel();
            this._textBoxQuestion = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this._labelChallenge = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this._buttonX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 41);
            this.panel1.TabIndex = 0;
            // 
            // _buttonX
            // 
            this._buttonX.AutoSize = true;
            this._buttonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(43)))));
            this._buttonX.Cursor = System.Windows.Forms.Cursors.Hand;
            this._buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._buttonX.ForeColor = System.Drawing.Color.White;
            this._buttonX.Location = new System.Drawing.Point(735, 4);
            this._buttonX.Name = "_buttonX";
            this._buttonX.Size = new System.Drawing.Size(24, 24);
            this._buttonX.TabIndex = 7;
            this._buttonX.Text = "X";
            this._buttonX.Click += new System.EventHandler(this._buttonX_Click);
            this._buttonX.MouseEnter += new System.EventHandler(this._buttonX_MouseEnter);
            this._buttonX.MouseLeave += new System.EventHandler(this._buttonX_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тест";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._labelQTitle);
            this.panel2.Controls.Add(this._labelChallenge);
            this.panel2.Controls.Add(this._labelCounter);
            this.panel2.Controls.Add(this._buttonNext);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._panel);
            this.panel2.Controls.Add(this._textBoxQuestion);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 581);
            this.panel2.TabIndex = 1;
            // 
            // _labelQTitle
            // 
            this._labelQTitle.AutoSize = true;
            this._labelQTitle.Location = new System.Drawing.Point(361, 60);
            this._labelQTitle.Name = "_labelQTitle";
            this._labelQTitle.Size = new System.Drawing.Size(35, 13);
            this._labelQTitle.TabIndex = 20;
            this._labelQTitle.Text = "label5";
            // 
            // _labelCounter
            // 
            this._labelCounter.AutoSize = true;
            this._labelCounter.Location = new System.Drawing.Point(84, 59);
            this._labelCounter.Name = "_labelCounter";
            this._labelCounter.Size = new System.Drawing.Size(35, 13);
            this._labelCounter.TabIndex = 19;
            this._labelCounter.Text = "label5";
            // 
            // _buttonNext
            // 
            this._buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this._buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._buttonNext.ForeColor = System.Drawing.Color.White;
            this._buttonNext.Location = new System.Drawing.Point(282, 538);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(210, 30);
            this._buttonNext.TabIndex = 18;
            this._buttonNext.Text = "Дальше";
            this._buttonNext.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Выбирите ? из ? вариантов ответа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(237, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Наименование:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Вопрос: ";
            // 
            // _panel
            // 
            this._panel.Location = new System.Drawing.Point(12, 203);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(744, 329);
            this._panel.TabIndex = 14;
            // 
            // _textBoxQuestion
            // 
            this._textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._textBoxQuestion.Location = new System.Drawing.Point(12, 89);
            this._textBoxQuestion.Multiline = true;
            this._textBoxQuestion.Name = "_textBoxQuestion";
            this._textBoxQuestion.Size = new System.Drawing.Size(744, 85);
            this._textBoxQuestion.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilsToolStripMenuItem,
            this.тестToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FilsToolStripMenuItem
            // 
            this.FilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this.toolStripSeparator1,
            this._exitToolStripMenuItem});
            this.FilsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.FilsToolStripMenuItem.Name = "FilsToolStripMenuItem";
            this.FilsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.FilsToolStripMenuItem.Text = "&Файл";
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this._openToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this._openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_openToolStripMenuItem.Image")));
            this._openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._openToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this._openToolStripMenuItem.Text = "&Открыть";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this._exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this._exitToolStripMenuItem.Text = "Вы&ход";
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.тестToolStripMenuItem.Text = "&Тест";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.HelpToolStripMenuItem.Text = "Спра&вка";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.AboutToolStripMenuItem.Text = "&О программе...";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "XML files (*.xml)|*.xml";
            this._openFileDialog.InitialDirectory = "\"c:\\\\\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Задание: ";
            // 
            // _labelChallenge
            // 
            this._labelChallenge.AutoSize = true;
            this._labelChallenge.Location = new System.Drawing.Point(94, 39);
            this._labelChallenge.Name = "_labelChallenge";
            this._labelChallenge.Size = new System.Drawing.Size(35, 13);
            this._labelChallenge.TabIndex = 19;
            this._labelChallenge.Text = "label5";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(47)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(768, 654);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTest";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _textBoxQuestion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.Label _buttonX;
        private System.Windows.Forms.Button _buttonNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _labelQTitle;
        private System.Windows.Forms.Label _labelCounter;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.Label _labelChallenge;
        private System.Windows.Forms.Label label5;
    }
}