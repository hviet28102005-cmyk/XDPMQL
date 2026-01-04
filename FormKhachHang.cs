using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        // Kết nối CSDL
        string Nguon = "Data Source=DESKTOP-PL4799R;Initial Catalog=XayDungPMQL;Integrated Security=True";
        string lenh = "";
        SqlConnection KetNoi;
        SqlCommand THucHien;
        SqlDataReader Doc;

        //DATA
        private void HienThiDuLieu()
        {
            KetNoi = new SqlConnection(Nguon);
            lenh = "SELECT * FROM KhachHang";
            THucHien = new SqlCommand(lenh, KetNoi);

            KetNoi.Open();
            Doc = THucHien.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(Doc);
            dataGridViewKhachHang.DataSource = dt;

            KetNoi.Close();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        // datagridview
        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtMail.Text = row.Cells["Mail"].Value.ToString();
            }
        }

        // thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMail.Clear();
            txtMaKH.Focus();
        }

        

        // lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckSDT())
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0");

                txtSDT.Focus();
                return;
            }

            if (!CheckGmail())
            {
                MessageBox.Show("Email phải có đuôi @gmail.com");
                txtMail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                txtDiaChi.Focus();
                return;
            }


            bool tonTai = KiemTraTonTaiSDT(txtSDT.Text.Trim());

            KetNoi = new SqlConnection(Nguon);

            if (tonTai)
            {
                lenh = @"UPDATE KhachHang 
                         SET TenKH=@TenKH, DiaChi=@DiaChi, Mail=@Mail 
                         WHERE SDT=@SDT";
            }
            else
            {
                lenh = @"INSERT INTO KhachHang(MaKH,TenKH,DiaChi,SDT,Mail)
                         VALUES(@MaKH,@TenKH,@DiaChi,@SDT,@Mail)";
            }

            THucHien = new SqlCommand(lenh, KetNoi);
            THucHien.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
            THucHien.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
            THucHien.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            THucHien.Parameters.AddWithValue("@SDT", txtSDT.Text);
            THucHien.Parameters.AddWithValue("@Mail", txtMail.Text);

            KetNoi.Open();
            THucHien.ExecuteNonQuery();
            KetNoi.Close();

            MessageBox.Show("Lưu thành công!");
            HienThiDuLieu();
        }

        // sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!CheckSDT())
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0");

                txtSDT.Focus();
                return;
            }
            if (!CheckGmail())
            {
                MessageBox.Show("Email phải có đuôi @gmail.com");
                txtMail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                txtDiaChi.Focus();
                return;
            }


            KetNoi = new SqlConnection(Nguon);
            lenh = @"UPDATE KhachHang 
                     SET TenKH=@TenKH, DiaChi=@DiaChi, SDT=@SDT, Mail=@Mail
                     WHERE MaKH=@MaKH";

            THucHien = new SqlCommand(lenh, KetNoi);
            THucHien.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
            THucHien.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
            THucHien.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            THucHien.Parameters.AddWithValue("@SDT", txtSDT.Text);
            THucHien.Parameters.AddWithValue("@Mail", txtMail.Text);

            KetNoi.Open();
            THucHien.ExecuteNonQuery();
            KetNoi.Close();

            MessageBox.Show("Sửa thành công!");
            HienThiDuLieu();
        }

        // xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            KetNoi = new SqlConnection(Nguon);
            lenh = "DELETE FROM KhachHang WHERE MaKH=@MaKH";
            THucHien = new SqlCommand(lenh, KetNoi);
            THucHien.Parameters.AddWithValue("@MaKH", txtMaKH.Text);

            KetNoi.Open();
            THucHien.ExecuteNonQuery();
            KetNoi.Close();

            MessageBox.Show("Xóa thành công!");
            HienThiDuLieu();
            btnThem_Click(sender, e);
        }

        // tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtTimKiem.Text.Trim();
            bool found = false;

            foreach (DataGridViewRow row in dataGridViewKhachHang.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["SDT"].Value.ToString() == sdt)
                {
                    row.Selected = true;
                    dataGridViewKhachHang.CurrentCell = row.Cells[0];

                    txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                    txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value.ToString();
                    txtMail.Text = row.Cells["Mail"].Value.ToString();

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Không tìm thấy khách hàng!");
        }
        // check gmail
        private bool CheckGmail()
        {
            return txtMail.Text.Trim().EndsWith("@gmail.com");
        }

        // ktra sdt tồn tại
        private bool KiemTraTonTaiSDT(string sdt)
        {
            KetNoi = new SqlConnection(Nguon);
            lenh = "SELECT COUNT(*) FROM KhachHang WHERE SDT=@SDT";
            THucHien = new SqlCommand(lenh, KetNoi);
            THucHien.Parameters.AddWithValue("@SDT", sdt);

            KetNoi.Open();
            int count = (int)THucHien.ExecuteScalar();
            KetNoi.Close();

            return count > 0;
        }
        private bool CheckSDT()
        {
            string sdt = txtSDT.Text.Trim();

            // Phải đúng 10 số, bắt đầu bằng 0
            if (sdt.Length != 10) return false;

            if (!sdt.StartsWith("0")) return false;

            // Kiểm tra toàn bộ là số
            foreach (char c in sdt)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }



    }
}
