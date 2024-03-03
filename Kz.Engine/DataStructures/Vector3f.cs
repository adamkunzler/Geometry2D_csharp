using Kz.Engine.General;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// Represents a vector in 3-dimensional space
    /// </summary>
    public class Vector3f
    {
        #region ctor

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static Vector3f Zero => new Vector3f();

        public Vector3f()
        {
            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
        }

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Vector3f lhs, Vector3f rhs)
        {
            if (lhs == null && rhs == null) return true;
            if (lhs != null && rhs == null) return false;
            if (lhs == null && rhs != null) return false;

            return lhs!.X == rhs!.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public bool AreEqual(Vector3f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Implicit/Explicit Operators

        /// <summary>
        /// Explicity cast from Vector3f to Vector4f (W = 0)
        /// </summary>        
        public static explicit operator Vector4f(Vector3f val) => new(val.X, val.Y, val.Z, 0.0f);

        #endregion Implicit/Explicit Operators

        #region Negate

        public static Vector3f Negate(Vector3f lhs)
        {
            return new Vector3f(-lhs.X, -lhs.Y, -lhs.Z);
        }

        public Vector3f Negate() => Negate(this);

        #endregion Negate

        #region Vector Addition

        public static Vector3f Add(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public Vector3f Add(Vector3f rhs) => Add(this, rhs);

        public static Vector3f operator +(Vector3f lhs, Vector3f rhs) => Add(lhs, rhs);

        #endregion Vector Addition

        #region Scalar Addition

        public static Vector3f Add(Vector3f lhs, float rhs)
        {
            return new Vector3f(lhs.X + rhs, lhs.Y + rhs, lhs.Z + rhs);
        }

        public Vector3f Add(float rhs) => Add(this, rhs);

        public static Vector3f operator +(float lhs, Vector3f rhs) => Add(rhs, lhs);

        public static Vector3f operator +(Vector3f lhs, float rhs) => Add(lhs, rhs);

        #endregion Scalar Addition

        #region Vector Subtraction

        public static Vector3f Subtract(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public Vector3f Subtact(Vector3f rhs) => Subtract(this, rhs);

        public static Vector3f operator -(Vector3f lhs, Vector3f rhs) => Subtract(lhs, rhs);

        #endregion Vector Subtraction

        #region Scalar Subtraction

        public static Vector3f Subtract(Vector3f lhs, float rhs)
        {
            return new Vector3f(lhs.X - rhs, lhs.Y - rhs, lhs.Z - rhs);
        }

        public static Vector3f Subtract(float lhs, Vector3f rhs)
        {
            return new Vector3f(lhs - rhs.X, lhs - rhs.Y, lhs - rhs.Z);
        }

        public Vector3f Subtract(float rhs) => Subtract(this, rhs);

        public static Vector3f operator -(Vector3f lhs, float rhs) => Subtract(lhs, rhs);

        public static Vector3f operator -(float lhs, Vector3f rhs) => Subtract(lhs, rhs);

        #endregion Scalar Subtraction

        #region Vector Multiplication

        public static Vector3f Multiply(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
        }

        public Vector3f Multiply(Vector3f rhs) => Multiply(this, rhs);

        public static Vector3f operator *(Vector3f lhs, Vector3f rhs) => Multiply(lhs, rhs);

        #endregion Vector Multiplication

        #region Scalar Multiplication

        public static Vector3f Multiply(Vector3f lhs, float rhs)
        {
            return new Vector3f(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        public Vector3f Multiply(float rhs) => Multiply(this, rhs);

        public static Vector3f operator *(Vector3f lhs, float rhs) => Multiply(lhs, rhs);

        public static Vector3f operator *(float rhs, Vector3f lhs) => Multiply(lhs, rhs);

        #endregion Scalar Multiplication

        #region Vector Division

        public static Vector3f Divide(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
        }

        public Vector3f Divide(Vector3f rhs) => Divide(this, rhs);

        public static Vector3f operator /(Vector3f lhs, Vector3f rhs) => Divide(lhs, rhs);

        #endregion Vector Division

        #region Scalar Division

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public static Vector3f Divide(Vector3f lhs, float rhs)
        {
            return new Vector3f(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public Vector3f Divide(float rhs) => Divide(this, rhs);

        /// <summary>
        /// Divide a vectors' components by a scalar
        /// </summary>
        public static Vector3f operator /(Vector3f lhs, float rhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Dot Product

        /// <summary>
        /// Calculate the Dot Product of two vectors
        /// </summary>
        public static float Dot(Vector3f lhs, Vector3f rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        /// <summary>
        /// Calculate the Dot Product of two vectors
        /// </summary>
        public float Dot(Vector3f rhs) => Dot(this, rhs);

        #endregion Dot Product

        #region Magnitude

        /// <summary>
        /// Calculate the magnitude (length) of a vector
        /// </summary>
        public static float Magnitude(Vector3f lhs)
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
        public static float Magnitude2(Vector3f lhs)
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
        public static Vector3f Normal(Vector3f lhs)
        {
            var magnitude = lhs.Magnitude();
            var normal = lhs / magnitude;
            return normal;
        }

        /// <summary>
        /// Calculate the normal of a vector
        /// </summary>
        public Vector3f Normal() => Normal(this);

        #endregion Normal

        #region Cross Product

        /// <summary>
        /// Calculate cross product of two vectors
        /// </summary>
        public static Vector3f CrossProduct(Vector3f lhs, Vector3f rhs)
        {
            var c1 = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            var c2 = lhs.Z * rhs.X - lhs.X * rhs.Z;
            var c3 = lhs.X * rhs.Y - lhs.Y * rhs.X;

            return new Vector3f(c1, c2, c3);
        }

        /// <summary>
        /// Calculate cross product of two vectors
        /// </summary>
        public Vector3f CrossProduct(Vector3f rhs) => CrossProduct(this, rhs);

        #endregion Cross Product

        #region Floor/Ceiling

        /// <summary>
        /// round components down
        /// </summary>
        public static Vector3f Floor(Vector3f lhs)
        {
            return new Vector3f(MathF.Floor(lhs.X), MathF.Floor(lhs.Y), MathF.Floor(lhs.Z));
        }

        /// <summary>
        /// round components down
        /// </summary>
        public Vector3f Floor() => Floor(this);

        /// <summary>
        /// round components up
        /// </summary>
        public static Vector3f Ceiling(Vector3f lhs)
        {
            return new Vector3f(MathF.Ceiling(lhs.X), MathF.Ceiling(lhs.Y), MathF.Ceiling(lhs.Z));
        }

        /// <summary>
        /// round components up
        /// </summary>
        public Vector3f Ceiling() => Ceiling(this);

        #endregion Floor/Ceiling

        #region Min/Max

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public static Vector3f Max(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(MathF.Max(lhs.X, rhs.X), MathF.Max(lhs.Y, rhs.Y), MathF.Max(lhs.Z, rhs.Z));
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public Vector3f Max(Vector3f rhs) => Max(this, rhs);

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public static Vector3f Min(Vector3f lhs, Vector3f rhs)
        {
            return new Vector3f(MathF.Min(lhs.X, rhs.X), MathF.Min(lhs.Y, rhs.Y), MathF.Min(lhs.Z, rhs.Z));
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public Vector3f Min(Vector3f rhs) => Min(this, rhs);

        #endregion Min/Max

        #region Clamp

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public static Vector3f Clamp(Vector3f lhs, Vector3f min, Vector3f max)
        {
            return lhs.Max(min).Min(max);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public Vector3f Clamp(Vector3f min, Vector3f max) => Clamp(this, min, max);

        #endregion Clamp

        #region Lerp

        /// <summary>
        /// Linearly interpolate between vector lhs and rhs given a normalized parameter t (0 <= t <= 1)
        /// </summary>
        public static Vector3f Lerp(Vector3f lhs, Vector3f rhs, float t)
        {
            var c1 = lhs.X + t * (rhs.X - lhs.X);
            var c2 = lhs.Y + t * (rhs.Y - lhs.Y);
            var c3 = lhs.Z + t * (rhs.Z - lhs.Z);
            return new Vector3f(c1, c2, c3);
        }

        /// <summary>
        /// Linearly interpolate between vector lhs (this) and rhs given a normalized parameter t (0 <= t <= 1)
        /// </summary>
        public Vector3f Lerp(Vector3f rhs, float t) => Lerp(this, rhs, t);

        #endregion Lerp

        #region AngleBetween

        /// <summary>
        /// Calculate the angle (in radians) between two vectors
        /// </summary>
        public static float AngleBetween(Vector3f lhs, Vector3f rhs)
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
        public float AngleBetween(Vector3f rhs) => AngleBetween(this, rhs);

        #endregion AngleBetween

        #region Distance Between

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public static float DistanceBetween(Vector3f lhs, Vector3f rhs)
        {
            var distance = (lhs - rhs).Magnitude();
            return distance;
        }

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public float DistanceBetween(Vector3f rhs) => DistanceBetween(this, rhs);

        #endregion Distance Between

        #region Projection

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public static Vector3f Project(Vector3f lhs, Vector3f rhs)
        {
            var scalarProjection = lhs.Dot(rhs) / rhs.Magnitude();
            var normal = rhs.Normal();
            var projection = normal * scalarProjection;
            return projection;
        }

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public Vector3f Project(Vector3f rhs) => Project(this, rhs);

        #endregion Projection

        #region Reflect

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>        
        public static Vector3f Reflect(Vector3f lhs, Vector3f rhs)
        {
            var normal = rhs.Normal();
            var projection = lhs.Dot(normal) * normal;
            var reflection = lhs - 2.0f * projection;
            return reflection;
        }

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>        
        public Vector3f Reflect(Vector3f rhs) => Reflect(this, rhs);

        #endregion Reflect

        #region Vector3 / Matrix3x3 Operations

        public Vector3f Multiply(Matrix3x3f rhs) => Matrix3x3f.Multiply(this, rhs);

        #endregion Vector3 / Matrix3x3 Operations
    }
}