using Kz.DataStructures;

namespace Kz.Geometry2d.Primitives
{
    public class RegularPolygon : Polygon
    {
        public float Radius { get; init; }

        public RegularPolygon(Point center, int numSides, float radius)
        {
            Radius = radius;
            BuildRegularPolygon(center, numSides, radius);
        }

        public RegularPolygon(float centerX, float centerY, int numSides, float radius)
        {
            Radius = radius;
            BuildRegularPolygon(new Point(centerX, centerY), numSides, radius);
        }

        public void BuildRegularPolygon(Point center, int numSides, float radius)
        {
            Vertices = new List<Point>();

            for (var i = 0; i < numSides; i++)
            {
                var angle = Consts.PI2 * ((float)i / numSides);

                var x = center.X + radius * MathF.Cos(angle);
                var y = center.Y + radius * MathF.Sin(angle);

                Vertices.Add(new Point(x, y));
            }
        }
    }
}