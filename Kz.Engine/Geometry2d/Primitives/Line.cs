using Kz.Engine.DataStructures;
using Kz.Engine.General;
using System.Numerics;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class Line : IShape
    {
        #region ctor

        public Vector2f Start { get; set; }
        public Vector2f End { get; set; }

        public Line()
        {
            Start = new Vector2f();
            End = new Vector2f();
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            Start = new Vector2f(x1, y1);
            End = new Vector2f(x2, y2);
        }

        public Line(Vector2f a, Vector2f b) : this(a.X, a.Y, b.X, b.Y)
        {
        }

        public override string ToString()
        {
            return $"Line [{Start}, {End}]";
        }

        public static bool AreEqual(Line lhs, Line rhs)
        {
            return (Vector2f.AreEqual(lhs.Start, rhs.Start) && Vector2f.AreEqual(lhs.End, rhs.End)) ||
                   (Vector2f.AreEqual(lhs.Start, rhs.End) && Vector2f.AreEqual(lhs.End, rhs.Start));
        }

        public bool AreEqual(Line rhs) => AreEqual(this, rhs);

        #endregion ctor

        #region Line Properties

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>
        public static Vector2f Vector(Line line)
        {
            return line.End - line.Start;
        }

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>
        public Vector2f Vector()
        {
            return End - Start;
        }

        /// <summary>
        /// returns the length of the line
        /// </summary>
        public static float Length(Line line)
        {
            var x = line.End.X - line.Start.X;
            var y = line.End.Y - line.Start.Y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// returns the length of the line
        /// </summary>
        public float Length() => Length(this);

        /// <summary>
        /// returns the length squared of the line
        /// </summary>
        public static float Length2(Line line)
        {
            var x = line.End.X - line.Start.X;
            var y = line.End.Y - line.Start.Y;

            return (x * x) + (y * y);
        }

        /// <summary>
        /// returns the length squared of the line
        /// </summary>
        public float Length2() => Length2(this);

        /// <summary>
        /// given a real distance, get a point along the line (distance is percent along the line, e.g. 0.5 would be middle)
        /// </summary>
        public static Vector2f RealPoint(Line line, float distance)
        {
            return line.Start + Vector(line).Normal() * distance;
        }

        /// <summary>
        /// given a real distance, get a point along the line
        /// </summary>
        public Vector2f RealPoint(float distance) => RealPoint(this, distance);

        /// <summary>
        /// returns the middle point of a line
        /// </summary>
        public static Vector2f Middle(Line line) => UnitPoint(line, 0.5f);

        /// <summary>
        /// returns the middle point of a line
        /// </summary>
        public Vector2f Middle() => Middle(this);

        /// <summary>
        /// given a unit distance, get a point along the line (1 unit = length of line)
        /// </summary>
        public static Vector2f UnitPoint(Line line, float distance)
        {
            return line.Start + Vector(line) * distance;
        }

        /// <summary>
        /// given a unit distance, get a point along the line
        /// </summary>
        public Vector2f UnitPoint(float distance) => UnitPoint(this, distance);

        /// <summary>
        /// return lne equation "mx + b" coefficients where: x = m and y-intercept = b
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>
        public static (float M, float B) Coefficients(Line line)
        {
            // check if line is close to vertical
            if (MathF.Abs(line.Start.X - line.End.X) < Consts.EPSILON)
            {
                return (float.PositiveInfinity, float.PositiveInfinity);
            }

            float m = (line.End.Y - line.Start.Y) / (line.End.X - line.Start.X);
            float a = -m * line.Start.X + line.Start.Y;
            return (m, a);
        }

        /// <summary>
        /// return lne equation "mx + a" coefficients where: x = m and y = a
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>
        public (float M, float A) Coefficients() => Coefficients(this);

        public static List<Vector2f> Endpoints(Line line) => new List<Vector2f> { line.Start, line.End };

        public List<Vector2f> Endpoints() => Endpoints(this);

        /// <summary>
        /// Calculate the normal vector of a line
        /// </summary>
        public static Vector2f Normal(Line lhs)
        {
            return lhs.Vector().Perpendicular().Normal();
        }

        /// <summary>
        /// Calculate the normal vector of a line
        /// </summary>
        public Vector2f Normal() => Normal(this);

        /// <summary>
        /// Calculate the normal vector of a line so that it is in the direction of a point.
        /// e.g. if the rhs is to the right of the lhs, then the normal should be on the "right" side 
        /// of the line.
        /// </summary>        
        public static Vector2f Normal(Line lhs, Vector2f rhs)
        {
            var normal = lhs.Normal();
            var lineStartToPoint = new Vector2f(rhs.X - lhs.Start.X, rhs.Y -lhs.Start.Y);

            var dot = normal.Dot(lineStartToPoint);
            if (dot < 0)
            {
                // Reverse the normal
                normal.X = -normal.X;
                normal.Y = -normal.Y;
            }

            return normal;
        }
        
        // <summary>
        /// Calculate the normal vector of a line so that it is in the direction of a point.
        /// e.g. if the rhs is to the right of the lhs, then the normal should be on the "right" side 
        /// of the line.
        /// </summary>  
        public Vector2f Normal(Vector2f rhs) => Normal(this, rhs);

        #endregion Line Properties

        #region Line Equation Forms

        /// <summary>
        /// y = mx + b
        ///
        /// m is the slope
        /// b is the y-intercept
        /// </summary>
        public static (float M, float B) SlopeInterceptForm(Line line)
        {
            return Coefficients(line);
        }

        /// <summary>
        /// y = mx + b
        ///
        /// m is the slope
        /// b is the y-intercept
        /// </summary>
        public (float M, float B) SlopeInterceptForm() => SlopeInterceptForm(this);

        /// <summary>
        /// Ax + By = C
        /// </summary>
        public static (float A, float B, float C) StandardForm(Line line)
        {
            // convert to standard form
            var a = line.End.Y - line.Start.Y;
            var b = line.Start.X - line.End.X;
            var c = a * line.Start.X + b * line.Start.Y;

            // normalize
            if (a < 0)
            {
                a = -a;
                b = -b;
                c = -c;
            }

            return (a, b, c);
        }

        /// <summary>
        /// Ax + By = C
        /// </summary>
        public (float A, float B, float C) StandardForm() => StandardForm(this);

        /// <summary>
        /// y - y1 = m(x - x1)
        /// </summary>
        public static (float M, float X1, float Y1) PointSlopeForm(Line line)
        {
            var coef = Coefficients(line);

            return (coef.M, line.Start.X, line.Start.Y);
        }

        /// <summary>
        /// y - y1 = m(x - x1)
        /// </summary>
        public void PointSlopeForm() => PointSlopeForm(this);

        /// <summary>
        /// (y - y1) / (x - x1) = (y2 - y1) / (x2 - x1)
        /// </summary>
        public static void TwoPointForm(Line line)
        {
            // doesn't make sense to return anything
        }

        /// <summary>
        /// (y - y1) / (x - x1) = (y2 - y1) / (x2 - x1)
        /// </summary>
        public void TwoPointForm() => TwoPointForm(this);

        /// <summary>
        /// (x / a) + (y / b) = 1
        ///
        /// If a line intersects the x-axis and y-axis at distinct points.
        ///
        /// a is the x-intercept (if == 0 then no intercept...parallel to x-axis)
        /// b is the y-intercept
        /// </summary>
        public static (float A, float B) InterceptForm(Line line)
        {
            var coef = Coefficients(line);

            var b = line.Start.Y - coef.M * line.Start.X;
            var a = coef.M != 0 ? -b / coef.M : 0;

            return (a, b);
        }

        /// <summary>
        /// x = x1 + t(vx)
        /// y = y1 + t(vy)
        ///
        /// x1,y1 is a point on the line
        /// vx,vy are components of a direction vector parallel to the line
        /// t can be interpreted as time
        /// </summary>
        public static void ParametricForm(Line line)
        {
            // TODO
        }

        /// <summary>
        /// x cos(theta) + y sin(theta) = p
        ///
        /// p is the perpendicular distance from the origin to the line
        /// theta is the angle formed by the x-axis and the line perpendicular to the given line
        /// </summary>
        public static void NormalForm(Line line)
        {
            // TODO
        }

        #endregion Line Equation Forms
    }
}