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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        string Nguon = @"Data Source=DESKTOP-S4KUUMQ\SQLEXPRESS;Initial Catalog=XayDungPMQL;Integrated Security=True";
       // SqlConnection  KetNoi;
       // SqlCommand ThucHien;
       // SqlDataReader Doc;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn phải nhập tài khoản và mật khẩu");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Nguon))
            {
                conn.Open();

               

               
                string sqlAdmin = @"SELECT COUNT(*) 
                            FROM TaiKhoan 
                            WHERE TenAdmin = @TenAdmin 
                            AND MatKhau = @MatKhau";

                using (SqlCommand cmdAdmin = new SqlCommand(sqlAdmin, conn))
                {
                    cmdAdmin.Parameters.AddWithValue("@TenAdmin", txtTaiKhoan.Text.Trim());
                    cmdAdmin.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());

                    int adminCount = (int)cmdAdmin.ExecuteScalar();

                    if (adminCount > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công rồi ông chủ ơi :))!");

                        this.Hide();
                        FormChu frm = new FormChu();
                        frm.ShowDialog();   
                        this.Close();
                        return;
                    }
                }

                string sqlNV = @"SELECT MaNV 
                         FROM NhanVien 
                         WHERE MaNV = @MaNV 
                         AND MatKhau = @MatKhau";

                using (SqlCommand cmdNV = new SqlCommand(sqlNV, conn))
                {
                    cmdNV.Parameters.AddWithValue("@MaNV", txtTaiKhoan.Text.Trim());
                    cmdNV.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());

                    SqlDataReader rd = cmdNV.ExecuteReader();
                    if (rd.Read())
                    {
                        string maNV = rd["MaNV"].ToString();

                       // MessageBox.Show("Đăng nhập thành công!");

                        this.Hide();
                        FormNhanVien frmNV = new FormNhanVien(maNV);
                        frmNV.ShowDialog();  
                        this.Close();
                        return;
                    }
                    rd.Close();
                }

                MessageBox.Show("Có Thế Thôi Cũng Nhập Sai Tài Khoản, Mật Khẩu ");
            }
        }



    }
}
