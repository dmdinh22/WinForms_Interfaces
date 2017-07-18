using System;

namespace Polygons.Library
{
    // interfaces are implemented not inherited
    public class Octagon : Object,  IRegularPolygon
    {
        // implementation of the two properties
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        // constructor to populate the properties
        public Octagon(int length)
        {
            NumberOfSides = 8;
            SideLength = length;
        }

        // the methods - provide method bodies because we don't have a parent class that provides them
        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength * (2 + 2 * Math.Sqrt(2));
        }
    }
}
