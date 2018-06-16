using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tulpep.NotificationWindow;

namespace KhuyenMai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var con = ketnoi.Khoitao();

            datag1.DataSource = con.bangKhuyenmai();
        }
        void NotificationHts(string noidung)
        {
            PopupNotifier pop = new PopupNotifier();
            pop.TitleText = "Thông báo";
            pop.ContentText = "\" " + noidung + " \"";
            pop.Image = Properties.Resources.totoro1;
            pop.IsRightToLeft = false;
            pop.TitleColor = System.Drawing.Color.Navy;
            pop.TitleFont = new System.Drawing.Font("Comic Sans MS", 11, System.Drawing.FontStyle.Underline);
            pop.BodyColor = System.Drawing.Color.DimGray;
            pop.Size = new System.Drawing.Size(380, 130);
            pop.ImageSize = new System.Drawing.Size(100, 100);
            pop.ImagePadding = new Padding(15);
            pop.ContentColor = System.Drawing.Color.White;
            pop.ContentFont = new System.Drawing.Font("Comic Sans MS", 13, System.Drawing.FontStyle.Bold);
            pop.Delay = 3500;
            pop.BorderColor = System.Drawing.Color.DimGray;
            pop.HeaderHeight = 1;
            pop.Popup();
        }
        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtbarcode.Text))
                {
                    var con = ketnoi.Khoitao();
                    hamtao ham = new hamtao();
                    string matong = con.laymasp(txtbarcode.Text);
                    if (matong == null)
                    {
                        NotificationHts("Ma nay chua co trong danh muc");
                        txtbarcode.Clear();
                        txtbarcode.Focus();
                        return;
                    }
                    lbmatong.Text = matong;
                    string[] laygiatri = con.laythongtinkhuyenmai(matong);
                    string[] ketqua = new string[2];
                    if (laygiatri != null)
                    {
                        ketqua = ham.tinhToan(laygiatri[0], laygiatri[1]);
                        lbgiachot.Text = ketqua[0];
                        lbphantram.Text = ketqua[1];
                        lbmota.Text = "\" " + laygiatri[2] + " - " + laygiatri[3] + "\"";
                    }
                    else
                    {
                        lbgiachot.Text = "-";
                        lbphantram.Text = "-";
                        lbmota.Text = "";
                    }
                    txtbarcode.Clear();
                    txtbarcode.Focus();
                }
            }
            
        }

        private void datag1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtmatong_TextChanged(object sender, EventArgs e)
        {
            var con = ketnoi.Khoitao();
            datag1.DataSource = con.bangKhuyenmai(txtmatong.Text);
        }

        private void pbxoa_Click(object sender, EventArgs e)
        {
            txtmatong.Clear();
            txtmatong.Focus();
        }
    }
}
