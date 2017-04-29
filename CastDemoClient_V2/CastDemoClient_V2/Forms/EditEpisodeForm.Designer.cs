namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    partial class EditEpisodeForm
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
            this.CastListControl = new DoenaSoft.DVDProfiler.CastDemoClient_V2.CastListControl();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.AbortButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // castListControl1
            // 
            this.CastListControl.Location = new System.Drawing.Point(12, 64);
            this.CastListControl.Name = "castListControl1";
            this.CastListControl.Size = new System.Drawing.Size(874, 329);
            this.CastListControl.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Episode Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(103, 38);
            this.TitleTextBox.MaxLength = 100;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(355, 20);
            this.TitleTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Episode Number:";
            // 
            // NumbertextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(103, 12);
            this.NumberTextBox.MaxLength = 15;
            this.NumberTextBox.Name = "NumbertextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(355, 20);
            this.NumberTextBox.TabIndex = 8;
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(93, 418);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 18;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.OnAbortButtonClick);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 418);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 17;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // EditEpisodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 453);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CastListControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberTextBox);
            this.Name = "EditEpisodeForm";
            this.Text = "EditEpisodeForm";
            this.Load += new System.EventHandler(this.OnEditEpisodeFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CastListControl CastListControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button OKButton;
    }
}