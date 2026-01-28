namespace Prof_Registration
{
    partial class ManageStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStudent));
            txtbx_searchBar = new TextBox();
            label7 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel9 = new Panel();
            panel8 = new Panel();
            bttn_delete = new Button();
            bttn_update = new Button();
            bttn_resetTable = new Button();
            label4 = new Label();
            panel10 = new Panel();
            cbx_section = new ComboBox();
            cbx_course = new ComboBox();
            label8 = new Label();
            panel6 = new Panel();
            pictureBox1 = new PictureBox();
            panel11 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            dgv_studentList = new DataGridView();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_studentList).BeginInit();
            SuspendLayout();
            // 
            // txtbx_searchBar
            // 
            txtbx_searchBar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtbx_searchBar.Location = new Point(6, 6);
            txtbx_searchBar.Margin = new Padding(3, 2, 3, 2);
            txtbx_searchBar.Multiline = true;
            txtbx_searchBar.Name = "txtbx_searchBar";
            txtbx_searchBar.PlaceholderText = "Search ";
            txtbx_searchBar.Size = new Size(363, 32);
            txtbx_searchBar.TabIndex = 34;
            txtbx_searchBar.TextChanged += txtbx_searchBar_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(141, 6);
            label7.Name = "label7";
            label7.Size = new Size(139, 26);
            label7.TabIndex = 9;
            label7.Text = "Student List";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(387, 145);
            label1.Name = "label1";
            label1.Size = new Size(73, 24);
            label1.TabIndex = 39;
            label1.Text = "Section";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.info;
            pictureBox2.Location = new Point(175, 107);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 14);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Black;
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(1, 256);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(789, 1);
            panel9.TabIndex = 32;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BackgroundImage = (Image)resources.GetObject("panel8.BackgroundImage");
            panel8.Controls.Add(bttn_delete);
            panel8.Controls.Add(bttn_update);
            panel8.Controls.Add(label1);
            panel8.Controls.Add(bttn_resetTable);
            panel8.Controls.Add(pictureBox2);
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(label4);
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(cbx_section);
            panel8.Controls.Add(cbx_course);
            panel8.Controls.Add(label8);
            panel8.Controls.Add(panel6);
            panel8.Controls.Add(panel11);
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(panel13);
            panel8.Location = new Point(-13, 13);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(791, 257);
            panel8.TabIndex = 13;
            // 
            // bttn_delete
            // 
            bttn_delete.BackColor = Color.Transparent;
            bttn_delete.FlatAppearance.BorderColor = Color.Maroon;
            bttn_delete.FlatAppearance.BorderSize = 2;
            bttn_delete.FlatStyle = FlatStyle.Flat;
            bttn_delete.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_delete.Location = new Point(316, 204);
            bttn_delete.Margin = new Padding(3, 2, 3, 2);
            bttn_delete.Name = "bttn_delete";
            bttn_delete.Size = new Size(124, 34);
            bttn_delete.TabIndex = 41;
            bttn_delete.Text = "Delete";
            bttn_delete.UseVisualStyleBackColor = false;
            bttn_delete.Click += bttn_delete_Click;
            // 
            // bttn_update
            // 
            bttn_update.BackColor = Color.Maroon;
            bttn_update.FlatAppearance.BorderColor = Color.Maroon;
            bttn_update.FlatAppearance.BorderSize = 2;
            bttn_update.FlatStyle = FlatStyle.Flat;
            bttn_update.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_update.ForeColor = Color.Transparent;
            bttn_update.Location = new Point(175, 204);
            bttn_update.Margin = new Padding(3, 2, 3, 2);
            bttn_update.Name = "bttn_update";
            bttn_update.Size = new Size(122, 34);
            bttn_update.TabIndex = 40;
            bttn_update.Text = "Update";
            bttn_update.UseVisualStyleBackColor = false;
            bttn_update.Click += bttn_update_Click;
            // 
            // bttn_resetTable
            // 
            bttn_resetTable.BackColor = Color.FromArgb(219, 167, 41);
            bttn_resetTable.FlatAppearance.BorderColor = Color.Black;
            bttn_resetTable.FlatAppearance.BorderSize = 0;
            bttn_resetTable.FlatStyle = FlatStyle.Flat;
            bttn_resetTable.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_resetTable.Location = new Point(457, 204);
            bttn_resetTable.Margin = new Padding(3, 2, 3, 2);
            bttn_resetTable.Name = "bttn_resetTable";
            bttn_resetTable.Size = new Size(131, 34);
            bttn_resetTable.TabIndex = 11;
            bttn_resetTable.Text = "Reload";
            bttn_resetTable.UseVisualStyleBackColor = false;
            bttn_resetTable.Click += bttn_resetTable_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Light", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(196, 108);
            label4.Name = "label4";
            label4.Size = new Size(139, 13);
            label4.TabIndex = 15;
            label4.Text = "(Note: First name, Last name)";
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(219, 167, 41);
            panel10.Controls.Add(label7);
            panel10.Location = new Point(175, 9);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(413, 39);
            panel10.TabIndex = 27;
            // 
            // cbx_section
            // 
            cbx_section.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbx_section.FormattingEnabled = true;
            cbx_section.Location = new Point(467, 140);
            cbx_section.Margin = new Padding(3, 2, 3, 2);
            cbx_section.Name = "cbx_section";
            cbx_section.Size = new Size(121, 32);
            cbx_section.TabIndex = 14;
            // 
            // cbx_course
            // 
            cbx_course.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbx_course.FormattingEnabled = true;
            cbx_course.Location = new Point(252, 140);
            cbx_course.Margin = new Padding(3, 2, 3, 2);
            cbx_course.Name = "cbx_course";
            cbx_course.Size = new Size(118, 32);
            cbx_course.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(175, 144);
            label8.Name = "label8";
            label8.Size = new Size(71, 24);
            label8.TabIndex = 11;
            label8.Text = "Course";
            // 
            // panel6
            // 
            panel6.Controls.Add(pictureBox1);
            panel6.Controls.Add(txtbx_searchBar);
            panel6.Location = new Point(175, 65);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 43);
            panel6.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(371, 5);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Black;
            panel11.Dock = DockStyle.Left;
            panel11.Location = new Point(0, 1);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(1, 256);
            panel11.TabIndex = 30;
            // 
            // panel12
            // 
            panel12.BackColor = Color.Black;
            panel12.Dock = DockStyle.Right;
            panel12.Location = new Point(790, 1);
            panel12.Margin = new Padding(3, 2, 3, 2);
            panel12.Name = "panel12";
            panel12.Size = new Size(1, 256);
            panel12.TabIndex = 31;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Black;
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Margin = new Padding(3, 2, 3, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(791, 1);
            panel13.TabIndex = 33;
            // 
            // dgv_studentList
            // 
            dgv_studentList.BackgroundColor = Color.White;
            dgv_studentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_studentList.Dock = DockStyle.Bottom;
            dgv_studentList.Location = new Point(0, 269);
            dgv_studentList.Margin = new Padding(3, 2, 3, 2);
            dgv_studentList.Name = "dgv_studentList";
            dgv_studentList.RowHeadersWidth = 51;
            dgv_studentList.Size = new Size(762, 249);
            dgv_studentList.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Maroon;
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(762, 11);
            panel7.TabIndex = 12;
            // 
            // ManageStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 518);
            Controls.Add(panel8);
            Controls.Add(dgv_studentList);
            Controls.Add(panel7);
            Name = "ManageStudent";
            Text = "ManageStudent";
            Load += ManageStudent_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_studentList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtbx_searchBar;
        private Label label7;
        private Label label1;
        private PictureBox pictureBox2;
        private Panel panel9;
        private Panel panel8;
        private Label label4;
        private Panel panel10;
        private ComboBox cbx_section;
        private ComboBox cbx_course;
        private Label label8;
        private Panel panel6;
        private PictureBox pictureBox1;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Button bttn_resetTable;
        private DataGridView dgv_studentList;
        private Panel panel7;
        private Button bttn_delete;
        private Button bttn_update;
    }
}