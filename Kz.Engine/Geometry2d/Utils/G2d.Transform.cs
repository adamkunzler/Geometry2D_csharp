using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Utils
{
    public static partial class G2d
    {
        #region TRANSLATE

        public static void Translate(IShape lhs, Vector2f rhs)
        {
            switch (lhs)
            {
                case Vector2f x: Translate(x, rhs); break;
                case Line x: Translate(x, rhs); break;
                case Rectangle x: Translate(x, rhs); break;
                case Circle x: Translate(x, rhs); break;
                case Triangle x: Translate(x, rhs); break;
                case Polygon x: Translate(x, rhs); break;
                case Ray x: Translate(x, rhs); break;
                case Ellipse x: Translate(x, rhs); break;
            };
        }

        public static void Translate(Vector2f lhs, Vector2f rhs)
        {
            lhs.X += rhs.X;
            lhs.Y += rhs.Y;
        }

        public static void Translate(Line lhs, Vector2f rhs)
        {
            lhs.Start.X += rhs.X;
            lhs.Start.Y += rhs.Y;

            lhs.End.X += rhs.Y;
            lhs.End.Y += rhs.Y;
        }

        public static void Translate(Rectangle lhs, Vector2f rhs)
        {
            lhs.Position.X += rhs.X;
            lhs.Position.Y += rhs.Y;
        }

        public static void Translate(Circle lhs, Vector2f rhs)
        {
            lhs.Origin.X += rhs.X;
            lhs.Origin.Y += rhs.Y;
        }

        public static void Translate(Triangle lhs, Vector2f rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Polygon lhs, Vector2f rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Ray lhs, Vector2f rhs)
        {
            lhs.Origin.X += rhs.X;
            lhs.Origin.Y += rhs.Y;
        }

        public static void Translate(Ellipse lhs, Vector2f rhs)
        {
            lhs.Origin.X += rhs.X;
            lhs.Origin.Y += rhs.Y;
        }

        private static void Translate(IList<Vector2f> vertices, Vector2f rhs)
        {
            for (var i = 0; i < vertices.Count(); i++)
            {
                var translated = new Vector2f(vertices[i].X + rhs.X, vertices[i].Y + rhs.Y);
                vertices[i] = translated;                
            }
        }

        #endregion TRANSLATE

        #region ROTATE around shape origin

        public static void Rotate(IShape lhs, float theta)
        {
            switch (lhs)
            {
                case Vector2f x: Rotate(x, theta); break;
                case Line x: Rotate(x, theta); break;
                case Rectangle x: Rotate(x, theta); break;
                case Circle x: Rotate(x, theta); break;
                case Triangle x: Rotate(x, theta); break;
                case Polygon x: Rotate(x, theta); break;
                case Ray x: Rotate(x, theta); break;
                case Ellipse x: Rotate(x, theta); break;
            };
        }

        /// <summary>
        /// doesn't do anything
        /// </summary>
        public static void Rotate(Vector2f lhs, float theta)
        {
            // do nothing
        }

        /// <summary>
        /// rotate a line around it's center
        /// </summary>
        public static void Rotate(Line lhs, float theta)
        {
            var middle = lhs.Middle();
            lhs.Start = RotatePoint(lhs.Start, middle, theta);
            lhs.End = RotatePoint(lhs.End, middle, theta);
        }

        /// <summary>
        /// can't rotate a rectangle...make a PolyRectangle instead
        /// </summary>
        public static void Rotate(Rectangle lhs, float theta)
        {
            // do nothing
        }

        /// <summary>
        /// doesn't do anything
        /// </summary>
        public static void Rotate(Circle lhs, float theta)
        {
            // do nothing
        }

        /// <summary>
        /// rotate a triangle around it's centroid
        /// </summary>
        public static void Rotate(Triangle lhs, float theta)
        {
            var centroid = lhs.Centroid();
            lhs.Vertices[0] = RotatePoint(lhs.Vertices[0], centroid, theta);
            lhs.Vertices[1] = RotatePoint(lhs.Vertices[1], centroid, theta);
            lhs.Vertices[2] = RotatePoint(lhs.Vertices[2], centroid, theta);
        }

        /// <summary>
        /// rotate a polygon around it's center
        /// </summary>
        public static void Rotate(Polygon lhs, float theta)
        {
            RotatePoints(lhs.Vertices, lhs.Center(), theta);
        }

        /// <summary>
        /// rotates the direction of a ray
        /// </summary>
        public static void Rotate(Ray lhs, float theta)
        {
            var v = new Vector2f(1.0f, theta);
            lhs.Direction = v.ToCartesian();
        }

        /// <summary>
        /// rotate an ellipse around it's center
        /// </summary>
        public static void Rotate(Ellipse lhs, float theta)
        {
            // TODO
        }

        private static void RotatePoints(List<Vector2f> points, Vector2f origin, float theta)
        {
            for (var i = 0; i < points.Count; i++)
            {
                points[i] = RotatePoint(points[i], origin, theta);
            }
        }

        private static Vector2f RotatePoint(Vector2f point, Vector2f origin, float theta)
        {
            // translate point relative to (0,0)
            var translated = point - origin;

            // rotate point
            var rotated = new Vector2f();
            rotated.X = translated.X * MathF.Cos(theta) - translated.Y * MathF.Sin(theta);
            rotated.Y = translated.X * MathF.Sin(theta) + translated.Y * MathF.Cos(theta);

            // translate back to origin
            var finalPoint = rotated + origin;
            return finalPoint;
        }

        #endregion ROTATE around shape origin

        #region ROTATE around arbitrary origin

        /// <summary>
        /// Rotate a shape around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>
        public static void Rotate(IShape lhs, Vector2f origin, float theta, bool counterRotate)
        {
            switch (lhs)
            {
                case Vector2f x: Rotate(x, origin, theta); break;
                case Line x: Rotate(x, origin, theta, counterRotate); break;
                case Rectangle x: Rotate(x, origin, theta); break;
                case Circle x: Rotate(x, origin, theta); break;
                case Triangle x: Rotate(x, origin, theta, counterRotate); break;
                case Polygon x: Rotate(x, origin, theta, counterRotate); break;
                case Ray x: Rotate(x, origin, theta); break;
                case Ellipse x: Rotate(x, origin, theta); break;
            };
        }

        /// <summary>
        /// rotate a point around an origin
        /// </summary>
        public static void Rotate(Vector2f lhs, Vector2f origin, float theta)
        {
            lhs = RotatePoint(lhs, origin, theta);
        }

        /// <summary>
        /// rotate a line around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>
        public static void Rotate(Line lhs, Vector2f origin, float theta, bool counterRotate)
        {
            lhs.Start = RotatePoint(lhs.Start, origin, theta);
            lhs.End = RotatePoint(lhs.End, origin, theta);

            if (counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// rotate a rectangle around an origin
        /// </summary>
        public static void Rotate(Rectangle lhs, Vector2f origin, float theta)
        {
            lhs.Position = RotatePoint(lhs.Position, origin, theta);
        }

        /// <summary>
        /// rotate a circle around an origin
        /// </summary>
        public static void Rotate(Circle lhs, Vector2f origin, float theta)
        {
            lhs.Origin = RotatePoint(lhs.Origin, origin, theta);
        }

        /// <summary>
        /// rotate a triangle around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>
        public static void Rotate(Triangle lhs, Vector2f origin, float theta, bool counterRotate)
        {
            lhs.Vertices[0] = RotatePoint(lhs.Vertices[0], origin, theta);
            lhs.Vertices[1] = RotatePoint(lhs.Vertices[1], origin, theta);
            lhs.Vertices[2] = RotatePoint(lhs.Vertices[2], origin, theta);

            if (counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// rotate a polygon around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>
        public static void Rotate(Polygon lhs, Vector2f origin, float theta, bool counterRotate)
        {
            RotatePoints(lhs.Vertices, origin, theta);

            if (counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// Rotate a ray around an origin
        /// </summary>
        public static void Rotate(Ray lhs, Vector2f origin, float theta)
        {
            // TODO ?does this make sense?
        }

        public static void Rotate(Ellipse lhs, Vector2f origin, float theta)
        {
            lhs.Origin = RotatePoint(lhs.Origin, origin, theta);
        }

        #endregion ROTATE around arbitrary origin

        #region SCALE

        public static void Scale(IShape lhs, Vector2f amount)
        {
            switch (lhs)
            {
                case Vector2f x: Scale(x, amount); break;
                case Line x: Scale(x, amount); break;
                case Rectangle x: Scale(x, amount); break;
                case Circle x: Scale(x, amount); break;
                case Triangle x: Scale(x, amount); break;
                case Polygon x: Scale(x, amount); break;
                case Ellipse x: Scale(x, amount); break;
            };
        }

        /// <summary>
        /// doesn't do anything
        /// </summary>
        public static void Scale(Vector2f lhs, Vector2f amount)
        {
            // do nothing
        }

        /// <summary>
        /// scale a line
        /// </summary>
        public static void Scale(Line lhs, Vector2f amount)
        {
            var middle = lhs.Middle();
            lhs.Start = ScalePoint(lhs.Start, middle, amount);
            lhs.End = ScalePoint(lhs.End, middle, amount);
        }

        /// <summary>
        /// scale a rectangle
        /// </summary>
        public static void Scale(Rectangle lhs, Vector2f amount)
        {
            // scale top-left corner
            lhs.Position = ScalePoint(lhs.Position, lhs.Middle, amount);

            // scale width/height
            lhs.Size *= amount;
        }

        /// <summary>
        /// scale a circle's radius (uses amount.X)
        /// </summary>
        public static void Scale(Circle lhs, Vector2f amount)
        {
            lhs.Radius *= amount.X;
        }

        /// <summary>
        /// scale a triangle
        /// </summary>
        public static void Scale(Triangle lhs, Vector2f amount)
        {
            lhs.Vertices[0] = ScalePoint(lhs.Vertices[0], lhs.Centroid(), amount);
            lhs.Vertices[1] = ScalePoint(lhs.Vertices[1], lhs.Centroid(), amount);
            lhs.Vertices[2] = ScalePoint(lhs.Vertices[2], lhs.Centroid(), amount);
        }

        /// <summary>
        /// scale a polygon
        /// </summary>
        public static void Scale(Polygon lhs, Vector2f amount)
        {
            ScalePoints(lhs.Vertices, lhs.Center(), amount);
        }

        public static void Scale(Ellipse lhs, Vector2f amount)
        {
            lhs.A *= amount.X;
            lhs.B *= amount.Y;
        }

        /// <summary>
        /// Scale a list of points around an origin
        /// </summary>
        private static void ScalePoints(List<Vector2f> points, Vector2f origin, Vector2f amount)
        {
            for (var i = 0; i < points.Count; i++)
            {
                points[i] = ScalePoint(points[i], origin, amount);
            }
        }

        /// <summary>
        /// Scale a point around an origin
        /// </summary>
        private static Vector2f ScalePoint(Vector2f point, Vector2f origin, Vector2f amount)
        {
            var translated = point - origin;
            var scaled = translated * amount;
            var finalPoint = scaled + origin;
            return finalPoint;
        }

        #endregion SCALE
    }
}