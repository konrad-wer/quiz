namespace Quiz
{
    partial class Menu
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
            this.solveQuiz = new System.Windows.Forms.Button();
            this.createQuiz = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.signature = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // solveQuiz
            // 
            this.solveQuiz.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.solveQuiz.Location = new System.Drawing.Point(11, 12);
            this.solveQuiz.Name = "solveQuiz";
            this.solveQuiz.Size = new System.Drawing.Size(393, 89);
            this.solveQuiz.TabIndex = 0;
            this.solveQuiz.Text = "Solve quiz";
            this.solveQuiz.UseVisualStyleBackColor = true;
            this.solveQuiz.Click += new System.EventHandler(this.solveQuizClick);
            // 
            // createQuiz
            // 
            this.createQuiz.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.createQuiz.Location = new System.Drawing.Point(11, 118);
            this.createQuiz.Name = "createQuiz";
            this.createQuiz.Size = new System.Drawing.Size(393, 89);
            this.createQuiz.TabIndex = 0;
            this.createQuiz.Text = "Create a quiz";
            this.createQuiz.UseVisualStyleBackColor = true;
            this.createQuiz.Click += new System.EventHandler(this.createQuizClick);
            // 
            // settings
            // 
            this.settings.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.settings.Location = new System.Drawing.Point(11, 228);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(393, 89);
            this.settings.TabIndex = 0;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settingsClick);
            // 
            // signature
            // 
            this.signature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signature.AutoSize = true;
            this.signature.Font = new System.Drawing.Font("Calibri", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signature.Location = new System.Drawing.Point(12, 338);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(177, 17);
            this.signature.TabIndex = 1;
            this.signature.Text = "Created by Konrad Werbliński";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(417, 364);
            this.Controls.Add(this.signature);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.createQuiz);
            this.Controls.Add(this.solveQuiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Quiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button solveQuiz;
        private System.Windows.Forms.Button createQuiz;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Label signature;
    }
}

