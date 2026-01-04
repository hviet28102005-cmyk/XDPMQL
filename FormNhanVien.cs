using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace WindowsFormsApp1
{
    public partial class FormNhanVien : Form
    {
        // ===== KẾT NỐI =====
        string Nguon = "Data Source=DESKTOP-PL4799R;Initial Catalog=XayDungPMQL;Integrated Security=True";
        string lenh = "";
        SqlConnection KetNoi;
        SqlCommand ThucHien;
        SqlDataReader Doc;

        public FormNhanVien()
        {
            InitializeComponent();
            KetNoi = new SqlConnection(Nguon);
        }

        // ===== KIỂM TRA RÀNG BUỘC DỮ LIỆU =====
        private bool KiemTraRangBuoc()
        {
            // Kiểm tra các trường không được rỗng
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(cbChucVu.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 1. Kiểm tra CCCD (12 số)
            if (txtCCCD.Text.Length != 12 || !long.TryParse(txtCCCD.Text, out _))
            {
                MessageBox.Show("Căn cước công dân phải gồm 12 chữ số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            // 2. Kiểm tra SDT (10 số, bắt đầu bằng '0')
            if (txtSDT.Text.Length != 10 || !txtSDT.Text.StartsWith("0") || !long.TryParse(txtSDT.Text, out _))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt buộc bắt đầu bằng số 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // 3. Kiểm tra Email (@gmail.com)
            string emailPattern = @"^[\w-\.]+@gmail\.com$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Email phải có định dạng hợp lệ và kết thúc bằng @gmail.com.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        // Hàm hỗ trợ để xóa trắng các ô nhập liệu
        private void LamMoiDuLieuNhap()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            cbChucVu.Text = "";
            // Tìm và xóa nội dung ô tìm kiếm (nếu tồn tại)
            Control[] foundControls = this.Controls.Find("txtTimKiem", true);
            if (foundControls.Length > 0 && foundControls[0] is TextBox txtTimKiem)
            {
                txtTimKiem.Clear();
            }
            txtMaNV.Focus();
        }

        //  HIỂN THỊ DỮ LIỆU
        void HienThi(string filter = "")
        {
            dataGridViewNhanVien.Rows.Clear();
            if (KetNoi.State != ConnectionState.Closed)
                KetNoi.Close();

            lenh = @"SELECT MaNV, TenNV, CCCD, SDT, Email, ChucVu, MatKhau FROM NhanVien";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                // Thêm điều kiện tìm kiếm theo TênNV (tìm kiếm gần đúng)
                lenh += " WHERE TenNV LIKE @TenNVFilter";
            }

            ThucHien = new SqlCommand(lenh, KetNoi);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                ThucHien.Parameters.AddWithValue("@TenNVFilter", "%" + filter + "%");
            }

            KetNoi.Open();
            Doc = ThucHien.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                dataGridViewNhanVien.Rows.Add();
                dataGridViewNhanVien.Rows[i].Cells[0].Value = Doc["MaNV"];
                dataGridViewNhanVien.Rows[i].Cells[1].Value = Doc["TenNV"];
                dataGridViewNhanVien.Rows[i].Cells[2].Value = Doc["CCCD"];
                dataGridViewNhanVien.Rows[i].Cells[3].Value = Doc["SDT"];
                dataGridViewNhanVien.Rows[i].Cells[4].Value = Doc["Email"];
                dataGridViewNhanVien.Rows[i].Cells[5].Value = Doc["ChucVu"];
                dataGridViewNhanVien.Rows[i].Cells[6].Value = Doc["MatKhau"];

                i++;
            }
            Doc.Close();
            KetNoi.Close();
        }


        // ===== LƯU (INSERT) =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraRangBuoc())
            {
                return;
            }

            // 1. Kiểm tra Mã NV đã tồn tại
            if (KetNoi.State != ConnectionState.Closed)
                KetNoi.Close();

            string checkLenh = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            ThucHien = new SqlCommand(checkLenh, KetNoi);
            ThucHien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

            KetNoi.Open();
            int count = (int)ThucHien.ExecuteScalar();
            KetNoi.Close();

            if (count > 0)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại. Vui lòng nhập Mã nhân viên khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }

            KetNoi = new SqlConnection(Nguon);
            lenh = "INSERT INTO NhanVien (MaNV, TenNV, CCCD, SDT, Email, ChucVu, MatKhau) VALUES (@MaNV, @TenNV, @CCCD, @SDT, @Email, @ChucVu,@MatKhau)";
            ThucHien = new SqlCommand(lenh, KetNoi);

            
            ThucHien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
            ThucHien.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
            ThucHien.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
            ThucHien.Parameters.AddWithValue("@SDT", txtSDT.Text);
            ThucHien.Parameters.AddWithValue("@Email", txtEmail.Text);
            ThucHien.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
            ThucHien.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);


            KetNoi.Open();
            ThucHien.ExecuteNonQuery();
            KetNoi.Close();

            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiDuLieuNhap();
            HienThi(); 
        }

        // ===== LOAD FORM =====
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            KetNoi = new SqlConnection(Nguon); 
            HienThi();
        }

        // ===== TÌM KIẾM (Theo Tên Nhân Viên) =====
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Control[] foundControls = this.Controls.Find("txtTimKiem", true);
            string tuKhoa = (foundControls.Length > 0 && foundControls[0] is TextBox txtTimKiem) ?
                            txtTimKiem.Text.Trim() :
                            "";

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                HienThi();
            }
            else
            {
                HienThi(tuKhoa);
            }
        }

        private void HienThiDuLieu()
        {
        }


        // ===== SỬA (UPDATE) =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraRangBuoc())
            {
                return;
            }

            if (dataGridViewNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string originalMaNV = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();

            // Ngăn cấm sửa MaNV
            if (txtMaNV.Text.Trim() != originalMaNV)
            {
                MessageBox.Show("Không được phép thay đổi Mã nhân viên. Chỉ được sửa các thông tin khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Text = originalMaNV; 
                return;
            }

            
            lenh = "UPDATE NhanVien SET TenNV = @TenNV, CCCD = @CCCD, SDT = @SDT, Email = @Email, ChucVu = @ChucVu, MatKhau = @MatKhau WHERE MaNV = @MaNV";

            KetNoi = new SqlConnection(Nguon);
            ThucHien = new SqlCommand(lenh, KetNoi);

            
            ThucHien.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
            ThucHien.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
            ThucHien.Parameters.AddWithValue("@SDT", txtSDT.Text);
            ThucHien.Parameters.AddWithValue("@Email", txtEmail.Text);
            ThucHien.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
            ThucHien.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

           
            ThucHien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

            KetNoi.Open();
            int rowsAffected = ThucHien.ExecuteNonQuery();
            KetNoi.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LamMoiDuLieuNhap();
            HienThi(); 
        }

        // ===== XÓA  =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {txtTenNV.Text} (Mã NV: {txtMaNV.Text})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            KetNoi = new SqlConnection(Nguon);
            lenh = "DELETE FROM NhanVien WHERE MaNV=@MaNV";

            ThucHien = new SqlCommand(lenh, KetNoi);
            ThucHien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

            KetNoi.Open();
            ThucHien.ExecuteNonQuery();
            KetNoi.Close();

            MessageBox.Show("Xóa thành công!");
            LamMoiDuLieuNhap();
            HienThi();
        }

        // ===== CLICK GRID =====
        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewNhanVien.Rows.Count - 1) 
            {
                txtMaNV.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value?.ToString() ?? "";
                txtTenNV.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value?.ToString() ?? "";
                txtCCCD.Text = dataGridViewNhanVien.CurrentRow.Cells[2].Value?.ToString() ?? "";
                txtSDT.Text = dataGridViewNhanVien.CurrentRow.Cells[3].Value?.ToString() ?? "";
                txtEmail.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value?.ToString() ?? "";
                cbChucVu.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value?.ToString() ?? "";
                txtMatKhau.Text = dataGridViewNhanVien.CurrentRow.Cells[6].Value?.ToString() ?? "";
            }
        }

        // ===== THÊM (LÀM MỚI/CLEAR) =====
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiDuLieuNhap();
            HienThi();
        }

       
    }
}