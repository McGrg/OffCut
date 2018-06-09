using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffCut
{
    class Result
    {
        public static int Calc (Rectangle big, Rectangle small)
        {
            int first = big.Lenght / small.Lenght;
            int second = big.Width / small.Width;
            int third = 0;
            if (big.Lenght % small.Lenght >= small.Width)
            {
                third = ((big.Lenght % small.Lenght) / small.Width) * (big.Width / small.Lenght);
            }
            int res1 = first * second + third;

            first = big.Lenght / small.Width;
            second = big.Width / small.Lenght;
            third = 0;
            if (big.Width % small.Lenght >= small.Width)
            {
                third = ((big.Width % small.Lenght) / small.Width) * (big.Lenght / small.Lenght);
            }
            int res2 = first * second + third;
            return Math.Max(res1, res2);
        }
    }
}
