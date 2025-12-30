using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LTMT4_NguyenTruongSon
{
    public partial class FormNhaSanXuat : Form
    {
        public FormNhaSanXuat()
        {
            InitializeComponent();
        }
        string connStr = @"Data Source=LAPTOP-MPN2R439\SQLEXPRESS;Initial Catalog=LTMT4-NguyenTruongSon;Integrated Security=True";
        string Lenh = @"";
        SqlConnection KetNoi;
        SqlCommand ThucHien;
        SqlDataReader Doc;

        bool ValidateInput()
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(textBoxMaNSX.Text) ||
                string.IsNullOrWhiteSpace(textBoxTenNSX.Text) ||
                string.IsNullOrWhiteSpace(textBoxSDT.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxDiaChi.Text))
            {
                MessageBox.Show("Vui lòng hãy nhập đầy đủ thông tin",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            string maNsx = textBoxMaNSX.Text.Trim();
            // Check chỉ được chữ và số từ đầu đến cuối 
            if (!System.Text.RegularExpressions.Regex.IsMatch(maNsx, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã nhà sản xuất không được chứa ký tự đặc biệt hoặc khoảng trắng (chỉ chấp nhận chữ không dấu và số)!",
                    "Lỗi định dạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxMaNSX.Focus(); // Đưa con trỏ chuột về lại ô Mã để sửa
                return false;
            }

            if (maNsx.Length > 10)
            {
                MessageBox.Show("Mã nhà sản xuất chỉ được nhập tối đa 10 ký tự!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxMaNSX.Focus();
                return false;
            }

            // Kiểm tra Email có @
            if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email phải chứa ký tự '@'",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // Kiểm tra SĐT đúng 10 số
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxSDT.Text, @"^0\d{9}$"))
            {
                MessageBox.Show(
                    "Số điện thoại phải bắt đầu bằng số 0 và gồm đúng 10 chữ số",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBoxSDT.Focus();
                return false;
            }

            return true;
        }

        void LoadData(string searchKeyword = "")
        {
            KetNoi = new SqlConnection(connStr);
            string sql = "SELECT * FROM NhaSanXuat";

            // Lọc theo tên nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                sql = $"SELECT * FROM NhaSanXuat WHERE TenNSX LIKE N'%{searchKeyword}%'";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, KetNoi);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                dataGridViewNSX.DataSource = dt;

                // ĐỊNH DẠNG LẠI CỘT SDT 
                if (dataGridViewNSX.Columns.Contains("SDT"))
                {
                    dataGridViewNSX.Columns["SDT"].DefaultCellStyle.Format = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormNhaSanXuat_Load(object sender, EventArgs e)
        {
            LoadData();

            if (dataGridViewNSX.Columns.Contains("SDT"))
            {

                dataGridViewNSX.Columns["SDT"].DefaultCellStyle.Format = "0";
          }

        }

        private void ClearInputs(bool enableMa = true)
        {
            textBoxMaNSX.Text = string.Empty;
            textBoxTenNSX.Text = string.Empty;
            textBoxSDT.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxDiaChi.Text = string.Empty;
            textBoxTimKiem.Text = string.Empty;

            // Đặt trạng thái Enabled của ô Mã NSX dựa trên tham số truyền vào
            textBoxMaNSX.Enabled = enableMa;
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                //  Kiểm tra trùng Mã NSX
                string checkSql = "SELECT COUNT(*) FROM NhaSanXuat WHERE MaNSX = @MaNSX";
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaNSX", textBoxMaNSX.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhà sản xuất đã tồn tại!",
                            "Trùng dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        textBoxMaNSX.Focus();
                        return;
                    }
                }

                string sql = @"INSERT INTO NhaSanXuat
                          (MaNSX, TenNSX, SDT, Email, DiaChi)
                          VALUES (@MaNSX,@TenNSX,@SDT,@Email,@DiaChi)";

                KetNoi = new SqlConnection(connStr);
                ThucHien = new SqlCommand(sql, KetNoi);

                ThucHien.Parameters.AddWithValue("@MaNSX", textBoxMaNSX.Text);
                ThucHien.Parameters.AddWithValue("@TenNSX", textBoxTenNSX.Text);
                ThucHien.Parameters.AddWithValue("@SDT", textBoxSDT.Text);
                ThucHien.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                ThucHien.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
                KetNoi.Open();
                ThucHien.ExecuteNonQuery();
                KetNoi.Close();

                LoadData();
                ClearInputs();
            }
        }
        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string sql = @"UPDATE NhaSanXuat SET 
                    MaNSX=@MaNSX,
                    TenNSX=@TenNSX,
                    SDT=@SDT,
                    Email=@Email,
                    DiaChi=@DiaChi
                    WHERE MaNSX=@MaNSX";

            KetNoi = new SqlConnection(connStr);
            ThucHien = new SqlCommand(sql, KetNoi);

            ThucHien.Parameters.AddWithValue("@MaNSX", textBoxMaNSX.Text);
            ThucHien.Parameters.AddWithValue("@TenNSX", textBoxTenNSX.Text);
            ThucHien.Parameters.AddWithValue("@SDT", textBoxSDT.Text);
            ThucHien.Parameters.AddWithValue("@Email", textBoxEmail.Text);
            ThucHien.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
            KetNoi.Open();
            ThucHien.ExecuteNonQuery();
            KetNoi.Close();

            LoadData();
        }

        private void buttonXoa_Click_1(object sender, EventArgs e)
        {
            var ma = textBoxMaNSX.Text?.Trim();
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn Mã nhà sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhà sản xuất '{ma}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("DELETE FROM NhaSanXuat WHERE MaNSX = @MaNSX", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNSX", ma);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        private void buttonLamMoi_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dataGridViewNSX_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridViewNSX.Rows[e.RowIndex];


                textBoxMaNSX.Text = row.Cells["MaNSX"].Value.ToString();
                textBoxTenNSX.Text = row.Cells["TenNSX"].Value.ToString();
                textBoxSDT.Text = row.Cells["SDT"].Value.ToString();
                textBoxEmail.Text = row.Cells["Email"].Value.ToString();
                textBoxDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                textBoxMaNSX.Enabled = false;
            }
        }

        private void buttonTimKiem_Click_1(object sender, EventArgs e)
        {

            string keyword = textBoxTimKiem.Text.Trim();

            LoadData(keyword);
        }
    }
}

