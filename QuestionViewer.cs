using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Quiz
{
    //one for every kind of question
    class QuestionViewer : Panel
    {
        string text;
        Label textLabel;
        Question question;

        public QuestionViewer(Question q)
        {
            question = q;
            text = question.GetQuestion();
            Dock = DockStyle.Fill;
            StyleApplier.ApplyColors(this);

            textLabel = new Label
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Text = text,
                Font = new Font("Callbri", 11, FontStyle.Bold),
            };

            if (question is ImageQuestion)
            {
                var splitContainer = new SplitContainer { IsSplitterFixed = true };
                splitContainer.Orientation = Orientation.Horizontal;
                splitContainer.Dock = DockStyle.Fill;
                splitContainer.SizeChanged += (s, ea) => splitContainer.SplitterDistance = 100;
                splitContainer.Panel1.Controls.Add(textLabel);
                splitContainer.Panel1.Controls.Add(new Button { Text = "" });  //now the spliter does not catch focus
                splitContainer.Panel1.AutoScroll = true;
                splitContainer.Panel2.Controls.Add(new PictureBox { Image = (question as ImageQuestion).Image, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom });
                this.Controls.Add(splitContainer);
            }
            else if (question is SoundQuestion)
            {
                var playButton = new Button
                {
                    Width = 120,
                    Height = 40,
                    Text = "Play sound",
                    BackColor = Color.Green,
                    Font = new Font("Callbri", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Popup,
                    ForeColor = Color.Black
                };

                var stopButton = new Button
                {
                    Width = 120,
                    Height = 40,
                    Text = "Stop",
                    BackColor = Color.Red,
                    Font = new Font("Callbri", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Popup,
                    ForeColor = Color.Black
                };
            
                playButton.Click += (s, ea) => (question as SoundQuestion).Play();
                stopButton.Click += (s, ea) => (question as SoundQuestion).Stop();

                var splitContainer = new SplitContainer { IsSplitterFixed = true };
                splitContainer.Orientation = Orientation.Horizontal;
                splitContainer.Dock = DockStyle.Fill;
                splitContainer.SizeChanged += (s, ea) => splitContainer.SplitterDistance = 80;
                splitContainer.Panel1.Controls.Add(playButton);
                splitContainer.Panel1.Controls.Add(stopButton);

                splitContainer.Panel1.SizeChanged += (s, ea) =>
                {
                    playButton.Left = (splitContainer.Panel1.Width) / 2 - playButton.Width - 10;
                    playButton.Top = (splitContainer.Panel1.Height - playButton.Height) / 2;

                    stopButton.Left = (splitContainer.Panel1.Width) / 2 + 10;
                    stopButton.Top = (splitContainer.Panel1.Height - stopButton.Height) / 2;
                };

                splitContainer.Panel2.Controls.Add(textLabel);
                splitContainer.Panel2.AutoScroll = true;
                this.Controls.Add(splitContainer);
            }
            else
                this.Controls.Add(textLabel);
        }

        public void Clear()
        {
            if (question is SoundQuestion) 
                (question as SoundQuestion).Stop();
        }



    }
}
