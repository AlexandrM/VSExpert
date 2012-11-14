using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.TabIndexManager
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();

            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("TabIndex", typeof(string));
            dt.Columns.Add("Object", typeof(object));
            dt.Columns.Add("idx1", typeof(int));
        }

        static DesignerTransaction Transaction;

        public static bool DoDialog()
        {
            IDesignerHost Host = GetActiveDesigner();
            if (Host == null)
                return false;

            if (!(Host.RootComponent is Control))
                return false;

            Transaction = Host.CreateTransaction();

            FmMain fm = new FmMain();
            fm.root = (Host.RootComponent as Control);
            fm.Text = "TabIndex: " + fm.root.Name;
            fm.FillDT(fm.root, "", "");
            fm.Fill();
            fm.ShowDialog();

            return true;
        }

        private Control root = null;
        private DataTable dt = new DataTable();

        private void FillDT(Control container, string path, string space)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.Parent == null)
                    continue;
                if (!ctrl.CanFocus)
                    continue;
                //if (!ctrl.TabStop)
                    //continue;

                string[] blocks = new string[1];
                if (path != "")
                {
                    blocks = path.Split(',');
                    if (blocks.Length > dt.Columns.Count - 3)
                        dt.Columns.Add("idx" + (dt.Columns.Count - 2).ToString(), typeof(int));
                }

                DataRow r = dt.NewRow();
                if (ctrl.Name == "")
                    r[0] = space + ctrl.ToString();
                else
                    r[0] = space + ctrl.Name;
                r[1] = path + ctrl.TabIndex;
                r[2] = ctrl;
                for (int i = 0; i < blocks.Length-1; i++)
                    r["idx" + (i + 1).ToString()] = int.Parse(blocks[i]);
                r["idx" + (blocks.Length).ToString()] = ctrl.TabIndex;
                
                dt.Rows.Add(r);

                if ((ctrl is Control))
                    FillDT((ctrl as Control), path + ctrl.TabIndex + ",", space + "  ");
            }
        }

        private void Fill()
        {
            string order = "";
            foreach(DataRow row in dt.Rows)
                for(int i = 3; i < dt.Columns.Count; i++)
                    if (row[i] == DBNull.Value)
                        row[i] = -1;
            for (int i = 3; i < dt.Columns.Count; i++)
                order = order + ",idx" + (i - 2).ToString();
            order = order.Substring(1);

            DataRow[] rows = dt.Select("", order);
            foreach (DataRow row in rows)
            {
                ListViewItem item;
                try
                {
                    item = new ListViewItem(new string[] { row[0].ToString(), (row[2] as Control).Text, row[1].ToString() }, -1);
                }
                catch
                {
                    item = new ListViewItem(new string[] { row[0].ToString(), "", row[1].ToString() }, -1);
                }
                item.Tag = row;
                list.Items.Add(item);
            }
        }

        private static IDesignerHost GetActiveDesigner()
        {
            if (IDE.ApplicationObject.ActiveDocument != null)
                foreach (Window W in IDE.ApplicationObject.ActiveDocument.Windows)
                {
                    IDesignerHost Host = W.Object as IDesignerHost;
                    if (Host != null)
                        return Host;
                }
            return null;
        }

        private void FmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.Up))
            {
            }
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.Down))
            {
            }
        }

        int Level(ListViewItem item)
        {
            if (item != null)
                for (int i = dt.Columns.Count - 1; i > 2; i--)
                    if ((int)(item.Tag as DataRow)[i] != -1)
                        return i - 2;

            return -1;
        }

        private DataRow[] GetList()
        {
            if (list.SelectedItems.Count == 0)
                return new DataRow[0];

            int level = Level(list.SelectedItems[0]);
            return GetListByLevel(level, (int)(list.SelectedItems[0].Tag as DataRow)[(level + 1)]);
        }

        private DataRow[] GetListByLevel(int level, int parentLevel)
        {
            if (level == -1)
                return new DataRow[0];

            string expr = "";
            if (level != 1)
                expr = expr + "idx" + (level - 1).ToString() + "=" + parentLevel;

            if (expr == "")
                expr = expr + "idx" + (level).ToString() + "<>-1";
            else
                expr = expr + " and idx" + (level).ToString() + "<>-1";

            for (int i = level + 1; i < dt.Columns.Count - 2; i++)
                expr = expr + " and " + "idx" + (i).ToString() + "=-1";

            return dt.Select(expr, "idx" + (level).ToString());
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            DataRow[] rows = GetList();
            string s = "";
            foreach (DataRow r in rows)
                s = s + r[0].ToString() + "\n";

            MessageBox.Show(s);
        }

        private void btDown_Click(object sender, EventArgs e)
        {

        }

        #region OwnerDrawList

        ArrayList colorsList = null;
        private void list_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int l = Level(e.Item);
            if (colorsList == null)
            {
                MethodAttributes attributes = MethodAttributes.Static | MethodAttributes.Public;
                PropertyInfo[] properties = typeof(Color).GetProperties();
                colorsList = new ArrayList();
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo info = properties[i];
                    if (info.PropertyType == typeof(Color))
                    {
                        MethodInfo getMethod = info.GetGetMethod();
                        if ((getMethod != null) && ((getMethod.Attributes & attributes) == attributes))
                        {
                            object[] index = null;
                            colorsList.Add(info.GetValue(null, index));
                        }
                    }
                }
            }

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                using (Brush brush = new SolidBrush((Color)colorsList[l + 20]))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                /*using (LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.Orange, Color.Maroon, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }*/
            }

            if (list.View != View.Details)
            {
                e.DrawText();
            }
            //e.Item.ForeColor = (Color)colorsList[l + 20];
            //System.Drawing.Design.ColorEditor
        }

        private void list_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont = new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        private void list_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;
            e.DrawText(flags);
            return;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                /*double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse(
                    e.SubItem.Text, NumberStyles.Currency,
                    NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    subItemValue < 0)
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        list.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }*/

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }
        }

        #endregion OwnerDrawList

        private string ToTabIndex(DataRow row)
        {
            string ret = "";
            for (int i = 3; i < dt.Columns.Count; i++)
            {
                if ((int) row[i] != -1)
                    ret = ret + "," + row[i].ToString();
            }

            return ret.Substring(1);
        }

        private void Reorder(Control container)
        {
            int idx = -1;
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.Parent == null)
                    continue;
                if (!ctrl.CanFocus)
                    continue;

                idx++;
                ctrl.TabIndex = idx;
                if ((ctrl is Control))
                    Reorder((ctrl as Control));
            }
       }

        private void btOrder_Click(object sender, EventArgs e)
        {
            Reorder(root);
            dt.Rows.Clear();
            list.Items.Clear();
            FillDT(root, "", "");
            Fill();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Transaction.Commit();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Transaction.Cancel();
        }
    }
}