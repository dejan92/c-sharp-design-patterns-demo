using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    public class RoomDirector
    {
        private IRoomBuilder _builder;

        public RoomDirector(IRoomBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructRoom(int size, string color, string flooring, string lighting, string[] optionalFeatures)
        {
            _builder.SetSize(size);
            _builder.SetColor(color);
            _builder.SetFlooring(flooring);
            _builder.SetLighting(lighting);
            foreach (var optionalFeature in optionalFeatures)
            {
                _builder.AddOptionalFeature(optionalFeature);
            }
        }
    }

}
