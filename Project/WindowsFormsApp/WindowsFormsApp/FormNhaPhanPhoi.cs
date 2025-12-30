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
    public partial class FormNhaPhanPhoi : Form
    {
        public FormNhaPhanPhoi()
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
            if (string.IsNullOrWhiteSpace(textBoxMaNPP.Text) ||
                string.IsNullOrWhiteSpace(textBoxTenNPP.Text) ||
                string.IsNullOrWhiteSpace(textBoxDiaChi.Text) ||
                string.IsNullOrWhiteSpace(textBoxSĐT.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Vui lòng hãy nhập đầy đủ thông tin",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            string maNPP = textBoxMaNPP.Text.Trim();
            // Regex: ^[a-zA-Z0-9]+$ nghĩa là từ đầu đến cuối chỉ được chứa chữ cái và số
            if (!System.Text.RegularExpressions.Regex.IsMatch(maNPP, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã nhà phân phối không được chứa ký tự đặc biệt hoặc khoảng trắng (chỉ chấp nhận chữ không dấu và số)!",
                    "Lỗi định dạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxMaNPP.Focus(); // Đưa con trỏ chuột về lại ô Mã để sửa
                return false;
            }


            if (comboBoxMaNSX.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Mã nhà sản xuất từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMaNSX.Focus();
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

            if (maNPP.Length > 10)
            {
                MessageBox.Show("Mã nhà phân phối chỉ được nhập tối đa 10 ký tự!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxMaNPP.Focus();
                return false;
            }

            if (!maNPP.StartsWith("NPP"))
            {
                MessageBox.Show("Mã nhà phân phối phải bắt đầu bằng cụm từ 'NPP' (Ví dụ: NPP001)!",
                    "Lỗi định dạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxMaNPP.Focus();
                return false;
            }

            // Kiểm tra SĐT đúng 10 số
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxSĐT.Text, @"^0\d{9}$"))
            {
                MessageBox.Show(
                    "Số điện thoại phải bắt đầu bằng số 0 và gồm đúng 10 chữ số",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBoxSĐT.Focus();
                return false;
            }

            return true;
        }


        private void LoadData(string searchKeyword = "")
        {
            string sql = "SELECT * FROM NhaPhanPhoi";

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                sql = "SELECT * FROM NhaPhanPhoi WHERE TenNPP LIKE @kw";
            }

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword + "%");
                    }

                    var dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewNhaPhanPhoi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhà phân phối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadCombobox()
        {
            const string sql = "SELECT MaNSX FROM NhaSanXuat";

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    comboBoxMaNSX.DisplayMember = "MaNSX";
                    comboBoxMaNSX.ValueMember = "MaNSX";
                    comboBoxMaNSX.DataSource = dt;

                    // Optional: không chọn gì mặc định
                    comboBoxMaNSX.SelectedIndex = -1;
                    comboBoxMaNSX.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhà sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormNhaPhanPhoi_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombobox();
        }

      

        private void ClearInputs(bool enableMa = true)
        {
            textBoxMaNPP.Text = string.Empty;
            textBoxTenNPP.Text = string.Empty;
            textBoxDiaChi.Text = string.Empty;
            textBoxSĐT.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxTimKiem.Text = string.Empty;
            comboBoxMaNSX.SelectedIndex = -1;


            // Đặt trạng thái Enabled của ô Mã NSX dựa trên tham số truyền vào
            textBoxMaNPP.Enabled = enableMa;
        }


        private void buttonThem_Click_1(object sender, EventArgs e)
        {

            if (!ValidateInput())
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1️⃣ Kiểm tra trùng Mã NSX
                string checkSql = "SELECT COUNT(*) FROM NhaPhanPhoi WHERE MaNPP = @MaNPP";
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaNPP", textBoxMaNPP.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhà phân phối đã tồn tại!",
                            "Trùng dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        textBoxMaNPP.Focus();
                        return;
                    }
                }

                string sql = @"INSERT INTO NhaPhanPhoi
                          (MaNPP, TenNPP,DiaChi, SDT, Email,MaNSX)
                          VALUES (@MaNPP,@TenNPP,@DiaChi,@SDT,@Email,@MaNSX)";

                KetNoi = new SqlConnection(connStr);
                ThucHien = new SqlCommand(sql, KetNoi);

                ThucHien.Parameters.AddWithValue("@MaNPP", textBoxMaNPP.Text);
                ThucHien.Parameters.AddWithValue("@TenNPP", textBoxTenNPP.Text);
                ThucHien.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
                ThucHien.Parameters.AddWithValue("@SDT", textBoxSĐT.Text);
                ThucHien.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                ThucHien.Parameters.AddWithValue("@MaNSX", comboBoxMaNSX.SelectedValue ?? DBNull.Value);

                KetNoi.Open();
                ThucHien.ExecuteNonQuery();
                KetNoi.Close();

                LoadData();
            }
        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        { 
            if (!ValidateInput()) return;

            string sql = @"UPDATE NhaPhanPhoi SET 
                    MaNPP=@MaNPP,
                    TenNPP=@TenNPP,
                    DiaChi=@DiaChi,
                    SDT=@SDT,
                    Email=@Email,
                    MaNSX=@MaNSX
                    WHERE MaNPP=@MaNPP";

            KetNoi = new SqlConnection(connStr);
            ThucHien = new SqlCommand(sql, KetNoi);

            ThucHien.Parameters.AddWithValue("@MaNPP", textBoxMaNPP.Text);
            ThucHien.Parameters.AddWithValue("@TenNPP", textBoxTenNPP.Text);
            ThucHien.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
            ThucHien.Parameters.AddWithValue("@SDT", textBoxSĐT.Text);
            ThucHien.Parameters.AddWithValue("@Email", textBoxEmail.Text);
            ThucHien.Parameters.AddWithValue("@MaNSX", comboBoxMaNSX.SelectedValue ?? DBNull.Value);

            KetNoi.Open();
            ThucHien.ExecuteNonQuery();
            KetNoi.Close();

            LoadData();
        }

        private void buttonXoa_Click_1(object sender, EventArgs e)
        {
            var ma = textBoxMaNPP.Text?.Trim();
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn Mã nhà phân phối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhà phân phối '{ma}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("DELETE FROM NhaPhanPhoi WHERE MaNPP = @MaNPP", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNPP", ma);
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

        private void buttonTimKiem_Click_1(object sender, EventArgs e)
        {
            string keyword = textBoxTimKiem.Text.Trim();

            LoadData(keyword);
        }

        private void dataGridViewNhaPhanPhoi_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridViewNhaPhanPhoi.Rows[e.RowIndex];


                textBoxMaNPP.Text = row.Cells["MaNPP"].Value.ToString();
                textBoxTenNPP.Text = row.Cells["TenNPP"].Value.ToString();
                textBoxDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                textBoxSĐT.Text = row.Cells["SDT"].Value.ToString();
                textBoxEmail.Text = row.Cells["Email"].Value.ToString();
                textBoxMaNPP.Enabled = false;

                if (row.Cells["MaNSX"].Value != null)
                {
                    comboBoxMaNSX.SelectedValue = row.Cells["MaNSX"].Value.ToString();
                }
            }
        }
    }
}
