namespace Prof_Registration
{
    partial class Points
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Points));
            panel1 = new Panel();
            panel2 = new Panel();
            dgv_data = new DataGridView();
            panel_classrRecit = new Panel();
            pic_info = new PictureBox();
            panel10 = new Panel();
            label7 = new Label();
            bttn_addLifePoints = new Button();
            bttn_reset = new Button();
            bttn_refreshData = new Button();
            lbl_points = new Label();
            btn_minusPoints = new Button();
            btn_addPoints = new Button();
            panel6 = new Panel();
            cbx_section = new ComboBox();
            cbx_course = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtbx_search = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_data).BeginInit();
            panel_classrRecit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_info).BeginInit();
            panel10.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(dgv_data);
            panel1.Controls.Add(panel_classrRecit);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(765, 518);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Maroon;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(765, 10);
            panel2.TabIndex = 9;
            panel2.Paint += panel2_Paint;
            // 
            // dgv_data
            // 
            dgv_data.BackgroundColor = Color.White;
            dgv_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_data.Dock = DockStyle.Bottom;
            dgv_data.Location = new Point(0, 308);
            dgv_data.Name = "dgv_data";
            dgv_data.RowHeadersWidth = 51;
            dgv_data.Size = new Size(765, 210);
            dgv_data.TabIndex = 7;
            // 
            // panel_classrRecit
            // 
            panel_classrRecit.BackColor = Color.White;
            panel_classrRecit.BackgroundImage = (Image)resources.GetObject("panel_classrRecit.BackgroundImage");
            panel_classrRecit.Controls.Add(pic_info);
            panel_classrRecit.Controls.Add(panel10);
            panel_classrRecit.Controls.Add(bttn_addLifePoints);
            panel_classrRecit.Controls.Add(bttn_reset);
            panel_classrRecit.Controls.Add(bttn_refreshData);
            panel_classrRecit.Controls.Add(lbl_points);
            panel_classrRecit.Controls.Add(btn_minusPoints);
            panel_classrRecit.Controls.Add(btn_addPoints);
            panel_classrRecit.Controls.Add(panel6);
            panel_classrRecit.Controls.Add(cbx_section);
            panel_classrRecit.Controls.Add(cbx_course);
            panel_classrRecit.Controls.Add(label2);
            panel_classrRecit.Controls.Add(label3);
            panel_classrRecit.Controls.Add(panel3);
            panel_classrRecit.Controls.Add(panel5);
            panel_classrRecit.Controls.Add(panel7);
            panel_classrRecit.Controls.Add(flowLayoutPanel1);
            panel_classrRecit.Location = new Point(4, 13);
            panel_classrRecit.Margin = new Padding(4);
            panel_classrRecit.Name = "panel_classrRecit";
            panel_classrRecit.Size = new Size(757, 293);
            panel_classrRecit.TabIndex = 6;
            // 
            // pic_info
            // 
            pic_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pic_info.Image = (Image)resources.GetObject("pic_info.Image");
            pic_info.Location = new Point(231, 175);
            pic_info.Name = "pic_info";
            pic_info.Size = new Size(21, 0);
            pic_info.SizeMode = PictureBoxSizeMode.Zoom;
            pic_info.TabIndex = 28;
            pic_info.TabStop = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(219, 167, 41);
            panel10.Controls.Add(label7);
            panel10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            panel10.Location = new Point(169, 5);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(431, 39);
            panel10.TabIndex = 190;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(119, 7);
            label7.Name = "label7";
            label7.Size = new Size(184, 25);
            label7.TabIndex = 9;
            label7.Text = "Class Recitation";
            label7.TextAlign = ContentAlignment.TopCenter;
            label7.Click += label7_Click;
            // 
            // bttn_addLifePoints
            // 
            bttn_addLifePoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            bttn_addLifePoints.BackColor = Color.Maroon;
            bttn_addLifePoints.FlatAppearance.BorderColor = Color.Maroon;
            bttn_addLifePoints.FlatAppearance.BorderSize = 2;
            bttn_addLifePoints.FlatStyle = FlatStyle.Flat;
            bttn_addLifePoints.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_addLifePoints.ForeColor = Color.Transparent;
            bttn_addLifePoints.Location = new Point(172, 228);
            bttn_addLifePoints.Name = "bttn_addLifePoints";
            bttn_addLifePoints.Size = new Size(180, 44);
            bttn_addLifePoints.TabIndex = 40;
            bttn_addLifePoints.Text = "ADD LIFE POINTS";
            bttn_addLifePoints.UseVisualStyleBackColor = false;
            bttn_addLifePoints.Click += bttn_addLifePoints_Click;
            // 
            // bttn_reset
            // 
            bttn_reset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            bttn_reset.BackColor = Color.FromArgb(219, 167, 41);
            bttn_reset.FlatAppearance.BorderColor = Color.FromArgb(219, 167, 41);
            bttn_reset.FlatAppearance.BorderSize = 2;
            bttn_reset.FlatStyle = FlatStyle.Flat;
            bttn_reset.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_reset.Location = new Point(498, 228);
            bttn_reset.Name = "bttn_reset";
            bttn_reset.Size = new Size(102, 42);
            bttn_reset.TabIndex = 39;
            bttn_reset.Text = "RESET";
            bttn_reset.UseVisualStyleBackColor = false;
            bttn_reset.Click += bttn_reset_Click;
            // 
            // bttn_refreshData
            // 
            bttn_refreshData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            bttn_refreshData.BackColor = Color.Transparent;
            bttn_refreshData.FlatAppearance.BorderColor = Color.Black;
            bttn_refreshData.FlatAppearance.BorderSize = 2;
            bttn_refreshData.FlatStyle = FlatStyle.Flat;
            bttn_refreshData.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bttn_refreshData.ForeColor = Color.Black;
            bttn_refreshData.Location = new Point(367, 228);
            bttn_refreshData.Name = "bttn_refreshData";
            bttn_refreshData.Size = new Size(109, 44);
            bttn_refreshData.TabIndex = 36;
            bttn_refreshData.Text = "REFRESH";
            bttn_refreshData.UseVisualStyleBackColor = false;
            bttn_refreshData.Click += bttn_refreshData_Click;
            // 
            // lbl_points
            // 
            lbl_points.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_points.AutoSize = true;
            lbl_points.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_points.Location = new Point(169, 171);
            lbl_points.Name = "lbl_points";
            lbl_points.Size = new Size(61, 24);
            lbl_points.TabIndex = 35;
            lbl_points.Text = "Points";
            // 
            // btn_minusPoints
            // 
            btn_minusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_minusPoints.BackColor = Color.Transparent;
            btn_minusPoints.FlatAppearance.BorderColor = Color.Maroon;
            btn_minusPoints.FlatStyle = FlatStyle.Flat;
            btn_minusPoints.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_minusPoints.ForeColor = Color.Maroon;
            btn_minusPoints.Location = new Point(326, 163);
            btn_minusPoints.Name = "btn_minusPoints";
            btn_minusPoints.Size = new Size(53, 36);
            btn_minusPoints.TabIndex = 34;
            btn_minusPoints.Text = "-";
            btn_minusPoints.TextAlign = ContentAlignment.TopCenter;
            btn_minusPoints.UseVisualStyleBackColor = false;
            btn_minusPoints.Click += btn_minusPoints_Click;
            // 
            // btn_addPoints
            // 
            btn_addPoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_addPoints.BackColor = Color.Transparent;
            btn_addPoints.FlatAppearance.BorderColor = Color.Maroon;
            btn_addPoints.FlatStyle = FlatStyle.Flat;
            btn_addPoints.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_addPoints.ForeColor = Color.Maroon;
            btn_addPoints.Location = new Point(258, 163);
            btn_addPoints.Name = "btn_addPoints";
            btn_addPoints.Size = new Size(52, 36);
            btn_addPoints.TabIndex = 5;
            btn_addPoints.Text = "+";
            btn_addPoints.UseVisualStyleBackColor = false;
            btn_addPoints.Click += btn_addPoints_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Black;
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(1, 292);
            panel6.Name = "panel6";
            panel6.Size = new Size(755, 1);
            panel6.TabIndex = 32;
            // 
            // cbx_section
            // 
            cbx_section.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbx_section.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbx_section.FormattingEnabled = true;
            cbx_section.Location = new Point(479, 109);
            cbx_section.Name = "cbx_section";
            cbx_section.Size = new Size(121, 32);
            cbx_section.TabIndex = 14;
            cbx_section.SelectedIndexChanged += cbx_section_SelectedIndexChanged;
            // 
            // cbx_course
            // 
            cbx_course.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbx_course.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbx_course.FormattingEnabled = true;
            cbx_course.Location = new Point(258, 109);
            cbx_course.Name = "cbx_course";
            cbx_course.Size = new Size(121, 32);
            cbx_course.TabIndex = 13;
            cbx_course.SelectedIndexChanged += cbx_section_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(169, 117);
            label2.Name = "label2";
            label2.Size = new Size(71, 24);
            label2.TabIndex = 11;
            label2.Text = "Course";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(403, 113);
            label3.Name = "label3";
            label3.Size = new Size(73, 24);
            label3.TabIndex = 12;
            label3.Text = "Section";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(1, 292);
            panel3.TabIndex = 30;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(756, 1);
            panel5.Name = "panel5";
            panel5.Size = new Size(1, 292);
            panel5.TabIndex = 31;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Black;
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(757, 1);
            panel7.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(txtbx_search);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Location = new Point(169, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(431, 38);
            flowLayoutPanel1.TabIndex = 41;
            // 
            // txtbx_search
            // 
            txtbx_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtbx_search.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtbx_search.Location = new Point(3, 3);
            txtbx_search.Name = "txtbx_search";
            txtbx_search.PlaceholderText = "Search";
            txtbx_search.Size = new Size(383, 29);
            txtbx_search.TabIndex = 37;
            txtbx_search.TextChanged += txtbx_search_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(392, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 191;
            pictureBox1.TabStop = false;
            // 
            // Points
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 518);
            Controls.Add(panel1);
            Name = "Points";
            Text = "Points";
            Load += Points_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_data).EndInit();
            panel_classrRecit.ResumeLayout(false);
            panel_classrRecit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_info).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgv_data;
        private Panel panel_classrRecit;
        private Label lbl_points;
        private Button btn_minusPoints;
        private Button btn_addPoints;
        private Panel panel6;
        private PictureBox pic_info;
        private ComboBox cbx_section;
        private ComboBox cbx_course;
        private Label label2;
        private Label label3;
        private Panel panel3;
        private Panel panel5;
        private Panel panel7;
        private Button bttn_refreshData;
        private TextBox txtbx_search;
        private Button bttn_reset;
        private Button bttn_addLifePoints;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel10;
        private Label label7;
        private PictureBox pictureBox1;
    }
}