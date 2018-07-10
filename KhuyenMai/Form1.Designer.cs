namespace KhuyenMai
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.datag1 = new System.Windows.Forms.DataGridView();
            this.txtmatong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbgiachot = new System.Windows.Forms.Label();
            this.lbphantram = new System.Windows.Forms.Label();
            this.lbmota = new System.Windows.Forms.Label();
            this.lbmatong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbcapnhat = new System.Windows.Forms.Label();
            this.pbamthanh = new System.Windows.Forms.PictureBox();
            this.pbxoa = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbamthanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbarcode
            // 
            this.txtbarcode.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.Location = new System.Drawing.Point(247, 26);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(220, 35);
            this.txtbarcode.TabIndex = 0;
            this.txtbarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyDown);
            // 
            // datag1
            // 
            this.datag1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datag1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datag1.BackgroundColor = System.Drawing.Color.White;
            this.datag1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datag1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datag1.Location = new System.Drawing.Point(12, 237);
            this.datag1.MultiSelect = false;
            this.datag1.Name = "datag1";
            this.datag1.RowHeadersVisible = false;
            this.datag1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datag1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag1.Size = new System.Drawing.Size(455, 408);
            this.datag1.TabIndex = 2;
            this.datag1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag1_CellClick);
            // 
            // txtmatong
            // 
            this.txtmatong.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmatong.Location = new System.Drawing.Point(246, 174);
            this.txtmatong.Name = "txtmatong";
            this.txtmatong.Size = new System.Drawing.Size(220, 35);
            this.txtmatong.TabIndex = 1;
            this.txtmatong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtmatong.TextChanged += new System.EventHandler(this.txtmatong_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập Barcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(8, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm theo Mã tổng";
            // 
            // lbgiachot
            // 
            this.lbgiachot.BackColor = System.Drawing.Color.White;
            this.lbgiachot.Font = new System.Drawing.Font("Comic Sans MS", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgiachot.ForeColor = System.Drawing.Color.DimGray;
            this.lbgiachot.Location = new System.Drawing.Point(487, 26);
            this.lbgiachot.Name = "lbgiachot";
            this.lbgiachot.Size = new System.Drawing.Size(829, 239);
            this.lbgiachot.TabIndex = 3;
            this.lbgiachot.Text = "Giá chốt";
            this.lbgiachot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbphantram
            // 
            this.lbphantram.BackColor = System.Drawing.Color.White;
            this.lbphantram.Font = new System.Drawing.Font("Comic Sans MS", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbphantram.ForeColor = System.Drawing.Color.DimGray;
            this.lbphantram.Location = new System.Drawing.Point(487, 295);
            this.lbphantram.Name = "lbphantram";
            this.lbphantram.Size = new System.Drawing.Size(829, 239);
            this.lbphantram.TabIndex = 3;
            this.lbphantram.Text = "Số % giảm";
            this.lbphantram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmota
            // 
            this.lbmota.BackColor = System.Drawing.Color.White;
            this.lbmota.Font = new System.Drawing.Font("Comic Sans MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmota.ForeColor = System.Drawing.Color.DimGray;
            this.lbmota.Location = new System.Drawing.Point(487, 561);
            this.lbmota.Name = "lbmota";
            this.lbmota.Size = new System.Drawing.Size(829, 118);
            this.lbmota.TabIndex = 3;
            this.lbmota.Text = "Mô tả sản phẩm";
            this.lbmota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbmatong
            // 
            this.lbmatong.BackColor = System.Drawing.Color.White;
            this.lbmatong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbmatong.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmatong.ForeColor = System.Drawing.Color.DimGray;
            this.lbmatong.Location = new System.Drawing.Point(195, 82);
            this.lbmatong.Name = "lbmatong";
            this.lbmatong.Size = new System.Drawing.Size(271, 73);
            this.lbmatong.TabIndex = 4;
            this.lbmatong.Text = "Mã tổng";
            this.lbmatong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cập nhật gần nhất ngày : ";
            // 
            // lbcapnhat
            // 
            this.lbcapnhat.AutoSize = true;
            this.lbcapnhat.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcapnhat.ForeColor = System.Drawing.Color.Indigo;
            this.lbcapnhat.Location = new System.Drawing.Point(206, 662);
            this.lbcapnhat.Name = "lbcapnhat";
            this.lbcapnhat.Size = new System.Drawing.Size(16, 22);
            this.lbcapnhat.TabIndex = 5;
            this.lbcapnhat.Text = "-";
            // 
            // pbamthanh
            // 
            this.pbamthanh.Image = ((System.Drawing.Image)(resources.GetObject("pbamthanh.Image")));
            this.pbamthanh.Location = new System.Drawing.Point(422, 651);
            this.pbamthanh.Name = "pbamthanh";
            this.pbamthanh.Size = new System.Drawing.Size(44, 37);
            this.pbamthanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbamthanh.TabIndex = 6;
            this.pbamthanh.TabStop = false;
            this.pbamthanh.Click += new System.EventHandler(this.pbamthanh_Click);
            // 
            // pbxoa
            // 
            this.pbxoa.Image = ((System.Drawing.Image)(resources.GetObject("pbxoa.Image")));
            this.pbxoa.Location = new System.Drawing.Point(195, 174);
            this.pbxoa.Name = "pbxoa";
            this.pbxoa.Size = new System.Drawing.Size(50, 35);
            this.pbxoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxoa.TabIndex = 1;
            this.pbxoa.TabStop = false;
            this.pbxoa.Click += new System.EventHandler(this.pbxoa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(195, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 691);
            this.Controls.Add(this.pbamthanh);
            this.Controls.Add(this.lbcapnhat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbmatong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbmota);
            this.Controls.Add(this.lbphantram);
            this.Controls.Add(this.lbgiachot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datag1);
            this.Controls.Add(this.pbxoa);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtmatong);
            this.Controls.Add(this.txtbarcode);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Khuyến Mãi ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbamthanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView datag1;
        private System.Windows.Forms.TextBox txtmatong;
        private System.Windows.Forms.PictureBox pbxoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbgiachot;
        private System.Windows.Forms.Label lbphantram;
        private System.Windows.Forms.Label lbmota;
        private System.Windows.Forms.Label lbmatong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbcapnhat;
        private System.Windows.Forms.PictureBox pbamthanh;
    }
}

