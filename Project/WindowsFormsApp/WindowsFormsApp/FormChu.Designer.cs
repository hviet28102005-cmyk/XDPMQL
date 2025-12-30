
namespace WindowsFormsApp
{
    partial class FormChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhSáchNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchNhânViênToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.càiĐặtToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // danhSáchNhânViênToolStripMenuItem
            // 
            resources.ApplyResources(this.danhSáchNhânViênToolStripMenuItem, "danhSáchNhânViênToolStripMenuItem");
            this.danhSáchNhânViênToolStripMenuItem.Name = "danhSáchNhânViênToolStripMenuItem";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            resources.ApplyResources(this.sảnPhẩmToolStripMenuItem, "sảnPhẩmToolStripMenuItem");
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            // 
            // danhMụcToolStripMenuItem
            // 
            resources.ApplyResources(this.danhMụcToolStripMenuItem, "danhMụcToolStripMenuItem");
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            // 
            // hóaĐơnToolStripMenuItem
            // 
            resources.ApplyResources(this.hóaĐơnToolStripMenuItem, "hóaĐơnToolStripMenuItem");
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            // 
            // càiĐặtToolStripMenuItem
            // 
            resources.ApplyResources(this.càiĐặtToolStripMenuItem, "càiĐặtToolStripMenuItem");
            this.càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            // 
            // FormChu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FormChu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtToolStripMenuItem;
    }
}