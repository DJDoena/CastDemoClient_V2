namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    partial class CastListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EditRowButton = new System.Windows.Forms.Button();
            this.AddEpisodeButton = new System.Windows.Forms.Button();
            this.AddCastButton = new System.Windows.Forms.Button();
            this.CastListView = new BrightIdeasSoftware.TreeListView();
            this.FirstNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.MiddleNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RoleColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.VoiceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CastIdColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.CastListView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditRowButton
            // 
            this.EditRowButton.Location = new System.Drawing.Point(761, 61);
            this.EditRowButton.Name = "EditRowButton";
            this.EditRowButton.Size = new System.Drawing.Size(105, 23);
            this.EditRowButton.TabIndex = 11;
            this.EditRowButton.Text = "Edit Row";
            this.EditRowButton.UseVisualStyleBackColor = true;
            this.EditRowButton.Click += new System.EventHandler(this.OnEditRowButtonClick);
            // 
            // AddEpisodeButton
            // 
            this.AddEpisodeButton.Location = new System.Drawing.Point(761, 32);
            this.AddEpisodeButton.Name = "AddEpisodeButton";
            this.AddEpisodeButton.Size = new System.Drawing.Size(105, 23);
            this.AddEpisodeButton.TabIndex = 10;
            this.AddEpisodeButton.Text = "Add Episode";
            this.AddEpisodeButton.UseVisualStyleBackColor = true;
            this.AddEpisodeButton.Click += new System.EventHandler(this.AddEpisodeButton_Click);
            // 
            // AddCastButton
            // 
            this.AddCastButton.Location = new System.Drawing.Point(761, 3);
            this.AddCastButton.Name = "AddCastButton";
            this.AddCastButton.Size = new System.Drawing.Size(105, 23);
            this.AddCastButton.TabIndex = 9;
            this.AddCastButton.Text = "Add Cast Member";
            this.AddCastButton.UseVisualStyleBackColor = true;
            this.AddCastButton.Click += new System.EventHandler(this.OnAddCastButtonClick);
            // 
            // CastListView
            // 
            this.CastListView.AllColumns.Add(this.FirstNameColumn);
            this.CastListView.AllColumns.Add(this.MiddleNameColumn);
            this.CastListView.AllColumns.Add(this.LastNameColumn);
            this.CastListView.AllColumns.Add(this.RoleColum);
            this.CastListView.AllColumns.Add(this.VoiceColumn);
            this.CastListView.AllColumns.Add(this.CastIdColumn);
            this.CastListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstNameColumn,
            this.MiddleNameColumn,
            this.LastNameColumn,
            this.RoleColum,
            this.VoiceColumn,
            this.CastIdColumn});
            this.CastListView.FullRowSelect = true;
            this.CastListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CastListView.Location = new System.Drawing.Point(3, 3);
            this.CastListView.Name = "CastListView";
            this.CastListView.OwnerDraw = true;
            this.CastListView.ShowGroups = false;
            this.CastListView.Size = new System.Drawing.Size(741, 309);
            this.CastListView.TabIndex = 8;
            this.CastListView.UseCompatibleStateImageBehavior = false;
            this.CastListView.View = System.Windows.Forms.View.Details;
            this.CastListView.VirtualMode = true;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.AspectName = "FirstName";
            this.FirstNameColumn.IsEditable = false;
            this.FirstNameColumn.Text = "FirstName";
            this.FirstNameColumn.Width = 150;
            // 
            // MiddleNameColumn
            // 
            this.MiddleNameColumn.AspectName = "MiddleName";
            this.MiddleNameColumn.IsEditable = false;
            this.MiddleNameColumn.Text = "Middle Name";
            this.MiddleNameColumn.Width = 150;
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.AspectName = "LastName";
            this.LastNameColumn.Text = "Last Name";
            this.LastNameColumn.Width = 150;
            // 
            // RoleColum
            // 
            this.RoleColum.AspectName = "Role";
            this.RoleColum.IsEditable = false;
            this.RoleColum.Text = "Role";
            this.RoleColum.Width = 150;
            // 
            // VoiceColumn
            // 
            this.VoiceColumn.AspectName = "Voice";
            this.VoiceColumn.CheckBoxes = true;
            this.VoiceColumn.IsEditable = false;
            this.VoiceColumn.Text = "Voice";
            // 
            // CastIdColumn
            // 
            this.CastIdColumn.AspectName = "CastId";
            this.CastIdColumn.Text = "Cast ID";
            // 
            // CastListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditRowButton);
            this.Controls.Add(this.AddEpisodeButton);
            this.Controls.Add(this.AddCastButton);
            this.Controls.Add(this.CastListView);
            this.Name = "CastListControl";
            this.Size = new System.Drawing.Size(874, 329);
            this.Load += new System.EventHandler(this.CastListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CastListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditRowButton;
        private System.Windows.Forms.Button AddEpisodeButton;
        private System.Windows.Forms.Button AddCastButton;
        private BrightIdeasSoftware.OLVColumn FirstNameColumn;
        private BrightIdeasSoftware.OLVColumn MiddleNameColumn;
        private BrightIdeasSoftware.OLVColumn LastNameColumn;
        private BrightIdeasSoftware.OLVColumn RoleColum;
        private BrightIdeasSoftware.OLVColumn VoiceColumn;
        private BrightIdeasSoftware.OLVColumn CastIdColumn;
        internal BrightIdeasSoftware.TreeListView CastListView;
    }
}
