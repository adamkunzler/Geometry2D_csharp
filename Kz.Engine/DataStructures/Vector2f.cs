namespace Kz.Engine.DataStructures
{
    public class Vector2f
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

        public static Vector2f Zero => new Vector2f();

        public Vector2f()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Vector2f(float x, float y)
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

        public static bool AreEqual(Vector2f lhs, Vector2f rhs)
        {
            if (lhs == null && rhs == null) return true;
            if (lhs != null && rhs == null) return false;
            if (lhs == null && rhs != null) return false;

            return (lhs!.X == rhs!.X && lhs.Y == rhs.Y);
        }

        public bool AreEqual(Vector2f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Vector Addition

        public static Vector2f Add(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2f operator +(Vector2f a, Vector2f b)
        {
            return Add(a, b);
        }

        public Vector2f Add(Vector2f other)
        {
            return Add(this, other);
        }

        #endregion Vector Addition

        #region Scalar Addition

        public static Vector2f Add(Vector2f a, float t)
        {
            return new Vector2f(a.X + t, a.Y + t);
        }

        public static Vector2f operator +(Vector2f a, float t)
        {
            return Add(a, t);
        }

        public static Vector2f operator +(float t, Vector2f a)
        {
            return Add(a, t);
        }

        public Vector2f Add(float t)
        {
            return Add(this, t);
        }

        #endregion Scalar Addition

        #region Vector Subtraction

        public static Vector2f Subtract(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2f operator -(Vector2f lhs, Vector2f rhs) => Subtract(lhs, rhs);
        
        public Vector2f Subtract(Vector2f rhs) => Subtract(this, rhs);
        

        #endregion Vector Subtraction

        #region Scalar Subtraction

        public static Vector2f Subtract(Vector2f a, float t)
        {
            return new Vector2f(a.X - t, a.Y - t);
        }

        public static Vector2f operator -(Vector2f a, float t)
        {
            return Subtract(a, t);
        }

        public static Vector2f operator -(float t, Vector2f a)
        {
            return Subtract(a, t);
        }

        public Vector2f Subtract(float t)
        {
            return Subtract(this, t);
        }

        #endregion Scalar Subtraction

        #region Vector Multiplication

        public static Vector2f Multiply(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2f operator *(Vector2f a, Vector2f b)
        {
            return Multiply(a, b);
        }

        public Vector2f Multiply(Vector2f a)
        {
            return Multiply(this, a);
        }

        #endregion Vector Multiplication

        #region Scalar Multiplication

        public static Vector2f Multiply(Vector2f a, float scalar)
        {
            return new Vector2f(a.X * scalar, a.Y * scalar);
        }

        public static Vector2f operator *(Vector2f a, float scalar)
        {
            return Multiply(a, scalar);
        }

        public static Vector2f operator *(float scalar, Vector2f a)
        {
            return Multiply(a, scalar);
        }

        public Vector2f Multiply(float scalar)
        {
            return Multiply(this, scalar);
        }

        #endregion Scalar Multiplication

        #region Vector Division

        public static Vector2f Divide(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.X / b.X, a.Y / b.Y);
        }

        public static Vector2f operator /(Vector2f a, Vector2f b)
        {
            return Divide(a, b);
        }

        public Vector2f Divide(Vector2f a)
        {
            return Divide(this, a);
        }

        #endregion Vector Division

        #region Scalar Division

        public static Vector2f Divide(Vector2f a, float scalar)
        {
            return new Vector2f(a.X / scalar, a.Y / scalar);
        }

        public static Vector2f operator /(Vector2f a, float scalar)
        {
            return Divide(a, scalar);
        }

        public Vector2f Divide(float scalar)
        {
            return Divide(this, scalar);
        }

        #endregion Scalar Division

        #region Dot Product (Scalar Product)

        public static float Dot(Vector2f a, Vector2f b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        public float Dot(Vector2f other)
        {
            return Dot(this, other);
        }

        #endregion Dot Product (Scalar Product)

        #region Magnitude (Length)

        /// <summary>
        /// return magnitude (length) of the vector
        /// </summary>
        public static float Magnitude(Vector2f a)
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
        public static float Magnitude2(Vector2f a)
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
        public static Vector2f Normal(Vector2f a)
        {
            var magnitude = Magnitude(a);
            return new Vector2f(a.X / magnitude, a.Y / magnitude);
        }

        /// <summary>
        /// returns the normalized version of the vector (length = 1)
        /// </summary>
        public Vector2f Normal()
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
        public static float CrossProduct(Vector2f a, Vector2f b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        /// Positive - b is counter clockwise to a
        /// Negative - b is clockwise to a
        /// Zero - a and b are parallel or one is a zero vector
        /// </summary>
        public float CrossProduct(Vector2f other)
        {
            return CrossProduct(this, other);
        }

        #endregion Scalar Cross Product

        #region Perpendicular

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public static Vector2f Perpendicular(Vector2f a)
        {
            return new Vector2f(-a.Y, a.X);
        }

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public Vector2f Perpendicular()
        {
            return Perpendicular(this);
        }

        #endregion Perpendicular

        #region Misc

        /// <summary>
        /// returns rectangular area of vector
        /// </summary>
        public static float Area(Vector2f a)
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
        public static Vector2f Floor(Vector2f a)
        {
            return new Vector2f(MathF.Floor(a.X), MathF.Floor(a.Y));
        }

        /// <summary>
        /// round both components down
        /// </summary>
        public Vector2f Floor()
        {
            return Floor(this);
        }

        /// <summary>
        /// round both components up
        /// </summary>
        public static Vector2f Ceiling(Vector2f a)
        {
            return new Vector2f(MathF.Ceiling(a.X), MathF.Ceiling(a.Y));
        }

        /// <summary>
        /// round both components up
        /// </summary>
        public Vector2f Ceiling()
        {
            return Floor(this);
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public static Vector2f Max(Vector2f a, Vector2f b)
        {
            return new Vector2f(MathF.Max(a.X, b.X), MathF.Max(a.Y, b.Y));
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public Vector2f Max(Vector2f other)
        {
            return Max(this, other);
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public static Vector2f Min(Vector2f a, Vector2f b)
        {
            return new Vector2f(MathF.Min(a.X, b.X), MathF.Min(a.Y, b.Y));
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public Vector2f Min(Vector2f other)
        {
            return Min(this, other);
        }

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// Theta is in radians.
        /// </summary>
        public static Vector2f ToCartesian(Vector2f a)
        {
            return new Vector2f(MathF.Cos(a.Theta) * a.R, MathF.Sin(a.Theta) * a.R);
        }

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// </summary>
        public Vector2f ToCartesian()
        {
            return ToCartesian(this);
        }

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public static Vector2f ToPolar(Vector2f a)
        {
            return new Vector2f(a.Magnitude(), MathF.Atan2(a.Y, a.X));
        }

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public Vector2f ToPolar()
        {
            return ToPolar(this);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public static Vector2f Clamp(Vector2f a, Vector2f min, Vector2f max)
        {
            return a.Max(min).Min(max);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public Vector2f Clamp(Vector2f min, Vector2f max)
        {
            return Clamp(this, min, max);
        }

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public static Vector2f Lerp(Vector2f a, Vector2f b, float t)
        {
            return new Vector2f
            (
                (1.0f - t) * a.X + t * b.X,
                (1.0f - t) * a.Y + t * b.Y
            );
        }

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public Vector2f Lerp(Vector2f other, float t)
        {
            return Lerp(this, other, t);
        }

        /// <summary>
        /// return the angle between two vectors in radians
        /// </summary>
        public static float AngleBetween(Vector2f a, Vector2f b)
        {
            var dot = Dot(a, b);
            var cosTheta = dot / (a.Magnitude() * b.Magnitude());
            var angle = MathF.Acos(cosTheta);
            return angle;
        }

        /// <summary>
        /// return the angle between two vectors in radians
        /// </summary>
        public float AngleBetwen(Vector2f rhs) => AngleBetween(this, rhs);

        #endregion Misc
    }
}