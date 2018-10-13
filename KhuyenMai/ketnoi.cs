using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace KhuyenMai
{
    class ketnoi
    {
        #region khoitao
        private ketnoi()
        {
            string connstring = string.Format("Server=27.72.29.28;port=3306; database=cnf; User Id=kho; password=1234");
            connection = new MySqlConnection(connstring);
        }

        private MySqlConnection connection = null;

        private static ketnoi _instance = null;
        public static ketnoi Khoitao()
        {
            if (_instance == null)
                _instance = new ketnoi();
            return _instance;
        }
        public void Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {

                    return;
                }

            }
        }

        public void Close()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        #endregion

        #region Xuly
        public string layngayData()
        {
            string sql = "SELECT ngaydata FROM ngaycapnhat";
            string h = null;

            Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            return h;
        }
        public string layngaycapnhat()
        {
            string sql = "SELECT ngaykhuyenmai FROM ngaycapnhat";
            string h = null;

            Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            return h;
        }
        public string laytongsomaKM()
        {
            string sql = "SELECT tongmakhuyenmai FROM ngaycapnhat";
            string h = null;

            Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr[0].ToString();
            }
            Close();
            return h;
        }

        public string GetPhienban(string tenungdung)
        {
            string kq = null;
            string sql = "select phienban from bangcapnhatphanmem where tenungdung = '" + tenungdung + "'";
            Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();
            kq = dtr[0].ToString();
            Close();
            return kq;
        }
        //public string[] laythongtinMota(string matong)
        //{
        //    string sql = string.Format("select mota,chude from hangduocban Where matong = '{0}'", matong);
        //    string[] luu = new string[2];

        //    MySqlCommand cmd = new MySqlCommand(sql, connection);
        //    Open();
        //    MySqlDataReader dtr = cmd.ExecuteReader();
        //    while (dtr.Read())
        //    {
        //        for (int i = 0; i < luu.Length; i++)
        //        {
        //            luu[i] = dtr[i].ToString();
        //        }
        //    }
        //    Close();
        //    return luu;
        //}
        #endregion
    }
}
