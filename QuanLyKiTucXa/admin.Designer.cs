
namespace QuanLyKiTucXa
{
    partial class admin
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
            this.cbbAccountType = new MetroFramework.Controls.MetroComboBox();
            this.dgvShow = new MetroFramework.Controls.MetroGrid();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lbSum = new MetroFramework.Controls.MetroLabel();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRoomType_Delete = new System.Windows.Forms.Button();
            this.btnRoomType_Edit = new System.Windows.Forms.Button();
            this.btnRoomType_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbAccountType
            // 
            this.cbbAccountType.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.cbbAccountType.FormattingEnabled = true;
            this.cbbAccountType.ItemHeight = 29;
            this.cbbAccountType.Items.AddRange(new object[] {
            "Sinh viên",
            "Nhân viên",
            "Quản trị viên",
            "Giám đốc"});
            this.cbbAccountType.Location = new System.Drawing.Point(159, 110);
            this.cbbAccountType.Name = "cbbAccountType";
            this.cbbAccountType.Size = new System.Drawing.Size(214, 35);
            this.cbbAccountType.TabIndex = 1;
            this.cbbAccountType.UseSelectable = true;
            this.cbbAccountType.SelectedIndexChanged += new System.EventHandler(this.cbbAccountType_SelectedIndexChanged);
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToResizeRows = false;
            this.dgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvShow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShow.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvShow.EnableHeadersVisualStyles = false;
            this.dgvShow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvShow.Location = new System.Drawing.Point(30, 190);
            this.dgvShow.MultiSelect = false;
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShow.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(894, 419);
            this.dgvShow.Style = MetroFramework.MetroColorStyle.Teal;
            this.dgvShow.TabIndex = 74;
            this.dgvShow.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(20, 120);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(122, 25);
            this.metroLabel1.TabIndex = 75;
            this.metroLabel1.Text = "Loại tài khoản:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(706, 120);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(55, 25);
            this.metroLabel2.TabIndex = 76;
            this.metroLabel2.Text = "Tổng:";
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbSum.Location = new System.Drawing.Point(777, 120);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(24, 25);
            this.lbSum.TabIndex = 77;
            this.lbSum.Text = "...";
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnManager.Image = global::QuanLyKiTucXa.Properties.Resources.management;
            this.btnManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManager.Location = new System.Drawing.Point(981, 559);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(139, 50);
            this.btnManager.TabIndex = 82;
            this.btnManager.Text = "QUẢN LÝ";
            this.btnManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManager.UseVisualStyleBackColor = false;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRefresh.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_available_updates_32;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(981, 456);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(139, 44);
            this.btnRefresh.TabIndex = 81;
            this.btnRefresh.Text = "LÀM MỚI";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRoomType_Delete
            // 
            this.btnRoomType_Delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRoomType_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomType_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoomType_Delete.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_trash_32;
            this.btnRoomType_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomType_Delete.Location = new System.Drawing.Point(981, 365);
            this.btnRoomType_Delete.Name = "btnRoomType_Delete";
            this.btnRoomType_Delete.Size = new System.Drawing.Size(139, 44);
            this.btnRoomType_Delete.TabIndex = 80;
            this.btnRoomType_Delete.Text = "XÓA";
            this.btnRoomType_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomType_Delete.UseVisualStyleBackColor = false;
            this.btnRoomType_Delete.Click += new System.EventHandler(this.btnRoomType_Delete_Click);
            // 
            // btnRoomType_Edit
            // 
            this.btnRoomType_Edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRoomType_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomType_Edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoomType_Edit.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_fix_30;
            this.btnRoomType_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomType_Edit.Location = new System.Drawing.Point(981, 277);
            this.btnRoomType_Edit.Name = "btnRoomType_Edit";
            this.btnRoomType_Edit.Size = new System.Drawing.Size(139, 44);
            this.btnRoomType_Edit.TabIndex = 79;
            this.btnRoomType_Edit.Text = "SỬA";
            this.btnRoomType_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomType_Edit.UseVisualStyleBackColor = false;
            this.btnRoomType_Edit.Click += new System.EventHandler(this.btnRoomType_Edit_Click);
            // 
            // btnRoomType_Add
            // 
            this.btnRoomType_Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRoomType_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomType_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRoomType_Add.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_plus_30;
            this.btnRoomType_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomType_Add.Location = new System.Drawing.Point(981, 190);
            this.btnRoomType_Add.Name = "btnRoomType_Add";
            this.btnRoomType_Add.Size = new System.Drawing.Size(139, 44);
            this.btnRoomType_Add.TabIndex = 78;
            this.btnRoomType_Add.Text = "THÊM";
            this.btnRoomType_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomType_Add.UseVisualStyleBackColor = false;
            this.btnRoomType_Add.Click += new System.EventHandler(this.btnRoomType_Add_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 654);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRoomType_Delete);
            this.Controls.Add(this.btnRoomType_Edit);
            this.Controls.Add(this.btnRoomType_Add);
            this.Controls.Add(this.lbSum);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.cbbAccountType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "admin";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox cbbAccountType;
        private MetroFramework.Controls.MetroGrid dgvShow;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lbSum;
        private System.Windows.Forms.Button btnRoomType_Delete;
        private System.Windows.Forms.Button btnRoomType_Edit;
        private System.Windows.Forms.Button btnRoomType_Add;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnManager;
    }
}