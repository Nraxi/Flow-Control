using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Flow_Control
{
    internal class Model
    {
        public int Age { get; set; }
        public int Price { get; set; }
        public int Antal { get; set; }

        public Model(int age, int price, int antal) { 
           Age = age;
           Antal = antal; 
           Price = price;
        }
        public override string ToString()
        {
            return $"Age: {Age} Antal: {Antal} Price: {Price}";
        }

    }
   
}
