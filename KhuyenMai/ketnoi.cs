using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;

namespace KhuyenMai
{
    class ketnoi
    {
        #region khoitao
        private ketnoi()
        {
            string connstring = string.Format("Server=27.72.29.28;port=3306; database=cnf; User Id=kho; password=1234");
            // string connstring = string.Format("Server=localhost;port=3306; database=cnf; User Id=hts; password=1211");
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
                connection.Open();
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
        // lay masp tu barcode
        public string laymasp(string barcode)
        {
            string sql = string.Format("SELECT masp FROM data WHERE barcode='{0}'", barcode);
            string h = null;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            Open();
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                h = dtr["masp"].ToString();
            }
            Close();
            if (h != null)
            {
                int vitri = h.IndexOf("-");
                h = h.Substring(0, vitri);
            }
            
            return h;
        }

        public string[] laythongtinkhuyenmai(string matong)
        {
            string sql = string.Format("select k.giagoc,k.giagiam,m.mota,m.chude from khuyenmai k join hangduocban m On k.matong= m.matong Where k.matong = '{0}'", matong);
            string[] luu = new string[4];

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            Open();
            MySqlDataReader dtr = cmd.ExecuteReader();
            while (dtr.Read())
            {
                for (int i = 0; i < luu.Length; i++)
                {
                    luu[i] = dtr[i].ToString();
                }
            }
            Close();
            return luu;
        }
        public DataTable bangKhuyenmai()
        {
            string sql = "SELECT matong as 'Mã tổng', giagoc as 'Giá gốc', giagiam as 'Giá giảm' FROM KHUYENMAI GROUP BY matong";
            DataTable dt = new DataTable();

            Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, connection);
            dta.Fill(dt);
            Close();
            return dt;
        }
        public DataTable bangKhuyenmai(string locmatong)
        {
            DataTable dt = new DataTable();
            string sql =string.Format( "SELECT matong as 'Mã tổng', giagoc as 'Giá gốc', giagiam as 'Giá giảm' FROM KHUYENMAI WHERE matong like '{0}%' GROUP BY matong",locmatong);
            

            Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, connection);
            dta.Fill(dt);
            Close();
            return dt;
          
        }
        #endregion
    }
}
