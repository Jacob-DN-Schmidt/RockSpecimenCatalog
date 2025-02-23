using LibrarySystem324.Model;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = DBEngine.GetTable("select * from userverification where upper(email)='" + txtLoginID.Text.ToUpper()
        + "' and userPassword='" + txtPassword.Text + "'");

            bool ok = dt.Rows.Count > 0;
            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            char c = '\u2022';                      // or "\u25cf"
            txtPassword.PasswordChar = c;
        }
    }
}
