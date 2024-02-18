using Kz.Geometry2d.Primitives;
using Geometry2d.Lib.Utils;
using Kz.DataStructures;
using Raylib_cs;
using Ray = Kz.Geometry2d.Primitives.Ray;
using Rectangle = Kz.Geometry2d.Primitives.Rectangle;

namespace Geometry2d.RayLib
{
    public static class Gfx
    {
        public static void DrawShape(IShape shape, Color color, bool fill = false)
        {
            switch (shape)
            {
                case Vector2f v: DrawPoint(v, color); break;
                case Line l: DrawLine(l, color); break;
                case Rectangle r: DrawRectangle(r, color, fill); break;
                case Circle c: DrawCircle(c, color, fill); break;
                case Triangle t: DrawTriangle(t, color, fill); break;
                case Polygon poly: DrawPolygon(poly, color, fill); break;
                case Ray ray: DrawRay(ray, color); break;
                case Ellipse e: DrawEllipse(e, color, fill); break;
            }
        }

        public static void DrawPoint(Vector2f p, Color color)
        {
            Raylib.DrawPixel((int)p.X, (int)p.Y, color);
        }

        public static void DrawLine(Line line, Color color)
        {
            Raylib.DrawLine((int)line.Start.X, (int)line.Start.Y, (int)line.End.X, (int)line.End.Y, color);
        }

        public static void DrawRay(Ray ray, Color color)
        {
            var end = ray.Origin + ray.Direction * 10000.0f;
            Raylib.DrawLine((int)ray.Origin.X, (int)ray.Origin.Y, (int)end.X, (int)end.Y, color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color, bool fill = false)
        {
            if (fill)
            {
                Raylib.DrawRectangle((int)rectangle.Position.X, (int)rectangle.Position.Y, (int)rectangle.Size.Width, (int)rectangle.Size.Height, color);
            }
            else
            {
                Raylib.DrawRectangleLines((int)rectangle.Position.X, (int)rectangle.Position.Y, (int)rectangle.Size.Width, (int)rectangle.Size.Height, color);
            }
        }

        public static void DrawCircle(Circle circle, Color color, bool fill = false)
        {
            if (fill)
            {
                Raylib.DrawCircle((int)circle.Origin.X, (int)circle.Origin.Y, circle.Radius, color);
            }
            else
            {
                Raylib.DrawCircleLines((int)circle.Origin.X, (int)circle.Origin.Y, circle.Radius, color);
            }
        }

        public static void DrawTriangle(Triangle triangle, Color color, bool fill = false)
        {
            if (fill)
            {
                Raylib.DrawTriangle
                (
                    new System.Numerics.Vector2(triangle.Vertices[0].X, triangle.Vertices[0].Y),
                    new System.Numerics.Vector2(triangle.Vertices[1].X, triangle.Vertices[1].Y),
                    new System.Numerics.Vector2(triangle.Vertices[2].X, triangle.Vertices[2].Y),
                    color
                );
            }
            else
            {
                Raylib.DrawTriangleLines
                (
                    new System.Numerics.Vector2(triangle.Vertices[0].X, triangle.Vertices[0].Y),
                    new System.Numerics.Vector2(triangle.Vertices[1].X, triangle.Vertices[1].Y),
                    new System.Numerics.Vector2(triangle.Vertices[2].X, triangle.Vertices[2].Y),
                    color
                );
            }
        }

        public static void DrawPolygon(Polygon polygon, Color color, bool fill = false)
        {
            if (fill)
            {
                throw new NotImplementedException("DrawPolygon fill=true not implemented");
            }
            else
            {
                for (var i = 0; i < polygon.Vertices.Count; i++)
                {
                    DrawLine(polygon.Side(i), color);
                }
            }
        }

        public static void DrawRayReflections(Ray ray, List<ReflectData> reflectData, Color color)
        {
            if (reflectData.Count == 0)
            {
                DrawRay(ray, color);
                return;
            }

            // line from ray origin to first reflection
            DrawLine(new Line(ray.Origin, reflectData[0].Intersection), Color.Red);

            // draw all middle reflections as lines
            for (var i = 1; i < reflectData.Count; i++)
            {
                DrawLine(new Line(reflectData[i - 1].Intersection, reflectData[i].Intersection), Color.Red);
            }

            // draw last reflection as a ray
            var index = reflectData.Count - 1;
            var tempRay = new Ray(reflectData[index].Intersection, reflectData[index].Reflection);
            DrawRay(tempRay, Color.Red);
        }

        public static void DrawEllipse(Ellipse ellipse, Color color, bool fill = false)
        {
            if (fill)
            {
                Raylib.DrawEllipse((int)ellipse.Origin.X, (int)ellipse.Origin.Y, ellipse.H, ellipse.V, color);
            }
            else
            {
                //Raylib.DrawEllipseLines((int)ellipse.Origin.X, (int)ellipse.Origin.Y, ellipse.H, ellipse.V, color);
                DrawRotatedEllipse(ellipse, color);
            }
        }

        /// <summary>
        /// Update this to render ellipse to texture, rotate the texture, then render texture
        /// </summary>
        private static void DrawRotatedEllipse(Ellipse ellipse, Color color)
        {
            var centerX = ellipse.Origin.X;
            var centerY = ellipse.Origin.Y;
            var radiusX = ellipse.SemiMajorAxis;
            var radiusY = ellipse.SemiMinorAxis;

            const int segments = 360; // Increase for smoother ellipse

            for (int i = 0; i < segments; i++)
            {
                var angle = i * (2.0f * MathF.PI / segments);
                var x = centerX + radiusX * MathF.Cos(angle);
                var y = centerY + radiusY * MathF.Sin(angle);

                // Rotate point
                //var rotatedX = MathF.Cos(rotation) * (x - centerX) - MathF.Sin(rotation) * (y - centerY) + centerX;
                //var rotatedY = MathF.Sin(rotation) * (x - centerX) + MathF.Cos(rotation) * (y - centerY) + centerY;

                // Draw point (or use lines for smoother ellipse)
                Raylib.DrawPixel((int)x, (int)y, color);
            }
        }
    }
}