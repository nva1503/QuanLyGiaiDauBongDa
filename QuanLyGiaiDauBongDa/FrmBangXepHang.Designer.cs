
namespace QuanLyGiaiDauBongDa
{
    partial class FrmBangXepHang
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
            this.dgvBangXepHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangXepHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBangXepHang
            // 
            this.dgvBangXepHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangXepHang.Location = new System.Drawing.Point(40, 65);
            this.dgvBangXepHang.Name = "dgvBangXepHang";
            this.dgvBangXepHang.RowHeadersWidth = 51;
            this.dgvBangXepHang.RowTemplate.Height = 29;
            this.dgvBangXepHang.Size = new System.Drawing.Size(707, 344);
            this.dgvBangXepHang.TabIndex = 0;
            // 
            // FrmBangXepHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBangXepHang);
            this.Name = "FrmBangXepHang";
            this.Text = "FrmBangXepHang";
            this.Load += new System.EventHandler(this.FrmBangXepHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangXepHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBangXepHang;
    }
}