using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Prof_Registration
{
    public partial class Points : Form
    {
        string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";
        string subjectCode;
        private System.Windows.Forms.Timer statusCheckTimer;

        public Points(string subjectCode)
        {
            InitializeComponent();
            this.subjectCode = subjectCode;

            InitializeComboBoxes();
            LoadComboBoxes();
            InitializeTimer();

            cbx_course.SelectedIndexChanged += cbx_section_SelectedIndexChanged;
            cbx_section.SelectedIndexChanged += cbx_section_SelectedIndexChanged;

            LoadData(subjectCode); // Load data once ComboBoxes are initialized
        }

        private void InitializeTimer()
        {
            statusCheckTimer = new System.Windows.Forms.Timer();
            statusCheckTimer.Interval = 1000; // 1 second
            statusCheckTimer.Tick += StatusCheckTimer_Tick;
            statusCheckTimer.Start();
        }

        private void Points_Load(object sender, EventArgs e)
        {
            LoadData(subjectCode);
        }

        private void InitializeComboBoxes()
        {
            cbx_course.Items.Clear();
            cbx_course.Items.AddRange(new string[] { "BSIT", "BSHM", "BSEDUC", "BSCPE" });

            cbx_section.Items.Clear();
            cbx_section.Items.AddRange(new string[] { "1-1", "1-2", "2-1", "2-2", "3-1", "3-2" });

            cbx_course.SelectedIndex = 0;
            cbx_section.SelectedIndex = 0;
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(constring))
                {
                    connection.Open();

                    string courseQuery = "SELECT DISTINCT Course FROM register_tb";
                    MySqlCommand courseCommand = new MySqlCommand(courseQuery, connection);
                    MySqlDataReader courseReader = courseCommand.ExecuteReader();
                    while (courseReader.Read())
                    {
                        string course = courseReader.GetString("Course");
                        if (!cbx_course.Items.Contains(course))
                        {
                            cbx_course.Items.Add(course);
                        }
                    }
                    courseReader.Close();

                    string sectionQuery = "SELECT DISTINCT Section FROM register_tb";
                    MySqlCommand sectionCommand = new MySqlCommand(sectionQuery, connection);
                    MySqlDataReader sectionReader = sectionCommand.ExecuteReader();
                    while (sectionReader.Read())
                    {
                        string section = sectionReader.GetString("Section");
                        if (!cbx_section.Items.Contains(section))
                        {
                            cbx_section.Items.Add(section);
                        }
                    }
                    sectionReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo boxes: {ex.Message}");
            }
        }

        private void UpdateRecitationPoints(int studentId, int pointChange, string subjCode)
        {
            string checkQuery = @"
                SELECT su.recitation_pts 
                FROM signup_tb_proxy su
                JOIN lifepoints_tb_proxy rc ON su.std_ID = rc.std_ID
                WHERE su.std_ID = @std_ID AND rc.subj_code = @subj_code";

            string updateQuery = @"
                UPDATE signup_tb_proxy 
                SET recitation_pts = recitation_pts + @pointChange
                WHERE std_ID = @std_ID";

            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@std_ID", studentId);
                        checkCmd.Parameters.AddWithValue("@subj_code", subjCode);

                        object result = checkCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Student not enrolled in the specified subject.");
                            return;
                        }

                        int currentPoints = Convert.ToInt32(result);
                        if (currentPoints + pointChange < 0)
                        {
                            MessageBox.Show("Points cannot be negative.");
                            return;
                        }
                    }

                    // Update the points
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@std_ID", studentId);
                        updateCmd.Parameters.AddWithValue("@pointChange", pointChange);

                        updateCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating points: {ex.Message}");
                }
            }
        }

        private void UpdateSelectedStudentPoints(int pointChange)
        {
            if (dgv_data.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dgv_data.SelectedRows[0].Cells["ID"].Value);
                string subjCode = dgv_data.SelectedRows[0].Cells["Subject Code"].Value.ToString();

                UpdateRecitationPoints(studentId, pointChange, subjCode);

                LoadData(subjCode);
            }
            else
            {
                MessageBox.Show("Please select a student row to update points.");
            }
        }

        private void LoadData(string subjCode)
        {
            try
            {
                string selectedCourse = cbx_course.SelectedItem?.ToString();
                string selectedSection = cbx_section.SelectedItem?.ToString();

                using (MySqlConnection conn = new MySqlConnection(constring))
                using (MySqlCommand cmd = new MySqlCommand())
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    // Construct the query with the necessary joins and filters
                    string query = @"
                SELECT DISTINCT  
                    su.std_ID AS ID,
                    su.first_name AS 'First Name', 
                    su.last_name AS 'Last Name', 
                    r.course AS 'Course',
                    r.section AS 'Section',
                    su.recitation_pts AS 'Recitation Points', 
                    lg.subj_code AS 'Subject Code', 
                    r.status_code AS Status                       
                FROM signup_tb_proxy su
                JOIN register_tb r ON su.std_ID = r.std_ID
                JOIN lifepoints_tb_proxy rc ON su.std_ID = rc.std_ID
                JOIN linkgenerator_tb lg ON rc.subj_code = lg.subj_code AND r.class_pass = lg.class_pass
                WHERE rc.subj_code = @subj_code
                AND r.course = @course
                AND r.section = @section";

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@subj_code", subjCode);
                    cmd.Parameters.AddWithValue("@course", selectedCourse ?? "");
                    cmd.Parameters.AddWithValue("@section", selectedSection ?? "");

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgv_data.DataSource = dataTable;

                    // Hide the "Status" and "ID" columns
                    dgv_data.Columns["Status"].Visible = false;
                    dgv_data.Columns["ID"].Visible = false;

                    // Add the status_image column to the end if it doesn't already exist
                    if (!dgv_data.Columns.Contains("status_image"))
                    {
                        DataGridViewImageColumn statusImageColumn = new DataGridViewImageColumn();
                        statusImageColumn.Name = "status_image";
                        statusImageColumn.HeaderText = "Status";
                        statusImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dgv_data.Columns.Add(statusImageColumn);
                        dgv_data.RowTemplate.Height = 50; // Set the row height to fit the image
                    }

                    // Set the status image based on the Status value
                    foreach (DataGridViewRow row in dgv_data.Rows)
                    {
                        if (row.Cells["Status"].Value != null)
                        {
                            int statusCode = Convert.ToInt32(row.Cells["Status"].Value);
                            row.Cells["status_image"].Value = GetStatusImage(statusCode);
                        }
                    }

                    dgv_data.Refresh();
                    dgv_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }


        private System.Drawing.Image GetStatusImage(int statusCode)
        {

            switch (statusCode)
            {
                case 0:
                    return Properties.Resources.RedImage; // Replace with actual image
                case 1:
                    return Properties.Resources.GreenImage; // Replace with actual image
                case 2:
                    return Properties.Resources.OrangeImage; // Replace with actual image
                default:
                    return null; // Or a default image
            }
        }

        private void UpdateStatusImages()
        {

            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    int statusCode = Convert.ToInt32(row.Cells["Status"].Value);
                    row.Cells["status_image"].Value = GetStatusImage(statusCode);
                }
            }

            dgv_data.Refresh();
        }

        private void btn_addPoints_Click(object sender, EventArgs e)
        {
            UpdateSelectedStudentPoints(1);
        }

        private void btn_minusPoints_Click(object sender, EventArgs e)
        {
            UpdateSelectedStudentPoints(-1);
        }

        private void bttn_refreshData_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();
                    string query = "UPDATE register_tb SET status_code = 2 WHERE status_code = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} rows updated to status code 2.");
                    }
                }

                // Refresh the data grid view to reflect the changes
                LoadData(subjectCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}");
            }
        }

        private void StatusCheckTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    con.Open();

                    // Query to select all rows with status code 1
                    string selectQuery = "SELECT std_ID FROM register_tb WHERE status_code = 1";

                    // Execute the query
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                    {
                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            // If any rows with status code 1 are found, refresh the DataGridView
                            if (reader.HasRows)
                            {
                                LoadData(subjectCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking status: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Stop the timer
            if (statusCheckTimer != null)
            {
                statusCheckTimer.Stop();
                statusCheckTimer.Dispose();
            }
        }

        private void cbx_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(subjectCode);
        }

        private void txtbx_search_TextChanged(object sender, EventArgs e)
        {
            // Filter the data grid view based on the search text
            string filterText = txtbx_search.Text.Trim().ToLower();
            DataTable dataTable = dgv_data.DataSource as DataTable;

            if (dataTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    // Clear the row filter to show all rows
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Apply row filter to the DataTable
                    dataTable.DefaultView.RowFilter =
                        $"[First Name] LIKE '%{filterText}%' OR [Last Name] LIKE '%{filterText}%'";
                }

                // Update the status images for the filtered rows
                UpdateStatusImages();
                dgv_data.Refresh();
            }
        }

        private void bttn_reset_Click(object sender, EventArgs e)
        {
            string class_pass = "";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();

                // Retrieve class_pass based on professor ID and subject code
                string selectQuery = "SELECT class_pass FROM linkgenerator_tb WHERE prof_id = @prof_id AND subj_code = @subj_code";
                using (MySqlCommand cmd1 = new MySqlCommand(selectQuery, con))
                {
                    cmd1.Parameters.AddWithValue("@prof_id", SignIn.ID);
                    cmd1.Parameters.AddWithValue("@subj_code", subjectCode);

                    object cPAss = cmd1.ExecuteScalar();
                    if (cPAss != null)
                    {
                        class_pass = cPAss.ToString();
                    }
                }

                // Update status_code to 0
                string updateStatusQuery = "UPDATE register_tb SET status_code = 0 WHERE prof_id = @prof_id AND class_pass = @class_pass AND section = @section AND course = @course";
                using (MySqlCommand cmd2 = new MySqlCommand(updateStatusQuery, con))
                {
                    cmd2.Parameters.AddWithValue("@prof_id", SignIn.ID);
                    cmd2.Parameters.AddWithValue("@class_pass", class_pass);
                    cmd2.Parameters.AddWithValue("@course", cbx_course.SelectedItem.ToString());
                    cmd2.Parameters.AddWithValue("@section", cbx_section.SelectedItem.ToString());

                    cmd2.ExecuteNonQuery();
                }

                // Reset life points to 3
                string resetPointsQuery = "UPDATE lifepoints_tb_proxy lp JOIN register_tb r ON lp.std_ID = r.std_ID SET lp.life_points = 3 WHERE r.prof_id = @prof_id AND r.class_pass = @class_pass AND r.section = @section AND r.course = @course";
                using (MySqlCommand cmd3 = new MySqlCommand(resetPointsQuery, con))
                {
                    cmd3.Parameters.AddWithValue("@prof_id", SignIn.ID);
                    cmd3.Parameters.AddWithValue("@class_pass", class_pass);
                    cmd3.Parameters.AddWithValue("@course", cbx_course.SelectedItem.ToString());
                    cmd3.Parameters.AddWithValue("@section", cbx_section.SelectedItem.ToString());

                    cmd3.ExecuteNonQuery();
                }
            }

            LoadData(subjectCode);
        }


        private void bttn_addLifePoints_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();

                    // Retrieve the selected course and section
                    string selectedCourse = cbx_course.SelectedItem?.ToString();
                    string selectedSection = cbx_section.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(selectedCourse) || string.IsNullOrEmpty(selectedSection))
                    {
                        MessageBox.Show("Please select both course and section.");
                        return;
                    }

                    // Update query to include course and section filters, and join with linkgenerator to get subj_code
                    string updateQuery = @"
                         UPDATE lifepoints_tb_proxy rcp
                         JOIN register_tb reg ON rcp.std_ID = reg.std_ID
                         JOIN linkgenerator_tb lg ON rcp.subj_code = lg.subj_code
                         SET rcp.life_points = rcp.life_points + 1
                         WHERE lg.subj_code = @subj_code AND reg.course = @course AND reg.section = @section";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                    {
                        // Retrieve the subj_code from linkgenerator based on the selected course and section
                        string subjCodeQuery = @"
                         SELECT lg.subj_code
                         FROM linkgenerator_tb lg
                         JOIN register_tb reg ON lg.class_pass = reg.class_pass
                         WHERE reg.course = @course AND reg.section = @section";

                        // Set the parameters for the update query
                        cmd.Parameters.AddWithValue("@subj_code", subjectCode);
                        cmd.Parameters.AddWithValue("@course", selectedCourse);
                        cmd.Parameters.AddWithValue("@section", selectedSection);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} students' life points updated.");
                    }

                    // Reload data to reflect the changes
                    LoadData(subjectCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void txtbx_startTime_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
