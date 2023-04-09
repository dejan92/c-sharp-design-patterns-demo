using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    public class BathroomBuilder : IRoomBuilder
    {
        private Room _room = new Room();

        public void SetSize(int size)
        {
            _room.Size = size;
        }

        public void SetColor(string color)
        {
            _room.Color = color;
        }

        public void SetFlooring(string flooring)
        {
            _room.Flooring = flooring;
        }

        public void SetLighting(string lighting)
        {
            _room.Lighting = lighting;
        }

        public void AddOptionalFeature(string feature)
        {
            _room.OptionalFeatures.Add(feature);
        }

        public Room GetResult()
        {
            return _room;
        }
    }

}
