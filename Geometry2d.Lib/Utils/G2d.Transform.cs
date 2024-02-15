using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region TRANSLATE

        public static void Translate(IShape lhs, Vector2 rhs)
        {
            switch (lhs)
            {
                case Vector2 x: Translate(x, rhs); break;                
                case Line x: Translate(x, rhs); break;
                case Rectangle x: Translate(x, rhs); break;
                case Circle x: Translate(x, rhs); break;
                case Triangle x: Translate(x, rhs); break;
                case Polygon x: Translate(x, rhs); break;
                case Ray x: Translate(x, rhs); break;

            };
        }

        public static void Translate(Vector2 lhs, Vector2 rhs)
        {
            lhs += rhs;
        }

        public static void Translate(Line lhs, Vector2 rhs)
        {
            lhs.Start += rhs;
            lhs.End += rhs;
        }

        public static void Translate(Rectangle lhs, Vector2 rhs)
        {
            lhs.Position += rhs;
        }

        public static void Translate(Circle lhs, Vector2 rhs)
        {
            lhs.Origin += rhs;
        }

        public static void Translate(Triangle lhs, Vector2 rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Polygon lhs, Vector2 rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Ray lhs, Vector2 rhs)
        {
            lhs.Origin += rhs;
        }

        private static void Translate(IList<Vector2> vertices, Vector2 rhs)
        {
            for(var i = 0; i < vertices.Count(); i++)
            {
                vertices[i] += rhs;
            }
        }

        #endregion TRANSLATE

        #region ROTATE around shape origin

        public static void Rotate(IShape lhs, float theta)
        {
            switch (lhs)
            {
                case Vector2 x: Rotate(x, theta); break;
                case Line x: Rotate(x, theta); break;
                case Rectangle x: Rotate(x, theta); break;
                case Circle x: Rotate(x, theta); break;
                case Triangle x: Rotate(x, theta); break;
                case Polygon x: Rotate(x, theta); break;
                case Ray x: Rotate(x, theta); break;

            };
        }

        /// <summary>
        /// doesn't do anything
        /// </summary>        
        public static void Rotate(Vector2 lhs, float theta)
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
            var v = new Vector2(1.0f, theta);
            lhs.Direction = v.ToCartesian();
        }

        private static void RotatePoints(List<Vector2> points, Vector2 origin, float theta)
        {
            for(var i = 0; i < points.Count; i++)
            {
                points[i] = RotatePoint(points[i], origin, theta);
            }
        }

        private static Vector2 RotatePoint(Vector2 point, Vector2 origin, float theta)
        {
            // translate point relative to (0,0)
            var translated = point - origin;

            // rotate point
            var rotated = new Vector2();
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
        public static void Rotate(IShape lhs, Vector2 origin, float theta, bool counterRotate)
        {
            switch (lhs)
            {
                case Vector2 x: Rotate(x, origin, theta); break;
                case Line x: Rotate(x, origin, theta, counterRotate); break;
                case Rectangle x: Rotate(x, origin, theta); break;
                case Circle x: Rotate(x, origin, theta); break;
                case Triangle x: Rotate(x, origin, theta, counterRotate); break;
                case Polygon x: Rotate(x, origin, theta, counterRotate); break;
                case Ray x: Rotate(x, origin, theta); break;

            };
        }

        /// <summary>
        /// rotate a point around an origin
        /// </summary>        
        public static void Rotate(Vector2 lhs, Vector2 origin, float theta)
        {
            lhs = RotatePoint(lhs, origin, theta);
        }

        /// <summary>
        /// rotate a line around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>        
        public static void Rotate(Line lhs, Vector2 origin, float theta, bool counterRotate)
        {
            lhs.Start = RotatePoint(lhs.Start, origin, theta);
            lhs.End = RotatePoint(lhs.End, origin, theta);

            if(counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// rotate a rectangle around an origin
        /// </summary>        
        public static void Rotate(Rectangle lhs, Vector2 origin, float theta)
        {
            lhs.Position = RotatePoint(lhs.Position, origin, theta);
        }

        /// <summary>
        /// rotate a circle around an origin
        /// </summary>        
        public static void Rotate(Circle lhs, Vector2 origin, float theta)
        {
            lhs.Origin = RotatePoint(lhs.Origin, origin, theta);
        }

        /// <summary>
        /// rotate a triangle around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>        
        public static void Rotate(Triangle lhs, Vector2 origin, float theta, bool counterRotate)
        {            
            lhs.Vertices[0] = RotatePoint(lhs.Vertices[0], origin, theta);
            lhs.Vertices[1] = RotatePoint(lhs.Vertices[1], origin, theta);
            lhs.Vertices[2] = RotatePoint(lhs.Vertices[2], origin, theta);

            if (counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// rotate a polygon around an origin. if counterRotate is true, rotate the shape -theta around the shape center.
        /// </summary>        
        public static void Rotate(Polygon lhs, Vector2 origin, float theta, bool counterRotate)
        {
            RotatePoints(lhs.Vertices, origin, theta);

            if (counterRotate) Rotate(lhs, -theta);
        }

        /// <summary>
        /// doesn't do anything
        /// </summary>        
        public static void Rotate(Ray lhs, Vector2 origin, float theta)
        {            
            // do nothing
        }        

        #endregion ROTATE around arbitrary origin

        #region SCALE

        public static void Scale(IShape lhs)
        {
            switch (lhs)
            {
                case Vector2 x: Scale(x); break;
                case Line x: Scale(x); break;
                case Rectangle x: Scale(x); break;
                case Circle x: Scale(x); break;
                case Triangle x: Scale(x); break;
                case Polygon x: Scale(x); break;               
            };
        }

        public static void Scale(Vector2 lhs)
        {

        }

        public static void Scale(Line lhs)
        {

        }

        public static void Scale(Rectangle lhs)
        {

        }

        public static void Scale(Circle lhs)
        {

        }

        public static void Scale(Triangle lhs)
        {

        }

        public static void Scale(Polygon lhs)
        {

        }

        #endregion SCALE
    }
}
