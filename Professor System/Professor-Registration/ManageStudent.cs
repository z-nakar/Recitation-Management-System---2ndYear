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
    public partial class ManageStudent : Form
    {
        string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";
        private DataRow lastDeletedRow;
        private int lastDeletedRowIndex;
        public ManageStudent()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadStudentData();
        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    conn.Open();

                    // Construct the query to retrieve student data including std_picture as byte array
                    string query = @"
                        SELECT DISTINCT 
                            su.std_ID,
                            su.first_name AS 'First Name', 
                            su.last_name AS 'Last Name', 
                            r.course AS 'Course',
                            r.section AS 'Section',
                            rc.subj_code AS 'Subject Code',
                            r.std_picture AS 'Picture'
                        FROM signup_tb_proxy su
                        JOIN register_tb r ON su.std_ID = r.std_ID
                        JOIN lifepoints_tb_proxy rc ON su.std_ID = rc.std_ID
                        WHERE prof_id = @prof_id AND 1=1";

                    // Add WHERE clauses based on ComboBox selections
                    if (cbx_course.SelectedIndex != -1)
                    {
                        query += $" AND r.course = @course";
                    }
                    if (cbx_section.SelectedIndex != -1)
                    {
                        query += $" AND r.section = @section";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prof_id", SignIn.ID);
                      
                        // Add parameters
                        if (cbx_course.SelectedIndex != -1)
                        {
                            cmd.Parameters.AddWithValue("@course", cbx_course.SelectedItem.ToString());
                        }
                        if (cbx_section.SelectedIndex != -1)
                        {
                            cmd.Parameters.AddWithValue("@section", cbx_section.SelectedItem.ToString());
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            dgv_studentList.DataSource = dataTable;

                            // Set the DataGridView column headers
                            dgv_studentList.Columns["First Name"].HeaderText = "First Name";
                            dgv_studentList.Columns["Last Name"].HeaderText = "Last Name";
                            dgv_studentList.Columns["Course"].HeaderText = "Course";
                            dgv_studentList.Columns["Section"].HeaderText = "Section";
                            dgv_studentList.Columns["Subject Code"].HeaderText = "Subject Code";

                            // Hide the std_ID column
                            dgv_studentList.Columns["std_ID"].Visible = false;

                            // Auto size columns to fill the DataGridView
                            dgv_studentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgv_studentList.Columns["Picture"];
                            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            dgv_studentList.RowTemplate.Height = 80;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComboBoxes()
        {
            // You can simplify adding items to ComboBoxes
            cbx_course.Items.AddRange(new string[] { "BSIT", "BSHM", "BSEDUC", "BSCPE" });
            cbx_section.Items.AddRange(new string[] { "1-1", "1-2", "2-1", "2-2" });

            cbx_course.SelectedIndex = 0;
            cbx_section.SelectedIndex = 0;

            // Attach event handlers for ComboBoxes
            cbx_course.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cbx_section.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When ComboBox selection changes, reload data
            LoadStudentData();
        }

        private void bttn_resetTable_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void bttn_delete_Click(object sender, EventArgs e)  
        {
            if (dgv_studentList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_studentList.SelectedRows[0];
                string studentID = selectedRow.Cells["std_ID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(constring))
                        {
                            conn.Open();
                            string query1 = "DELETE FROM register_TB WHERE std_ID = @std_ID";
                            using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                            {
                                cmd.Parameters.AddWithValue("@std_ID", studentID);
                                cmd.ExecuteNonQuery();
                            }

                            string querry2 = "DELETE FROM lifepoints_tb_proxy WHERE std_ID = @std_ID";
                            using (MySqlCommand cmd1 = new MySqlCommand(querry2, conn))
                            {
                                cmd1.Parameters.AddWithValue("@std_ID", studentID);
                                cmd1.ExecuteNonQuery();
                            }
                        }

                        // Remove the row from DataGridView after deletion
                        dgv_studentList.Rows.Remove(selectedRow);

                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bttn_update_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgv_studentList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_studentList.SelectedRows[0];

                // Extract necessary values from the selected row
                string studentID = selectedRow.Cells["std_ID"].Value?.ToString();
                string firstName = selectedRow.Cells["First Name"].Value?.ToString();
                string lastName = selectedRow.Cells["Last Name"].Value?.ToString();
                string course = selectedRow.Cells["Course"].Value?.ToString();
                string section = selectedRow.Cells["Section"].Value?.ToString();
                string subjectCode = selectedRow.Cells["Subject Code"].Value?.ToString();

                // Open connection and perform update
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        conn.Open();

                        // Use std_ID as identifier for updating
                        string updateQuery = @"
                UPDATE signup_tb_proxy su
                JOIN register_tb r ON su.std_ID = r.std_ID
                JOIN lifepoints_tb_proxy rc ON su.std_ID = rc.std_ID
                SET 
                    su.first_name = @first_name,
                    su.last_name = @last_name,
                    r.course = @course,
                    r.section = @section,
                    rc.subj_code = @subj_code
                WHERE su.std_ID = @std_ID";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            // Add parameters
                            cmd.Parameters.AddWithValue("@std_ID", studentID);
                            cmd.Parameters.AddWithValue("@first_name", firstName);
                            cmd.Parameters.AddWithValue("@last_name", lastName);
                            cmd.Parameters.AddWithValue("@course", course);
                            cmd.Parameters.AddWithValue("@section", section);
                            cmd.Parameters.AddWithValue("@subj_code", subjectCode);

                            // Execute the update
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were updated
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not found or no changes made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    // Refresh the DataGridView after update
                    LoadStudentData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void txtbx_searchBar_TextChanged(object sender, EventArgs e)
        {
            // Filter the data grid view based on the search text
            string filterText = txtbx_searchBar.Text.Trim().ToLower();
            DataTable dataTable = dgv_studentList.DataSource as DataTable;

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
            }
        }
    }
}
