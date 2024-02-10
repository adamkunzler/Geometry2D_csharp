using Geometry2d.Lib.Extensions;
using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region [Shape] CLOSEST Point

        /// <summary>
        /// Return the closest point on a point to a point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Vector2 rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a ray to a ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Vector2 rhs)
        {
            return rhs;
        }

        #endregion [Shape] CLOSEST Point

        #region [Shape] CLOSEST Line

        /// <summary>
        /// Return the closest point on a Line to a point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Line rhs)
        {
            var ab = rhs.End - rhs.Start;
            var ap = lhs - rhs.Start;

            var abApDot = ab.Dot(ap);
            var abAbDot = ab.Dot(ab);
            var t = abApDot / abAbDot;

            if (t < 0) return rhs.Start;
            if (t > 1) return rhs.End;

            var closestX = rhs.Start.X + t * ab.X;
            var closestY = rhs.Start.Y + t * ab.Y;
            return new Vector2(closestX, closestY);
        }

        /// <summary>
        /// Return the closest point on a Line to a line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Line to a rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Line to a circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Line to a triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Line to a polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Line to a ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Line rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Line

        #region [Shape] CLOSEST Rectangle

        /// <summary>
        /// Return the closest point on a Rectangle to a Point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Rectangle rhs)
        {
            var closest = Closest(lhs, rhs.Sides);
            return closest.Point;            
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Rectangle rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Rectangle

        #region [Shape] CLOSEST Circle

        /// <summary>
        /// Return the closest point on a Circle to a Point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Circle rhs)
        {            
            var v = (lhs - rhs.Position).Normal() * rhs.Radius;
            var closest = rhs.Position + v;
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Circle to a Line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Circle to a Rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Circle to a Circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Circle to a Triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Circle to a Polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Circle to a Ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Circle rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Circle

        #region [Shape] CLOSEST Triangle

        /// <summary>
        /// Return the closest point on a Triangle to a Point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Triangle rhs)
        {
            var closest = Closest(lhs, rhs.Sides);
            return closest.Point;
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Triangle rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Triangle

        #region [Shape] CLOSEST Polygon

        /// <summary>
        /// Return the closest point on a Polygon to a Point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Polygon rhs)
        {
            var closest = Closest(lhs, rhs.Sides());
            return closest.Point;
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Polygon rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Polygon

        #region [Shape] CLOSEST Ray

        /// <summary>
        /// Return the closest point on a Ray to a Point
        /// </summary>        
        public static Vector2 Closest(Vector2 lhs, Ray rhs)
        {
            var rayPoint = lhs - rhs.Origin;

            var rayPointDotDirection = rayPoint.Dot(rhs.Direction);
            var directionDotDirection = rhs.Direction.Dot(rhs.Direction);
            
            var t = rayPointDotDirection / directionDotDirection;

            if (t < 0) t = 0; // closest point is ray origin

            var closest = rhs.Origin + (t * rhs.Direction);
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Ray to a Line
        /// </summary>        
        public static Vector2 Closest(Line lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Ray to a Rectangle
        /// </summary>        
        public static Vector2 Closest(Rectangle lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Ray to a Circle
        /// </summary>        
        public static Vector2 Closest(Circle lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Ray to a Triangle
        /// </summary>        
        public static Vector2 Closest(Triangle lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Ray to a Polygon
        /// </summary>        
        public static Vector2 Closest(Polygon lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the closest point on a Ray to a Ray
        /// </summary>        
        public static Vector2 Closest(Ray lhs, Ray rhs)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CLOSEST Ray
    }
}
