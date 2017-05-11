using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI;
using RMS.WinForms;

namespace WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //FormSon form2 = new FormSon();

            //form2.Show(this.dockPanel1);

            //form2.DockTo(this.dockPanel1, DockStyle.Bottom); 
        }

        private void 下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormSon frm = new FormSon();
            //frm.Show(this.dockPanel1);
            //frm.Text = "底部停靠";

            //frmMainTool form2 = new frmMainTool();
            //form2.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            //form2.Show(this.dockPanel1);
            //form2.DockTo(this.dockPanel1, DockStyle.Bottom);
            
        }
    }
}
