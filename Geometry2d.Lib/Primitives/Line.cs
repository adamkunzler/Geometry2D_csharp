using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Primitives
{
    public class Line
    {
        #region ctor

        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        public Line()
        {
            Start = new Vector2();
            End = new Vector2();
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            Start = new Vector2(x1, y1);
            End = new Vector2(x2, y2);
        }

        public Line(Vector2 a, Vector2 b) : this(a.X, a.Y, b.X, b.Y)
        {
        }

        public override string ToString()
        {
            return $"[{Start}, {End}]";
        }

        #endregion ctor

        #region Line Properties

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>        
        public static Vector2 Vector(Line line)
        {
            return line.End - line.Start;
        }

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>        
        public Vector2 Vector()
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
        /// given a real distance, get a point along the line
        /// </summary>        
        public static Vector2 RealPoint(Line line, float distance)
        {
            return line.Start + Vector(line).Normal() * distance;
        }

        /// <summary>
        /// given a real distance, get a point along the line
        /// </summary>        
        public Vector2 RealPoint(float distance) => RealPoint(this, distance);

        /// <summary>
        /// given a unit distance, get a point along the line
        /// </summary>        
        public static Vector2 UnitPoint(Line line, float distance)
        {
            return line.Start + Vector(line) * distance;
        }

        /// <summary>
        /// given a unit distance, get a point along the line
        /// </summary>        
        public Vector2 UnitPoint(float distance) => UnitPoint(this, distance);

        /// <summary>
        /// return lne equation "mx + a" coefficients where: x = m and y = a
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>        
        public static Vector2 Coefficients(Line line)
        {
            // check if line is close to vertical
            if (MathF.Abs(line.Start.X - line.End.X) < Consts.EPSILON)
            {
                return new Vector2(float.PositiveInfinity, float.PositiveInfinity);
            }

            float m = (line.End.Y - line.Start.Y) / (line.End.X - line.Start.X);
            float a = -m * line.Start.X + line.Start.Y;
            return new Vector2(m, a);
        }

        /// <summary>
        /// return lne equation "mx + a" coefficients where: x = m and y = a
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>        
        public Vector2 Coefficients() => Coefficients(this);

        #endregion Line Properties
    }       
}