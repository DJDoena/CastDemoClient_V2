namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    partial class LoginForm
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
            this.AbortButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameTexBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(93, 254);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 18;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.OnAbortButtonClick);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 254);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 17;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Please enter a User Name. This is just for testing purposes. It does not need to " +
    "be your Invelos User Name. Just make somthing up. ;-)";
            // 
            // UserNameTexBox
            // 
            this.UserNameTexBox.Location = new System.Drawing.Point(81, 25);
            this.UserNameTexBox.Name = "UserNameTexBox";
            this.UserNameTexBox.Size = new System.Drawing.Size(215, 20);
            this.UserNameTexBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "User Name:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 289);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNameTexBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.OKButton);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNameTexBox;
        private System.Windows.Forms.Label label2;
    }
}