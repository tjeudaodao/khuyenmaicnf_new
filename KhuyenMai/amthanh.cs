using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hamamthanh = System.Media.SoundPlayer;


namespace KhuyenMai
{
    class amthanh
    {
        public static bool amluong(bool chay)
        {
            chayhaykhongchay = chay;
            return chay;
        }
        static bool chayhaykhongchay;
        public static hamamthanh bamuoiphantram = new hamamthanh(Properties.Resources._30pt);
        static hamamthanh bonmuoiphantram = new hamamthanh(Properties.Resources._40pt);
        static hamamthanh nammuoiphantram = new hamamthanh(Properties.Resources._50pt);
        public static hamamthanh _10phantram = new hamamthanh(Properties.Resources._10pt);
        public static hamamthanh _20phantram = new hamamthanh(Properties.Resources._20pt);

        static hamamthanh amDonggia = new hamamthanh(Properties.Resources.Donggia);
        public static hamamthanh _9nghin = new hamamthanh(Properties.Resources._9);
        public static hamamthanh _29nghin = new hamamthanh(Properties.Resources._29);
        public static hamamthanh _49nghin = new hamamthanh(Properties.Resources._49);
        public static hamamthanh _79nghin = new hamamthanh(Properties.Resources._79);
        public static hamamthanh _99nghin = new hamamthanh(Properties.Resources._99);
        public static hamamthanh _119nghin = new hamamthanh(Properties.Resources._119);
        public static hamamthanh _149nghin = new hamamthanh(Properties.Resources._149);
        public static hamamthanh _199nghin = new hamamthanh(Properties.Resources._199);
        public static hamamthanh _249nghin = new hamamthanh(Properties.Resources._249);
        public static hamamthanh _299nghin = new hamamthanh(Properties.Resources._299);
        public static hamamthanh _349nghin = new hamamthanh(Properties.Resources._349);
        public static hamamthanh _369nghin = new hamamthanh(Properties.Resources._369);
        public static hamamthanh _549nghin = new hamamthanh(Properties.Resources._549);
        public static hamamthanh _599nghin = new hamamthanh(Properties.Resources._599);

        public static void phat30()
        {
            if (chayhaykhongchay)
            {

                bamuoiphantram.Play();
            }
        }
        public static void phat40()
        {
            if (chayhaykhongchay)
            {

                bonmuoiphantram.Play();
            }
        }
        public static void phat50()
        {
            if (chayhaykhongchay)
            {

                nammuoiphantram.Play();
            }
        }
        public static void phatDonggia()
        {
            if (chayhaykhongchay)
            {

                amDonggia.Play();
            }
        }
    }
}
