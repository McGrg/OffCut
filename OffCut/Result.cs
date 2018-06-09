﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffCut
{
    class Result
    {

        //
        //Расчет количества изделий, 2 варианта размещения изделий на сырье вдоль и поперек
        //
        public static int Calc (Rectangle big, Rectangle small)
        {
            //
            //Расчет размещения вдоль
            //
            int first = big.Lenght / small.Lenght;
            int second = big.Width / small.Width;
            int third = 0;
            //
            //Расчет возможности раскроя остатков
            //
            if (big.Lenght % small.Lenght >= small.Width)
            {
                third = ((big.Lenght % small.Lenght) / small.Width) * (big.Width / small.Lenght);
            }
            int res1 = first * second + third;
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
            int res2 = first * second + third;
            return Math.Max(res1, res2);
        }
    }
}
