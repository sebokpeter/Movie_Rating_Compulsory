using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rating_Compulsory
{
    public class Review
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}