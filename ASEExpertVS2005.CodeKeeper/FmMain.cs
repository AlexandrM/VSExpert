using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
using Finisar.SQLite;
using System.IO;

namespace ASEExpertVS2005.CodeKeeper
{
    public partial class FmMain : Form
    {
        private static SQLiteConnection connection = null;
        private static SQLiteCommand command = null;

        static FmMain()
        {
            connection = new SQLiteConnection();
            command = new SQLiteCommand();

            String cs = "";
            cs = cs + String.Format("Data Source={0};", IDE.LibPath + "ASEExpertVS2005.CodeKeeper.db");
            cs = cs + String.Format("Version=3;");
            bool isNew = !File.Exists(IDE.LibPath + "ASEExpertVS2005.CodeKeeper.db");
            if (isNew)
                cs = cs + String.Format("New=True;");
            cs = cs + String.Format("UTF8Encoding=True;");
            cs = cs + String.Format(";");

            connection.ConnectionString = cs;
            try
            {
                connection.Open();

                command.Connection = connection;

                if (isNew)
                {
                    ExecuteNonQuery("CREATE TABLE groups (parentid INTEGER, name TEXT)");
                    ExecuteNonQuery("CREATE TABLE code (groupid INTEGER, name TEXT, code TEXT, langid INTEGER)");

                    ExecuteNonQuery("INSERT INTO groups (parentid , name) VALUES (0, 'General')");
                    ExecuteNonQuery("INSERT INTO groups (parentid , name) VALUES (0, 'Forms')");
                    ExecuteNonQuery("INSERT INTO groups (parentid , name) VALUES (0, 'IO')");
                    ExecuteNonQuery("INSERT INTO groups (parentid , name) VALUES (0, 'NET')");
                }
            }
            catch (Exception exc)
            {
                IDE.Debug("", exc);
            }
        }

        public FmMain()
        {
            InitializeComponent();

            list.DataSource = new DataTable();

            string[] langs = Rsdn.Scintilla.ScintillaEditor.GetStandardLanguagesName();
            foreach (string item in langs)
                cbLanguage.Items.Add(Rsdn.Scintilla.ScintillaEditor.GetStandardLanguage(item));

            cbLanguage.SelectedItem = cbLanguage.Items[1];


            AddChilds(tree.Nodes, 0);
            tree.SelectedNode = tree.Nodes[0];

            list.AutoGenerateColumns = false;
        }

        private void AddChilds(TreeNodeCollection parentNodes, long parentid)
        {
            DataTable dt = ExecuteDataTable("SELECT ROWID, name FROM groups WHERE parentid = @0 ORDER BY parentid, name", parentid);
            foreach (DataRow row in dt.Rows)
            {
                TreeNode node = new TreeNode(row["name"].ToString());
                node.Name = System.Convert.ToInt64(row["ROWID"]).ToString();

                parentNodes.Add(node);
                AddChilds(node.Nodes, System.Convert.ToInt64(row["ROWID"]));
            }
        }

        ~FmMain()
        {
            connection.Close();
        }


        
        public static DialogResult DoDialog(string text)
        {
            FmMain fm = new FmMain();

            #region Remove tabs

            string[] lines = text.Split('\n');
            if (lines.Length > 1)
            {
                int spaces = 0;
                for(int offset = 0; offset < 500; offset++)
                {
                    bool space = true;
                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        if ((offset >= lines[i].Length) || (lines[i][offset] != ' '))
                        {
                            space = false;
                            break;
                        }
                    }

                    if (space)
                        spaces++;
                    else
                        break;
                }
                text = "";
                for (int i = 0; i < lines.Length - 1; i++)
                    text = text + lines[i].Substring(spaces) + "\n";
            }

            #endregion Remove tabs

            fm.edCode.Text = text;
            if (text == "")
            {
                fm.lblFilter.Text = "Filter: ";
                fm.list.Visible = true;
                fm.btSave.Visible = true;

                fm.pnlFilter.TabIndex = 0;
                    fm.lblFilter.TabIndex = 0;
                    fm.edFilter.TabIndex = 1;
                    fm.list.TabIndex = 2;

                fm.tree.TabIndex = 1;

                fm.pnlCode.TabIndex = 2;
                    fm.edCode.TabIndex = 0;

                fm.pnlButtons.TabIndex = 3;
                    fm.btSave.TabIndex = 0;
                    fm.btOk.TabIndex = 1;
                    fm.btCancel.TabIndex = 2;
            }
            else
            {
                fm.pnlFilter.Height = fm.pnlFilter.Height - fm.list.Height;
                fm.lblFilter.Text = "Name: ";
                fm.list.Visible = false;
                fm.btSave.Visible = false; ;

                fm.pnlFilter.TabIndex = 0;
                    fm.edFilter.TabIndex = 0;

                fm.tree.TabIndex = 1;

                fm.pnlButtons.TabIndex = 2;
                    fm.btSave.TabIndex = 0;
                    fm.btOk.TabIndex = 1;
                    fm.btCancel.TabIndex = 2;

                fm.pnlCode.TabIndex = 3;
                    fm.list.TabIndex = 0;
                    fm.edCode.TabIndex = 2;
                }
            fm.edFilter.Focus();
            return fm.ShowDialog();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            tree.Width = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Tree", "Width", tree.Width);
            list.Height = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/List", "Height", list.Height);

            pnlFilter.Height = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Filter", "Height", pnlFilter.Height);

            Top = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Form", "Top", Top);
            Left = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Form", "Left", Left);
            Width = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Form", "Width", Width);
            Height = ASE.Xml.XmlIniStatic.ReadInt("CodeKeeper/Form", "Height", Height);

            if (!list.Visible)
                lblFilter.Text = "Name:";
            else
            {
                if (!ASE.Xml.XmlIniStatic.ReadBoolean("CodeKeeper/Form", "NameAndCode", true))
                {
                    lblFilter.Text = "Only 'Name' filter. 'Name + Code' filter press <F5>";
                    lblFilter.Tag = "0";
                }
                else
                {
                    lblFilter.Text = "'Name' + 'Code' filter. Only 'Name' filter press <F5>";
                    lblFilter.Tag = "1";
                }
            }
        }

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Tree", "Width", tree.Width);
            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/List", "Height", list.Height);

            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Filter", "Height", pnlFilter.Height);

            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Form", "Top", Top);
            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Form", "Left", Left);
            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Form", "Width", Width);
            ASE.Xml.XmlIniStatic.WriteInt("CodeKeeper/Form", "Height", Height);
            ASE.Xml.XmlIniStatic.WriteBoolean("CodeKeeper/Form", "NameAndCode", lblFilter.Tag.ToString() == "1");
        }

        private void cbLexer_SelectedIndexChanged(object sender, EventArgs e)
        {
            edCode.Language = (Rsdn.Scintilla.ILanguage)cbLanguage.SelectedItem;
        }

        #region DataBase

        private static object ExecuteOneValue(string text, object defValue, params object[] data)
        {
            try
            {
                command.CommandText = text;
                command.Parameters.Clear();
                for (int i = 0; i < data.Length; i++)
                    command.Parameters.Add("@" + i.ToString(), data[0]);
                SQLiteDataReader dr = command.ExecuteReader();
                if (dr.Read())
                    defValue = dr.GetValue(0);

                dr.Close();
            }
            catch (Exception exc)
            {
                IDE.Debug("ExecuteNonQuery!!! ", exc, text);
            }

            return defValue;
        }

        private static void ExecuteNonQuery(string text, params object[] data)
        {
            try
            {
                command.CommandText = text;
                command.Parameters.Clear();
                for (int i = 0; i < data.Length; i++)
                    command.Parameters.Add("@" + i.ToString(), data[i]);
                command.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                IDE.Debug("ExecuteNonQuery!!! ", exc, text);
            }
        }

        private static DataTable ExecuteDataTable(string text, params object[] data)
        {
            try
            {
                command.CommandText = text;
                command.Parameters.Clear();
                for (int i = 0; i < data.Length; i++)
                    command.Parameters.Add("@" + i.ToString(), data[0]);

                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable("DataTable");
                da.Fill(dt);

                return dt;
            }
            catch (Exception exc)
            {
                IDE.Debug("ExecuteNonQuery!!! ", exc, text);
            }
            return null;
        }

        #endregion DataBase

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Group name:", "New group", "New group", -1, -1);
            if (name == "")
                return;
            if (tree.SelectedNode == null)
                return;
            
            TreeNode node = new TreeNode();
            node.Text = name;
            TreeNodeCollection list = tree.Nodes;
            long parent = 0;
            if (tree.SelectedNode != null)
            {
                list = tree.SelectedNode.Nodes;
                parent = long.Parse(tree.SelectedNode.Name);
            }
            if (clickNode != null)
            {
                list = clickNode.Nodes;
                parent = long.Parse(clickNode.Name);
                clickNode = null;
            }

            ExecuteNonQuery("INSERT INTO groups (parentid, name) VALUES (@0, @1)", parent, name);
            list.Add(node);

            node.Name = ExecuteOneValue("SELECT MAX(ROWID) FROM groups", null).ToString();
        }
        
        private void removeGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
                return;
            if (tree.Nodes.Count == 1)
                return;

            if (MessageBox.Show("Do you want delete node: " + tree.SelectedNode.Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteNonQuery("DELETE FROM groups WHERE ROWID = @0", long.Parse(tree.SelectedNode.Name));
                tree.SelectedNode.Remove();
            }
        }
        private void edFilter_TextChanged(object sender, EventArgs e)
        {
            if (list.Visible)
            {
                if (edFilter.Text == "")
                    list.DataSource = new DataTable();
                else if (lblFilter.Tag.ToString() == "1")
                    list.DataSource = ExecuteDataTable("SELECT ROWID, groupid, name, code, langid FROM code WHERE name LIKE @0 OR code LIKE @0", "%" + edFilter.Text + "%");
                else
                    list.DataSource = ExecuteDataTable("SELECT ROWID, groupid, name, code, langid FROM code WHERE name LIKE @0", "%" + edFilter.Text + "%");
            }
        }

        private TreeNode clickNode = null;
        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            clickNode = e.Node;
        }

        private void tree_MouseDown(object sender, MouseEventArgs e)
        {
            clickNode = null;
        }

        private void renameGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickNode == null)
                return;

            string name = Microsoft.VisualBasic.Interaction.InputBox("Group name:", clickNode.Text, "New group", -1, -1);
            if (name == "")
                return;

            ExecuteNonQuery("UPDATE groups SET name = @0 WHERE ROWID = @1", name, long.Parse(clickNode.Name));
            clickNode.Text = name;
        }

        private ArrayList codeLlist = new ArrayList();
        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode == null)
                return;

            if ((tree.Focused) && (list.Visible))
                list.DataSource = ExecuteDataTable("SELECT ROWID, groupid, name, code, langid FROM code WHERE groupid = @0", long.Parse(tree.SelectedNode.Name));
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (edFilter.Text == "")
            {
                MessageBox.Show("Name is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExecuteNonQuery("UPDATE code SET groupid = @0, name = @1, code = @2, langid = @3 WHERE ROWID = @4", System.Convert.ToInt64(tree.SelectedNode.Name), edFilter.Text, edCode.Text, cbLanguage.SelectedIndex, Convert.ToInt64((list.DataSource as DataTable).Rows[CurrentRow][0]));
        }
        
        public static string Code = "";

        private void btOk_Click(object sender, EventArgs e)
        {
            if (btSave.Visible)
            {
                Code = edCode.Text;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            if (edFilter.Text == "")
            {
                MessageBox.Show("Name is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExecuteNonQuery("INSERT INTO code (groupid, name, code, langid) VALUES (@0, @1, @2, @3)", System.Convert.ToInt64(tree.SelectedNode.Name), edFilter.Text, edCode.Text, cbLanguage.SelectedIndex);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void list_DataSourceChanged(object sender, EventArgs e)
        {
            list.Columns[0].Width = list.Width - 10;
            edCode.Text = "";
            list_CurrentCellChanged(list, EventArgs.Empty);
        }

        private int CurrentRow
        {
            get
            {
                if (list.SelectedRows.Count == 0)
                    return -1;

                return list.SelectedRows[0].Index;
            }
        }

        private void miRenameCode_Click(object sender, EventArgs e)
        {
            if (CurrentRow == -1)
                return;

            string name = Microsoft.VisualBasic.Interaction.InputBox("Code name:", "Name", (list.DataSource as DataTable).Rows[CurrentRow]["name"].ToString(), -1, -1);
            if (name == "")
                return;

            ExecuteNonQuery("UPDATE code SET name = @0 WHERE ROWID = @1", name, Convert.ToInt64((list.DataSource as DataTable).Rows[CurrentRow]["ROWID"]));
            (list.DataSource as DataTable).Rows[CurrentRow]["name"] = name;
        }

        private void miRemoveCode_Click(object sender, EventArgs e)
        {
            if (CurrentRow == -1)
                return;

            if (MessageBox.Show("Do you want delete : " + (list.DataSource as DataTable).Rows[CurrentRow]["name"], "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteNonQuery("DELETE FROM code WHERE ROWID = @0", Convert.ToInt64((list.DataSource as DataTable).Rows[CurrentRow]["ROWID"]));
                (list.DataSource as DataTable).Rows.Remove((list.DataSource as DataTable).Rows[CurrentRow]);
            }
        }

        private void edFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) && (edFilter.Focused))
            {
                e.Handled = true;
                if (CurrentRow != -1)
                    btOk.PerformClick();
            }
            else if ((e.KeyCode == Keys.Up) && (edFilter.Focused))
            {
                e.Handled = true;
                if ((CurrentRow == 0) && (list.Rows.Count > 0))
                    list.Rows[list.Rows.Count - 1].Selected = true;
                else
                    list.Rows[CurrentRow - 1].Selected = true;
                list_CurrentCellChanged(list, EventArgs.Empty);
            }
            else if ((e.KeyCode == Keys.Down) && (edFilter.Focused))
            {
                e.Handled = true;
                if ((CurrentRow == list.Rows.Count - 1) && (list.Rows.Count > 0))
                    list.Rows[0].Selected = true;
                else
                    list.Rows[CurrentRow + 1].Selected = true;
                list_CurrentCellChanged(list, EventArgs.Empty);
            }
            else if ((e.KeyCode == Keys.F5) && (edFilter.Focused) && (list.Visible))
            {
                e.Handled = true;
                if (lblFilter.Tag.ToString() == "1")
                {
                    lblFilter.Text = "Only 'Name' filter. 'Name + Code' filter press <F5>";
                    lblFilter.Tag = "0";
                }
                else
                {
                    lblFilter.Text = "'Name' + 'Code' filter. Only 'Name' filter press <F5>";
                    lblFilter.Tag = "1";
                }
            }
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) && (list.Focused))
            {
                e.Handled = true;
                btOk.PerformClick();
            }
        }

        private void edCode_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btOk;
        }

        private void edCode_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void list_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
            }
        }

        private void list_CurrentCellChanged(object sender, EventArgs e)
        {
            if (CurrentRow != -1)
            {
                DataRow row = (list.DataSource as DataTable).Rows[CurrentRow];
                edCode.Text = row["code"].ToString();
                if (row["langid"] == null)
                    row["langid"] = 1;
                cbLanguage.SelectedIndex = System.Convert.ToInt32(row["langid"]);
            }
        }

        private void tree_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) && (tree.Focused))
            {
                e.Handled = true;
                if (CurrentRow != -1)
                    btOk.PerformClick();
            }
        }
    }
}