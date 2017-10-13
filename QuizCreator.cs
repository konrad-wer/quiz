using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace Quiz
{
    public partial class QuizCreator : Form
    {
        class EntryInterface
        {
            public Action<string> SetQuestion;
            public Action<int, string> SetAnswer;
            public Action<int> SetRight;
            public Action<string> SetFilepath;

            public EntryInterface(Action<string> SetQuestion, Action<int, string> SetAnswer, Action<int> SetRight, Action<string> SetFilepath)
            {
                this.SetQuestion = SetQuestion;
                this.SetAnswer = SetAnswer;
                this.SetRight = SetRight;
                this.SetFilepath = SetFilepath;
            }
        }

        List<EntryInterface> entries;
        QuizCreatorControler controler;
        ToolTip filePathInfo;
        private static int entryHeight = 200;


        public QuizCreator()
        {
            InitializeComponent();
            controler = new QuizCreatorControler();
            filePathInfo = new ToolTip { IsBalloon = true };
            entries = new List<EntryInterface>();

            StyleApplier.ApplyColors(mainPanel);
        }

        private void addQuestionClick(object sender, EventArgs e)
        {
            int vx = mainPanel.AutoScrollPosition.X;
            int vy = mainPanel.AutoScrollPosition.Y;

            int textBoxWidth = 200;
            int leftStart = 40;
            int topStart = 20;

            var questionPanel = new Panel
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Height = entryHeight,
                Width = mainPanel.Width,
                Top = controler.QuestionCount * entryHeight + vy

            };
            mainPanel.Controls.Add(questionPanel);

            //Creating object in controler
            QuizCreatorQuestion question = controler.AddQuestion();

            #region Quit Button

            var quitButton = new Button
            {
                Top = 10,
                Left = 10,
                Height = 20,
                Width = 20,
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "X",
                Cursor = Cursors.Hand,
                ForeColor = Color.Black
            };

            quitButton.Click += (s, ea) => removePanel(quitButton.Parent as Panel);
            quitButton.Click += (s, ea) => controler.RemoveQuestion(question);
            questionPanel.Controls.Add(quitButton);

            #endregion
            #region Question

            var questionLabel = new Label
            {
                Top = topStart,
                Left = leftStart,
                Height = 20,
                Text = "Question"
            };
            questionPanel.Controls.Add(questionLabel);

            var questionTextBox = new RichTextBox
            {
                Top = topStart + 20,
                Left = leftStart,
                Height = entryHeight - 40 - topStart,
                Width = textBoxWidth,
                ForeColor = Color.Black
            };

            questionTextBox.TextChanged += (s, ea) => question.Question = (s as RichTextBox).Text;
            questionPanel.Controls.Add(questionTextBox);

            #endregion
            #region Answers

            var answerTextBoxes = new RichTextBox[4];

            for (int i = 0; i < 4; i++)
            {
                var answerLabel = new Label
                {
                    Top = topStart,
                    Left = leftStart + (i + 1) * (textBoxWidth + 10),
                    Height = 20,
                    Text = "Answer " + (char)('a' + i)
                };
                questionPanel.Controls.Add(answerLabel);

                answerTextBoxes[i] = new RichTextBox
                {
                    Top = topStart + 20,
                    Left = leftStart + (i + 1) * (textBoxWidth + 10),
                    Height = entryHeight - 40 - topStart,
                    Width = 200,
                    ForeColor = Color.Black
                };

                int index = i;
                answerTextBoxes[i].TextChanged += (s, ea) => question[index] = (s as RichTextBox).Text;
                questionPanel.Controls.Add(answerTextBoxes[i]);

            }

            #endregion
            #region Add Multimedia Button

            var addMultimediaButton = new Button
            {
                Left = leftStart + 5 * (textBoxWidth + 10),
                Top = topStart + 20,
                Height = 30,
                Width = 150,
                Text = "Add multimedia",
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Green,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };


            questionPanel.Controls.Add(addMultimediaButton);

            #endregion
            #region Multimedia Label

            var multimediaLabel = new Label
            {
                Left = leftStart + 5 * (textBoxWidth + 10) + addMultimediaButton.Width + 10,
                Top = topStart + 20,
                Height = 30,
                Width = 40,
                Text = "None",
                TextAlign = ContentAlignment.MiddleCenter
            };
            questionPanel.Controls.Add(multimediaLabel);
            filePathInfo.SetToolTip(multimediaLabel, "No file selected");

            #endregion
            addMultimediaButton.Click += (s, ea) => AddMultimedia(question, multimediaLabel);
            #region Remove Multimedia Button

            var RemoveMultimediaButton = new Button
            {
                Left = leftStart + 5 * (textBoxWidth + 10) + addMultimediaButton.Width + multimediaLabel.Width + 15,
                Top = topStart + 20,
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "X",
                Cursor = Cursors.Hand,
                Height = 30,
                Width = 30,
                ForeColor = Color.Black
            };

            questionPanel.Controls.Add(RemoveMultimediaButton);
            RemoveMultimediaButton.Click += (s, ea) => RemoveMultimedia(question, multimediaLabel);

            #endregion
            #region Right answers radio buttons
            var answerRadioButtons = new RadioButton[4];
            for (int i = 0; i < 4; i++)
            {
                var index = i;
                answerRadioButtons[i] = new RadioButton
                {
                    Left = leftStart + 5 * (textBoxWidth + 10),
                    Top = addMultimediaButton.Top + addMultimediaButton.Height + 10 + i * (20),
                    Text = "Answer " + (char)('a' + i) + " is correct.",
                    Width = 150,
                    Checked = i == 0
                };
                questionPanel.Controls.Add(answerRadioButtons[i]);
                answerRadioButtons[i].CheckedChanged += (s, ea) => { if ((s as RadioButton).Checked) question.RightAnswerIndex = index; };
            }

            #endregion
            #region Make entry inrerface

            Action<string> setQuestion = (text) => questionTextBox.Text = text;
            Action<int, string> setAnswer = (index, text) => answerTextBoxes[index].Text = text;
            Action<int> setRight = (index) => answerRadioButtons[index].Checked = true;
            Action<string> setFilePath = (filepath) =>
            {
                question.FilePath = filepath;
                if (filepath != "")
                {
                    if (File.Exists(filepath))
                    {
                        multimediaLabel.Text = "Ok";
                        question.Multimedia = true;
                        filePathInfo.SetToolTip(multimediaLabel, filepath);
                    }
                    else
                    {
                        multimediaLabel.Text = "Error";
                        question.Multimedia = false;
                        filePathInfo.SetToolTip(multimediaLabel, "File does not exist");
                    }
                }
                else
                {
                    question.Multimedia = false;
                    filePathInfo.SetToolTip(multimediaLabel, "No file selected");
                    multimediaLabel.Text = "None";
                }

            };
            var entry = new EntryInterface(setQuestion, setAnswer, setRight, setFilePath);
            entries.Add(entry);

            quitButton.Click += (s, ea) => entries.Remove(entry);

            #endregion

        }

        private void removePanel(Panel panel)
        {
            int vy = mainPanel.VerticalScroll.Value;
            var lastPosition = mainPanel.AutoScrollPosition;

            mainPanel.Controls.Remove(panel);


            for (int i = 0; i < mainPanel.Controls.Count; i++)
                mainPanel.Controls[i].Top = i * entryHeight + mainPanel.AutoScrollPosition.Y;

            mainPanel.VerticalScroll.Value = vy;
            mainPanel.AutoScrollPosition = new Point(mainPanel.AutoScrollPosition.X, vy);
        }

        private void AddMultimedia(QuizCreatorQuestion question, Label multimediaLabel)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "All Files | *.bmp; *.jpg; *.jpeg; *.png; *.tif; *.tiff; *.wav|" +
                "Image Files(*.bmp; *.jpg; *.jpeg; *.png; *.tif; *.tiff)| *.bmp; *.jpg; *.jpeg; *.png; *.tif; *.tiff| Sound files(*.wav) | *.wav";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                question.FilePath = dialog.FileName;
                question.Multimedia = true;
                multimediaLabel.Text = "Ok";
                filePathInfo.SetToolTip(multimediaLabel, dialog.FileName);

            }
        }

        private void Clear()
        {
            filePathInfo.RemoveAll();
            entries.Clear();
            mainPanel.Controls.Clear();
            controler.Clear();
        }

        private void RemoveMultimedia(QuizCreatorQuestion question, Label multimediaLabel)
        {
            question.FilePath = "";
            question.Multimedia = false;
            multimediaLabel.Text = "None";
            filePathInfo.SetToolTip(multimediaLabel, "No file selected");
        }

        private void saveQuizClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Quiz(*.quiz)|*.quiz";
            dialog.Title = "Save quiz";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                controler.SaveAsQuiz(dialog.FileName);
                if (projectFilePath.Text != "")
                    controler.SaveAsProject(projectFilePath.Text);
            }
        }

        private void saveProjectClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Quiz project (*.quizproj)|*.quizproj";
            dialog.Title = "Save project";

            if (projectFilePath.Text == "")
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    controler.SaveAsProject(dialog.FileName);
                    projectFilePath.Text = dialog.FileName;
                }
            }
            else
                controler.SaveAsProject(projectFilePath.Text);

        }

        private void openProjectClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Quiz project (*.quizproj)|*.quizproj";
            dialog.Title = "Open project";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Clear();
                projectFilePath.Text = dialog.FileName;

                foreach (var entry in XDocument.Load(dialog.FileName).Descendants("entry"))
                {
                    addQuestionClick(null, null);

                    var entryInterface = entries.Last();
                    entryInterface.SetQuestion(entry.Element("question").Value);

                    entryInterface.SetAnswer(0, entry.Element("ansA").Value);
                    entryInterface.SetAnswer(1, entry.Element("ansB").Value);
                    entryInterface.SetAnswer(2, entry.Element("ansC").Value);
                    entryInterface.SetAnswer(3, entry.Element("ansD").Value);

                    entryInterface.SetRight(int.Parse(entry.Element("right").Value));

                    if (entry.Element("multimedia").Value == "true")
                        entryInterface.SetFilepath(entry.Element("filepath").Value);
                }
            }
        }

        private void newProjectClick(object sender, EventArgs e)
        {
            Clear();
            projectFilePath.Text = "";
        }
    }
}
