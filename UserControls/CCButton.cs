using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UserControls
{
    public partial class CCButton : UserControl
    {
        

        public CCButton()
        {
            InitializeComponent();
        }

        public new event EventHandler<RMS.UserControls.CCButtonGrid.MyClickEventArgs> Click;
        public event EventHandler<RMS.UserControls.CCButtonGrid.MyClickEventArgs> DblClick;

    }
}
