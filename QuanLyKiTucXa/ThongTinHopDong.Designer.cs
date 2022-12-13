
namespace QuanLyKiTucXa
{
    partial class ThongTinHopDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNote = new MetroFramework.Controls.MetroTextBox();
            this.dtpCreateDay = new MetroFramework.Controls.MetroDateTime();
            this.dtpBeginDay = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpEnđay = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbbStaffID = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbbStudentID = new MetroFramework.Controls.MetroComboBox();
            this.cbbRoomID = new MetroFramework.Controls.MetroComboBox();
            this.cbbStatus = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.dgvRoomShow = new MetroFramework.Controls.MetroGrid();
            this.btnRoom_Save = new System.Windows.Forms.Button();
            this.btnStaff_Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomShow)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(33, 98);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Ngày lập:";
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.CustomButton.Image = null;
            this.txtNote.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.txtNote.CustomButton.Name = "";
            this.txtNote.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtNote.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNote.CustomButton.TabIndex = 1;
            this.txtNote.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNote.CustomButton.UseSelectable = true;
            this.txtNote.CustomButton.Visible = false;
            this.txtNote.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNote.Lines = new string[0];
            this.txtNote.Location = new System.Drawing.Point(186, 476);
            this.txtNote.MaxLength = 32767;
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNote.SelectedText = "";
            this.txtNote.SelectionLength = 0;
            this.txtNote.SelectionStart = 0;
            this.txtNote.ShortcutsEnabled = true;
            this.txtNote.Size = new System.Drawing.Size(220, 29);
            this.txtNote.TabIndex = 1;
            this.txtNote.UseSelectable = true;
            this.txtNote.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNote.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtpCreateDay
            // 
            this.dtpCreateDay.CustomFormat = "dd/MM/yyyy";
            this.dtpCreateDay.Enabled = false;
            this.dtpCreateDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDay.Location = new System.Drawing.Point(186, 98);
            this.dtpCreateDay.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpCreateDay.Name = "dtpCreateDay";
            this.dtpCreateDay.Size = new System.Drawing.Size(220, 29);
            this.dtpCreateDay.TabIndex = 2;
            // 
            // dtpBeginDay
            // 
            this.dtpBeginDay.CustomFormat = "dd/MM/yyyy";
            this.dtpBeginDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginDay.Location = new System.Drawing.Point(186, 149);
            this.dtpBeginDay.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpBeginDay.Name = "dtpBeginDay";
            this.dtpBeginDay.Size = new System.Drawing.Size(220, 29);
            this.dtpBeginDay.TabIndex = 4;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(33, 149);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Ngày bắt đầu:";
            // 
            // dtpEnđay
            // 
            this.dtpEnđay.CustomFormat = "dd/MM/yyyy";
            this.dtpEnđay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnđay.Location = new System.Drawing.Point(186, 202);
            this.dtpEnđay.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpEnđay.Name = "dtpEnđay";
            this.dtpEnđay.Size = new System.Drawing.Size(220, 29);
            this.dtpEnđay.TabIndex = 6;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(33, 202);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(87, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "ngày hết hạn:";
            // 
            // cbbStaffID
            // 
            this.cbbStaffID.FormattingEnabled = true;
            this.cbbStaffID.ItemHeight = 23;
            this.cbbStaffID.Location = new System.Drawing.Point(186, 256);
            this.cbbStaffID.Name = "cbbStaffID";
            this.cbbStaffID.Size = new System.Drawing.Size(220, 29);
            this.cbbStaffID.TabIndex = 7;
            this.cbbStaffID.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(33, 256);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Mã nhân viên:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(33, 307);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(84, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Mã sinh viên:";
            // 
            // cbbStudentID
            // 
            this.cbbStudentID.FormattingEnabled = true;
            this.cbbStudentID.ItemHeight = 23;
            this.cbbStudentID.Location = new System.Drawing.Point(186, 307);
            this.cbbStudentID.Name = "cbbStudentID";
            this.cbbStudentID.Size = new System.Drawing.Size(220, 29);
            this.cbbStudentID.TabIndex = 9;
            this.cbbStudentID.UseSelectable = true;
            // 
            // cbbRoomID
            // 
            this.cbbRoomID.FormattingEnabled = true;
            this.cbbRoomID.ItemHeight = 23;
            this.cbbRoomID.Location = new System.Drawing.Point(186, 360);
            this.cbbRoomID.Name = "cbbRoomID";
            this.cbbRoomID.Size = new System.Drawing.Size(220, 29);
            this.cbbRoomID.TabIndex = 11;
            this.cbbRoomID.UseSelectable = true;
            // 
            // cbbStatus
            // 
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.ItemHeight = 23;
            this.cbbStatus.Items.AddRange(new object[] {
            "Đang",
            "Ngừng"});
            this.cbbStatus.Location = new System.Drawing.Point(186, 419);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(220, 29);
            this.cbbStatus.TabIndex = 13;
            this.cbbStatus.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(33, 360);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(73, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Mã phòng:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(33, 419);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(69, 19);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "Trạng thái:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(33, 476);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(52, 19);
            this.metroLabel8.TabIndex = 15;
            this.metroLabel8.Text = "Ghí chú";
            // 
            // dgvRoomShow
            // 
            this.dgvRoomShow.AllowUserToResizeRows = false;
            this.dgvRoomShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRoomShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoomShow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRoomShow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoomShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoomShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoomShow.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoomShow.EnableHeadersVisualStyles = false;
            this.dgvRoomShow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvRoomShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRoomShow.Location = new System.Drawing.Point(422, 98);
            this.dgvRoomShow.Name = "dgvRoomShow";
            this.dgvRoomShow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoomShow.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoomShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoomShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomShow.Size = new System.Drawing.Size(662, 407);
            this.dgvRoomShow.TabIndex = 16;
            // 
            // btnRoom_Save
            // 
            this.btnRoom_Save.BackColor = System.Drawing.Color.LightSalmon;
            this.btnRoom_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoom_Save.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_save_32__1_;
            this.btnRoom_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom_Save.Location = new System.Drawing.Point(117, 535);
            this.btnRoom_Save.Name = "btnRoom_Save";
            this.btnRoom_Save.Size = new System.Drawing.Size(114, 44);
            this.btnRoom_Save.TabIndex = 51;
            this.btnRoom_Save.Text = "LƯU";
            this.btnRoom_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoom_Save.UseVisualStyleBackColor = false;
            // 
            // btnStaff_Return
            // 
            this.btnStaff_Return.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStaff_Return.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStaff_Return.Image = global::QuanLyKiTucXa.Properties.Resources.undo__1_;
            this.btnStaff_Return.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff_Return.Location = new System.Drawing.Point(822, 535);
            this.btnStaff_Return.Name = "btnStaff_Return";
            this.btnStaff_Return.Size = new System.Drawing.Size(114, 44);
            this.btnStaff_Return.TabIndex = 52;
            this.btnStaff_Return.Text = "QUAY LẠI";
            this.btnStaff_Return.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStaff_Return.UseVisualStyleBackColor = false;
            // 
            // ThongTinHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 627);
            this.Controls.Add(this.btnStaff_Return);
            this.Controls.Add(this.btnRoom_Save);
            this.Controls.Add(this.dgvRoomShow);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbbRoomID);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbbStudentID);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.cbbStaffID);
            this.Controls.Add(this.dtpEnđay);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtpBeginDay);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dtpCreateDay);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongTinHopDong";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Thông tin hợp đồng";
            this.Load += new System.EventHandler(this.ThongTinHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtNote;
        private MetroFramework.Controls.MetroDateTime dtpCreateDay;
        private MetroFramework.Controls.MetroDateTime dtpBeginDay;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtpEnđay;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbbStaffID;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbbStudentID;
        private MetroFramework.Controls.MetroComboBox cbbRoomID;
        private MetroFramework.Controls.MetroComboBox cbbStatus;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroGrid dgvRoomShow;
        private System.Windows.Forms.Button btnRoom_Save;
        private System.Windows.Forms.Button btnStaff_Return;
    }
}