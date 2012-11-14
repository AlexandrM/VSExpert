using System;
using Extensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using Microsoft.Win32;
using System.Xml;

using EnvDTE;
using EnvDTE80;

//using ASE.VS.Core;
using ASEExpertVS2005;

namespace ASEExpertVS2005.CodeItemsList
{
	/// <summary>
	/// Summary description for FmCodeItems.
	/// </summary>
	public class FmCodeItems : System.Windows.Forms.Form
	{
        private ASEExpertVS2005.ASListView listView;
		private System.Windows.Forms.ColumnHeader lvcolName;
		private System.Windows.Forms.ImageList imageList;
        private Stimulsoft.Controls.StiTextBox textBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader lvcolDescription;
		private System.Windows.Forms.Panel panel1;
        private Stimulsoft.Controls.StiButton btCancel;
        private Stimulsoft.Controls.StiButton btOk;
        private ColumnHeader lvcolComments;
        private Label lbDescription;
        private Label lbName;
        private Label lbComments;
		private System.ComponentModel.IContainer components;

		public FmCodeItems()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmCodeItems));
            this.listView = new ASEExpertVS2005.ASListView();
            this.lvcolName = new System.Windows.Forms.ColumnHeader();
            this.lvcolDescription = new System.Windows.Forms.ColumnHeader();
            this.lvcolComments = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.textBox = new Stimulsoft.Controls.StiTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new Stimulsoft.Controls.StiButton();
            this.btOk = new Stimulsoft.Controls.StiButton();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcolName,
            this.lvcolDescription,
            this.lvcolComments});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 87);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(696, 210);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // lvcolName
            // 
            this.lvcolName.Text = "Name";
            this.lvcolName.Width = 242;
            // 
            // lvcolDescription
            // 
            this.lvcolDescription.Text = "Description";
            this.lvcolDescription.Width = 268;
            // 
            // lvcolComments
            // 
            this.lvcolComments.Text = "Comments";
            this.lvcolComments.Width = 161;
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
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox.Location = new System.Drawing.Point(0, 16);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(696, 20);
            this.textBox.TabIndex = 6;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Element:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 32);
            this.panel1.TabIndex = 11;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(576, 8);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 23);
            this.btCancel.TabIndex = 12;
            this.btCancel.Text = "&Cancel <Escape>";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(4, 8);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(120, 23);
            this.btOk.TabIndex = 11;
            this.btOk.Text = "&Ok <Return>";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDescription.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lbDescription.Location = new System.Drawing.Point(0, 53);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(52, 17);
            this.lbDescription.TabIndex = 13;
            this.lbDescription.Text = "label3";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbName.Location = new System.Drawing.Point(0, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(52, 17);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "label4";
            // 
            // lbComments
            // 
            this.lbComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbComments.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbComments.Location = new System.Drawing.Point(0, 70);
            this.lbComments.MaximumSize = new System.Drawing.Size(0, 68);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(696, 17);
            this.lbComments.TabIndex = 15;
            this.lbComments.Text = "label2";
            this.lbComments.UseMnemonic = false;
            this.lbComments.TextChanged += new System.EventHandler(this.lbComments_TextChanged);
            // 
            // FmCodeItems
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(696, 329);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.lbComments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Name = "FmCodeItems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Code Elements";
            this.Load += new System.EventHandler(this.FmCodeItems_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmCodeItems_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	
		public DialogResult DoDialog()
		{
			if (IDE.ApplicationObject.ActiveDocument == null) 
				return DialogResult.Ignore;
			if (IDE.ApplicationObject.ActiveDocument.ProjectItem == null) 
				return DialogResult.Ignore;
			if (IDE.ApplicationObject.ActiveDocument.ProjectItem.FileCodeModel == null) 
				return DialogResult.Ignore;
			if (IDE.ApplicationObject.ActiveDocument.ProjectItem.FileCodeModel.CodeElements == null) 
				return DialogResult.Ignore;
			if (IDE.ApplicationObject.ActiveDocument.ProjectItem.FileCodeModel.CodeElements.Count == 0) 
				return DialogResult.Ignore;

			Document Doc = IDE.ApplicationObject.ActiveDocument;

			ArrayList result = new ArrayList();
			foreach(CodeElement e in IDE.ApplicationObject.ActiveDocument.ProjectItem.FileCodeModel.CodeElements)
			{
				result.AddRange(FillElements(e));
			}

			listView.SetList(result);

			return this.ShowDialog();
		}

		private ArrayList FillElements(CodeElement startElement)
		{

			ArrayList result = new ArrayList();			
			try
			{
				string s = "";

				switch(startElement.Kind)
				{
					case vsCMElement.vsCMElementNamespace:
						CodeNamespace cn = (CodeNamespace) startElement;
						foreach(CodeElement element in cn.Members)
							result.AddRange(FillElements(element));
						break;

					case vsCMElement.vsCMElementClass:			
						CodeClass cc = (CodeClass) startElement;
						foreach(CodeElement element in cc.Members)
							result.AddRange(FillElements(element));
						break;

					case vsCMElement.vsCMElementInterface:
						CodeInterface ci = (CodeInterface) startElement;
						foreach(CodeElement element in ci.Members)
							result.AddRange(FillElements(element));
						break;

					case vsCMElement.vsCMElementFunction:
                        result.Add(new ListItemData(startElement.Name, 0, FunctionToString((CodeFunction)startElement), ParseComment((startElement as CodeFunction).DocComment), startElement));
						break;

					case vsCMElement.vsCMElementProperty:
                        result.Add(new ListItemData(startElement.Name, 1, PropertyToString((CodeProperty) startElement), ParseComment((startElement as CodeProperty).DocComment), startElement));
						break;

					case vsCMElement.vsCMElementEvent:
                        result.Add(new ListItemData(startElement.Name, 2, (startElement as CodeEvent).Name, ParseComment((startElement as CodeEvent).DocComment), startElement));
						break;

					case vsCMElement.vsCMElementDelegate:
						result.Add(new ListItemData(startElement.Name, 3, DelegateToString((CodeDelegate) startElement), ParseComment((startElement as CodeDelegate).DocComment), startElement));
						break;

					case vsCMElement.vsCMElementEnum:
						result.Add(new ListItemData(startElement.Name, 4, EnumToString((CodeEnum) startElement), ParseComment((startElement as CodeEnum).DocComment), startElement));
						break;

					case vsCMElement.vsCMElementStruct:
                        result.Add(new ListItemData(startElement.Name, 5, s, ParseComment((startElement as CodeStruct).DocComment), startElement));
						CodeStruct cs = (CodeStruct) startElement;
						foreach(CodeElement element in cs.Members)
							result.AddRange(FillElements(element));
						break;
				}
			}
			catch(Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: FillElements");
			}

			return result;
		}

        private XmlDocument xmlDoc = new XmlDocument();

        private string InParseComment(XmlNode list)
        {
            string s = "";

            try
            {
                foreach (XmlNode element in list)
                {
                    if (element.HasChildNodes)
                        s = s + InParseComment(element);
                    else
                    {
                        if (element.ParentNode.Attributes.Count != 0)
                            s = s + element.ParentNode.Attributes[0].Value + ": " + element.Value.Replace("\r\n", "") + ", ";
                        else
                            s = s + element.Value.Replace("\r\n", "") + ", ";
                    }
                }
            }
            catch(Exception exc)
            {
                System.Diagnostics.Trace.WriteLine("InParseComment!! " + exc.Message);
            }

            return s;
        }

        private string ParseComment(string comment)
        {
            string s = "";

            try
            {
                xmlDoc.LoadXml(comment);
                s = InParseComment(xmlDoc);
            }
            catch
            {
                s = comment;
            }

            return s;
        }
		private string FunctionToString(CodeFunction codeFunction)
		{
			try
			{
				string s = "";

				s = s + codeFunction.Type.AsString + " (";
				for(int i = 1; i <= codeFunction.Parameters.Count; i++)
				{
					CodeElement codeElement = codeFunction.Parameters.Item(i);
					if (codeElement.Kind == vsCMElement.vsCMElementParameter)
					{
						CodeParameter codeParameter = (CodeParameter) codeElement;
						s = s + codeParameter.Type.AsString + " " + codeParameter.Name;
						if (i != codeFunction.Parameters.Count) 
							s = s + ", ";
					}
				}
				s = s + ")";

				return s;
			}
			catch(Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: FunctionToString");
				return "";
			}
		}

		private string PropertyToString(CodeProperty codeProperty)
		{
			try
			{
				string s = codeProperty.Type.AsString;

				try
				{
					if (codeProperty.Getter != null)	s = s + " get{} ";
				}
				catch
				{
				}
				try
				{
					if (codeProperty.Setter != null)	s = s + " set{} ";
				}
				catch
				{
				}
				return s;
			}
			catch(Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: PropertyToString");
				return "";
			}
		}

		private string EnumToString(CodeEnum codeEnum)
		{
			try
			{
				string s = "";
				for (int i = 1; i <= codeEnum.Members.Count; i++)
				{
					CodeElement c = codeEnum.Members.Item(i);
					s = s + c.Name;
					if (i != codeEnum.Members.Count) s  = s + ", ";
				}
				return s;
			}
			catch(Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: EnumToString");
				return "";
			}
		}

		private string DelegateToString(CodeDelegate codeDelegate)
		{
			try
			{
				string s = "";
				s = s + codeDelegate.Type.AsString + " (";
				for(int i = 1; i <= codeDelegate.Parameters.Count; i++)
				{
					CodeElement codeElement = codeDelegate.Parameters.Item(i);
					if (codeElement.Kind == vsCMElement.vsCMElementParameter)
					{
						CodeParameter codeParameter = (CodeParameter) codeElement;
						s = s + codeParameter.Type.AsString + " " + codeParameter.Name;
						if (i != codeDelegate.Parameters.Count) 
							s = s + ", ";
					}
				}
				s = s + ")";
				return s;
			}
			catch(Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message, "AS VS Expert: DelegateToString");
				return "";
			}
		}

		private void textBox_TextChanged(object sender, System.EventArgs e)
		{
			listView.SetFilter(textBox.Text);
		}

		private void textBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Alt)
			{
				e.Handled = true;

				if (e.KeyCode == Keys.O)	btOk.PerformClick();
				if (e.KeyCode == Keys.C)	btCancel.PerformClick();
			}
		}

		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
			btOk.PerformClick();
		}

		private void btOk_Click(object sender, System.EventArgs e)
		{
			ListItemData data = listView.SelectedData;

			if (data == null) 
                return;

			if (!(data.Datas[2] is CodeElement)) 
                return;

            CodeElement el = (CodeElement)data.Datas[2];

			TextSelection ts = IDE.ApplicationObject.DTE.ActiveDocument.Selection as TextSelection;
			if(ts != null)
			{
				ts.MoveToPoint(el.StartPoint, false);
			}
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

		private void FmCodeItems_Load(object sender, System.EventArgs e)
		{

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\ASE\ASE Expert VS2005\CodeItems\");
			if (key == null) return;
			try
            {
                Top = System.Convert.ToInt32(key.GetValue("FormTop"));
                Left = System.Convert.ToInt32(key.GetValue("FormLeft"));
                Width = System.Convert.ToInt32(key.GetValue("FormWidth"));
                Height = System.Convert.ToInt32(key.GetValue("FormHeight"));

                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    listView.Columns[i].Width = System.Convert.ToInt32(key.GetValue("CodeItemsColumnWidth" + i.ToString()));
                    
                    if (listView.Columns[i].Width < 20)
                        listView.Columns[i].Width = 20;
                }
            }
			catch
			{
			}
		}

        private void FmCodeItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ASE\ASE Expert VS2005\CodeItems\");
                key.SetValue("FormWidth", Width);
                key.SetValue("FormHeight", Height);
                key.SetValue("FormTop", Top);
                key.SetValue("FormLeft", Left);

                for (int i = 0; i < listView.Columns.Count; i++)
                    key.SetValue("CodeItemsColumnWidth" + i.ToString(), listView.Columns[i].Width);
            }
            catch
            {
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbName.Text = "Name: ";
            lbDescription.Text = "Description: ";
            lbComments.Text = "Comments:";

            if (listView.SelectedItems.Count == 0)
                return;

            lbName.Text = "Name: " + listView.SelectedItems[0].SubItems[0].Text;
            lbDescription.Text = "Description: " + listView.SelectedItems[0].SubItems[1].Text;
            lbComments.Text = "Comments: " + listView.SelectedItems[0].SubItems[2].Text;
        }

        private System.Drawing.Graphics gr = null;

        private void lbComments_TextChanged(object sender, EventArgs e)
        {
            if (gr == null)
                gr = lbComments.CreateGraphics();

            System.Drawing.SizeF sf = gr.MeasureString(lbComments.Text, lbComments.Font);
            decimal d = System.Convert.ToDecimal(sf.Width / this.Width);
            
            lbComments.Height = System.Convert.ToInt32(17 * (decimal.Floor(d) + 1));
        }
	}
}
