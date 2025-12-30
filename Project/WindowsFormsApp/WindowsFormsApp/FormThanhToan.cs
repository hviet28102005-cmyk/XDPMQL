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

namespace WindowsFormsApp
{
    public partial class FormThanhToan : Form
    {
        DataTable dtNhan2;


        bool laKhachCu = false;
        string maKH_DangChon = "";
        string maNV_DangChon = "";
      

        public FormThanhToan(DataTable dtnhan)
        {
            InitializeComponent();
            dtNhan2 = dtnhan;
          
        }

        string nguon = @"Data Source=DESKTOP-S4KUUMQ\SQLEXPRESS;Initial Catalog=XayDungPMQL;Integrated Security=True";
        string lenh = "";
        SqlConnection KetNoi;
        SqlCommand ThucHien;
        SqlDataReader Doc;

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtNhan2;

            dataGridView2.Rows.Clear();
            KetNoi = new SqlConnection(nguon);

            lenh = @"SELECT MaKH, TenKH, DiaChi, SDT, Mail FROM KhachHang";
            ThucHien = new SqlCommand(lenh, KetNoi);

            KetNoi.Open();
            Doc = ThucHien.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = Doc[0];
                dataGridView2.Rows[i].Cells[1].Value = Doc[1];
                dataGridView2.Rows[i].Cells[2].Value = Doc[2];
                dataGridView2.Rows[i].Cells[3].Value = Doc[3];
                dataGridView2.Rows[i].Cells[4].Value = Doc[4];
                i++;
            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            laKhachCu = false;
            maKH_DangChon = "";

            KetNoi = new SqlConnection(nguon);
            lenh = @"SELECT MaKH, TenKH, DiaChi, SDT, Mail FROM KhachHang WHERE SDT = @SDT";

            ThucHien = new SqlCommand(lenh, KetNoi);
            ThucHien.Parameters.Add("@SDT", SqlDbType.NVarChar);
            ThucHien.Parameters["@SDT"].Value = textBox6.Text;
            KetNoi.Open();
            Doc = ThucHien.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                laKhachCu = true;
                maKH_DangChon = Doc["MaKH"].ToString();

                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = Doc[0];
                dataGridView2.Rows[i].Cells[1].Value = Doc[1];
                dataGridView2.Rows[i].Cells[2].Value = Doc[2];
                dataGridView2.Rows[i].Cells[3].Value = Doc[3];
                dataGridView2.Rows[i].Cells[4].Value = Doc[4];
                i++;
            }

            KetNoi.Close();

         /*   if (laKhachCu)
                MessageBox.Show("Đã Tìm Thấy Khách");
            else
                MessageBox.Show("Không Có Dữ Liệu Của Khách");
         */
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;

            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            maKH_DangChon = textBox1.Text;
            laKhachCu = true;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection KetNoi = new SqlConnection(nguon))
            {
                KetNoi.Open();
                SqlTransaction tran = KetNoi.BeginTransaction();

                try
                {
                    
                    if (!laKhachCu)
                    {
                        string sqlKH = @"INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SDT, Mail)
                                 VALUES (@MaKH, @TenKH, @DiaChi, @SDT, @Mail)";

                        using (SqlCommand cmdKH = new SqlCommand(sqlKH, KetNoi, tran))
                        {
                            cmdKH.Parameters.AddWithValue("@MaKH", textBox1.Text);
                            cmdKH.Parameters.AddWithValue("@TenKH", textBox2.Text);
                            cmdKH.Parameters.AddWithValue("@DiaChi", textBox3.Text);
                            cmdKH.Parameters.AddWithValue("@SDT", textBox4.Text);
                            cmdKH.Parameters.AddWithValue("@Mail", textBox5.Text);
                            cmdKH.ExecuteNonQuery();
                        }

                        maKH_DangChon = textBox1.Text;
                    }

                   
                    string sqlHD = @"INSERT INTO HoaDon (MaHD, NgayLapHD, TongTien, MaKH, MaNV)
                             VALUES (@MaHD, @NgayLapHD, @TongTien, @MaKH, @MaNV)";

                    using (SqlCommand cmdHD = new SqlCommand(sqlHD, KetNoi, tran))
                    {
                        cmdHD.Parameters.AddWithValue("@MaHD", textBox7.Text);
                        cmdHD.Parameters.AddWithValue("@NgayLapHD", dtpNgayLapHD.Value);
                        cmdHD.Parameters.AddWithValue("@TongTien", decimal.Parse(textBox11.Text));
                        cmdHD.Parameters.AddWithValue("@MaKH", maKH_DangChon);
                        cmdHD.Parameters.AddWithValue("@MaNV", maNV_DangChon);
                        cmdHD.ExecuteNonQuery();
                    }

                   
                    string sqlCT = @"INSERT INTO ChiTietHoaDon
                             (MaHD, MaSP, SoLuongBan, DonGia, ThanhTien)
                             VALUES (@MaHD, @MaSP, @SoLuongBan, @DonGia, @ThanhTien)";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        if (row.Cells["MaSP"].Value == null) continue;

                        using (SqlCommand cmdCT = new SqlCommand(sqlCT, KetNoi, tran))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", textBox7.Text);
                            cmdCT.Parameters.AddWithValue("@MaSP", row.Cells["MaSP"].Value);
                            cmdCT.Parameters.AddWithValue("@SoLuongBan", row.Cells["SoLuong"].Value);
                            cmdCT.Parameters.AddWithValue("@DonGia", row.Cells["GiaBan"].Value);
                            cmdCT.Parameters.AddWithValue("@ThanhTien", row.Cells["ThanhTien"].Value);
                            cmdCT.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("✅ Thanh toán thành công");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi thanh toán: " + ex.Message);
                    FormThanhToan T = new FormThanhToan(dtNhan2);
                    T.Show();
                   
                }
                FormSanPhamNV f = new FormSanPhamNV();
                f.Show();
            }
        }

    }
}
