using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using RMS.DataAccess;
using RMS.Entities;
using RMS.Logging;
using RMS.Utility;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;


namespace RMS.WinForms
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            SqlServerDbMapper<DishMenu> dishMenu = new SqlServerDbMapper<DishMenu>();
            //this.gridControl1.DataSource = dishMenu.GetAllObjectInstanceList();
            //DevExpress.XtraGrid.Views.Grid.GridView gridView2;

            this.gridControl1.DataSource = this.GetDataTable(); //dishMenu.GetAllObjectInstanceList();
            //this.gridControl1.DefaultView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

            gridView1.OptionsBehavior.Editable = false;

            gridView1.OptionsView.ShowGroupPanel = false;
        }

        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }


            int[] rowSelected = this.gridView1.GetSelectedRows();
          
            foreach(int iRow in rowSelected)
            {
                string id = this.gridView1.GetRowCellDisplayText(iRow, "Id");
            
                SqlServerDbMapper<DishMenu> dishMenuMap = new SqlServerDbMapper<DishMenu>();
                dishMenuMap.Delete(new DishMenu{ Id = Convert.ToInt32(id)});   
            }
            
            this.gridControl1.DataSource = this.GetDataTable();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if(e.SelectedControl != gridControl1)
                return;

            ToolTipControlInfo info = null;
            //Get the view at the current mouse position
            GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            if(view == null)
                return;

            //Get the view's element information that resides at the current position
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            //Display a hint for row indicator cells
            if(hi.HitTest == GridHitTest.RowIndicator)
            {
                //An object that uniquely identifies a row indicator cell
                object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("行数据基本信息：");
                foreach(GridColumn gridCol in view.Columns)
                {
                    if(gridCol.Visible)
                    {
                        sb.AppendFormat("    {0}：{1}\r\n", gridCol.Caption, view.GetRowCellDisplayText(hi.RowHandle, gridCol.FieldName));
                    }
                }
                info = new ToolTipControlInfo(o, sb.ToString());
            }

            //Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
            if(info != null)
            {
                e.Info = info;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ShowLineNumber = true;
            
            if(ShowLineNumber)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if(e.Info.IsRowIndicator)
                {
                    if(e.RowHandle >= 0)
                    {
                       
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                }
            }
        }

        private DataTable GetDataTable()
        {
            SqlServerExecute exe = new SqlServerExecute();

            return exe.FillDataTable(CommandType.Text, "select Id, Name, Code,Memo from dishmenu");
        }
        
        public bool ShowLineNumber
        {
            get;
            set;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int[] selectRowIdx = gridView1.GetSelectedRows();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.Caption == "备注")
            {
                if(DBNull.Value == e.Value)
                {
                    e.DisplayText = "空";
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            Color ori = e.Appearance.BackColor;
            if(e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.CornflowerBlue;
            }
            else
            {
                e.Appearance.BackColor = ori;
                //e.Appearance.Image = 
            }
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            //winGridViewPager1_OnDeleteSelected(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            winGridViewPager1_OnDeleteSelected(sender, e);
        }
    }
}