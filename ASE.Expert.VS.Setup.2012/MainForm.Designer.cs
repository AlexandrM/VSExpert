namespace ASE.Expert.VS.Setup._2012
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
            this.cbVS2005 = new System.Windows.Forms.CheckBox();
            this.cbVS2008 = new System.Windows.Forms.CheckBox();
            this.cbVS2010 = new System.Windows.Forms.CheckBox();
            this.cbVS2012 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbVS2005
            // 
            this.cbVS2005.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbVS2005.Location = new System.Drawing.Point(0, 0);
            this.cbVS2005.Name = "cbVS2005";
            this.cbVS2005.Size = new System.Drawing.Size(225, 50);
            this.cbVS2005.TabIndex = 0;
            this.cbVS2005.Tag = "2005";
            this.cbVS2005.Text = "Enable in Visual Studio 2005";
            this.cbVS2005.UseVisualStyleBackColor = true;
            this.cbVS2005.CheckedChanged += new System.EventHandler(this.cbVS2005_CheckedChanged);
            // 
            // cbVS2008
            // 
            this.cbVS2008.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbVS2008.Location = new System.Drawing.Point(0, 50);
            this.cbVS2008.Name = "cbVS2008";
            this.cbVS2008.Size = new System.Drawing.Size(225, 50);
            this.cbVS2008.TabIndex = 1;
            this.cbVS2008.Tag = "2008";
            this.cbVS2008.Text = "Enable in Visual Studio 2008";
            this.cbVS2008.UseVisualStyleBackColor = true;
            this.cbVS2008.CheckedChanged += new System.EventHandler(this.cbVS2005_CheckedChanged);
            // 
            // cbVS2010
            // 
            this.cbVS2010.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbVS2010.Location = new System.Drawing.Point(0, 100);
            this.cbVS2010.Name = "cbVS2010";
            this.cbVS2010.Size = new System.Drawing.Size(225, 50);
            this.cbVS2010.TabIndex = 2;
            this.cbVS2010.Tag = "2010";
            this.cbVS2010.Text = "Enable in Visual Studio 2010";
            this.cbVS2010.UseVisualStyleBackColor = true;
            this.cbVS2010.CheckedChanged += new System.EventHandler(this.cbVS2005_CheckedChanged);
            // 
            // cbVS2012
            // 
            this.cbVS2012.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbVS2012.Location = new System.Drawing.Point(0, 150);
            this.cbVS2012.Name = "cbVS2012";
            this.cbVS2012.Size = new System.Drawing.Size(225, 50);
            this.cbVS2012.TabIndex = 3;
            this.cbVS2012.Tag = "2012";
            this.cbVS2012.Text = "Enable in Visual Studio 2012";
            this.cbVS2012.UseVisualStyleBackColor = true;
            this.cbVS2012.CheckedChanged += new System.EventHandler(this.cbVS2005_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 354);
            this.Controls.Add(this.cbVS2012);
            this.Controls.Add(this.cbVS2010);
            this.Controls.Add(this.cbVS2008);
            this.Controls.Add(this.cbVS2005);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy setup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbVS2005;
        private System.Windows.Forms.CheckBox cbVS2008;
        private System.Windows.Forms.CheckBox cbVS2010;
        private System.Windows.Forms.CheckBox cbVS2012;
    }
}

