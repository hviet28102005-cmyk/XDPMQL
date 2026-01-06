using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormHoaDonChu : Form
    {
        string Nguon = "Data Source=DESKTOP-PL4799R;Initial Catalog=XayDungPMQL;Integrated Security=True";
        string lenh = "";
        SqlConnection KetNoi;
        SqlCommand ThucHien;
        SqlDataReader Doc;
        public FormHoaDonChu()
        {
            InitializeComponent();
        }

        private void labelTimKiem_Click(object sender, EventArgs e)
        {
           

        }

        private void FormHoaDonChu_Load(object sender, EventArgs e)
        {
            KetNoi = new SqlConnection(Nguon);
            lenh = "SELECT MaHD, NgayLapHD, TongTien, MaKH, MaNV FROM dbo.HoaDon";
            ThucHien = new SqlCommand(lenh, KetNoi);
            KetNoi.Open();
            Doc = ThucHien.ExecuteReader();
            int i = 0;
            while(Doc.Read())
            {
                dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[i].Cells[0].Value = Doc[0];
                dgvHoaDon.Rows[i].Cells[1].Value = Doc[1];
                dgvHoaDon.Rows[i].Cells[2].Value = Doc[2];
                dgvHoaDon.Rows[i].Cells[3].Value = Doc[3];
                dgvHoaDon.Rows[i].Cells[4].Value = Doc[4];
                i++;

            }  
            KetNoi.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
            KetNoi = new SqlConnection(Nguon);
            lenh = @"SELECT MaHD, NgayLapHD, TongTien, MaKH, MaNV FROM dbo.HoaDon WHERE  MaHD LIKE '%' +@MaHD+ '%' ";
            ThucHien = new SqlCommand(lenh, KetNoi);
            KetNoi.Open();
            ThucHien.Parameters.Add("@MaHD", SqlDbType.NVarChar);
            ThucHien.Parameters["@MaHD"].Value = txtTimKiem.Text;
            Doc = ThucHien.ExecuteReader();
            int i = 0; 
            while(Doc.Read())
            {
                dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[i].Cells[0].Value = Doc[0];
                dgvHoaDon.Rows[i].Cells[1].Value = Doc[1];
                dgvHoaDon.Rows[i].Cells[2].Value = Doc[2];
                dgvHoaDon.Rows[i].Cells[3].Value = Doc[3];
                dgvHoaDon.Rows[i].Cells[4].Value = Doc[4];
                i++;
            }    
            KetNoi.Close();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            txtNgayLapHD.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
            txtTongTien.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            txtMaKH.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();
            txtMaNV.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE HoaDon 
                     SET MaHD=@TenKH, NgayLapHD=@NgayLapHD, TongTien=@TongTien, MaKH=@MaKH, MaNV=@MaNV
                     WHERE MaHD=@MaHD";
            ThucHien = new SqlCommand(lenh, KetNoi);
            ThucHien.Parameters.Add("@MaHD", SqlDbType.NVarChar);
            ThucHien.Parameters.Add("@NgayLapHD", SqlDbType.NVarChar);
            ThucHien.Parameters.Add("@TongTien", SqlDbType.NVarChar);
            ThucHien.Parameters.Add("@MaKH", SqlDbType.NVarChar);
            ThucHien.Parameters.Add("@MaNV", SqlDbType.NVarChar);

            ThucHien.Parameters["@MaHD"].Value = txtMaHD.Text;
            ThucHien.Parameters["@NgayLapHD"].Value = txtNgayLapHD.Text;
            ThucHien.Parameters["@TongTien"].Value = txtTongTien.Text;
            ThucHien.Parameters["@MaKH"].Value = txtMaKH.Text;
            ThucHien.Parameters["@MaNV"].Value = txtMaNV.Text;

            KetNoi.Open();
            ThucHien.ExecuteNonQuery();
            KetNoi.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (D == DialogResult.Yes)
            {
                lenh = @"DELETE FROM HoaDon WHERE MaHD=@MaHD";
                ThucHien = new SqlCommand(lenh, KetNoi);
                ThucHien.Parameters.Add("@MaHD", SqlDbType.NVarChar);
                ThucHien.Parameters["@MaHD"].Value = dgvHoaDon.CurrentRow.Cells[0].Value;
                KetNoi.Open();
                ThucHien.ExecuteNonQuery();
                KetNoi.Close();
            }

        }
    }
}
