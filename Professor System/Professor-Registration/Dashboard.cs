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
    public partial class Dashboard : Form
    {
        private System.Windows.Forms.Timer timer;
        string subjectCode;
        string constring = "server=localhost;database=professor_application;uid=root;password=admin2004-01-15";
        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public Dashboard()
        {
            InitializeComponent();
            customizedPanelDesign(); // Call to hide submenus initially

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                string query = "SELECT subj_code from linkgenerator_tb WHERE prof_id = @ID";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", SignIn.ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    subjectCode = reader["subj_code"].ToString();
                    CreateDynamicButton(subjectCode);
                }

                reader.Close();
            }
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start(); // Start the timer
        }

        private void customizedPanelDesign()
        {
            pnl_dynamicButton.Visible = false;
            panel_menu.Visible = true;
        }

        private void hideSubmenu()
        {
            if (pnl_dynamicButton.Visible == true)
                pnl_dynamicButton.Visible = false;
        }

        private void ShowSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Perform the task to check for new classes and update the interface
            CheckForNewClasses();
        }

        private void CheckForNewClasses()
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                string query = "SELECT subj_code FROM linkgenerator_tb WHERE prof_id = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", SignIn.ID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjCode = reader["subj_code"].ToString();
                            // Check if the button for this subject code already exists
                            if (!ButtonExists(subjCode))
                            {
                                // If the button doesn't exist, create it
                                CreateDynamicButton(subjCode);
                            }
                        }
                    }
                }
            }
        }

        private bool ButtonExists(string subjCode)
        {
            // Iterate through the controls in pnl_classes and check if a button with the specified Tag exists
            foreach (Control control in pnl_dynamicButton.Controls)
            {
                if (control is Button button && button.Tag != null && button.Tag.ToString() == subjCode)
                {
                    return true;
                }
            }
            return false;
        }

        void CreateDynamicButton(string class_code)
        {
            Button dynamicButton = new Button(); // Create a new instance of Button
            dynamicButton.Dock = DockStyle.Top; // Adjust the DockStyle as needed
            dynamicButton.Text = class_code;
            dynamicButton.Enabled = true;
            dynamicButton.ForeColor = Color.White; // Set font color to white
            dynamicButton.BackColor = Color.Maroon; // Set background color to maroon
            dynamicButton.Height = 50; // Set height to 20px
            dynamicButton.FlatStyle = FlatStyle.Flat; // Set flat style
            dynamicButton.FlatAppearance.BorderSize = 0; // Set border size to 0

            // Change background color on mouse down
            dynamicButton.FlatAppearance.MouseDownBackColor = Color.Maroon;
            // Change background color on mouse over
            dynamicButton.FlatAppearance.MouseOverBackColor = Color.Firebrick;

            // Set font to Century, 11.25pt, style=Bold
            dynamicButton.Font = new Font("Century", 9.15F, FontStyle.Bold);

            dynamicButton.Click += dynamicButton_Clicked;
            pnl_dynamicButton.Controls.Add(dynamicButton);

            using (MySqlConnection connection = new MySqlConnection(constring))
            {
                connection.Open();
                string query = "SELECT subj_code FROM linkgenerator_tb WHERE subj_code = @scode";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@scode", class_code);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string subcode = reader["subj_code"].ToString();
                            // Save the subj_code in the button's Tag property
                            dynamicButton.Tag = subcode;
                        }
                    }
                }
            }
        }

        private void dynamicButton_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender; // Cast sender to Button
            subjectCode = clickedButton.Tag.ToString(); // Get the subj_code from the Tag property

            // Pass the subjectCode to the Points class and open it
            Points p = new Points(subjectCode);
            openChildForm(p);
        }

        private void bttn_createClass_Click(object sender, EventArgs e)
        {
            panel_panel.Visible = true;
            CreateClass cc = new CreateClass(SignIn.ID);
            cc.Show();
            openChildForm(cc);
        }

        private void bttn_manageStudent_Click(object sender, EventArgs e)
        {
            panel_panel.Visible = true;
            ManageStudent ms = new ManageStudent();
            openChildForm(ms);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            customizedPanelDesign(); // Ensure submenus are hidden initially
        }

        private void bttn_class_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_dynamicButton);
        }

        private void bttn_logout_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }

        private void bttn_dashboard_Click(object sender, EventArgs e)
        {
            DashBoardPanel dbp = new DashBoardPanel();
            dbp.Show();
            openChildForm(dbp);
        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
