using System;
using Extensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;

using EnvDTE;
using EnvDTE80;

//using ASE.VS.Core;

namespace ASEExpertVS2005.AddProperty
{
	/// <summary>
	/// Summary description for FmAddProperty.
	/// </summary>
	public class FmAddProperty : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        internal Stimulsoft.Controls.StiComboBox cbType;
        internal Stimulsoft.Controls.StiTextBox edPropertyName;
        internal Stimulsoft.Controls.StiTextBox edInernalVar;
        internal Stimulsoft.Controls.StiTextBox edComment;
		private Stimulsoft.Controls.StiButton btOk;
        private Stimulsoft.Controls.StiButton btCancel;
        internal Stimulsoft.Controls.StiCheckBox cbGet;
        internal Stimulsoft.Controls.StiCheckBox cbSet;
        internal Stimulsoft.Controls.StiComboBox cbModifers;
		internal System.Windows.Forms.Label label5;
        internal Stimulsoft.Controls.StiCheckBox cbVirtual;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FmAddProperty()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbType = new Stimulsoft.Controls.StiComboBox();
            this.edPropertyName = new Stimulsoft.Controls.StiTextBox();
            this.edInernalVar = new Stimulsoft.Controls.StiTextBox();
            this.edComment = new Stimulsoft.Controls.StiTextBox();
            this.btOk = new Stimulsoft.Controls.StiButton();
            this.btCancel = new Stimulsoft.Controls.StiButton();
            this.cbGet = new Stimulsoft.Controls.StiCheckBox();
            this.cbSet = new Stimulsoft.Controls.StiCheckBox();
            this.cbModifers = new Stimulsoft.Controls.StiComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVirtual = new Stimulsoft.Controls.StiCheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Property name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Internal var:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Comment:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type:";
            // 
            // cbType
            // 
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbType.Items.AddRange(new object[] {
            "string",
            "int",
            "log",
            "decimal",
            "DateTime"});
            this.cbType.Location = new System.Drawing.Point(88, 28);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 21);
            this.cbType.TabIndex = 3;
            this.cbType.Text = "string";
            // 
            // edPropertyName
            // 
            this.edPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edPropertyName.Location = new System.Drawing.Point(88, 4);
            this.edPropertyName.Name = "edPropertyName";
            this.edPropertyName.Size = new System.Drawing.Size(136, 20);
            this.edPropertyName.TabIndex = 1;
            this.edPropertyName.TextChanged += new System.EventHandler(this.edPropertyName_TextChanged);
            // 
            // edInernalVar
            // 
            this.edInernalVar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edInernalVar.Location = new System.Drawing.Point(88, 76);
            this.edInernalVar.Name = "edInernalVar";
            this.edInernalVar.Size = new System.Drawing.Size(136, 20);
            this.edInernalVar.TabIndex = 7;
            // 
            // edComment
            // 
            this.edComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edComment.Location = new System.Drawing.Point(88, 154);
            this.edComment.Name = "edComment";
            this.edComment.Size = new System.Drawing.Size(136, 20);
            this.edComment.TabIndex = 12;
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.Transparent;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Location = new System.Drawing.Point(4, 182);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(108, 24);
            this.btOk.TabIndex = 13;
            this.btOk.Text = "&Ok";
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Transparent;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(116, 182);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(108, 24);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // cbGet
            // 
            this.cbGet.Checked = true;
            this.cbGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGet.Location = new System.Drawing.Point(88, 96);
            this.cbGet.Name = "cbGet";
            this.cbGet.Size = new System.Drawing.Size(104, 16);
            this.cbGet.TabIndex = 8;
            this.cbGet.Text = "get";
            // 
            // cbSet
            // 
            this.cbSet.Checked = true;
            this.cbSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSet.Location = new System.Drawing.Point(88, 115);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(104, 16);
            this.cbSet.TabIndex = 9;
            this.cbSet.Text = "set";
            // 
            // cbModifers
            // 
            this.cbModifers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbModifers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModifers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModifers.Items.AddRange(new object[] {
            "public",
            "protected",
            "protected internal",
            "internal",
            "private"});
            this.cbModifers.Location = new System.Drawing.Point(88, 52);
            this.cbModifers.Name = "cbModifers";
            this.cbModifers.Size = new System.Drawing.Size(136, 21);
            this.cbModifers.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Modifers:";
            // 
            // cbVirtual
            // 
            this.cbVirtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVirtual.Location = new System.Drawing.Point(88, 134);
            this.cbVirtual.Name = "cbVirtual";
            this.cbVirtual.Size = new System.Drawing.Size(104, 16);
            this.cbVirtual.TabIndex = 10;
            this.cbVirtual.Text = "virtual";
            // 
            // FmAddProperty
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(230, 210);
            this.Controls.Add(this.cbVirtual);
            this.Controls.Add(this.cbModifers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSet);
            this.Controls.Add(this.cbGet);
            this.Controls.Add(this.edComment);
            this.Controls.Add(this.edInernalVar);
            this.Controls.Add(this.edPropertyName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FmAddProperty";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add property";
            this.Load += new System.EventHandler(this.FmAddProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void edPropertyName_TextChanged(object sender, System.EventArgs e)
		{
			if (edPropertyName.Text.Length > 1)
				edInernalVar.Text = "_" + edPropertyName.Text.Substring(0, 1).ToLower() + edPropertyName.Text.Substring(1);

			edComment.Text = edPropertyName.Text;
		}

		private void FmAddProperty_Load(object sender, System.EventArgs e)
		{
			cbModifers.SelectedIndex = 0;
		}

		private void btOk_Click(object sender, System.EventArgs e)
		{
			CodeAddProperty(
				edPropertyName.Text, 
				cbType.Text, 
				cbModifers.SelectedIndex, 
				edInernalVar.Text, 
				cbGet.Checked, 
				cbSet.Checked, 
				cbVirtual.Checked, 
				edComment.Text,
				(TextSelection) IDE.ApplicationObject.ActiveDocument.Selection);
			Close();
		}

		private void CodeAddProperty(string name, string type, int modifers, string internalVar, bool isGet, bool isSet, 
            bool isVirtual, string comment, TextSelection ts)
		{
			try
			{
				FileCodeModel code = IDE.ApplicationObject.ActiveDocument.ProjectItem.FileCodeModel;
				if (code == null) 
                    return;

				EnvDTE.vsCMAccess acc = EnvDTE.vsCMAccess.vsCMAccessPublic;
				if (modifers == 1)
					acc = EnvDTE.vsCMAccess.vsCMAccessProtected;
				if (modifers == 2)
					acc = EnvDTE.vsCMAccess.vsCMAccessProjectOrProtected;
				if (modifers == 3)
					acc = EnvDTE.vsCMAccess.vsCMAccessProject;
				if (modifers == 4)
					acc = EnvDTE.vsCMAccess.vsCMAccessPrivate;

				CodeClass element = (CodeClass) code.CodeElementFromPoint(ts.ActivePoint, vsCMElement.vsCMElementClass);
				if (element == null) 
                    return;

				CodeElement prev = null;
				for(int i = 1; i <= element.Members.Count; i++)
				{
					if (element.Members.Item(i).EndPoint.Line == ts.ActivePoint.Line)
						break;

					if (element.Members.Item(i).EndPoint.Line >= ts.ActivePoint.Line)
						break;

					prev = element.Members.Item(i);
				}

				object pos;
				if (prev == null)
					pos = 0;
				else
					pos = prev;

				CodeVariable cv = null;

				if (internalVar != "")
				{
					cv = element.AddVariable(
						internalVar, 
						type,
						pos,
						vsCMAccess.vsCMAccessPrivate,
						ts
						);
				}

				if (cv == null)
					pos = 0;
				else
					pos = cv;

				CodeProperty prp;
				if ((isGet) & (isSet))
					prp = element.AddProperty(
						"A", 
						"A", 
						type, 
						pos, 
						acc,
						ts);
				else if (isGet)
					prp = element.AddProperty(
						"A", 
						"", 
						type, 
						pos, 
						acc,
						ts);
				else 
					prp = element.AddProperty(
						"", 
						"A", 
						type, 
						pos, 
						acc,
						ts);

				prp.Name = name;

                if (comment != "")
                {
                    //prp.Comment = "<doc>\r\n<summary>\r\ncomment\r\n</summary>\r\n</doc>";
                }

				if ((isGet) & (internalVar != ""))
				{
					string getExpression = "get\n\t{\n\treturn " +  internalVar + ";\n\t}";
					EditPoint ep = prp.Getter.StartPoint.CreateEditPoint();
					ep.ReplaceText(prp.Getter.EndPoint, getExpression, 3);
				}
				if ((isSet) & (internalVar != ""))
				{
					EditPoint ep = prp.Setter.StartPoint.CreateEditPoint();
					string setExpression = 	"set\n{\n" + internalVar + " = value;\n}";
					ep.ReplaceText(prp.Setter.EndPoint, setExpression,	1);
				}
				if ((isGet) & (internalVar == ""))
				{
					string getExpression = "get\n\t{\n\treturn null;\n\t}\n";
					EditPoint ep = prp.Getter.StartPoint.CreateEditPoint();
					ep.ReplaceText(prp.Getter.EndPoint, getExpression, 3);
				}

				prp.StartPoint.CreateEditPoint().SmartFormat(prp.EndPoint);

			}
			catch(Exception exc)
			{
				System.Diagnostics.Trace.WriteLine(exc.Message, "AS VS Expert: CodeAddProperty");
			}
		}
	}
}
