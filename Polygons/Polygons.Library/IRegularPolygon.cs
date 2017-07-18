
namespace Polygons.Library
{
    // convention is to start interface with an I 
    // interfaces are only allowed to have declarations, the parts of the contract, and NO implementation
    public interface IRegularPolygon
    {
        int NumberOfSides { get; set; }
        int SideLength { get; set; }

        double GetPerimeter();
        double GetArea();
    }
}
