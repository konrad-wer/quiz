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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            StyleApplier.ApplyName(this);
            StyleApplier.ApplyColors(this);
        }

        private void createQuizClick(object sender, EventArgs e)
        {
            this.Visible = false;
            var creator = new QuizCreator();
            creator.FormClosed += (s, ea) => this.Visible = true;
            creator.Show();
        }

        private void solveQuizClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Quiz(*.quiz)|*.quiz";
            dialog.Title = "Open quiz";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Visible = false;
                var window = new QuizWindow(dialog.FileName);
                window.FormClosed += (s, ea) => this.Visible = true;
                window.Show();
            }
        }

        private void settingsClick(object sender, EventArgs e)
        {
            this.Visible = false;
            var settings = new Settings();
            settings.FormClosed += (s, ea) =>
            {
                StyleApplier.Reload();
                StyleApplier.ApplyColors(this);
                StyleApplier.ApplyName(this);
                this.Visible = true;
            };
            settings.Show();
        }
    } 



}

