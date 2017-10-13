using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class QuizWindow : Form
    {
        QuizWindowControler controler;
        Timer timer;

        public QuizWindow(string filePath)
        {
            InitializeComponent();

            controler = new QuizWindowControler(filePath);

            answerAButton.Click += (s, ea) => AnswerButtonClick(0);
            answerBButton.Click += (s, ea) => AnswerButtonClick(1);
            answerCButton.Click += (s, ea) => AnswerButtonClick(2);
            answerDButton.Click += (s, ea) => AnswerButtonClick(3);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += AnswerShowEnd;

            StyleApplier.ApplyName(this);
            StyleApplier.ApplyColors(splitContainer);
            StyleApplier.ApplyColors(splitContainer.Panel1);
            StyleApplier.ApplyColors(splitContainer.Panel2);

            LoadQuestion();
        }

        private void splitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            foreach (var b in new Button[] { answerAButton, answerBButton, answerCButton, answerDButton })
            {
                b.Height = splitContainer.Panel2.Height / 2 - 1;
                b.Width = splitContainer.Panel2.Width / 2 - 1;
            }

            answerBButton.Left = answerDButton.Left = splitContainer.Panel2.Width / 2;
            answerCButton.Top = answerDButton.Top = splitContainer.Panel2.Height / 2;
        }

        private void LoadQuestion()
        {
            foreach (var c in splitContainer.Panel1.Controls)
                if (c is QuestionViewer)
                    (c as QuestionViewer).Clear();

            splitContainer.Panel1.Controls.Clear();

            var q = controler.GetNextQuestion();

            if (q == null)
            {
                var scoreLabel = new Label
                {
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Text = "Your score:\n" + controler.Points + " / " + controler.QuestionsCount,
                    Font = new Font("Callbri", 20, FontStyle.Bold),
                };
                splitContainer.Panel1.Controls.Add(scoreLabel);
                splitContainer.Panel2.Controls.Clear();

                var quitButton = new Button
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Callbri", 15, FontStyle.Bold),
                    Text = "Back to menu",
                };

                quitButton.Click += (s, ea) => Close();
                splitContainer.Panel2.Controls.Add(quitButton);
                StyleApplier.ApplyColors(splitContainer.Panel2);

                return;
            }

            splitContainer.Panel1.Controls.Add(new QuestionViewer(q));
            answerAButton.Text = q[0];
            answerBButton.Text = q[1];
            answerCButton.Text = q[2];
            answerDButton.Text = q[3];

            foreach (var b in new Button[] { answerAButton, answerBButton, answerCButton, answerDButton })
            {
                b.Enabled = true;
                StyleApplier.ApplyColors(splitContainer.Panel2);
            }
        }

        private void AnswerButtonClick(int answer)
        {
            var answerButtons = new Button[] { answerAButton, answerBButton, answerCButton, answerDButton };
            for (int i = 0; i < 4; i++)
            {
                answerButtons[i].Enabled = false;
                if (controler.CheckAnswer(i))
                    answerButtons[i].BackColor = Color.Green;
            }

            if (controler.CheckAnswer(answer))
            {
                answerButtons[answer].BackColor = Color.Green;
                controler.AddPoint();
            }
            else
                answerButtons[answer].BackColor = Color.Red;
     
            timer.Start();
        }

        private void AnswerShowEnd(object sender, EventArgs ea)
        {
            (sender as Timer).Stop();
            if (this.Visible)
                LoadQuestion();
        }

        private void QuizWindowFormClosed(object sender, FormClosedEventArgs e)
        {
            controler.Clear();
            foreach (var c in splitContainer.Panel1.Controls)
                if (c is QuestionViewer)
                    (c as QuestionViewer).Clear();
        }
    }
}
