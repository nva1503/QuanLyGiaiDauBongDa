namespace QuanLyGiaiDauBongDa
{
    partial class FrmLichThiDauChoClub
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbClub = new System.Windows.Forms.Label();
            this.pbClub = new System.Windows.Forms.PictureBox();
            this.flpSchedule = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbClub)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(33, 39);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(250, 35);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Lịch Thi Đấu của CLB:";
            // 
            // lbClub
            // 
            this.lbClub.AutoSize = true;
            this.lbClub.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbClub.Location = new System.Drawing.Point(355, 39);
            this.lbClub.Name = "lbClub";
            this.lbClub.Size = new System.Drawing.Size(65, 35);
            this.lbClub.TabIndex = 1;
            this.lbClub.Text = "Club";
            // 
            // pbClub
            // 
            this.pbClub.Location = new System.Drawing.Point(289, 28);
            this.pbClub.Name = "pbClub";
            this.pbClub.Size = new System.Drawing.Size(60, 60);
            this.pbClub.TabIndex = 2;
            this.pbClub.TabStop = false;
            // 
            // flpSchedule
            // 
            this.flpSchedule.Location = new System.Drawing.Point(33, 115);
            this.flpSchedule.Name = "flpSchedule";
            this.flpSchedule.Size = new System.Drawing.Size(834, 372);
            this.flpSchedule.TabIndex = 3;
            // 
            // FrmLichThiDauChoClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 511);
            this.Controls.Add(this.flpSchedule);
            this.Controls.Add(this.pbClub);
            this.Controls.Add(this.lbClub);
            this.Controls.Add(this.lbTitle);
            this.Name = "FrmLichThiDauChoClub";
            this.Text = "FrmLichThiDauChoClub";
            this.Load += new System.EventHandler(this.FrmLichThiDauChoClub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbClub;
        private System.Windows.Forms.PictureBox pbClub;
        private System.Windows.Forms.FlowLayoutPanel flpSchedule;
    }
}