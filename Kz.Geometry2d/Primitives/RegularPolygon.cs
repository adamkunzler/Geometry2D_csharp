using Kz.DataStructures;

namespace Geometry2d.Lib.Primitives
{
    public class RegularPolygon : Polygon
    {
        public float Radius { get; init; }

        public RegularPolygon(Vector2f center, int numSides, float radius)
        {
            Radius = radius;
            BuildRegularPolygon(center, numSides, radius);
        }

        public RegularPolygon(float centerX, float centerY, int numSides, float radius)
        {
            Radius = radius;
            BuildRegularPolygon(new Vector2f(centerX, centerY), numSides, radius);
        }

        public void BuildRegularPolygon(Vector2f center, int numSides, float radius)
        {
            Vertices = new List<Vector2f>();

            for (var i = 0; i < numSides; i++)
            {
                var angle = (MathF.PI * 2.0f) * ((float)i / numSides);

                var x = center.X + radius * MathF.Cos(angle);
                var y = center.Y + radius * MathF.Sin(angle);

                Vertices.Add(new Vector2f(x, y));
            }
        }
    }
}