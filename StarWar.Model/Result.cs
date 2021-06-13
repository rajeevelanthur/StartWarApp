using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Model
{
    public class Result <T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Results { get; set; }
    }
}
