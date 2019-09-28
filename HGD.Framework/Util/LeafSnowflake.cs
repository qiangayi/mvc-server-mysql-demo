using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HGD.Framework.Util
{
    public class LeafSnowflake
    {
        private static int seq16 = 0;
        private static long ms16 = 0;
        private static int seq22 = 0;
        private static long ms22 = 0;
        private static object obj16 = new object();
        private static object obj22 = new object();

        public static Int64 getID(int workID)
        {
            DateTime fromYear = new DateTime(2000, 1, 1);

            long ms = 0;
            int theSeq = 0;
            try
            {
                Monitor.Enter(obj16);

                ms = (DateTime.Now.Ticks - fromYear.Ticks) / 10000;

                if (seq16 >= 0xffff)
                    seq16 = 0;

                if (ms16 != ms)
                {
                    seq16 = 0;
                    ms16 = ms;
                }

                theSeq = ++seq16;
            }
            finally
            {
                //
                Monitor.Exit(obj16);
            }

            return ((0x1ffffffffff & ms) << 22) + ((workID & 0x03f) << 16) + (theSeq & 0xffff);
        }

        public static Int64 getID()
        {
            DateTime fromYear = new DateTime(2000, 1, 1);

            long ms = 0;
            int theSeq = 0;
            try
            {
                Monitor.Enter(obj22);

                ms = (DateTime.Now.Ticks - fromYear.Ticks) / 10000;

                if (seq22 >= 0x3fffff)
                    seq22 = 0;

                if (ms22 != ms)
                {
                    seq22 = 0;
                    ms22 = ms;
                }

                theSeq = ++seq22;
            }
            finally
            {
                //
                Monitor.Exit(obj22);
            }

            return ((0x1ffffffffff & ms) << 22) + (theSeq & 0x3fffff);
        }
    }
}
