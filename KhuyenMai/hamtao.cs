using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Forms;

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
        public string[] tinhToan(string giagoc, string sogiam, Label lbgiachot, Label lbphantram)
        {
            double db_giagoc = chuyenDouble(giagoc);
            double db_sogiam = chuyenDouble(sogiam);

            string luu1 = null;
            string luu2 = null;

            if (db_sogiam > 0 && db_sogiam < 1)
            {
                luu1 = doisangdonvitien(db_giagoc - (db_sogiam * db_giagoc));
                luu2 = doisangphantramgiam(db_sogiam * 100);
                lbgiachot.ForeColor = Color.DimGray;

                string mauPhantram10 = @"10.0%$";
                string mauPhantram20 = @"20.0%$";
                string mauPhantram30 = @"30.0%$";
                string mauPhantram40 = @"40.0%$";
                string mauPhantram50 = @"50.0%$";

                if (Regex.IsMatch(luu2, mauPhantram30))
                {
                    lbphantram.ForeColor = Color.SpringGreen;
                    amthanh.phat30();
                }
                else if (Regex.IsMatch(luu2, mauPhantram40))
                {
                    lbphantram.ForeColor = Color.DarkOrange;
                    amthanh.phat40();
                }
                else if (Regex.IsMatch(luu2, mauPhantram50))
                {
                    lbphantram.ForeColor = Color.Tomato;
                    amthanh.phat50();
                }
                else if (Regex.IsMatch(luu2, mauPhantram10))
                {
                    lbphantram.ForeColor = Color.DimGray;
                    amthanh._10phantram.Play();
                }
                else if (Regex.IsMatch(luu2, mauPhantram20))
                {
                    lbphantram.ForeColor = Color.DimGray;
                    amthanh._20phantram.Play();
                }
                else
                {
                    lbphantram.ForeColor = Color.DimGray;
                }
            }
            else if (db_sogiam > 1)
            {
                luu1 = doisangdonvitien(db_sogiam);
                luu2 = doisangphantramgiam((1 - db_sogiam / db_giagoc) * 100);
                lbgiachot.ForeColor = Color.Violet;
                lbphantram.ForeColor = Color.DimGray;

                string mau = @"(\d+),000 đ$";
                Match kq = Regex.Match(luu1, mau);

                string songhin = kq.Groups[1].ToString();
                if (songhin.Length == 1)
                {
                    // 9000
                    amthanh._9nghin.Play();
                }
                else if (songhin.Length == 2)
                {
                    if (songhin == "29")
                    {
                        amthanh._29nghin.Play();
                    }
                    else if (songhin == "49")
                    {
                        amthanh._49nghin.Play();
                    }
                    else if (songhin == "79")
                    {
                        amthanh._79nghin.Play();
                    }
                    else if (songhin == "99")
                    {
                        amthanh._99nghin.Play();
                    }
                }
                else 
                {
                    if (songhin == "119")
                    {
                        amthanh._119nghin.Play();
                    }
                    else if (songhin == "149")
                    {
                        amthanh._149nghin.Play();
                    }
                    else if (songhin == "199")
                    {
                        amthanh._199nghin.Play();
                    }
                    else if (songhin == "249")
                    {
                        amthanh._249nghin.Play();
                    }
                    else if (songhin == "299")
                    {
                        amthanh._299nghin.Play();
                    }
                    else if (songhin == "349")
                    {
                        amthanh._349nghin.Play();
                    }
                    else if (songhin == "369")
                    {
                        amthanh._369nghin.Play();
                    }
                    else if (songhin == "549")
                    {
                        amthanh._549nghin.Play();
                    }
                    else if (songhin == "599")
                    {
                        amthanh._599nghin.Play();
                    }
                    else
                    {
                        amthanh.phatDonggia();
                    }
                }
            }

            string[] luu = new string[2];
            luu[0] = luu1;
            luu[1] = luu2;

            return luu;
        }
    }
}
