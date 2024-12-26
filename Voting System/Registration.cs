using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Voting_System
{
    public partial class Registration : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VotingDB.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter ada = new OleDbDataAdapter();
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = email.Text;
            
            if(firstname.Text == "" || lastname.Text == "" || email.Text == "" || birth.Text =="" || contact.Text == "" || password.Text == "" || reenter.Text == "")
            {
                MessageBox.Show("Fields are not all completed yet.");
            }
            else if (password.Text == reenter.Text)
            {
                con.Open();
                string register = "INSERT into tbl_users VALUES('" + email.Text + "','" + password.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();
                if (!Email.Contains("@") || !Email.Contains("."))
                {
                    MessageBox.Show("Please Enter a Valid Email");
                    email.Focus();
                }
                MessageBox.Show("Account has been created");
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if(showpass.Checked)
            {
                password.PasswordChar = '\0';
                reenter.PasswordChar = '\0';
            } else
            {
                password.PasswordChar = '*';
                reenter.PasswordChar = '*';
            }
        }

        private void firstname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstname.Text))
            {
                fn.Visible = true;
            }
            else
            {
                fn.Visible = false;
            }
        }

        private void lastname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastname.Text))
            {
                ln.Visible = true;
            }
            else
            {
                ln.Visible = false;
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                emailLb.Visible = true;
            }
            else
            {
                emailLb.Visible = false;
            }
        }

        private void contact_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contact.Text))
            {
                cntct.Visible = true;
            }
            else
            {
                cntct.Visible = false;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text))
            {
                passlbl.Visible = true;
            }
            else
            {
                passlbl.Visible = false;
            }
        }

        private void reenter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reenter.Text))
            {
                rnpass.Visible = true;
            }
            else
            {
                rnpass.Visible = false;
            }
        }
    }
}
