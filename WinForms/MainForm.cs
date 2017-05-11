using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMS.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace RMS.WinForms
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
           

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            frmMainTool mainTool = new frmMainTool();

            mainTool.Show(this.dockPanel1);

            mainTool.DockTo(this.dockPanel1, DockStyle.Right);


            frmMainInfo mainInfo = new frmMainInfo();
            mainInfo.Show(this.dockPanel1);

            mainInfo.DockTo(this.dockPanel1, DockStyle.Bottom);


            frmMain main = new frmMain();
            main.Show(this.dockPanel1);
            main.DockTo(this.dockPanel1, DockStyle.Fill);

            //this.frmSelectArea.Left = 517;
            //this.frmSelectArea.Top = 107;
            //this.frmSelectArea.frmMain = this;
        }
    }
}
