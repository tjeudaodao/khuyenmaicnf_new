﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tulpep.NotificationWindow;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace KhuyenMai
{
    public partial class Form1 : Form
    {
        bool chay = true;
        static bool bang1 = true;
        DataTable dt = new DataTable();
        Thread capnhat;
        Thread closecheckupdate;

        public Form1()
        {
            InitializeComponent();
            capnhat = new Thread(hamcapnhat);
            capnhat.IsBackground = true;
            capnhat.Start();

            closecheckupdate = new Thread(CloseCheckupdate);
            closecheckupdate.IsBackground = true;
            closecheckupdate.Start();
            if (!File.Exists("capnhat_data.json"))
            {
                string hh = @"{
                            'dbbarcode' : {
                                'phienban_cl' : '0',
                                'phienban_sv' : '0'
                                },
                            'dbkhuyenmai' : {
                                'phienban_cl' : '0',
                                'phienban_sv' : '0'
                                }
                            }";
                File.WriteAllText("capnhat_data.json", hh);
            }
            try
            {
                xulyfirebase.langnghe_khuyenmai(lbcapnhat, this, datag1);
                xulyfirebase.langnghe_barcode(this);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        public void CloseCheckupdate()
        {
            Process[] GetPArry = Process.GetProcesses();
            foreach (Process testProcess in GetPArry)
            {
                string ProcessName = testProcess.ProcessName;
                if (ProcessName.CompareTo("checkUpdate") == 0)
                {
                    testProcess.Kill();
                    return;
                }
                    
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            amthanh.amluong(chay);
            
            dt.Columns.Add("Mã hàng");
            dt.Columns.Add("Giá chốt");
            dt.Columns.Add("Giá giảm");
            dt.AcceptChanges();

            if (!File.Exists("capnhat.json"))
            {
                string h = @"{
                            'phienban' : '0',
                            'ngaycapnhat' : '-',
                            'phienbanSV' : '0' 
                            }                          
                            ";
                File.WriteAllText("capnhat.json", h);
            }
            
        }
        void hamcapnhat()
        {
            closecheckupdate.Join();
            while (true)
            {
                    Thread.Sleep(200);
                    string ngay = null;
                    string ngaydata = null;
                    string tongmaKMSV = null;
                    try
                    {
                        var con = ketnoi.Khoitao();
                        ngay = con.layngaycapnhat();
                        ngaydata = con.layngayData();
                        tongmaKMSV = con.laytongsomaKM();

                        xulyJSON js = new xulyJSON();
                        string layPhienbanSV = con.GetPhienban("khuyenmaicnf");
                        js.UpdatevalueJSON("phienbanSV", layPhienbanSV);
                        string layphienbanClient = js.ReadJSON("phienban");

                        if (layphienbanClient != layPhienbanSV)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                DialogResult hoi = MessageBox.Show(this, "Có phiên bản cập nhật mới\nCó muốn cập nhật luôn không?\n\n(Chú ý: Chương trình sẽ đóng lại)", "New update", MessageBoxButtons.YesNo);
                                if (hoi == DialogResult.Yes)
                                {
                                    Process chayupdate = Process.Start(Application.StartupPath + "/checkUpdate.exe");
                                    Application.Exit();
                                }
                            }));
                        }
                    }
                    catch (Exception e)
                    {
                        lbthongbapcapnhat.Invoke(new MethodInvoker(delegate ()
                        {
                            lbthongbapcapnhat.Text = "Có lỗi kết nối đến máy chủ MySql";
                        }));
                        ghiloi.WriteLogError(e);
                        return;
                    }

                    //    var consqlite = ketnoingaycapnhat.Khoitao();


                    //    string tongmaKMCL = consqlite.tongmaKM();
                    //    string ngaykm2 = consqlite.layngaycapnhat();
                    //    string ngaydata2 = consqlite.layngayData();
                    //    if (ngaykm2 != ngay || tongmaKMSV != tongmaKMCL)
                    //    {
                    //        try
                    //        {
                    //            try
                    //            {
                    //                ftp ftpClient = new ftp(@"ftp://27.72.29.28/", "hts", "hoanglaota");

                    //                ftpClient.download("app/luutru/datakhuyenmai.db", Application.StartupPath + @"\datakhuyenmai.db");

                    //                datag1.Invoke(new MethodInvoker(delegate ()
                    //                {
                    //                    var conkm = ketnoikhuyenmai.Khoitao();
                    //                    datag1.DataSource = conkm.bangKhuyenmai();

                    //                }));
                    //                this.Invoke(new Action(delegate ()
                    //                {
                    //                    NotificationHts("Vừa Cập Nhật bảng khuyến mãi xong\nOk, triển chiêu.");
                    //                }));
                    //                lbcapnhat.Invoke(new MethodInvoker(delegate ()
                    //                {
                    //                    lbcapnhat.Text = ngay;
                    //                }));
                    //                consqlite.capnhatngayKM(ngay);
                    //                consqlite.capnhattongmaKM(tongmaKMSV);
                    //            }
                    //            catch (Exception)
                    //            {
                    //                lbthongbapcapnhat.Invoke(new MethodInvoker(delegate ()
                    //                {
                    //                    lbthongbapcapnhat.Text = "Có lỗi kết nối mạng";
                    //                }));
                    //                return;
                    //            }

                    //        }
                    //        catch (Exception)
                    //        {
                    //            lbthongbapcapnhat.Invoke(new MethodInvoker(delegate ()
                    //            {
                    //                lbthongbapcapnhat.Text = "Có bản dữ liệu mới khởi động lại chương trình để cập nhật";
                    //            }));
                    //            consqlite.capnhatngayKM("-");
                    //            throw;
                    //        }

                    //    }

                    //    if (ngaydata2 != ngaydata)
                    //    {
                    //        try
                    //        {
                    //            try
                    //            {
                    //                ftp ftpClient = new ftp(@"ftp://27.72.29.28/", "hts", "hoanglaota");

                    //                ftpClient.download("app/luutru/databarcode.db", Application.StartupPath + @"\databarcode.db");
                    //            }
                    //            catch (Exception)
                    //            {
                    //                lbthongbapcapnhat.Invoke(new MethodInvoker(delegate ()
                    //                {
                    //                    lbthongbapcapnhat.Text = "Có lỗi kết nối mạng";
                    //                }));
                    //                return;
                    //            }


                    //            this.Invoke(new Action(delegate ()
                    //            {
                    //                NotificationHts("Vừa Cập Nhật bảng barcode xong\nOk, triển chiêu.");
                    //            }));
                    //            consqlite.capnhatngayData(ngaydata);
                    //        }
                    //        catch (Exception)
                    //        {
                    //            lbthongbapcapnhat.Invoke(new MethodInvoker(delegate ()
                    //            {
                    //                lbthongbapcapnhat.Text = "Có bản dữ liệu mới khởi động lại chương trình để cập nhật";
                    //            }));
                    //            consqlite.capnhatngayData("-");
                    //            throw;
                    //        }

                    //    }
                    //    datag1.Invoke(new MethodInvoker(delegate ()
                    //    {
                    //        var conkm = ketnoikhuyenmai.Khoitao();
                    //        datag1.DataSource = conkm.bangKhuyenmai();

                    //    }));
                    //    lbcapnhat.Invoke(new MethodInvoker(delegate ()
                    //    {
                    //        lbcapnhat.Text = ngaykm2;
                    //    }));
                    //}

                    //Thread.Sleep(1800000);
            }


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
            pop.Delay = 1000;
            pop.BorderColor = System.Drawing.Color.DimGray;
            pop.HeaderHeight = 1;
            pop.Popup();
        }
        void doiMau_Phatam()
        {
            string mau = @"(^9,0)|(^[123456789]9,0)|(^1[0123456789]9,0)|(^2[0123456789]9,0)|(^3[0123456789]9,0)";
            
            string mauPhantram30 = @"30.0%$";
            string mauPhantram40 = @"40.0%$";
            string mauPhantram50 = @"50.0%$";
            //sua mau gia ca
            if (Regex.IsMatch(lbgiachot.Text,mau) && lbphantram.Text != "-")
            {
                lbgiachot.ForeColor = Color.Violet;
                amthanh.phatDonggia();
            }
            else
            {
                lbgiachot.ForeColor = Color.DimGray;
            }
           // sua mau phan tram
            if (Regex.IsMatch(lbphantram.Text,mauPhantram30))
            {
                lbphantram.ForeColor = Color.SpringGreen;
                amthanh.phat30();
            }
            else if (Regex.IsMatch(lbphantram.Text, mauPhantram40))
            {
                lbphantram.ForeColor = Color.DarkOrange;
                amthanh.phat40();
            }
            else if (Regex.IsMatch(lbphantram.Text, mauPhantram50))
            {
                lbphantram.ForeColor = Color.Tomato;
                amthanh.phat50();
            }
            else
            {
                lbphantram.ForeColor = Color.DimGray;
            }
        }
        void chenBang()
        {

            if (dt.Rows.Count > 12)
            {
                dt.Clear();
            }
            dt.Rows.Add(lbmatong.Text, lbgiachot.Text, lbphantram.Text);
            datag1.DataSource = dt;
            datag1.FirstDisplayedScrollingRowIndex =datag1.RowCount - 1;
            datag1.Rows[datag1.RowCount - 2].Selected = true;
            bang1 = false;
        }

        //void Laymota(string matong)
        //{
        //    try
        //    {
        //        string[] laythongtinMota = null;
        //        //try
        //        //{
        //        //    var conmysql = ketnoi.Khoitao();
        //        //    //laythongtinMota = conmysql.laythongtinMota(matong);
        //        //}
        //        //catch (Exception)
        //        //{

        //        //    laythongtinMota = null;
        //        //}
        //        if (laythongtinMota[0] != null || laythongtinMota[1] != null)
        //        {
        //            lbmota.Text = "\" " + laythongtinMota[0] + " - " + laythongtinMota[1] + "\"";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        lbmota.Text = "^--^";
        //        return;
        //    }
            
        //}
        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtbarcode.Text))
                    {
                        var con = ketnoisqlite.Khoitao();
                        var conkm = ketnoikhuyenmai.Khoitao();

                        hamtao ham = new hamtao();
                        string matong = con.laymasp(txtbarcode.Text);
                        if (matong == null)
                        {
                            NotificationHts("Lỗi\nMã này chưa có trong danh mục Khuyến Mãi");
                            txtbarcode.Clear();
                            txtbarcode.Focus();
                            return;
                        }
                        lbmatong.Text = matong;
                        string[] laygiatri = conkm.laythongtinkhuyenmai(matong);

                        string[] ketqua = new string[2];
                        if (laygiatri[0] != null || laygiatri[1] != null)
                        {
                            ketqua = ham.tinhToan(laygiatri[0], laygiatri[1], lbgiachot, lbphantram);
                            lbgiachot.Text = ketqua[0];
                            lbphantram.Text = ketqua[1];
                            
                            chenBang(); // them ma moi vao bang hien thi
                        }
                        else
                        {
                            lbgiachot.Text = "Nguyên giá";
                            lbphantram.Text = "-";
                            chenBang();
                            lbgiachot.ForeColor = Color.DimGray;
                            lbphantram.ForeColor = Color.DimGray;
                        }
                        txtbarcode.Clear();
                        txtbarcode.Focus();
                    }
                }
            }
            catch (Exception)
            {

                NotificationHts("Lỗi\n");
                return;
            }
            
            
        }

        private void datag1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow roww = datag1.Rows[e.RowIndex];
                string matong = roww.Cells[0].Value.ToString();
                lbmatong.Text = matong;
                string giagoc = roww.Cells[1].Value.ToString();
                string giagiam = roww.Cells[2].Value.ToString();
                if (bang1)
                {
                    hamtao ham = new hamtao();
                    
                    string[] ketqua = new string[2];
                    ketqua = ham.tinhToan(giagoc, giagiam, lbgiachot, lbphantram);
                    lbgiachot.Text = ketqua[0];
                    lbphantram.Text = ketqua[1];
                }
                else
                {
                    lbgiachot.Text = giagoc;
                    lbphantram.Text = giagiam;
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void txtmatong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var con = ketnoikhuyenmai.Khoitao();
                datag1.DataSource = con.bangKhuyenmai(txtmatong.Text);
                bang1 = true;
            }
            catch (Exception)
            {

                NotificationHts("Có lỗi rồi");
            }
            
        }

        private void pbxoa_Click(object sender, EventArgs e)
        {
            txtmatong.Clear();
            txtmatong.Focus();

        }

        private void pbamthanh_Click(object sender, EventArgs e)
        {
            chay = !chay;
            amthanh.amluong(chay);
            if (chay)
            {
                pbamthanh.Image = Properties.Resources.speaker;
            }
            else
            {
                pbamthanh.Image = Properties.Resources.mute;
            }
        }

        private void lbphantram_Click(object sender, EventArgs e)
        {

        }

        private void lbmota_Click(object sender, EventArgs e)
        {

        }
    }
}
