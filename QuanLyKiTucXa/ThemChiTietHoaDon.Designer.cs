
namespace QuanLyKiTucXa
{
    partial class ThemChiTietHoaDon
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
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.cbbType = new MetroFramework.Controls.MetroComboBox();
            this.txtOldNum = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtNewNum = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtNote = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cbbUnit = new MetroFramework.Controls.MetroComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMoney = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(24, 101);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(61, 19);
            this.metroLabel7.TabIndex = 16;
            this.metroLabel7.Text = "Loại tiền:";
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.ItemHeight = 23;
            this.cbbType.Items.AddRange(new object[] {
            "Tiền phòng",
            "Tiền nước",
            "Tiền điện"});
            this.cbbType.Location = new System.Drawing.Point(177, 101);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(220, 29);
            this.cbbType.TabIndex = 15;
            this.cbbType.UseSelectable = true;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // txtOldNum
            // 
            // 
            // 
            // 
            this.txtOldNum.CustomButton.Image = null;
            this.txtOldNum.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.txtOldNum.CustomButton.Name = "";
            this.txtOldNum.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtOldNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOldNum.CustomButton.TabIndex = 1;
            this.txtOldNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOldNum.CustomButton.UseSelectable = true;
            this.txtOldNum.CustomButton.Visible = false;
            this.txtOldNum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtOldNum.Lines = new string[0];
            this.txtOldNum.Location = new System.Drawing.Point(177, 157);
            this.txtOldNum.MaxLength = 32767;
            this.txtOldNum.Name = "txtOldNum";
            this.txtOldNum.PasswordChar = '\0';
            this.txtOldNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOldNum.SelectedText = "";
            this.txtOldNum.SelectionLength = 0;
            this.txtOldNum.SelectionStart = 0;
            this.txtOldNum.ShortcutsEnabled = true;
            this.txtOldNum.Size = new System.Drawing.Size(220, 29);
            this.txtOldNum.TabIndex = 82;
            this.txtOldNum.UseSelectable = true;
            this.txtOldNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOldNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(24, 157);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(44, 19);
            this.metroLabel5.TabIndex = 81;
            this.metroLabel5.Text = "Số cũ:";
            // 
            // txtNewNum
            // 
            // 
            // 
            // 
            this.txtNewNum.CustomButton.Image = null;
            this.txtNewNum.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.txtNewNum.CustomButton.Name = "";
            this.txtNewNum.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtNewNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNewNum.CustomButton.TabIndex = 1;
            this.txtNewNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNewNum.CustomButton.UseSelectable = true;
            this.txtNewNum.CustomButton.Visible = false;
            this.txtNewNum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNewNum.Lines = new string[0];
            this.txtNewNum.Location = new System.Drawing.Point(177, 213);
            this.txtNewNum.MaxLength = 32767;
            this.txtNewNum.Name = "txtNewNum";
            this.txtNewNum.PasswordChar = '\0';
            this.txtNewNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewNum.SelectedText = "";
            this.txtNewNum.SelectionLength = 0;
            this.txtNewNum.SelectionStart = 0;
            this.txtNewNum.ShortcutsEnabled = true;
            this.txtNewNum.Size = new System.Drawing.Size(220, 29);
            this.txtNewNum.TabIndex = 84;
            this.txtNewNum.UseSelectable = true;
            this.txtNewNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNewNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 213);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 83;
            this.metroLabel1.Text = "Số mới:";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrice.Lines = new string[0];
            this.txtPrice.Location = new System.Drawing.Point(177, 345);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.ShortcutsEnabled = true;
            this.txtPrice.Size = new System.Drawing.Size(220, 29);
            this.txtPrice.TabIndex = 86;
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 345);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 19);
            this.metroLabel2.TabIndex = 85;
            this.metroLabel2.Text = "Đơn giá:";
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
            this.txtNote.Location = new System.Drawing.Point(177, 459);
            this.txtNote.MaxLength = 32767;
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNote.SelectedText = "";
            this.txtNote.SelectionLength = 0;
            this.txtNote.SelectionStart = 0;
            this.txtNote.ShortcutsEnabled = true;
            this.txtNote.Size = new System.Drawing.Size(220, 29);
            this.txtNote.TabIndex = 88;
            this.txtNote.UseSelectable = true;
            this.txtNote.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNote.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 459);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(55, 19);
            this.metroLabel3.TabIndex = 87;
            this.metroLabel3.Text = "Ghi chú:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(24, 278);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 90;
            this.metroLabel4.Text = "Đơn vị tính:";
            // 
            // cbbUnit
            // 
            this.cbbUnit.Enabled = false;
            this.cbbUnit.FormattingEnabled = true;
            this.cbbUnit.ItemHeight = 23;
            this.cbbUnit.Items.AddRange(new object[] {
            "Kỳ",
            "m3",
            "kWh"});
            this.cbbUnit.Location = new System.Drawing.Point(177, 278);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Size = new System.Drawing.Size(220, 29);
            this.cbbUnit.TabIndex = 89;
            this.cbbUnit.UseSelectable = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAdd.Image = global::QuanLyKiTucXa.Properties.Resources.icons8_save_32__1_;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(30, 540);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 44);
            this.btnAdd.TabIndex = 91;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMoney
            // 
            // 
            // 
            // 
            this.txtMoney.CustomButton.Image = null;
            this.txtMoney.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.txtMoney.CustomButton.Name = "";
            this.txtMoney.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtMoney.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMoney.CustomButton.TabIndex = 1;
            this.txtMoney.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMoney.CustomButton.UseSelectable = true;
            this.txtMoney.CustomButton.Visible = false;
            this.txtMoney.Enabled = false;
            this.txtMoney.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMoney.Lines = new string[0];
            this.txtMoney.Location = new System.Drawing.Point(177, 401);
            this.txtMoney.MaxLength = 32767;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.PasswordChar = '\0';
            this.txtMoney.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMoney.SelectedText = "";
            this.txtMoney.SelectionLength = 0;
            this.txtMoney.SelectionStart = 0;
            this.txtMoney.ShortcutsEnabled = true;
            this.txtMoney.Size = new System.Drawing.Size(220, 29);
            this.txtMoney.TabIndex = 94;
            this.txtMoney.UseSelectable = true;
            this.txtMoney.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMoney.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(24, 401);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 19);
            this.metroLabel6.TabIndex = 93;
            this.metroLabel6.Text = "Số tiền:";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReturn.Image = global::QuanLyKiTucXa.Properties.Resources.undo__1_;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(283, 540);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(114, 44);
            this.btnReturn.TabIndex = 95;
            this.btnReturn.Text = "QUAY LẠI";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ThemChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 626);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.cbbUnit);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtNewNum);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtOldNum);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.cbbType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThemChiTietHoaDon";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Thêm mục";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox cbbType;
        private MetroFramework.Controls.MetroTextBox txtOldNum;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtNewNum;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPrice;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtNote;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cbbUnit;
        private System.Windows.Forms.Button btnAdd;
        private MetroFramework.Controls.MetroTextBox txtMoney;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.Button btnReturn;
    }
}