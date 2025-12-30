
namespace LTMT4_NguyenTruongSon
{
    partial class FormSanPham
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
            this.labelMaSanPham = new System.Windows.Forms.Label();
            this.labelTenSP = new System.Windows.Forms.Label();
            this.labelGiaNhap = new System.Windows.Forms.Label();
            this.labelGiaBan = new System.Windows.Forms.Label();
            this.labelSoLuongTon = new System.Windows.Forms.Label();
            this.textBoxMaSanPham = new System.Windows.Forms.TextBox();
            this.textBoxTenSP = new System.Windows.Forms.TextBox();
            this.textBoxGiaNhap = new System.Windows.Forms.TextBox();
            this.textBoxGiaBan = new System.Windows.Forms.TextBox();
            this.textBoxSoLuongTon = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonThem = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonLamMoi = new System.Windows.Forms.Button();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.buttonTimKiem = new System.Windows.Forms.Button();
            this.dataGridViewSanPham = new System.Windows.Forms.DataGridView();
            this.labelTenNSX = new System.Windows.Forms.Label();
            this.comboBoxTenNSX = new System.Windows.Forms.ComboBox();
            this.labelTenNPP = new System.Windows.Forms.Label();
            this.comboBoxTenNPP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonXuatExcel = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaSanPham
            // 
            this.labelMaSanPham.AutoSize = true;
            this.labelMaSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaSanPham.Location = new System.Drawing.Point(1049, 131);
            this.labelMaSanPham.Name = "labelMaSanPham";
            this.labelMaSanPham.Size = new System.Drawing.Size(249, 58);
            this.labelMaSanPham.TabIndex = 0;
            this.labelMaSanPham.Text = "Mã sản phẩm";
            this.labelMaSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTenSP
            // 
            this.labelTenSP.AutoSize = true;
            this.labelTenSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenSP.Location = new System.Drawing.Point(1049, 189);
            this.labelTenSP.Name = "labelTenSP";
            this.labelTenSP.Size = new System.Drawing.Size(249, 58);
            this.labelTenSP.TabIndex = 1;
            this.labelTenSP.Text = "Tên sản phẩm ";
            this.labelTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGiaNhap
            // 
            this.labelGiaNhap.AutoSize = true;
            this.labelGiaNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGiaNhap.Location = new System.Drawing.Point(3, 0);
            this.labelGiaNhap.Name = "labelGiaNhap";
            this.labelGiaNhap.Size = new System.Drawing.Size(1040, 73);
            this.labelGiaNhap.TabIndex = 2;
            this.labelGiaNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGiaBan
            // 
            this.labelGiaBan.AutoSize = true;
            this.labelGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGiaBan.Location = new System.Drawing.Point(1049, 305);
            this.labelGiaBan.Name = "labelGiaBan";
            this.labelGiaBan.Size = new System.Drawing.Size(249, 58);
            this.labelGiaBan.TabIndex = 3;
            this.labelGiaBan.Text = "Giá bán ";
            this.labelGiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSoLuongTon
            // 
            this.labelSoLuongTon.AutoSize = true;
            this.labelSoLuongTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoLuongTon.Location = new System.Drawing.Point(1049, 363);
            this.labelSoLuongTon.Name = "labelSoLuongTon";
            this.labelSoLuongTon.Size = new System.Drawing.Size(249, 58);
            this.labelSoLuongTon.TabIndex = 4;
            this.labelSoLuongTon.Text = "Số lượng tồn ";
            this.labelSoLuongTon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMaSanPham
            // 
            this.textBoxMaSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaSanPham.Location = new System.Drawing.Point(1304, 134);
            this.textBoxMaSanPham.Name = "textBoxMaSanPham";
            this.textBoxMaSanPham.Size = new System.Drawing.Size(232, 27);
            this.textBoxMaSanPham.TabIndex = 7;
            // 
            // textBoxTenSP
            // 
            this.textBoxTenSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenSP.Location = new System.Drawing.Point(1304, 192);
            this.textBoxTenSP.Name = "textBoxTenSP";
            this.textBoxTenSP.Size = new System.Drawing.Size(232, 27);
            this.textBoxTenSP.TabIndex = 8;
            // 
            // textBoxGiaNhap
            // 
            this.textBoxGiaNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGiaNhap.Location = new System.Drawing.Point(1304, 250);
            this.textBoxGiaNhap.Name = "textBoxGiaNhap";
            this.textBoxGiaNhap.Size = new System.Drawing.Size(232, 27);
            this.textBoxGiaNhap.TabIndex = 10;
            // 
            // textBoxGiaBan
            // 
            this.textBoxGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGiaBan.Location = new System.Drawing.Point(1304, 308);
            this.textBoxGiaBan.Name = "textBoxGiaBan";
            this.textBoxGiaBan.Size = new System.Drawing.Size(232, 27);
            this.textBoxGiaBan.TabIndex = 11;
            // 
            // textBoxSoLuongTon
            // 
            this.textBoxSoLuongTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoLuongTon.Location = new System.Drawing.Point(1304, 366);
            this.textBoxSoLuongTon.Name = "textBoxSoLuongTon";
            this.textBoxSoLuongTon.Size = new System.Drawing.Size(232, 27);
            this.textBoxSoLuongTon.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.82825F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.36597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40289F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxMaSanPham, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelMaSanPham, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTenSP, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTenSP, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGiaNhap, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSoLuongTon, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelGiaBan, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxGiaBan, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelSoLuongTon, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonThem, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.buttonLamMoi, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTimKiem, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonTimKiem, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSanPham, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTenNSX, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTenNSX, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelTenNPP, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTenNPP, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelGiaNhap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonXuatExcel, 1, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1779, 731);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // buttonThem
            // 
            this.buttonThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.Location = new System.Drawing.Point(1049, 540);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(249, 67);
            this.buttonThem.TabIndex = 14;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonXoa, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSua, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1304, 540);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(232, 67);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.Location = new System.Drawing.Point(119, 3);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(110, 61);
            this.buttonXoa.TabIndex = 17;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click_1);
            // 
            // buttonSua
            // 
            this.buttonSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSua.Location = new System.Drawing.Point(3, 3);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(110, 61);
            this.buttonSua.TabIndex = 15;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click_1);
            // 
            // buttonLamMoi
            // 
            this.buttonLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLamMoi.Location = new System.Drawing.Point(1542, 540);
            this.buttonLamMoi.Name = "buttonLamMoi";
            this.buttonLamMoi.Size = new System.Drawing.Size(234, 67);
            this.buttonLamMoi.TabIndex = 17;
            this.buttonLamMoi.Text = "Làm mới";
            this.buttonLamMoi.UseVisualStyleBackColor = true;
            this.buttonLamMoi.Click += new System.EventHandler(this.buttonLamMoi_Click);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(1304, 76);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(232, 27);
            this.textBoxTimKiem.TabIndex = 18;
            // 
            // buttonTimKiem
            // 
            this.buttonTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimKiem.Location = new System.Drawing.Point(1542, 76);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(234, 52);
            this.buttonTimKiem.TabIndex = 19;
            this.buttonTimKiem.Text = "Tìm kiếm";
            this.buttonTimKiem.UseVisualStyleBackColor = true;
            this.buttonTimKiem.Click += new System.EventHandler(this.buttonTimKiem_Click);
            // 
            // dataGridViewSanPham
            // 
            this.dataGridViewSanPham.AllowUserToAddRows = false;
            this.dataGridViewSanPham.AllowUserToDeleteRows = false;
            this.dataGridViewSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSanPham.Location = new System.Drawing.Point(3, 76);
            this.dataGridViewSanPham.Name = "dataGridViewSanPham";
            this.dataGridViewSanPham.ReadOnly = true;
            this.dataGridViewSanPham.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewSanPham, 9);
            this.dataGridViewSanPham.RowTemplate.Height = 24;
            this.dataGridViewSanPham.Size = new System.Drawing.Size(1040, 531);
            this.dataGridViewSanPham.TabIndex = 20;
            this.dataGridViewSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSanPham_CellClick);
            // 
            // labelTenNSX
            // 
            this.labelTenNSX.AutoSize = true;
            this.labelTenNSX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTenNSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNSX.Location = new System.Drawing.Point(1049, 421);
            this.labelTenNSX.Name = "labelTenNSX";
            this.labelTenNSX.Size = new System.Drawing.Size(249, 58);
            this.labelTenNSX.TabIndex = 21;
            this.labelTenNSX.Text = "Tên nhà sản xuất  ";
            this.labelTenNSX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTenNSX
            // 
            this.comboBoxTenNSX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTenNSX.FormattingEnabled = true;
            this.comboBoxTenNSX.Location = new System.Drawing.Point(1304, 424);
            this.comboBoxTenNSX.Name = "comboBoxTenNSX";
            this.comboBoxTenNSX.Size = new System.Drawing.Size(232, 24);
            this.comboBoxTenNSX.TabIndex = 22;
            this.comboBoxTenNSX.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenNSX_SelectedIndexChanged);
            // 
            // labelTenNPP
            // 
            this.labelTenNPP.AutoSize = true;
            this.labelTenNPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTenNPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNPP.Location = new System.Drawing.Point(1049, 479);
            this.labelTenNPP.Name = "labelTenNPP";
            this.labelTenNPP.Size = new System.Drawing.Size(249, 58);
            this.labelTenNPP.TabIndex = 23;
            this.labelTenNPP.Text = "Tên nhà phân phối";
            this.labelTenNPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTenNPP
            // 
            this.comboBoxTenNPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTenNPP.FormattingEnabled = true;
            this.comboBoxTenNPP.Location = new System.Drawing.Point(1304, 482);
            this.comboBoxTenNPP.Name = "comboBoxTenNPP";
            this.comboBoxTenNPP.Size = new System.Drawing.Size(232, 24);
            this.comboBoxTenNPP.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1049, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 58);
            this.label1.TabIndex = 25;
            this.label1.Text = "Giá nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonXuatExcel
            // 
            this.buttonXuatExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXuatExcel.Location = new System.Drawing.Point(1049, 613);
            this.buttonXuatExcel.Name = "buttonXuatExcel";
            this.buttonXuatExcel.Size = new System.Drawing.Size(249, 37);
            this.buttonXuatExcel.TabIndex = 26;
            this.buttonXuatExcel.Text = "Xuất excel";
            this.buttonXuatExcel.UseVisualStyleBackColor = true;
            this.buttonXuatExcel.Click += new System.EventHandler(this.buttonXuatExcel_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1779, 731);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản phẩm ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMaSanPham;
        private System.Windows.Forms.Label labelTenSP;
        private System.Windows.Forms.Label labelGiaNhap;
        private System.Windows.Forms.Label labelGiaBan;
        private System.Windows.Forms.Label labelSoLuongTon;
        private System.Windows.Forms.TextBox textBoxMaSanPham;
        private System.Windows.Forms.TextBox textBoxTenSP;
        private System.Windows.Forms.TextBox textBoxGiaNhap;
        private System.Windows.Forms.TextBox textBoxGiaBan;
        private System.Windows.Forms.TextBox textBoxSoLuongTon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonLamMoi;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Button buttonTimKiem;
        private System.Windows.Forms.DataGridView dataGridViewSanPham;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label labelTenNSX;
        private System.Windows.Forms.ComboBox comboBoxTenNSX;
        private System.Windows.Forms.Label labelTenNPP;
        private System.Windows.Forms.ComboBox comboBoxTenNPP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonXuatExcel;
    }
}

