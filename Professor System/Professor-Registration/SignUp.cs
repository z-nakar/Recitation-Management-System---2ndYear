using System.Security.Cryptography.Xml;
using MySql.Data.MySqlClient;
using static System.Collections.Specialized.BitVector32;
namespace Prof_Registration;


public partial class SignUp : Form
{
    error_handling ER = new error_handling();
    string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";
    SignIn si;

    public SignUp(SignIn si)
    {
        InitializeComponent();
        this.si = si;
        this.AcceptButton = btn_SignUp;
    }

    private void btnLogIn_Click(object sender, EventArgs e)
    {
        si.openChildForm(this);
    }

    private void btn_SignUp_Click(object sender, EventArgs e)
    {


        if (ER.notNull(txtbx_email.Text, txtbx_username.Text, txtbx_password.Text))
        {


            if (ER.emailChecker(txtbx_email.Text) )
            {

                if (ER.userNameLengthCheck(txtbx_username.Text))
                {

                    if (ER.passwordLengthCheck(txtbx_password.Text))
                    {                  
                        // Check if passwords match
                        if (txtbx_password.Text != txtbx_password_confirm.Text)
                        {
                            MessageBox.Show("The passwords you entered do not match. Please try again.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the method if passwords don't match
                        }
                        else
                        {
                            using (MySqlConnection con = new MySqlConnection(constring))
                            {
                                con.Open();
                                string query = "INSERT INTO signup_tb (email_, username, prof_password) " +
                                    "VALUES (@email, @username, @password)";
                                using (MySqlCommand cmd = new MySqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@email", txtbx_email.Text);
                                    cmd.Parameters.AddWithValue("@username", txtbx_username.Text);
                                    cmd.Parameters.AddWithValue("@password", txtbx_password.Text);

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Sign Up Successfully!!", "Sign Up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }else  MessageBox.Show("Password must be atleast 8", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else  MessageBox.Show("User name must greater than 4 and Lower than 16 characters ", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!ER.emailChecker(txtbx_email.Text))
                {
                    MessageBox.Show("Email must end with \"@gmail.com\" ", "Invalid email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }

        }
        else MessageBox.Show("Fields should not be empty", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);

    }

    private void SignUp_Load(object sender, EventArgs e)
    {

    }

    private void chck_ShowPass_CheckedChanged(object sender, EventArgs e)
    {
        txtbx_password.UseSystemPasswordChar = !txtbx_password.UseSystemPasswordChar;
        txtbx_password_confirm.UseSystemPasswordChar = !txtbx_password_confirm.UseSystemPasswordChar;
    }
}