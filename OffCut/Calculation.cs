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
            int first = (int)Math.Truncate(big.Lenght / small.Lenght); //Math.Truncate отбрасывает остаток от деления и преобразуем в int
            int second = (int)Math.Truncate(big.Width / small.Width);
            int third = 0;
            //
            //Расчет возможности раскроя остатков
            //
            if (big.Lenght % small.Lenght >= small.Width) // Проверка на возможность размещения деталей на обрезке 
            {
                third = (int)Math.Truncate(Math.Truncate(((big.Lenght % small.Lenght) / small.Width)) * Math.Truncate((big.Width / small.Lenght)));
            }
            int res1 = first * second + third;
            //
            //Расчет размещения поперек
            //
            first = (int)Math.Truncate(big.Lenght / small.Width);
            second = (int)Math.Truncate(big.Width / small.Lenght);
            //
            //Расчет возможности раскроя остатков
            //
            if (big.Width % small.Lenght >= small.Width)
            {
                third = (int)Math.Truncate(Math.Truncate(((big.Width % small.Lenght) / small.Width)) * Math.Truncate((big.Lenght / small.Lenght)));
            }
            int res2 = first * second + third;
            return Math.Max(res1, res2);
        }
    }
}
