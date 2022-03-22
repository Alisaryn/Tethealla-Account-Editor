
namespace Tethealla_Account_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.accountNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.globalGMs = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(321, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuAddAccount,
            this.mnuSave,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(142, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuAddAccount
            // 
            this.mnuAddAccount.Enabled = false;
            this.mnuAddAccount.Name = "mnuAddAccount";
            this.mnuAddAccount.Size = new System.Drawing.Size(142, 22);
            this.mnuAddAccount.Text = "Add account";
            this.mnuAddAccount.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Enabled = false;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(142, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(142, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.AllowUserToDeleteRows = false;
            this.dataTable.AllowUserToResizeColumns = false;
            this.dataTable.AllowUserToResizeRows = false;
            this.dataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountNames,
            this.gcNumbers,
            this.globalGMs});
            this.dataTable.Enabled = false;
            this.dataTable.Location = new System.Drawing.Point(10, 32);
            this.dataTable.Name = "dataTable";
            this.dataTable.RowHeadersVisible = false;
            this.dataTable.RowTemplate.Height = 25;
            this.dataTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTable.ShowCellToolTips = false;
            this.dataTable.Size = new System.Drawing.Size(302, 173);
            this.dataTable.TabIndex = 2;
            this.dataTable.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataTable_CurrentCellDirtyStateChanged);
            this.dataTable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataTable_EditingControlShowing);
            // 
            // accountNames
            // 
            this.accountNames.HeaderText = "Account name";
            this.accountNames.MaxInputLength = 16;
            this.accountNames.Name = "accountNames";
            this.accountNames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.accountNames.Width = 125;
            // 
            // gcNumbers
            // 
            this.gcNumbers.HeaderText = "GC#";
            this.gcNumbers.MaxInputLength = 10;
            this.gcNumbers.Name = "gcNumbers";
            this.gcNumbers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gcNumbers.Width = 75;
            // 
            // globalGMs
            // 
            this.globalGMs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.globalGMs.HeaderText = "Global GM?";
            this.globalGMs.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.globalGMs.Name = "globalGMs";
            this.globalGMs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 214);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tethealla account.dat Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.ToolStripMenuItem mnuAddAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcNumbers;
        private System.Windows.Forms.DataGridViewComboBoxColumn globalGMs;
    }
}

