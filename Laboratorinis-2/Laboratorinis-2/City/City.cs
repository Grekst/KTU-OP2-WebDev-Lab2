using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_2
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public City()
        {
            Name = null;
            Population = 0;
        }

        public override string ToString()
        {
            return string.Format("{0} (pop. {1})", Name, Population);
        }

        public override bool Equals(object obj)
        {
            return obj is City city && Name == city.Name;
        }
    }
}