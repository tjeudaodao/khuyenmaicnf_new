using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KhuyenMai
{
    class ketnoikhuyenmai
    {
        #region khoitao
        private ketnoikhuyenmai()
        {
            string connstring = @"Data source=datakhuyenmai.db;version=3;new=false";
            connection = new SQLiteConnection(connstring);
        }

        private static SQLiteConnection connection = null;

        private static ketnoikhuyenmai _instance = null;
        public static ketnoikhuyenmai Khoitao()
        {
            if (_instance == null)
                _instance = new ketnoikhuyenmai();
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
        //public static void DisposeSQLite()
        //{
        //    connection.Close();
        //    System.Data.SQLite.SQLiteConnection.ClearAllPools();

        //    GC.Collect();
        //    connection.Dispose();
        //}
        #endregion

        public string[] laythongtinkhuyenmai(string matong)
        {
            string sql = string.Format("select giagoc,giagiam from khuyenmai Where matong = '{0}'", matong);
            string[] luu = new string[2];

            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            Open();
            SQLiteDataReader dtr = cmd.ExecuteReader();
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

            try
            {
                string sql = "SELECT matong as 'Mã tổng', giagoc as 'Giá gốc', giagiam as 'Giá giảm' FROM khuyenmai GROUP BY matong";
                DataTable dt = new DataTable();
                Open();
                SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, connection);
                dta.Fill(dt);
                Close();
                return dt;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public DataTable bangKhuyenmai(string locmatong)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("SELECT matong as 'Mã tổng', giagoc as 'Giá gốc', giagiam as 'Giá giảm' FROM khuyenmai WHERE matong like '{0}%' GROUP BY matong", locmatong);

            try
            {
                Open();
                SQLiteDataAdapter dta = new SQLiteDataAdapter(sql, connection);
                dta.Fill(dt);
                Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
