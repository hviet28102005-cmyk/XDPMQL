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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        string connStr = @"Data Source=LAPTOP-MPN2R439\SQLEXPRESS;Initial Catalog=LTMT4-NguyenTruongSon;Integrated Security=True";
        SqlConnection KetNoi;

        #region Các hàm bổ trợ
        bool ValidateInput()
        {
            string maSP = textBoxMaSanPham.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(textBoxTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm!", "Thông báo");
                return false;
            }

            if (!maSP.StartsWith("SP"))
            {
                MessageBox.Show("Mã sản phẩm phải bắt đầu bằng 'SP'!", "Lỗi");
                return false;
            }

           
            if (comboBoxTenNPP.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà Phân Phối!", "Lỗi");
                return false;
            }

            return true;
        }

        private bool CheckTrungMa(string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        #endregion

        #region Load Dữ liệu
        void LoadData()
        {
            try
            {
                using (KetNoi = new SqlConnection(connStr))
                {
                    string sql = @"SELECT sp.MaSP, sp.TenSP, sp.GiaBan, sp.GiaNhap, sp.SoLuongTon, 
                                          npp.TenNPP, nsx.TenNSX 
                                   FROM SanPham sp
                                   INNER JOIN NhaPhanPhoi npp ON sp.MaNPP = npp.MaNPP
                                   INNER JOIN NhaSanXuat nsx ON npp.MaNSX = nsx.MaNSX";

                    SqlDataAdapter da = new SqlDataAdapter(sql, KetNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewSanPham.DataSource = dt;

                    dataGridViewSanPham.Columns["TenNPP"].HeaderText = "Nhà Phân Phối";
                    dataGridViewSanPham.Columns["TenNSX"].HeaderText = "Nhà Sản Xuất";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        
        void LoadComboBoxNSX()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaNSX, TenNSX FROM NhaSanXuat";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxTenNSX.DataSource = dt;
                comboBoxTenNSX.DisplayMember = "TenNSX";
                comboBoxTenNSX.ValueMember = "MaNSX";
                comboBoxTenNSX.SelectedIndex = -1;
            }
        }

        
        void LoadComboBoxNPP_TheoNSX(string maNSX)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT MaNPP, TenNPP FROM NhaPhanPhoi WHERE MaNSX = @maNSX";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNSX", maNSX);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                comboBoxTenNPP.DataSource = null;
                comboBoxTenNPP.Items.Clear();
              

                if (dt.Rows.Count > 0)
                {
                    comboBoxTenNPP.DataSource = dt;
                    comboBoxTenNPP.DisplayMember = "TenNPP";
                    comboBoxTenNPP.ValueMember = "MaNPP";
                    comboBoxTenNPP.SelectedIndex = -1; 
                }
                else
                {

                    comboBoxTenNPP.Text = "";
                }
            }

        }
        #endregion

        #region Sự kiện Form và ComboBox
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxNSX();
        }

       
        #endregion

        #region Các nút chức năng
        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (CheckTrungMa(textBoxMaSanPham.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"INSERT INTO SanPham (MaSP, TenSP, GiaNhap, GiaBan, SoLuongTon, MaNPP)
                                   VALUES (@MaSP, @TenSP, @GiaNhap, @GiaBan, @SoLuongTon, @MaNPP)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSP", textBoxMaSanPham.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", textBoxTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaNhap", double.Parse(textBoxGiaNhap.Text));
                    cmd.Parameters.AddWithValue("@GiaBan", double.Parse(textBoxGiaBan.Text));
                    cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(textBoxSoLuongTon.Text));
                    // Lấy MaNPP từ ComboBox phía dưới
                    cmd.Parameters.AddWithValue("@MaNPP", comboBoxTenNPP.SelectedValue.ToString());


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"UPDATE SanPham SET TenSP=@TenSP, GiaNhap=@GiaNhap, GiaBan=@GiaBan, 
                                   SoLuongTon=@SoLuongTon, MaNPP=@MaNPP WHERE MaSP=@MaSP";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSP", textBoxMaSanPham.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenSP", textBoxTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaNhap", double.Parse(textBoxGiaNhap.Text));
                    cmd.Parameters.AddWithValue("@GiaBan", double.Parse(textBoxGiaBan.Text));
                    cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(textBoxSoLuongTon.Text));
                    cmd.Parameters.AddWithValue("@MaNPP", comboBoxTenNPP.SelectedValue.ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void buttonXoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaSanPham.Text)) return;

            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string sql = "DELETE FROM SanPham WHERE MaSP=@MaSP";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@MaSP", textBoxMaSanPham.Text.Trim());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        LoadData();
                        ClearInputs();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
            LoadComboBoxNSX();
        }
        #endregion

        #region Tìm kiếm và Click bảng
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = textBoxTimKiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT sp.MaSP, sp.TenSP, sp.GiaBan, sp.GiaNhap, sp.SoLuongTon, npp.TenNPP, nsx.TenNSX 
                               FROM SanPham sp
                               INNER JOIN NhaPhanPhoi npp ON sp.MaNPP = npp.MaNPP
                               INNER JOIN NhaSanXuat nsx ON npp.MaNSX = nsx.MaNSX
                               WHERE sp.TenSP LIKE @keyword OR sp.MaSP LIKE @keyword";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + tuKhoa + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewSanPham.DataSource = dt;
            }
        }

        private void dataGridViewSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSanPham.Rows[e.RowIndex];
                textBoxMaSanPham.Text = row.Cells["MaSP"].Value.ToString();
                textBoxTenSP.Text = row.Cells["TenSP"].Value.ToString();
                textBoxGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                textBoxGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                textBoxSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();

               
                comboBoxTenNSX.Text = row.Cells["TenNSX"].Value.ToString();
                comboBoxTenNPP.Text = row.Cells["TenNPP"].Value.ToString();

                textBoxMaSanPham.ReadOnly = true;
            }
        }

        private void ClearInputs()
        {
        
            textBoxMaSanPham.Clear();
            textBoxTenSP.Clear();
            textBoxGiaNhap.Clear();
            textBoxGiaBan.Clear();
            textBoxSoLuongTon.Clear();
            textBoxTimKiem.Clear();

           
            textBoxMaSanPham.ReadOnly = false;
            textBoxMaSanPham.Focus();

         
            comboBoxTenNSX.SelectedIndex = -1;

            
            comboBoxTenNPP.DataSource = null;
        }
        #endregion

        private void comboBoxTenNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBoxTenNSX.SelectedValue != null && comboBoxTenNSX.SelectedIndex != -1
                && !(comboBoxTenNSX.SelectedValue is DataRowView))
            {
                string maNSX = comboBoxTenNSX.SelectedValue.ToString();
                LoadComboBoxNPP_TheoNSX(maNSX);
            }
            else
            {
               
                comboBoxTenNPP.DataSource = null;
                comboBoxTenNPP.Text = "";
            }
        }

        private void ExportToExcel(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
          
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
           
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Danh sách sản phẩm";

                
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                    
                    worksheet.Cells[1, i].Font.Bold = true;
                }

                
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = "DanhSachSanPham_" + DateTime.Now.ToString("ddMMyyyy");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo");
                }

                
                app.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.Rows.Count > 0)
            {
                ExportToExcel(dataGridViewSanPham);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
            }
         }

    }
}