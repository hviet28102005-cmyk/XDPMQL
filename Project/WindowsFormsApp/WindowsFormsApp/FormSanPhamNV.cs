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
using System.Globalization;

namespace WindowsFormsApp
{
    public partial class FormSanPhamChu : Form
    {
        DataTable dt = new DataTable();
        DataTable dtNhan;
       
        public FormSanPhamChu()
        {
            InitializeComponent();
            dtNhan = dt;
        }

        string nguon = @"Data Source=DESKTOP-S4KUUMQ\SQLEXPRESS;Initial Catalog=XayDungPMQL;Integrated Security=True";
        string lenh = @"";
        SqlConnection KetNoi;
        SqlCommand ThucHien;
        SqlDataReader Doc;


        private void FormSanPham_Load(object sender, EventArgs e)
        {

            //Đây là tạo cột cho datatable nhớ chưa cứ sai 
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            KetNoi = new SqlConnection(nguon);
            lenh = @"SELECT MaSP, TenSP, MaNPP, GiaBan, SoLuongTon, MaNSX FROM dbo.SanPham";
            ThucHien = new SqlCommand(lenh, KetNoi);
            KetNoi.Open();
            Doc = ThucHien.ExecuteReader();
            int i = 0;
            while (Doc.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Doc[0];
                dataGridView1.Rows[i].Cells[1].Value = Doc[1];
                dataGridView1.Rows[i].Cells[2].Value = Doc[2];
                dataGridView1.Rows[i].Cells[3].Value = Doc[3];
                dataGridView1.Rows[i].Cells[4].Value = Doc[4];
                dataGridView1.Rows[i].Cells[5].Value = Doc[5];
                i++;
            }
            KetNoi.Close();
            dataGridView2.DataSource = dtNhan;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            decimal giaTien = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
            textBox5.Text = giaTien.ToString("#,##0", new CultureInfo("vi-VN"));
            decimal giaTien1 = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
            textBox6.Text = giaTien1.ToString("#,##0", new CultureInfo("vi-VN"));
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            lenh = @"SELECT MaSP, TenSP, MaNPP, GiaBan, SoLuongTon, MaNSX FROM dbo.SanPham WHERE TenSP LIKE N'%' +@TenSP+ '%'";
            ThucHien = new SqlCommand(lenh, KetNoi);
            KetNoi.Open();
            ThucHien.Parameters.Add("@TenSP",SqlDbType.NVarChar);
            ThucHien.Parameters["@TenSP"].Value = textBox1.Text;
            Doc = ThucHien.ExecuteReader();
            int i = 0;
            while(Doc.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Doc[0];
                dataGridView1.Rows[i].Cells[1].Value = Doc[1];
                dataGridView1.Rows[i].Cells[2].Value = Doc[2];
                dataGridView1.Rows[i].Cells[3].Value = Doc[3];
                dataGridView1.Rows[i].Cells[4].Value = Doc[4];
                dataGridView1.Rows[i].Cells[5].Value = Doc[5];
                i++;

            }    
            KetNoi.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string maSP = textBox2.Text;
            string tenSP = textBox3.Text;
            string giaText = textBox5.Text.Replace(".", "");
            decimal giaBan = decimal.Parse(giaText);

            int soLuongMua = (int)numericUpDown1.Value;

            if (soLuongMua <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0");
                return;
            }

            bool daTonTai = false;

          
            foreach (DataRow row in dt.Rows)
            {
                if (row["MaSP"].ToString() == maSP)
                {
                    int soLuongCu = (int)(row["SoLuong"]); // or int soLuongCu = Convert.ToInt32(row["SoLuong"]);
                    int soLuongMoi = soLuongCu + soLuongMua;

                    row["SoLuong"] = soLuongMoi;
                    row["ThanhTien"] = giaBan * soLuongMoi;

                    daTonTai = true;
                    break;
                }
            }

           
            if (!daTonTai)
            {
                dt.Rows.Add(
                    maSP,
                    tenSP,
                    giaBan,
                    soLuongMua,
                    giaBan * soLuongMua
                );
            }

            MessageBox.Show("Đã thêm sản phẩm!");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormThanhToan f = new FormThanhToan(dt);
            f.Show();
        }
    }
}

