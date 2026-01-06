namespace WindowsFormsApp1
{
    partial class FormHoaDonChu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.labelMANV = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.labelMaKH = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.txtNgayLapHD = new System.Windows.Forms.TextBox();
            this.labelNgayLapHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.labelMaHD = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.labelTimKiem = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tableLayoutPanel1.Controls.Add(this.panelControls, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvHoaDon, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 481);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.txtMaNV);
            this.panelControls.Controls.Add(this.labelMANV);
            this.panelControls.Controls.Add(this.txtMaKH);
            this.panelControls.Controls.Add(this.labelMaKH);
            this.panelControls.Controls.Add(this.txtTongTien);
            this.panelControls.Controls.Add(this.labelTongTien);
            this.panelControls.Controls.Add(this.txtNgayLapHD);
            this.panelControls.Controls.Add(this.labelNgayLapHD);
            this.panelControls.Controls.Add(this.txtMaHD);
            this.panelControls.Controls.Add(this.labelMaHD);
            this.panelControls.Controls.Add(this.btnXoa);
            this.panelControls.Controls.Add(this.btnSua);
            this.panelControls.Controls.Add(this.btnTimKiem);
            this.panelControls.Controls.Add(this.txtTimKiem);
            this.panelControls.Controls.Add(this.labelTimKiem);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(571, 3);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(319, 475);
            this.panelControls.TabIndex = 0;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(120, 207);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(170, 20);
            this.txtMaNV.TabIndex = 14;
            // 
            // labelMANV
            // 
            this.labelMANV.AutoSize = true;
            this.labelMANV.Location = new System.Drawing.Point(18, 214);
            this.labelMANV.Name = "labelMANV";
            this.labelMANV.Size = new System.Drawing.Size(43, 13);
            this.labelMANV.TabIndex = 13;
            this.labelMANV.Text = "Mã NV:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(120, 178);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(170, 20);
            this.txtMaKH.TabIndex = 12;
            // 
            // labelMaKH
            // 
            this.labelMaKH.AutoSize = true;
            this.labelMaKH.Location = new System.Drawing.Point(18, 184);
            this.labelMaKH.Name = "labelMaKH";
            this.labelMaKH.Size = new System.Drawing.Size(43, 13);
            this.labelMaKH.TabIndex = 11;
            this.labelMaKH.Text = "Mã KH:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(120, 149);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(170, 20);
            this.txtTongTien.TabIndex = 10;
            // 
            // labelTongTien
            // 
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Location = new System.Drawing.Point(18, 154);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(59, 13);
            this.labelTongTien.TabIndex = 9;
            this.labelTongTien.Text = "Tổng Tiền:";
            // 
            // txtNgayLapHD
            // 
            this.txtNgayLapHD.Location = new System.Drawing.Point(120, 120);
            this.txtNgayLapHD.Name = "txtNgayLapHD";
            this.txtNgayLapHD.Size = new System.Drawing.Size(170, 20);
            this.txtNgayLapHD.TabIndex = 8;
            // 
            // labelNgayLapHD
            // 
            this.labelNgayLapHD.AutoSize = true;
            this.labelNgayLapHD.Location = new System.Drawing.Point(18, 124);
            this.labelNgayLapHD.Name = "labelNgayLapHD";
            this.labelNgayLapHD.Size = new System.Drawing.Size(56, 13);
            this.labelNgayLapHD.TabIndex = 7;
            this.labelNgayLapHD.Text = "Ngày Lập:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(120, 91);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(170, 20);
            this.txtMaHD.TabIndex = 6;
            // 
            // labelMaHD
            // 
            this.labelMaHD.AutoSize = true;
            this.labelMaHD.Location = new System.Drawing.Point(18, 94);
            this.labelMaHD.Name = "labelMaHD";
            this.labelMaHD.Size = new System.Drawing.Size(44, 13);
            this.labelMaHD.TabIndex = 5;
            this.labelMaHD.Text = "Mã HD:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(18, 375);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(272, 35);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa Hóa Đơn";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(18, 325);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(272, 35);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa Chi Tiết";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(120, 38);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(170, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(120, 9);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(170, 20);
            this.txtTimKiem.TabIndex = 1;
            // 
            // labelTimKiem
            // 
            this.labelTimKiem.AutoSize = true;
            this.labelTimKiem.Location = new System.Drawing.Point(18, 12);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(95, 13);
            this.labelTimKiem.TabIndex = 0;
            this.labelTimKiem.Text = "Tìm Kiếm Mã/Tên:";
            this.labelTimKiem.Click += new System.EventHandler(this.labelTimKiem_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.NgayLapHD,
            this.TongTien,
            this.MaKH,
            this.MaNV});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 3);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(562, 475);
            this.dgvHoaDon.TabIndex = 1;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            // 
            // MaHD
            // 
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            // 
            // NgayLapHD
            // 
            this.NgayLapHD.HeaderText = "NgayLapHD";
            this.NgayLapHD.Name = "NgayLapHD";
            this.NgayLapHD.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "TongTien";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "MaKH";
            this.MaKH.Name = "MaKH";
            this.MaKH.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "MaNV";
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // FormHoaDonChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormHoaDonChu";
            this.Text = "Quản Lý Hóa Đơn (Tìm kiếm, Sửa, Xóa)";
            this.Load += new System.EventHandler(this.FormHoaDonChu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelControls;
        // Khai báo Controls cho chức năng
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label labelMANV;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label labelMaKH;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.TextBox txtNgayLapHD;
        private System.Windows.Forms.Label labelNgayLapHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
    }
}