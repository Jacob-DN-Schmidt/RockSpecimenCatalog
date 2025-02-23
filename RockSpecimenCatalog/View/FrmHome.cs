using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem324.View
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            if (frm.ShowDialog(this) != DialogResult.OK) { 
                Application.Exit();
            }

        }

        private void BtnBookEditor_Click(object sender, EventArgs e)
        {
            FrmSpecimen frm=new FrmSpecimen();
            frm.ShowDialog(this);
        }
    }
}
