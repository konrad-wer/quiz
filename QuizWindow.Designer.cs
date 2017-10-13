namespace Quiz
{
    partial class QuizWindow
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.answerCButton = new System.Windows.Forms.Button();
            this.answerDButton = new System.Windows.Forms.Button();
            this.answerBButton = new System.Windows.Forms.Button();
            this.answerAButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer.Panel2.Controls.Add(this.answerCButton);
            this.splitContainer.Panel2.Controls.Add(this.answerDButton);
            this.splitContainer.Panel2.Controls.Add(this.answerBButton);
            this.splitContainer.Panel2.Controls.Add(this.answerAButton);
            this.splitContainer.Panel2.SizeChanged += new System.EventHandler(this.splitContainer_Panel2_SizeChanged);
            this.splitContainer.Size = new System.Drawing.Size(1124, 738);
            this.splitContainer.SplitterDistance = 503;
            this.splitContainer.TabIndex = 0;
            // 
            // AnswerCButton
            // 
            this.answerCButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.answerCButton.BackColor = System.Drawing.SystemColors.Control;
            this.answerCButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerCButton.Location = new System.Drawing.Point(3, 116);
            this.answerCButton.Name = "AnswerCButton";
            this.answerCButton.Size = new System.Drawing.Size(557, 112);
            this.answerCButton.TabIndex = 3;
            this.answerCButton.UseVisualStyleBackColor = false;
            // 
            // AnswerDButton
            // 
            this.answerDButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.answerDButton.BackColor = System.Drawing.SystemColors.Control;
            this.answerDButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerDButton.Location = new System.Drawing.Point(564, 116);
            this.answerDButton.Name = "AnswerDButton";
            this.answerDButton.Size = new System.Drawing.Size(557, 112);
            this.answerDButton.TabIndex = 2;
            this.answerDButton.UseVisualStyleBackColor = false;
            // 
            // AnswerBButton
            // 
            this.answerBButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBButton.BackColor = System.Drawing.SystemColors.Control;
            this.answerBButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerBButton.Location = new System.Drawing.Point(564, 3);
            this.answerBButton.Name = "AnswerBButton";
            this.answerBButton.Size = new System.Drawing.Size(557, 112);
            this.answerBButton.TabIndex = 1;
            this.answerBButton.UseVisualStyleBackColor = false;
            // 
            // AnswerAButton
            // 
            this.answerAButton.BackColor = System.Drawing.SystemColors.Control;
            this.answerAButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerAButton.Location = new System.Drawing.Point(3, 3);
            this.answerAButton.Name = "AnswerAButton";
            this.answerAButton.Size = new System.Drawing.Size(557, 112);
            this.answerAButton.TabIndex = 0;
            this.answerAButton.UseVisualStyleBackColor = false;
            // 
            // QuizWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 738);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "QuizWindow";
            this.Text = "QuizWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuizWindowFormClosed);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button answerAButton;
        private System.Windows.Forms.Button answerCButton;
        private System.Windows.Forms.Button answerDButton;
        private System.Windows.Forms.Button answerBButton;
    }
}