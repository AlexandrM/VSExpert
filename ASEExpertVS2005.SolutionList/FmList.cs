using System;
using Extensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using Microsoft.Win32;

using EnvDTE;
using EnvDTE80;

//using ASE.VS.Core;
using ASEExpertVS2005;

namespace ASEExpertVS2005.SolutionList
{
	/// <summary>
	/// Summary description for FmList.
	/// </summary>
	public class FmList : System.Windows.Forms.Form
	{
		private bool _onlyOpenned = false;
        private Stimulsoft.Controls.StiTextBox textBox;
		private System.Windows.Forms.Label label1;
        private ASEExpertVS2005.ASListView listView;
		private System.Windows.Forms.ColumnHeader lvcolProject;
		private System.Windows.Forms.ColumnHeader lvcolFile;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel panel1;
        private Stimulsoft.Controls.StiButton btClose;
        private Stimulsoft.Controls.StiButton btCancel;
        private Stimulsoft.Controls.StiButton btOk;
        private Stimulsoft.Controls.StiButton btOnlyOpenned;
        private Stimulsoft.Controls.StiCheckBox cbSaveOnlyOppened;
		private System.ComponentModel.IContainer components;

		public FmList()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmList));
            this.textBox = new Stimulsoft.Controls.StiTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView = new ASEExpertVS2005.ASListView();
            this.lvcolProject = new System.Windows.Forms.ColumnHeader();
            this.lvcolFile = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSaveOnlyOppened = new Stimulsoft.Controls.StiCheckBox();
            this.btOnlyOpenned = new Stimulsoft.Controls.StiButton();
            this.btClose = new Stimulsoft.Controls.StiButton();
            this.btCancel = new Stimulsoft.Controls.StiButton();
            this.btOk = new Stimulsoft.Controls.StiButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox.Location = new System.Drawing.Point(0, 13);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(652, 20);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Element:";
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcolProject,
            this.lvcolFile});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 33);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(652, 259);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // lvcolProject
            // 
            this.lvcolProject.Text = "Project";
            this.lvcolProject.Width = 247;
            // 
            // lvcolFile
            // 
            this.lvcolFile.Text = "File";
            this.lvcolFile.Width = 154;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSaveOnlyOppened);
            this.panel1.Controls.Add(this.btOnlyOpenned);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 32);
            this.panel1.TabIndex = 2;
            // 
            // cbSaveOnlyOppened
            // 
            this.cbSaveOnlyOppened.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSaveOnlyOppened.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSaveOnlyOppened.Image = null;
            this.cbSaveOnlyOppened.Location = new System.Drawing.Point(372, 4);
            this.cbSaveOnlyOppened.Name = "cbSaveOnlyOppened";
            this.cbSaveOnlyOppened.Size = new System.Drawing.Size(148, 16);
            this.cbSaveOnlyOppened.TabIndex = 4;
            this.cbSaveOnlyOppened.Text = "Save state only oppened";
            // 
            // btOnlyOpenned
            // 
            this.btOnlyOpenned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOnlyOpenned.Location = new System.Drawing.Point(249, 4);
            this.btOnlyOpenned.Name = "btOnlyOpenned";
            this.btOnlyOpenned.Size = new System.Drawing.Size(120, 23);
            this.btOnlyOpenned.TabIndex = 2;
            this.btOnlyOpenned.Text = "Only openned <F12>";
            this.btOnlyOpenned.UseVisualStyleBackColor = false;
            this.btOnlyOpenned.Click += new System.EventHandler(this.btOnlyOpenned_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btClose.Location = new System.Drawing.Point(126, 4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(120, 23);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "C&lose <Delete>";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(530, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "&Cancel <Escape>";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(2, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(120, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "&Ok <Return>";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // FmList
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(652, 324);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Name = "FmList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project items";
            this.Load += new System.EventHandler(this.FmList_Load);
            this.Activated += new System.EventHandler(this.FmList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmList_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private ArrayList GetItem(ProjectItems prj, string prjName)
		{
			ArrayList result = new ArrayList();

			try
			{
				for(int iProjectItem = 0; iProjectItem < prj.Count; iProjectItem++)
				{
					ProjectItem prjItem = prj.Item(iProjectItem+1);

					Property ob = null;
					for(int i = 0; i < prjItem.Properties.Count; i++)
					{
						Property p = prjItem.Properties.Item(i+1);
						if (p.Name == "SubType") 
						{
							ob = p;
							break;
						}
					}

					if (ob != null)
					{
						int img = -1;
						int add = 0;
						if (_onlyOpenned)
							if (prjItem.Document == null) continue;

						if (prjItem.Document != null) 
                            add = 4;
						if (ob.Value.ToString() == "Code") 
                            img = 0 + add;
						if (ob.Value.ToString() == "Form") 
                            img = 1 + add;
						if (ob.Value.ToString() == "UserControl") 
                            img = 2 + add;
						if (ob.Value.ToString() == "Component") 
                            img = 3 + add;

						//if (img == -1) 
                            //continue;

						result.Add(new ListItemData(prjItem.Name, img, prjName, prjItem));
					}

					if (prjItem.ProjectItems != null)
					{
						result.AddRange(GetItem(prjItem.ProjectItems, prjName + "\\" + prjItem.Name));
					}
				}
			}
			catch
			{
				//System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: GetItem");
			}

			return result;
		}

		public void Fill()
		{
			ArrayList list = new ArrayList();
		
			for(int iProjects = 0; iProjects < IDE.ApplicationObject.Solution.Projects.Count; iProjects++)
			{
				Project prj = IDE.ApplicationObject.Solution.Projects.Item(iProjects+1);

				list.AddRange(GetItem(prj.ProjectItems, prj.Name));
			}									
			listView.SetList(list);
		}

		private void textBox_TextChanged(object sender, System.EventArgs e)
		{
			listView.SetFilter(textBox.Text);
		}

		private void btOk_Click(object sender, System.EventArgs e)
		{
			ListItemData data = listView.SelectedData;
            if (data == null)
                return;

            Close();
            if (data.Datas[1] is ProjectItem)
			{
                Window win;
                if ((data.Datas[1] as ProjectItem).Document == null)
                    win = (data.Datas[1] as ProjectItem).Open("{00000000-0000-0000-0000-000000000000}");
                else
                    win = (data.Datas[1] as ProjectItem).Document.ActiveWindow;

                win.SetFocus();
                (data.Datas[1] as ProjectItem).Document.Activate();
                //if (IDE.ApplicationObject.Version != "9.0")
                (((IDE.ApplicationObject.ActiveDocument as Document).Selection as TextSelection).ActivePoint as VirtualPoint).TryToShow(vsPaneShowHow.vsPaneShowTop, null);
                win.SetFocus();
			}
		}

		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
			btOk.PerformClick();
		}

		private void textBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.F12)	& (e.Modifiers != Keys.Control))
				btOnlyOpenned.PerformClick();

			if (e.KeyCode == Keys.Delete)		
                btClose.PerformClick();

			if (e.Modifiers == Keys.Alt)
			{
				e.Handled = true;

				if (e.KeyCode == Keys.O)	
                    btOk.PerformClick();

				if (e.KeyCode == Keys.L)	
                    btClose.PerformClick();

				if (e.KeyCode == Keys.C)	
                    btCancel.PerformClick();
			}
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			ListItemData data = listView.SelectedData;
			if ((data.Datas[1] is ProjectItem))
                if ((data.Datas[1] as ProjectItem).Document != null)
                    (data.Datas[1] as ProjectItem).Document.Close(vsSaveChanges.vsSaveChangesPrompt);

			Close();
		}

		private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				listView.ProcessKey(e.KeyCode);
			}
			catch
			{
			}
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated (e);

			textBox.Text = "";
			textBox.Focus();
		}

		private void FmList_Load(object sender, System.EventArgs e)
		{
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\ASE\ASE Expert VS2005\SolutionItems\");
            if (key == null)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }

			try
			{
                Top = System.Convert.ToInt32(key.GetValue("FormTop"));
                Left = System.Convert.ToInt32(key.GetValue("FormLeft"));
                Width = System.Convert.ToInt32(key.GetValue("FormWidth"));
				Height = System.Convert.ToInt32(key.GetValue("FormHeight"));
                cbSaveOnlyOppened.Checked = System.Convert.ToBoolean(key.GetValue("SaveStateOnlyOppened"));

                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    listView.Columns[i].Width = System.Convert.ToInt32(key.GetValue("SolutionItemsColumnWidth" + i.ToString()));

                    if (listView.Columns[i].Width < 20)
                        listView.Columns[i].Width = 20;
                }
            }
			catch
			{
			}
		}

		private void btOnlyOpenned_Click(object sender, System.EventArgs e)
		{
			_onlyOpenned = !_onlyOpenned;
			if (_onlyOpenned)
				btOnlyOpenned.Text = "All <F12>";
			else
				btOnlyOpenned.Text = "Only opened <F12>";

			Fill();
			listView.SetFilter(textBox.Text);
		}

		private void FmList_Activated(object sender, System.EventArgs e)
		{
		}

		public DialogResult DoDialog()
		{
			textBox.Text = "";
			if (!cbSaveOnlyOppened.Checked)
			{
				_onlyOpenned = false;
				btOnlyOpenned.Text = "Only opened <F12>";
			}

			Fill();

			return ShowDialog();
		}

        private void FmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ASE\ASE Expert VS2005\SolutionItems\");
                key.SetValue("FormWidth", Width);
                key.SetValue("FormHeight", Height);
                key.SetValue("FormTop", Top);
                key.SetValue("FormLeft", Left);
                key.SetValue("SaveStateOnlyOppened", cbSaveOnlyOppened.Checked);

                for (int i = 0; i < listView.Columns.Count; i++)
                    key.SetValue("SolutionItemsColumnWidth" + i.ToString(), listView.Columns[i].Width);
            }
            catch
            {
            }
        }
	}
}
