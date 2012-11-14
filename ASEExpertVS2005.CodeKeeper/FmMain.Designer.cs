namespace ASEExpertVS2005.CodeKeeper
{
    partial class FmMain
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btSave = new Stimulsoft.Controls.StiButton();
            this.btOk = new Stimulsoft.Controls.StiButton();
            this.btCancel = new Stimulsoft.Controls.StiButton();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.list = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRenameCode = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveCode = new System.Windows.Forms.ToolStripMenuItem();
            this.edFilter = new Stimulsoft.Controls.StiTextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.edCode = new Rsdn.Scintilla.ScintillaEditor();
            this.pnlLang = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLanguage = new Stimulsoft.Controls.StiComboBox();
            this.tree = new Stimulsoft.Controls.StiTreeView();
            this.cmTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.stiMenuProvider = new Stimulsoft.Controls.StiMenuProvider();
            this.pnlCode = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlButtons.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.cmGrid.SuspendLayout();
            this.pnlLang.SuspendLayout();
            this.cmTree.SuspendLayout();
            this.pnlCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btSave);
            this.pnlButtons.Controls.Add(this.btOk);
            this.pnlButtons.Controls.Add(this.btCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 535);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(778, 31);
            this.pnlButtons.TabIndex = 5;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(313, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(150, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Visible = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(469, 3);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(150, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "&Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(625, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(150, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.splitter2);
            this.pnlFilter.Controls.Add(this.list);
            this.pnlFilter.Controls.Add(this.edFilter);
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(778, 115);
            this.pnlFilter.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 39);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 76);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.AllowUserToResizeColumns = false;
            this.list.AllowUserToResizeRows = false;
            this.list.BackgroundColor = System.Drawing.SystemColors.Window;
            this.list.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.list.ColumnHeadersVisible = false;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName});
            this.list.ContextMenuStrip = this.cmGrid;
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.list.EnableHeadersVisualStyles = false;
            this.list.Location = new System.Drawing.Point(0, 39);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.list.RowTemplate.ReadOnly = true;
            this.list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.list.ShowCellErrors = false;
            this.list.ShowCellToolTips = false;
            this.list.ShowEditingIcon = false;
            this.list.ShowRowErrors = false;
            this.list.Size = new System.Drawing.Size(778, 76);
            this.list.StandardTab = true;
            this.list.TabIndex = 1;
            this.list.CurrentCellChanged += new System.EventHandler(this.list_CurrentCellChanged);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            this.list.DataSourceChanged += new System.EventHandler(this.list_DataSourceChanged);
            this.list.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.list_RowStateChanged);
            // 
            // cName
            // 
            this.cName.DataPropertyName = "name";
            this.cName.Frozen = true;
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmGrid
            // 
            this.cmGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRenameCode,
            this.miRemoveCode});
            this.cmGrid.Name = "cmTree";
            this.cmGrid.Size = new System.Drawing.Size(125, 48);
            // 
            // miRenameCode
            // 
            this.miRenameCode.Name = "miRenameCode";
            this.miRenameCode.Size = new System.Drawing.Size(124, 22);
            this.miRenameCode.Text = "Re&name";
            this.miRenameCode.Click += new System.EventHandler(this.miRenameCode_Click);
            // 
            // miRemoveCode
            // 
            this.miRemoveCode.Name = "miRemoveCode";
            this.miRemoveCode.Size = new System.Drawing.Size(124, 22);
            this.miRemoveCode.Text = "&Remove";
            this.miRemoveCode.Click += new System.EventHandler(this.miRemoveCode_Click);
            // 
            // edFilter
            // 
            this.edFilter.AcceptsReturn = true;
            this.edFilter.AcceptsTab = true;
            this.edFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.edFilter.Location = new System.Drawing.Point(0, 19);
            this.edFilter.Name = "edFilter";
            this.edFilter.Size = new System.Drawing.Size(778, 20);
            this.edFilter.TabIndex = 0;
            this.edFilter.TextChanged += new System.EventHandler(this.edFilter_TextChanged);
            this.edFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edFilter_KeyDown);
            // 
            // lblFilter
            // 
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilter.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFilter.Location = new System.Drawing.Point(0, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(778, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Only \'Name\' filter. \'Name + Code\' filter press <F5>";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edCode
            // 
            this.edCode.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.edCode.CaretLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.edCode.CaretPosition = 0;
            this.edCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edCode.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.edCode.Lexer = Rsdn.Scintilla.SciLexer.CPlusPlus;
            this.edCode.Location = new System.Drawing.Point(0, 23);
            this.edCode.Name = "edCode";
            this.edCode.Size = new System.Drawing.Size(589, 394);
            this.edCode.TabIndex = 5;
            this.edCode.Leave += new System.EventHandler(this.edCode_Leave);
            this.edCode.Enter += new System.EventHandler(this.edCode_Enter);
            // 
            // pnlLang
            // 
            this.pnlLang.Controls.Add(this.label2);
            this.pnlLang.Controls.Add(this.cbLanguage);
            this.pnlLang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLang.Location = new System.Drawing.Point(0, 0);
            this.pnlLang.Name = "pnlLang";
            this.pnlLang.Size = new System.Drawing.Size(589, 23);
            this.pnlLang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Language:";
            // 
            // cbLanguage
            // 
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(73, 0);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbLanguage.TabIndex = 1;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLexer_SelectedIndexChanged);
            // 
            // tree
            // 
            this.tree.ContextMenuStrip = this.cmTree;
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(0, 118);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(186, 417);
            this.tree.TabIndex = 2;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_MouseDown);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            this.tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_KeyDown);
            // 
            // cmTree
            // 
            this.cmTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.renameGroupToolStripMenuItem,
            this.removeGroupToolStripMenuItem});
            this.cmTree.Name = "cmTree";
            this.cmTree.Size = new System.Drawing.Size(156, 70);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addGroupToolStripMenuItem.Text = "&Add group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // renameGroupToolStripMenuItem
            // 
            this.renameGroupToolStripMenuItem.Name = "renameGroupToolStripMenuItem";
            this.renameGroupToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.renameGroupToolStripMenuItem.Text = "Re&name group";
            this.renameGroupToolStripMenuItem.Click += new System.EventHandler(this.renameGroupToolStripMenuItem_Click);
            // 
            // removeGroupToolStripMenuItem
            // 
            this.removeGroupToolStripMenuItem.Name = "removeGroupToolStripMenuItem";
            this.removeGroupToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.removeGroupToolStripMenuItem.Text = "&Remove group";
            this.removeGroupToolStripMenuItem.Click += new System.EventHandler(this.removeGToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitter1.Location = new System.Drawing.Point(186, 118);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 417);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // stiMenuProvider
            // 
            this.stiMenuProvider.Font = new System.Drawing.Font("Arial", 8F);
            // 
            // pnlCode
            // 
            this.pnlCode.Controls.Add(this.edCode);
            this.pnlCode.Controls.Add(this.pnlLang);
            this.pnlCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCode.Location = new System.Drawing.Point(189, 118);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.Size = new System.Drawing.Size(589, 417);
            this.pnlCode.TabIndex = 9;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 115);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(778, 3);
            this.splitter3.TabIndex = 10;
            this.splitter3.TabStop = false;
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(778, 566);
            this.Controls.Add(this.pnlCode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASE Expert VS 2005 - Code Keeper";
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            this.pnlButtons.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.cmGrid.ResumeLayout(false);
            this.pnlLang.ResumeLayout(false);
            this.pnlLang.PerformLayout();
            this.cmTree.ResumeLayout(false);
            this.pnlCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private Stimulsoft.Controls.StiButton btOk;
        private Stimulsoft.Controls.StiButton btCancel;
        private System.Windows.Forms.Panel pnlFilter;
        private Stimulsoft.Controls.StiTextBox edFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlLang;
        private Stimulsoft.Controls.StiButton btSave;
        private System.Windows.Forms.Label label2;
        private Stimulsoft.Controls.StiComboBox cbLanguage;
        private Stimulsoft.Controls.StiTreeView tree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip cmTree;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private Stimulsoft.Controls.StiMenuProvider stiMenuProvider;
        private System.Windows.Forms.ToolStripMenuItem removeGroupToolStripMenuItem;
        private System.Windows.Forms.Panel pnlCode;
        private Rsdn.Scintilla.ScintillaEditor edCode;
        private System.Windows.Forms.ToolStripMenuItem renameGroupToolStripMenuItem;
        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.ContextMenuStrip cmGrid;
        private System.Windows.Forms.ToolStripMenuItem miRenameCode;
        private System.Windows.Forms.ToolStripMenuItem miRemoveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
    }
}