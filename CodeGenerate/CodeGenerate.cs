using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMS.UserControls;

namespace CodeGenerate
{
    public partial class CodeGenerate : RoundedForm
    {
        public CodeGenerate()
        {
            InitializeComponent();
        }

        private void CodeGenerate_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            CodeGenerateControl codeGenerate = new CodeGenerateControl();
            this.lblCurrentServerValue.Text = codeGenerate.GetServerName();

            BindDatabases(codeGenerate);

            //codeGenerate.GetTablesInDatabase();
        }

        private void BindDatabases(CodeGenerateControl codeGenerate)
        {
            this.cmbDatabase.ValueMember = "Id";
            this.cmbDatabase.DisplayMember = "Name";
            this.cmbDatabase.DataSource = codeGenerate.GetDatabases();
        }

        private void BindListBox(CodeGenerateControl codeGenerate, string dataBaseName)
        {
            List<string> tableNameList = codeGenerate.GetTableNamesInDatabase(dataBaseName);
            if(this.ltbSourceTable.Items.Count > 0 || this.ltbSelTables.Items.Count > 0)
            {
                this.ltbSourceTable.Items.Clear();
                this.ltbSelTables.Items.Clear();
            }

            tableNameList.ForEach(each => this.ltbSourceTable.Items.Add(each));
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodeGenerateControl codeGenerate = new CodeGenerateControl();
            BindListBox(codeGenerate, this.cmbDatabase.Text);
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSourceTable, ltbSelTables, false);
        }

        private void SelectTableName(ListBox firstListBox, ListBox secondListBox, bool notAllItems = true)
        {
            if(notAllItems)
            {
                for(int itemIndex = firstListBox.SelectedItems.Count - 1; itemIndex > -1; itemIndex--)
                {
                    if(!secondListBox.Items.Contains(firstListBox.SelectedItems[itemIndex]))
                    {
                        secondListBox.Items.Add(firstListBox.SelectedItems[itemIndex]);
                    }

                    firstListBox.Items.Remove(firstListBox.SelectedItems[itemIndex]);
                }
            }
            else
            {
                for(int itemIndex = firstListBox.Items.Count - 1; itemIndex > -1; itemIndex--)
                {
                    if(!secondListBox.Items.Contains(firstListBox.Items[itemIndex]))
                    {
                        secondListBox.Items.Add(firstListBox.Items[itemIndex]);
                    }

                    firstListBox.Items.RemoveAt(itemIndex);
                }

            }
        }

        private void btnSelOne_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSourceTable, ltbSelTables);
        }

        private void btnReSelAll_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSelTables, ltbSourceTable, false);
        }

        private void btnReSel_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSelTables, ltbSourceTable);
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if(!string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                folderDlg.SelectedPath = this.txtFolder.Text;
            }

            if(folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
               frmMsgBox msg = new frmMsgBox("信息", "确定要生成代码吗?", MsgboxButtonStyle.YesNoCancel, MsgboxIconStyle.Information);
               if(DialogResult.Yes == msg.ShowDialog())
               {
                   GenerateCode gc = new GenerateCode();
                   CodeGenerateControl cgc = new CodeGenerateControl();
                   List<DataTable> tableList = cgc.GetTablesInDatabase(GetTableNameList());
                   if(string.IsNullOrWhiteSpace(txtFolder.Text) || string.IsNullOrWhiteSpace(txtNameSpace.Text))
                   {
                       MessageBox.Show("文件夹或命名空间不能为空");
                       return;
                   }

                   gc.GenerateClassCode(tableList, txtNameSpace.Text, txtFolder.Text);
               }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private List<string> GetTableNameList()
        {
            List<string> tableNameList = new List<string>();
            if(ltbSelTables.Items.Count > 0)
            {
                foreach(var item in ltbSelTables.Items)
                {
                    tableNameList.Add(item.ToString());
                }
            }

            return tableNameList;
        }
    }
}
