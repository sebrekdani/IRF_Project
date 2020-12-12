using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project
{
    public class Player
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Months Month { get; set; }
        public int Day { get; set; }
        public string Post { get; set; }
        public int Goal { get; set; }
        public int Assist { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public bool Injured { get; set; }
        public decimal Average { get; set; }
    }
}
