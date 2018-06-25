using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffCut
{
    class Calculation
    {

        //
        //Расчет количества изделий, 2 варианта размещения изделий на сырье вдоль и поперек
        //
        public static int Calc (Sheet big, Sheet small)
        {
            //
            //Расчет размещения вдоль
            //
            int first = (int)Math.Truncate(big.Lenght / small.Lenght);
            int second = (int)Math.Truncate(big.Width / small.Width);
            double third = 0;
            //
            //Расчет возможности раскроя остатков
            //
            if (big.Lenght % small.Lenght >= small.Width)
            {
                third = Math.Truncate((big.Lenght % small.Lenght) / small.Width) * (big.Width / small.Lenght));
            }
            double res1 = first * second + third;
            //
            //Расчет размещения поперек
            //
            first = big.Lenght / small.Width;
            second = big.Width / small.Lenght;
            third = 0;
            //
            //Расчет возможности раскроя остатков
            //
            if (big.Width % small.Lenght >= small.Width)
            {
                third = ((big.Width % small.Lenght) / small.Width) * (big.Lenght / small.Lenght);
            }
            double res2 = first * second + third;
            return Math.Max(res1, res2);
        }
    }
}
