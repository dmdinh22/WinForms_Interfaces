using System;

namespace Polygons.Library
{
    public class ConcreteRegularPolygon
    {
        // automatic properties
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public ConcreteRegularPolygon(int sides, int length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        public virtual double GetArea()
        {
            // implementation depends on the polygon
            // child class will have to determine implementation
            throw new NotImplementedException();
        }
    }
}
