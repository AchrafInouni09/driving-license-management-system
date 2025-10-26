using dvld_business_layer;
using System;
using System.Windows.Forms;

namespace dvld_presantation_layer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void picCloseForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CBrememberme_CheckedChanged(object sender, EventArgs e)
        {
            if (CBrememberme.Checked)
            {

            }
        }

        private void btmLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxUserName.Text))
            {
                errorProvider1.SetError(txtBoxUserName, "login failed");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBoxUserName, "");
            }

            if (string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                errorProvider1.SetError(txtBoxPassword, "login failed");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBoxPassword, "");
            }


            if (clsUsers.Find(txtBoxUserName.Text, txtBoxPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(txtBoxUserName, "login failed");
                errorProvider1.SetError(txtBoxPassword, "");
            }
        }
    }
}
