using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormNhanVien : Form
    {
        string _maNV;
        DataTable dtGioHang = new DataTable();

        public FormNhanVien(string maNV)
        {
            InitializeComponent();
            _maNV = maNV;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
           
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPhamChu F = new FormSanPhamChu();
            F.MdiParent = this;
            F.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThanhToan T = new FormThanhToan(dtGioHang);
            T.MdiParent = this;
            T.Show();
        }
    }

}
