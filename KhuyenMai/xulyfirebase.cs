using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace KhuyenMai
{
    class xulyfirebase
    {// khoitao
        public static string duongdan = Application.StartupPath + @"\";
        public static IFirebaseClient clientFirebase;
        public static IFirebaseConfig configFirebase = new FirebaseConfig
        {
            AuthSecret = "w2evy6pLiTOlWdsl3ZJ40eJ1qvCkCrFGUecs2kou",
            BasePath = "https://danhmucvm-cnf.firebaseio.com/"
        };
        public static JObject jo = JObject.Parse(File.ReadAllText("capnhat_data.json"));
        // class
        class capnhatbarcode
        {
            public string phienban { get; set; }
            public string ngay { get; set; }
        }

        // lang nghe co ban dbbarcode khong
        public static async void langnghe_barcode(Form ff)
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            EventStreamResponse response = await clientFirebase.OnAsync("capnhat/capnhatdbbarcode/phienban",
                changed:
                (sender, args, context) => {
                    taifiledbbarcode(args.Data, ff);
                });
        }
        // lang nghe dbkhuyenmai
        public static async void langnghe_khuyenmai(Label lbngaycapnhat, Form ff, DataGridView dtg)
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            EventStreamResponse response = await clientFirebase.OnAsync("capnhat/capnhatdbkhuyenmai/phienban",
                changed:
                (sender, args, context) => {
                    taifiledbkhuyenmai(args.Data, lbngaycapnhat, ff, dtg);
                });
        }
        //public static async Task<string> layPhienbanbarcode()
        //{
        //    clientFirebase = new FireSharp.FirebaseClient(configFirebase);
        //    FirebaseResponse lay = await clientFirebase.GetAsync("capnhat/capnhatdbbarcode");
        //    capnhatbarcode kq = lay.ResultAs<capnhatbarcode>();
        //    return kq.phienban;
        //}
        public static async Task<string> layngay(string tenloaidata)
        {
            clientFirebase = new FireSharp.FirebaseClient(configFirebase);
            FirebaseResponse lay = await clientFirebase.GetAsync("capnhat/capnhatdb" + tenloaidata);
            capnhatbarcode kq = lay.ResultAs<capnhatbarcode>();
            return kq.ngay;
        }
        public static async void taifiledbbarcode(string phienbanSV, Form ff)
        {

            string tenfile = @"databarcode.db";
            var task = new FirebaseStorage("danhmucvm-cnf.appspot.com")
                    .Child("database")
                    .Child(tenfile)
                    .GetDownloadUrlAsync();
            string link = await task;

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(link, "databarcode.db");
                    jo["dbbarcode"]["phienban_cl"] = phienbanSV;
                    jo["dbbarcode"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat_data.json", output);

                    string ngay = await layngay("barcode");
                    ff.Invoke(new MethodInvoker(delegate ()
                    {
                        hamtao.notifi_hts("Vừa cập nhật bảng Barcode mới\nDữ liệu ngày: " + ngay);
                    }));
                }
                catch (Exception)
                {
                    jo["dbbarcode"]["phienban_cl"] = "0";
                    jo["dbbarcode"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat_data.json", output);
                    return;
                }

            }
        }
        public static async void taifiledbkhuyenmai(string phienbanSV, Label lbngaycapnhat, Form ff, DataGridView datagrid)
        {

            string tenfile = @"datakhuyenmai.db";
            var task = new FirebaseStorage("danhmucvm-cnf.appspot.com")
                    .Child("database")
                    .Child(tenfile)
                    .GetDownloadUrlAsync();
            string link = await task;

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(link, "datakhuyenmai.db");
                    jo["dbkhuyenmai"]["phienban_cl"] = phienbanSV;
                    jo["dbkhuyenmai"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat_data.json", output);

                    string ngay = await layngay("khuyenmai");
                    datagrid.Invoke(new MethodInvoker(delegate ()
                    {
                        var conkm = ketnoikhuyenmai.Khoitao();
                        datagrid.DataSource = conkm.bangKhuyenmai();

                    }));
                    lbngaycapnhat.Invoke(new MethodInvoker(delegate ()
                    {
                        lbngaycapnhat.Text = ngay;
                    }));
                    ff.Invoke(new MethodInvoker(delegate ()
                    {
                        hamtao.notifi_hts("Vừa cập nhật bảng khuyến mại mới\nDữ liệu ngày: " + ngay);
                    }));
                }
                catch (Exception)
                {
                    jo["dbkhuyenmai"]["phienban_cl"] = "0";
                    jo["dbkhuyenmai"]["phienban_sv"] = phienbanSV;
                    string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
                    File.WriteAllText("capnhat_data.json", output);
                    return;
                }

            }
        }
    }
}
