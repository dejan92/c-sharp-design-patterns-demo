using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    public interface IRoomBuilder
    {
        void SetSize(int size);
        void SetColor(string color);
        void SetFlooring(string flooring);
        void SetLighting(string lighting);
        void AddOptionalFeature(string feature);
        Room GetResult();
    }
}
