using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    public class Room
    {
        public int Size { get; set; }
        public string Color { get; set; }
        public string Flooring { get; set; }
        public string Lighting { get; set; }
        public List<string> OptionalFeatures { get; set; } = new List<string>();
    }
}
