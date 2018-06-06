using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffCut
{
    class Detail
    {
        private double width, lenght, thikness, weight, overmeasure;
        private string name;

        public double Width
        {
            get { return width; }
        }
        public double Lenght
        {
            get { return lenght; }
        }
        public double Thikness
        {
            get { return thikness; }
        }
        public double Weight
        {
            get { return weight; }
        }
        public string Name
        {
            get { return name; }
        }
        private double SetWeight()
        {
            return (width / 1000) * (lenght / 1000) * (thikness / 1000) * 7850;
        }

        public Detail(double w, double l, double t, string n = null)
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
        private bool Permission(double w, double l, double t)
        {
            return true;
        }
    }
    
}
