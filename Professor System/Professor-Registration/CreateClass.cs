using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Prof_Registration
{
    public partial class CreateClass : Form
    {
        error_handling ER = new error_handling();
        string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";
        public CreateClass(int iD)
        {
            InitializeComponent();
            InitializeComboBoxes();
  

              
        }

        private void bttn_clear_Click(object sender, EventArgs e)
        {
            txtbx_subjectName.Clear();
            txtbx_subjectCode.Clear();
            txtbx_password.Clear();
            txtbx_startTime.Clear();
            txtbx_endTime.Clear();
            cbx_day.SelectedIndex = -1; // Clear selection instead of clearing items
        }

        private void InitializeComboBoxes()
        {
            // Initialize combo boxes with days from Monday to Saturday
            cbx_day.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            // Optionally, select Monday as default
            cbx_day.SelectedIndex = 0;

            // Attach event handler for ComboBox
            cbx_day.SelectedIndexChanged += cbx_day_SelectedIndexChanged;
        }

        private void bttn_create_Click(object sender, EventArgs e)
        {
            // Check if any field is empty
            if (ER.notNull(txtbx_subjectName.Text, txtbx_subjectCode.Text, txtbx_password.Text, txtbx_startTime.Text, txtbx_endTime.Text))
            {
                // Check if time format is correct (nn:nn)
                if (ER.IsValidNumberFormat(txtbx_startTime.Text) && ER.IsValidNumberFormat(txtbx_endTime.Text))
                {
                    // Check if start time is less than end time
                    if (ER.endAndStartTime(txtbx_startTime.Text, txtbx_endTime.Text))
                    {
                        using (MySqlConnection con = new MySqlConnection(constring))
                        {
                            con.Open();

                            // Check if subj_name and subj_code already exist
                            string checkQuery = "SELECT COUNT(*) FROM linkgenerator_tb WHERE subj_name = @s_name AND subj_code = @s_code";
                            MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
                            checkCmd.Parameters.AddWithValue("@s_name", txtbx_subjectName.Text);
                            checkCmd.Parameters.AddWithValue("@s_code", txtbx_subjectCode.Text);

                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("Subject name and code already exist in the database.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query = "INSERT INTO linkgenerator_tb(prof_id, class_pass, subj_name, subj_code, start_time, end_time, day_) " +
                                               "VALUES (@prof_id, @c_pass, @s_name, @s_code, @sTime, @eTime, @day)";
                                MySqlCommand cmd = new MySqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@prof_id", SignIn.ID);
                                cmd.Parameters.AddWithValue("@s_name", txtbx_subjectName.Text);
                                cmd.Parameters.AddWithValue("@s_code", txtbx_subjectCode.Text);
                                cmd.Parameters.AddWithValue("@c_pass", txtbx_password.Text);
                                cmd.Parameters.AddWithValue("@sTime", txtbx_startTime.Text);
                                cmd.Parameters.AddWithValue("@eTime", txtbx_endTime.Text);
                                cmd.Parameters.AddWithValue("@day", cbx_day.Text);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Creating Class Successfully!", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Starting time should not be higher than or equal to the end time.", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("\r\rNote: format is military clock,\r\rEx:\r\r       00:00 is 12am\r       12:00 is 12pm\r       \r       hours:minute ", "Invalid time format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fields should not be empty", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbx_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler for day combo box selection change
        }

        private void CreateClass_Load(object sender, EventArgs e)
        {

        }
    }
}
