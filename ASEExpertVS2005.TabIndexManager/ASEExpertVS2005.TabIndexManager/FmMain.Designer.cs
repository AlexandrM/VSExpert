namespace ASEExpertVS2005.TabIndexManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new Stimulsoft.Controls.StiButton();
            this.btOk = new Stimulsoft.Controls.StiButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDown = new Stimulsoft.Controls.StiButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btUp = new Stimulsoft.Controls.StiButton();
            this.list = new System.Windows.Forms.ListView();
            this.colControl = new System.Windows.Forms.ColumnHeader();
            this.colText = new System.Windows.Forms.ColumnHeader();
            this.colTabIndex = new System.Windows.Forms.ColumnHeader();
            this.btOrder = new Stimulsoft.Controls.StiButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 33);
            this.panel1.TabIndex = 2;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(334, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(200, 6);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(120, 23);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "&Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btOrder);
            this.panel2.Controls.Add(this.btDown);
            this.panel2.Controls.Add(this.btUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 63);
            this.panel2.TabIndex = 3;
            // 
            // btDown
            // 
            this.btDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDown.ImageIndex = 1;
            this.btDown.ImageList = this.imageList;
            this.btDown.Location = new System.Drawing.Point(12, 32);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(143, 23);
            this.btDown.TabIndex = 1;
            this.btDown.TabStop = false;
            this.btDown.Text = "Down <Ctrl+Down>";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "arrowup_green16_h.bmp");
            this.imageList.Images.SetKeyName(1, "arrowdown_green16_h.bmp");
            // 
            // btUp
            // 
            this.btUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUp.ImageIndex = 0;
            this.btUp.ImageList = this.imageList;
            this.btUp.Location = new System.Drawing.Point(12, 3);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(143, 23);
            this.btUp.TabIndex = 0;
            this.btUp.TabStop = false;
            this.btUp.Text = "Up <Ctrl+Up>";
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // list
            // 
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colControl,
            this.colText,
            this.colTabIndex});
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.list.FullRowSelect = true;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list.Location = new System.Drawing.Point(0, 63);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(457, 393);
            this.list.SmallImageList = this.imageList;
            this.list.TabIndex = 0;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.list_DrawColumnHeader);
            this.list.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.list_DrawItem);
            this.list.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.list_DrawSubItem);
            // 
            // colControl
            // 
            this.colControl.Text = "Control";
            this.colControl.Width = 250;
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 100;
            // 
            // colTabIndex
            // 
            this.colTabIndex.Text = "TabIndex";
            this.colTabIndex.Width = 100;
            // 
            // btOrder
            // 
            this.btOrder.Location = new System.Drawing.Point(254, 32);
            this.btOrder.Name = "btOrder";
            this.btOrder.Size = new System.Drawing.Size(191, 23);
            this.btOrder.TabIndex = 2;
            this.btOrder.Text = "&Automatic order";
            this.btOrder.UseVisualStyleBackColor = true;
            this.btOrder.Click += new System.EventHandler(this.btOrder_Click);
            // 
            // FmMain
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(457, 489);
            this.Controls.Add(this.list);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tab Index manager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FmMain_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Stimulsoft.Controls.StiButton btCancel;
        private Stimulsoft.Controls.StiButton btOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.ColumnHeader colControl;
        private System.Windows.Forms.ColumnHeader colTabIndex;
        private Stimulsoft.Controls.StiButton btDown;
        private Stimulsoft.Controls.StiButton btUp;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader colText;
        private Stimulsoft.Controls.StiButton btOrder;

    }
}