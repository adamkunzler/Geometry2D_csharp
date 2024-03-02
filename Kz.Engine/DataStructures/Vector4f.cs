using Kz.Engine.General;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// Represents a vector in 3-dimensional space, but with an additional component 'W'.
    /// 
    /// 'W' is used in the basic mathematical methods (e.g. add, subtract, floor, max, etc), 
    /// but not used in vector operations (e.g. cross product, magnitude, dot product, reflect, etc).
    /// </summary>
    public class Vector4f
    {
        #region ctor

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public static Vector4f Zero => new Vector4f();

        public Vector4f()
        {
            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
            W = 0.0f;
        }

        public Vector4f(float x, float y, float z, float w = 0.0f)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Vector4f lhs, Vector4f rhs)
        {
            if (lhs == null && rhs == null) return true;
            if (lhs != null && rhs == null) return false;
            if (lhs == null && rhs != null) return false;

            return lhs!.X == rhs!.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W;
        }

        public bool AreEqual(Vector4f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Negate

        public static Vector4f Negate(Vector4f lhs)
        {
            return new Vector4f(-lhs.X, -lhs.Y, -lhs.Z, -lhs.W);
        }

        public Vector4f Negate() => Negate(this);

        #endregion Negate

        #region Vector Addition

        public static Vector4f Add(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public Vector4f Add(Vector4f rhs) => Add(this, rhs);

        public static Vector4f operator +(Vector4f lhs, Vector4f rhs) => Add(lhs, rhs);

        #endregion Vector Addition

        #region Scalar Addition

        public static Vector4f Add(Vector4f lhs, float rhs)
        {
            return new Vector4f(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs, lhs.W + rhs);
        }

        public Vector4f Add(float rhs) => Add(this, rhs);

        public static Vector4f operator +(float lhs, Vector4f rhs) => Add(rhs, lhs);

        public static Vector4f operator +(Vector4f lhs, float rhs) => Add(lhs, rhs);

        #endregion Scalar Addition

        #region Vector Subtraction

        public static Vector4f Subtract(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public Vector4f Subtact(Vector4f rhs) => Subtract(this, rhs);

        public static Vector4f operator -(Vector4f lhs, Vector4f rhs) => Subtract(lhs, rhs);

        #endregion Vector Subtraction

        #region Scalar Subtraction

        public static Vector4f Subtract(Vector4f lhs, float rhs)
        {
            return new Vector4f(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs, lhs.W - rhs);
        }

        public static Vector4f Subtract(float lhs, Vector4f rhs)
        {
            return new Vector4f(lhs - rhs.X, lhs - rhs.Y, lhs - rhs.Z, lhs - rhs.W);
        }

        public Vector4f Subtract(float rhs) => Subtract(this, rhs);

        public static Vector4f operator -(Vector4f lhs, float rhs) => Subtract(lhs, rhs);

        public static Vector4f operator -(float lhs, Vector4f rhs) => Subtract(lhs, rhs);

        #endregion Scalar Subtraction

        #region Vector Multiplication

        public static Vector4f Multiply(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z, lhs.W * rhs.W);
        }

        public Vector4f Multiply(Vector4f rhs) => Multiply(this, rhs);

        public static Vector4f operator *(Vector4f lhs, Vector4f rhs) => Multiply(lhs, rhs);

        #endregion Vector Multiplication

        #region Scalar Multiplication

        public static Vector4f Multiply(Vector4f lhs, float rhs)
        {
            return new Vector4f(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        public Vector4f Multiply(float rhs) => Multiply(this, rhs);

        public static Vector4f operator *(Vector4f lhs, float rhs) => Multiply(lhs, rhs);

        public static Vector4f operator *(float rhs, Vector4f lhs) => Multiply(lhs, rhs);

        #endregion Scalar Multiplication

        #region Vector Division

        public static Vector4f Divide(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z, lhs.W / rhs.W);
        }

        public Vector4f Divide(Vector4f rhs) => Divide(this, rhs);

        public static Vector4f operator /(Vector4f lhs, Vector4f rhs) => Divide(lhs, rhs);

        #endregion Vector Division

        #region Scalar Division

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public static Vector4f Divide(Vector4f lhs, float rhs)
        {
            return new Vector4f(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs, lhs.W / rhs);
        }

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public Vector4f Divide(float rhs) => Divide(this, rhs);

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public static Vector4f operator /(Vector4f lhs, float rhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Dot Product

        /// <summary>
        /// Calculate the Dot Product of two vectors
        /// </summary>
        public static float Dot(Vector4f lhs, Vector4f rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        /// <summary>
        /// Calculate the Dot Product of two vectors
        /// </summary>
        public float Dot(Vector4f rhs) => Dot(this, rhs);

        #endregion Dot Product

        #region Magnitude

        /// <summary>
        /// Calculate the magnitude (length) of a vector
        /// </summary>
        public static float Magnitude(Vector4f lhs)
        {
            return MathF.Sqrt(lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z);
        }

        /// <summary>
        /// Calculate the magnitude (length) of a vector
        /// </summary>
        public float Magnitude() => Magnitude(this);

        /// <summary>
        /// Calculate the squared magnitude of a vector
        /// </summary>
        public static float Magnitude2(Vector4f lhs)
        {
            return lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z;
        }

        /// <summary>
        /// Calculate the squared magnitude of a vector
        /// </summary>
        public float Magnitude2() => Magnitude2(this);

        #endregion Magnitude

        #region Normal

        /// <summary>
        /// Calculate the normal of a vector
        /// </summary>
        public static Vector4f Normal(Vector4f lhs)
        {
            var magnitude = lhs.Magnitude();
            var normal = lhs / magnitude;
            return normal;
        }

        /// <summary>
        /// Calculate the normal of a vector
        /// </summary>
        public Vector4f Normal() => Normal(this);

        #endregion Normal

        #region Cross Product

        /// <summary>
        /// Calculate cross product of two vectors
        /// </summary>
        public static Vector4f CrossProduct(Vector4f lhs, Vector4f rhs)
        {
            var c1 = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            var c2 = lhs.Z * rhs.X - lhs.X * rhs.Z;
            var c3 = lhs.X * rhs.Y - lhs.Y * rhs.X;

            return new Vector4f(c1, c2, c3);
        }

        /// <summary>
        /// Calculate cross product of two vectors
        /// </summary>
        public Vector4f CrossProduct(Vector4f rhs) => CrossProduct(this, rhs);

        #endregion Cross Product

        #region Floor/Ceiling

        /// <summary>
        /// round components down
        /// </summary>
        public static Vector4f Floor(Vector4f lhs)
        {
            return new Vector4f(MathF.Floor(lhs.X), MathF.Floor(lhs.Y), MathF.Floor(lhs.Z), MathF.Floor(lhs.W));
        }

        /// <summary>
        /// round components down
        /// </summary>
        public Vector4f Floor() => Floor(this);

        /// <summary>
        /// round components up
        /// </summary>
        public static Vector4f Ceiling(Vector4f lhs)
        {
            return new Vector4f(MathF.Ceiling(lhs.X), MathF.Ceiling(lhs.Y), MathF.Ceiling(lhs.Z), MathF.Ceiling(lhs.W));
        }

        /// <summary>
        /// round components up
        /// </summary>
        public Vector4f Ceiling() => Ceiling(this);

        #endregion Floor/Ceiling

        #region Min/Max

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public static Vector4f Max(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(MathF.Max(lhs.X, rhs.X), MathF.Max(lhs.Y, rhs.Y), MathF.Max(lhs.Z, rhs.Z), MathF.Max(lhs.W, rhs.W));
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public Vector4f Max(Vector4f rhs) => Max(this, rhs);

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public static Vector4f Min(Vector4f lhs, Vector4f rhs)
        {
            return new Vector4f(MathF.Min(lhs.X, rhs.X), MathF.Min(lhs.Y, rhs.Y), MathF.Min(lhs.Z, rhs.Z), MathF.Min(lhs.W, rhs.W));
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public Vector4f Min(Vector4f rhs) => Min(this, rhs);

        #endregion Min/Max

        #region Clamp

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public static Vector4f Clamp(Vector4f lhs, Vector4f min, Vector4f max)
        {
            return lhs.Max(min).Min(max);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public Vector4f Clamp(Vector4f min, Vector4f max) => Clamp(this, min, max);

        #endregion Clamp

        #region Lerp

        /// <summary>
        /// Linearly interpolate between vector lhs and rhs given a normalized parameter t (0 <= t <= 1)
        /// </summary>
        public static Vector4f Lerp(Vector4f lhs, Vector4f rhs, float t)
        {
            var c1 = lhs.X + t * (rhs.X - lhs.X);
            var c2 = lhs.Y + t * (rhs.Y - lhs.Y);
            var c3 = lhs.Z + t * (rhs.Z - lhs.Z);
            return new Vector4f(c1, c2, c3);
        }

        /// <summary>
        /// Linearly interpolate between vector lhs (this) and rhs given a normalized parameter t (0 <= t <= 1)
        /// </summary>
        public Vector4f Lerp(Vector4f rhs, float t) => Lerp(this, rhs, t);

        #endregion Lerp

        #region AngleBetween

        /// <summary>
        /// Calculate the angle (in radians) between two vectors
        /// </summary>
        public static float AngleBetween(Vector4f lhs, Vector4f rhs)
        {
            var dot = lhs.Dot(rhs);
            var mag = lhs.Magnitude() * rhs.Magnitude();
            var value = dot / mag;
            var clamped = Utils.Clamp(value, -1.0f, 1.0f);

            var angle = MathF.Acos(clamped);
            return angle;
        }

        /// <summary>
        /// Calculate the angle (in radians) between two vectors
        /// </summary>
        public float AngleBetween(Vector4f rhs) => AngleBetween(this, rhs);

        #endregion AngleBetween

        #region Distance Between

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public static float DistanceBetween(Vector4f lhs, Vector4f rhs)
        {
            var distance = (lhs - rhs).Magnitude();
            return distance;
        }

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public float DistanceBetween(Vector4f rhs) => DistanceBetween(this, rhs);

        #endregion Distance Between

        #region Projection

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public static Vector4f Project(Vector4f lhs, Vector4f rhs)
        {
            var scalarProjection = lhs.Dot(rhs) / rhs.Magnitude();
            var normal = rhs.Normal();
            var projection = normal * scalarProjection;
            return projection;
        }

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public Vector4f Project(Vector4f rhs) => Project(this, rhs);

        #endregion Projection

        #region Reflect

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>        
        public static Vector4f Reflect(Vector4f lhs, Vector4f rhs)
        {
            var normal = rhs.Normal();
            var projection = lhs.Dot(normal) * normal;
            var reflection = lhs - 2.0f * projection;
            return reflection;
        }

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>        
        public Vector4f Reflect(Vector4f rhs) => Reflect(this, rhs);

        #endregion Reflect
    }
}
