using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffCut
{
    class Sheet
    {
        private double width, lenght, thikness;
        private double weight;
        private string name;

        public double Width { get => width; set => width = value; }

        public double Lenght { get => lenght; set => lenght = value; }

        public double Thikness { get => thikness; set => thikness = value; }

        public double Weight
        {
            get { return weight; }
        }
        public string Name { get => name; set => name = value; }

        private double SetWeight()
        {
            return (width / 1000) * (lenght / 1000) * (thikness / 1000) * 7850;
        }

        public Sheet (double w, double l, double t, string n=null)
        {
            if (Permission(w, l, t))
            {
                this.width = w;
                this.lenght = l;
                this.thikness = t;
                this.name = n;
                this.weight = this.SetWeight();
            }
        }

        private bool Permission (double w, double l, double t)
        {
            return true;
        }
    }
}
