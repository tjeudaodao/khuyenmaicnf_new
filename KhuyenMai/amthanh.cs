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
        static hamamthanh bamuoiphantram = new hamamthanh(Properties.Resources._30);
        static hamamthanh bonmuoiphantram = new hamamthanh(Properties.Resources._40);
        static hamamthanh nammuoiphantram = new hamamthanh(Properties.Resources._50);

        static hamamthanh amDonggia = new hamamthanh(Properties.Resources.Donggia);

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
