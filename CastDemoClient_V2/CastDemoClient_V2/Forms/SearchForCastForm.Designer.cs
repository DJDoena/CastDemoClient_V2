namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    partial class SearchForCastForm
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
            this.components = new System.ComponentModel.Container();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchResultsView = new BrightIdeasSoftware.TreeListView();
            this.FirstNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.MiddleNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TitleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProdYearColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CreditedAsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.SelectCastMemberButton = new System.Windows.Forms.Button();
            this.CreateNewIdButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsView)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(59, 14);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(441, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name: ";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(506, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.OnSearchButtonClick);
            // 
            // SearchResultsView
            // 
            this.SearchResultsView.AllColumns.Add(this.FirstNameColumn);
            this.SearchResultsView.AllColumns.Add(this.MiddleNameColumn);
            this.SearchResultsView.AllColumns.Add(this.LastNameColumn);
            this.SearchResultsView.AllColumns.Add(this.TitleColumn);
            this.SearchResultsView.AllColumns.Add(this.ProdYearColumn);
            this.SearchResultsView.AllColumns.Add(this.CreditedAsColumn);
            this.SearchResultsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstNameColumn,
            this.MiddleNameColumn,
            this.LastNameColumn,
            this.TitleColumn,
            this.ProdYearColumn,
            this.CreditedAsColumn});
            this.SearchResultsView.FullRowSelect = true;
            this.SearchResultsView.Location = new System.Drawing.Point(12, 40);
            this.SearchResultsView.Name = "SearchResultsView";
            this.SearchResultsView.OwnerDraw = true;
            this.SearchResultsView.ShowGroups = false;
            this.SearchResultsView.Size = new System.Drawing.Size(974, 345);
            this.SearchResultsView.TabIndex = 3;
            this.SearchResultsView.UseCompatibleStateImageBehavior = false;
            this.SearchResultsView.View = System.Windows.Forms.View.Details;
            this.SearchResultsView.VirtualMode = true;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.AspectName = "FirstName";
            this.FirstNameColumn.IsEditable = false;
            this.FirstNameColumn.Text = "First Name";
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
            this.LastNameColumn.IsEditable = false;
            this.LastNameColumn.Text = "Last Name";
            this.LastNameColumn.Width = 150;
            // 
            // TitleColumn
            // 
            this.TitleColumn.AspectName = "Title";
            this.TitleColumn.IsEditable = false;
            this.TitleColumn.Text = "Title";
            this.TitleColumn.Width = 250;
            // 
            // ProdYearColumn
            // 
            this.ProdYearColumn.AspectName = "ProductionYear";
            this.ProdYearColumn.IsEditable = false;
            this.ProdYearColumn.Text = "Prod. Year";
            this.ProdYearColumn.Width = 70;
            // 
            // CreditedAsColumn
            // 
            this.CreditedAsColumn.AspectName = "CreditedAs";
            this.CreditedAsColumn.IsEditable = false;
            this.CreditedAsColumn.Text = "Credited As";
            this.CreditedAsColumn.Width = 200;
            // 
            // SelectCastMemberButton
            // 
            this.SelectCastMemberButton.Location = new System.Drawing.Point(992, 40);
            this.SelectCastMemberButton.Name = "SelectCastMemberButton";
            this.SelectCastMemberButton.Size = new System.Drawing.Size(137, 23);
            this.SelectCastMemberButton.TabIndex = 4;
            this.SelectCastMemberButton.Text = "Select Cast Member";
            this.SelectCastMemberButton.UseVisualStyleBackColor = true;
            this.SelectCastMemberButton.Click += new System.EventHandler(this.OnSelectCastMemberButtonClick);
            // 
            // CreateNewIdButton
            // 
            this.CreateNewIdButton.Location = new System.Drawing.Point(992, 69);
            this.CreateNewIdButton.Name = "CreateNewIdButton";
            this.CreateNewIdButton.Size = new System.Drawing.Size(137, 23);
            this.CreateNewIdButton.TabIndex = 5;
            this.CreateNewIdButton.Text = "Create New ID";
            this.CreateNewIdButton.UseVisualStyleBackColor = true;
            this.CreateNewIdButton.Click += new System.EventHandler(this.OnCreateNewIdButtonClick);
            // 
            // SearchForCastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 472);
            this.Controls.Add(this.CreateNewIdButton);
            this.Controls.Add(this.SelectCastMemberButton);
            this.Controls.Add(this.SearchResultsView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTextBox);
            this.Name = "SearchForCastForm";
            this.Text = "SearchForCastForm";
            this.Load += new System.EventHandler(this.OnSearchForCastFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchButton;
        private BrightIdeasSoftware.TreeListView SearchResultsView;
        private BrightIdeasSoftware.OLVColumn FirstNameColumn;
        private BrightIdeasSoftware.OLVColumn MiddleNameColumn;
        private BrightIdeasSoftware.OLVColumn LastNameColumn;
        private BrightIdeasSoftware.OLVColumn TitleColumn;
        private BrightIdeasSoftware.OLVColumn ProdYearColumn;
        private BrightIdeasSoftware.OLVColumn CreditedAsColumn;
        private System.Windows.Forms.Button SelectCastMemberButton;
        private System.Windows.Forms.Button CreateNewIdButton;
    }
}