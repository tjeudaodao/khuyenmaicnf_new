using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhuyenMai
{
    class hamtao
    {
        // ham tinh toan khuyen mai
        public double chuyenDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return OutVal;
            }
        }
        public string doisangdonvitien(double sotien)
        {
            return string.Format("{0:0,0 đ}", sotien);
        }
        public string doisangphantramgiam(double giagiam)
        {
            return string.Format("Giảm {0:0.0}%", giagiam);
        }
        public string[] tinhToan(string giagoc, string sogiam)
        {
            double db_giagoc = chuyenDouble(giagoc);
            double db_sogiam = chuyenDouble(sogiam);

            string luu1 = null;
            string luu2 = null;

            if (db_giagoc == 0)
            {
                if (db_sogiam > 0 && db_sogiam < 1)
                {
                    luu1 = "-";
                    luu2 = doisangphantramgiam(db_sogiam * 100);
                }
                else if (db_sogiam > 1)
                {
                    luu1 = doisangdonvitien(db_sogiam);
                    luu2 = "-";
                }
            }
            else if (db_giagoc != 0)
            {

            }
            string[] luu = new string[2];
            luu[0] = luu1;
            luu[1] = luu2;

            return luu;
        }
    }
}
