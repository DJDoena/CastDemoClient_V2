namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    partial class MainForm
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
            this.UpcTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.ContributeButton = new System.Windows.Forms.Button();
            this.CastListControl = new DoenaSoft.DVDProfiler.CastDemoClient_V2.CastListControl();
            this.SuspendLayout();
            // 
            // UpcTextBox
            // 
            this.UpcTextBox.Location = new System.Drawing.Point(83, 12);
            this.UpcTextBox.MaxLength = 15;
            this.UpcTextBox.Name = "UpcTextBox";
            this.UpcTextBox.ReadOnly = true;
            this.UpcTextBox.Size = new System.Drawing.Size(355, 20);
            this.UpcTextBox.TabIndex = 3;
            this.UpcTextBox.Text = "5014437868237";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UPC / EAN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(83, 38);
            this.TitleTextBox.MaxLength = 100;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.ReadOnly = true;
            this.TitleTextBox.Size = new System.Drawing.Size(355, 20);
            this.TitleTextBox.TabIndex = 5;
            this.TitleTextBox.Text = "MacGuyver: The Complete First Season";
            // 
            // ContributeButton
            // 
            this.ContributeButton.Image = global::DoenaSoft.DVDProfiler.CastDemoClient_V2.Properties.Resources.star16;
            this.ContributeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ContributeButton.Location = new System.Drawing.Point(675, 399);
            this.ContributeButton.Name = "ContributeButton";
            this.ContributeButton.Size = new System.Drawing.Size(82, 23);
            this.ContributeButton.TabIndex = 8;
            this.ContributeButton.Text = "Contribute";
            this.ContributeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ContributeButton.UseVisualStyleBackColor = true;
            this.ContributeButton.Click += new System.EventHandler(this.OnContributeButtonClick);
            // 
            // CastListControl
            // 
            this.CastListControl.Location = new System.Drawing.Point(12, 64);
            this.CastListControl.Name = "CastListControl";
            this.CastListControl.Size = new System.Drawing.Size(874, 329);
            this.CastListControl.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 465);
            this.Controls.Add(this.ContributeButton);
            this.Controls.Add(this.CastListControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpcTextBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UpcTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleTextBox;
        private CastListControl CastListControl;
        private System.Windows.Forms.Button ContributeButton;
    }
}

