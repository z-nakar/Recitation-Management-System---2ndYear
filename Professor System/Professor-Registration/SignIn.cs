using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prof_Registration
{

    public partial class SignIn : Form
    {
        error_handling ER = new error_handling();
        static public int ID;
        string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";

        private Form activeForm = null;


        public SignIn()
        {
            InitializeComponent();
            panel_logo.Visible = true;
            txtbx_username.TabIndex = 0;
            txtbx_password.TabIndex = 1;
            this.AcceptButton = btn_SignIn;
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1_parent.Controls.Add(childForm);
            panel1_parent.Tag = childForm;
            childForm.BringToFront();

            childForm.Show();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();

            openChildForm(new SignUp(si));
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            if (ER.notNull(txtbx_username.Text) && ER.notNull(txtbx_password.Text))
            {

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    string query = "SELECT prof_id from signup_tb WHERE username = @username AND prof_password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtbx_username.Text);
                        cmd.Parameters.AddWithValue("@password", txtbx_password.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {

                            ID = Convert.ToInt32(result);
                            Dashboard dh = new Dashboard();
                            dh.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Your username or password is incorrect!", "Invalid credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else MessageBox.Show("Fields should not be empty", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void chck_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
           txtbx_password.UseSystemPasswordChar = !txtbx_password.UseSystemPasswordChar;
        }
    }
}
