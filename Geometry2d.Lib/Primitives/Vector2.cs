namespace Geometry2d.Lib.Primitives
{
    public interface IShape { }


    public class Vector2 : IShape
    {
        #region ctor

        public float X { get; set; }
        public float Y { get; set; }

        #region Aliases

        public float R => X;
        public float Theta => Y;

        public float Width => X;
        public float Height => Y;

        #endregion Aliases

        public static Vector2 Zero => new Vector2();

        public Vector2()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X == rhs.X && lhs.Y == rhs.Y);
        }

        public bool AreEqual(Vector2 rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Vector Addition

        public static Vector2 Add(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return Add(a, b);
        }

        public Vector2 Add(Vector2 other)
        {
            return Add(this, other);
        }

        #endregion Vector Addition

        #region Scalar Addition

        public static Vector2 Add(Vector2 a, float t)
        {
            return new Vector2(a.X + t, a.Y + t);
        }

        public static Vector2 operator +(Vector2 a, float t)
        {
            return Add(a, t);
        }

        public static Vector2 operator +(float t, Vector2 a)
        {
            return Add(a, t);
        }

        public Vector2 Add(float t)
        {
            return Add(this, t);
        }

        #endregion Scalar Addition

        #region Vector Subtraction

        public static Vector2 Subtract(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return Subtract(a, b);
        }

        public Vector2 Subtract(Vector2 other)
        {
            return Subtract(this, other);
        }

        #endregion Vector Subtraction

        #region Scalar Subtraction

        public static Vector2 Subtract(Vector2 a, float t)
        {
            return new Vector2(a.X - t, a.Y - t);
        }

        public static Vector2 operator -(Vector2 a, float t)
        {
            return Subtract(a, t);
        }

        public static Vector2 operator -(float t, Vector2 a)
        {
            return Subtract(a, t);
        }

        public Vector2 Subtract(float t)
        {
            return Subtract(this, t);
        }

        #endregion Scalar Subtraction

        #region Vector Multiplication

        public static Vector2 Multiply(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return Multiply(a, b);
        }

        public Vector2 Multiply(Vector2 a)
        {
            return Multiply(this, a);
        }

        #endregion Vector Multiplication

        #region Scalar Multiplication

        public static Vector2 Multiply(Vector2 a, float scalar)
        {
            return new Vector2(a.X * scalar, a.Y * scalar);
        }

        public static Vector2 operator *(Vector2 a, float scalar)
        {
            return Multiply(a, scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 a)
        {
            return Multiply(a, scalar);
        }

        public Vector2 Multiply(float scalar)
        {
            return Multiply(this, scalar);
        }

        #endregion Scalar Multiplication

        #region Vector Division

        public static Vector2 Divide(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return Divide(a, b);
        }

        public Vector2 Divide(Vector2 a)
        {
            return Divide(this, a);
        }

        #endregion Vector Division

        #region Scalar Division

        public static Vector2 Divide(Vector2 a, float scalar)
        {
            return new Vector2(a.X / scalar, a.Y / scalar);
        }

        public static Vector2 operator /(Vector2 a, float scalar)
        {
            return Divide(a, scalar);
        }

        public Vector2 Divide(float scalar)
        {
            return Divide(this, scalar);
        }

        #endregion Scalar Division

        #region Dot Product (Scalar Product)

        public static float Dot(Vector2 a, Vector2 b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        public float Dot(Vector2 other)
        {
            return Dot(this, other);
        }

        #endregion Dot Product (Scalar Product)

        #region Magnitude (Length)

        /// <summary>
        /// return magnitude (length) of the vector
        /// </summary>
        public static float Magnitude(Vector2 a)
        {
            return MathF.Sqrt((a.X * a.X) + (a.Y * a.Y));
        }

        /// <summary>
        /// return magnitude (length) of the vector
        /// </summary>
        public float Magnitude()
        {
            return Magnitude(this);
        }

        /// <summary>
        /// returns magnitude squared (useful for fast comparison)
        /// </summary>
        public static float Magnitude2(Vector2 a)
        {
            return (a.X * a.X) + (a.Y * a.Y);
        }

        /// <summary>
        /// returns magnitude squared (useful for fast comparison)
        /// </summary>
        public float Magnitude2()
        {
            return Magnitude2(this);
        }

        #endregion Magnitude (Length)

        #region Normalization

        /// <summary>
        /// returns the normalized version of the vector (length = 1)
        /// </summary>
        public static Vector2 Normal(Vector2 a)
        {
            var magnitude = Magnitude(a);
            return new Vector2(a.X / magnitude, a.Y / magnitude);
        }

        /// <summary>
        /// returns the normalized version of the vector (length = 1)
        /// </summary>
        public Vector2 Normal()
        {
            return Normal(this);
        }

        #endregion Normalization

        #region Scalar Cross Product

        /// <summary>
        /// Positive - b is counter clockwise to a
        /// Negative - b is clockwise to a
        /// Zero - a and b are parallel or one is a zero vector
        /// </summary>
        public static float CrossProduct(Vector2 a, Vector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        /// Positive - b is counter clockwise to a
        /// Negative - b is clockwise to a
        /// Zero - a and b are parallel or one is a zero vector
        /// </summary>
        public float CrossProduct(Vector2 other)
        {
            return CrossProduct(this, other);
        }

        #endregion Scalar Cross Product

        #region Perpendicular

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public static Vector2 Perpendicular(Vector2 a)
        {
            return new Vector2(-a.Y, a.X);
        }

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public Vector2 Perpendicular()
        {
            return Perpendicular(this);
        }

        #endregion Perpendicular

        #region Misc

        /// <summary>
        /// returns rectangular area of vector
        /// </summary>
        public static float Area(Vector2 a)
        {
            return a.X * a.Y;
        }

        /// <summary>
        /// returns rectangular area of vector
        /// </summary>
        public float Area()
        {
            return Area(this);
        }

        /// <summary>
        /// round both components down
        /// </summary>
        public static Vector2 Floor(Vector2 a)
        {
            return new Vector2(MathF.Floor(a.X), MathF.Floor(a.Y));
        }

        /// <summary>
        /// round both components down
        /// </summary>
        public Vector2 Floor()
        {
            return Floor(this);
        }

        /// <summary>
        /// round both components up
        /// </summary>
        public static Vector2 Ceiling(Vector2 a)
        {
            return new Vector2(MathF.Ceiling(a.X), MathF.Ceiling(a.Y));
        }

        /// <summary>
        /// round both components up
        /// </summary>
        public Vector2 Ceiling()
        {
            return Floor(this);
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2(MathF.Max(a.X, b.X), MathF.Max(a.Y, b.Y));
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public Vector2 Max(Vector2 other)
        {
            return Max(this, other);
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2(MathF.Min(a.X, b.X), MathF.Min(a.Y, b.Y));
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public Vector2 Min(Vector2 other)
        {
            return Min(this, other);
        }

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// Theta is in radians.
        /// </summary>
        public static Vector2 ToCartesian(Vector2 a)
        {
            return new Vector2(MathF.Cos(a.Theta) * a.R, MathF.Sin(a.Theta) * a.R);
        }

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// </summary>
        public Vector2 ToCartesian()
        {
            return ToCartesian(this);
        }

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public static Vector2 ToPolar(Vector2 a)
        {
            return new Vector2(a.Magnitude(), MathF.Atan2(a.Y, a.X));
        }

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public Vector2 ToPolar()
        {
            return ToPolar(this);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public static Vector2 Clamp(Vector2 a, Vector2 min, Vector2 max)
        {
            return a.Max(min).Min(max);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public Vector2 Clamp(Vector2 min, Vector2 max)
        {
            return Clamp(this, min, max);
        }

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {            
            return new Vector2
            (
                (1.0f - t) * a.X + t * b.X,
                (1.0f - t) * a.Y + t * b.Y
            );
        }

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public Vector2 Lerp(Vector2 other, float t)
        {
            return Lerp(this, other, t);
        }

        #endregion Misc
    }
}