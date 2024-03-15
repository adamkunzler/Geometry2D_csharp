using Kz.Engine.General;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Trigonometry;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// Represents a vector in 2-dimensional space
    /// </summary>
    public struct Vector2f : IShape
    {
        #region ctor

        public float X;
        public float Y;

        #region Aliases

        public readonly float R => X;
        public readonly float Theta => Y;

        public readonly float Width => X;
        public readonly float Height => Y;

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
            return (lhs!.X == rhs!.X && lhs.Y == rhs.Y);
        }

        public bool AreEqual(Vector2f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Negate

        public static Vector2f Negate(Vector2f lhs)
        {
            return new Vector2f(-lhs.X, -lhs.Y);
        }

        public Vector2f Negate() => Negate(this);

        #endregion Negate

        #region Vector Addition

        public static Vector2f Add(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2f operator +(Vector2f lhs, Vector2f rhs) => Add(lhs, rhs);

        public Vector2f Add(Vector2f rhs) => Add(this, rhs);

        #endregion Vector Addition

        #region Scalar Addition

        public static Vector2f Add(Vector2f lhs, float t)
        {
            return new Vector2f(lhs.X + t, lhs.Y + t);
        }

        public static Vector2f operator +(Vector2f lhs, float t) => Add(lhs, t);

        public static Vector2f operator +(float t, Vector2f rhs) => Add(rhs, t);

        public Vector2f Add(float t) => Add(this, t);

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

        public static Vector2f Subtract(Vector2f lhs, float rhs)
        {
            return new Vector2f(lhs.X - rhs, lhs.Y - rhs);
        }

        public static Vector2f Subtract(float lhs, Vector2f rhs)
        {
            return new Vector2f(lhs - rhs.X, lhs - rhs.Y);
        }

        public static Vector2f operator -(Vector2f lhs, float rhs) => Subtract(lhs, rhs);

        public static Vector2f operator -(float lhs, Vector2f rhs) => Subtract(lhs, rhs);

        public Vector2f Subtract(float rhs) => Subtract(this, rhs);

        #endregion Scalar Subtraction

        #region Vector Multiplication

        public static Vector2f Multiply(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(lhs.X * rhs.X, lhs.Y * rhs.Y);
        }

        public static Vector2f operator *(Vector2f lhs, Vector2f rhs) => Multiply(lhs, rhs);

        public Vector2f Multiply(Vector2f rhs) => Multiply(this, rhs);

        #endregion Vector Multiplication

        #region Scalar Multiplication

        public static Vector2f Multiply(Vector2f lhs, float rhs)
        {
            return new Vector2f(lhs.X * rhs, lhs.Y * rhs);
        }

        public static Vector2f operator *(Vector2f lhs, float rhs) => Multiply(lhs, rhs);

        public static Vector2f operator *(float lhs, Vector2f rhs) => Multiply(rhs, lhs);

        public Vector2f Multiply(float rhs) => Multiply(this, rhs);

        #endregion Scalar Multiplication

        #region Vector Division

        public static Vector2f Divide(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(lhs.X / rhs.X, lhs.Y / rhs.Y);
        }

        public static Vector2f operator /(Vector2f lhs, Vector2f rhs) => Divide(lhs, rhs);

        public Vector2f Divide(Vector2f rhs) => Divide(this, rhs);

        #endregion Vector Division

        #region Scalar Division

        public static Vector2f Divide(Vector2f lhs, float rhs)
        {
            return new Vector2f(lhs.X / rhs, lhs.Y / rhs);
        }

        public static Vector2f operator /(Vector2f lhs, float rhs) => Divide(lhs, rhs);

        public Vector2f Divide(float rhs) => Divide(this, rhs);

        #endregion Scalar Division

        #region Dot Product (Scalar Product)

        public static float Dot(Vector2f lhs, Vector2f rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public float Dot(Vector2f rhs) => Dot(this, rhs);

        #endregion Dot Product (Scalar Product)

        #region Magnitude (Length)

        /// <summary>
        /// return magnitude (length) of the vector
        /// </summary>
        public static float Magnitude(Vector2f lhs)
        {
            return MathF.Sqrt((lhs.X * lhs.X) + (lhs.Y * lhs.Y));
        }

        /// <summary>
        /// return magnitude (length) of the vector
        /// </summary>
        public float Magnitude() => Magnitude(this);

        /// <summary>
        /// returns magnitude squared (useful for fast comparison)
        /// </summary>
        public static float Magnitude2(Vector2f lhs)
        {
            return (lhs.X * lhs.X) + (lhs.Y * lhs.Y);
        }

        /// <summary>
        /// returns magnitude squared (useful for fast comparison)
        /// </summary>
        public float Magnitude2() => Magnitude2(this);

        #endregion Magnitude (Length)

        #region Normalization

        /// <summary>
        /// returns the normalized version of the vector (length = 1)
        /// </summary>
        public static Vector2f Normal(Vector2f lhs)
        {
            var magnitude = Magnitude(lhs);
            return new Vector2f(lhs.X / magnitude, lhs.Y / magnitude);
        }

        /// <summary>
        /// returns the normalized version of the vector (length = 1)
        /// </summary>
        public Vector2f Normal() => Normal(this);

        #endregion Normalization

        #region Scalar Cross Product

        /// <summary>
        /// Positive - b is counter clockwise to a
        /// Negative - b is clockwise to a
        /// Zero - a and b are parallel or one is a zero vector
        /// </summary>
        public static float CrossProduct(Vector2f lhs, Vector2f rhs)
        {
            return lhs.X * rhs.Y - lhs.Y * rhs.X;
        }

        /// <summary>
        /// Positive - b is counter clockwise to a
        /// Negative - b is clockwise to a
        /// Zero - a and b are parallel or one is a zero vector
        /// </summary>
        public float CrossProduct(Vector2f rhs) => CrossProduct(this, rhs);

        #endregion Scalar Cross Product

        #region Perpendicular

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public static Vector2f Perpendicular(Vector2f lhs)
        {
            return new Vector2f(-lhs.Y, lhs.X);
        }

        /// <summary>
        /// returns a vector perpendicular to the vector
        /// </summary>
        public Vector2f Perpendicular() => Perpendicular(this);

        #endregion Perpendicular

        #region Distance Between

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public static float DistanceBetween(Vector2f lhs, Vector2f rhs)
        {
            var distance = (lhs - rhs).Magnitude();
            return distance;
        }

        /// <summary>
        /// Calculate the distance between two vectors
        /// </summary>
        public float DistanceBetween(Vector2f rhs) => DistanceBetween(this, rhs);

        #endregion Distance Between

        #region Area

        /// <summary>
        /// returns rectangular area of vector
        /// </summary>
        public static float Area(Vector2f lhs)
        {
            return lhs.X * lhs.Y;
        }

        /// <summary>
        /// returns rectangular area of vector
        /// </summary>
        public float Area() => Area(this);

        #endregion Area

        #region Floor / Ceiling

        /// <summary>
        /// round both components down
        /// </summary>
        public static Vector2f Floor(Vector2f lhs)
        {
            return new Vector2f(MathF.Floor(lhs.X), MathF.Floor(lhs.Y));
        }

        /// <summary>
        /// round both components down
        /// </summary>
        public Vector2f Floor() => Floor(this);

        /// <summary>
        /// round both components up
        /// </summary>
        public static Vector2f Ceiling(Vector2f lhs)
        {
            return new Vector2f(MathF.Ceiling(lhs.X), MathF.Ceiling(lhs.Y));
        }

        /// <summary>
        /// round both components up
        /// </summary>
        public Vector2f Ceiling() => Ceiling(this);

        #endregion Floor / Ceiling

        #region Min / Max

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public static Vector2f Max(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(MathF.Max(lhs.X, rhs.X), MathF.Max(lhs.Y, rhs.Y));
        }

        /// <summary>
        /// returns element-wise max of two vectors
        /// </summary>
        public Vector2f Max(Vector2f rhs) => Max(this, rhs);

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public static Vector2f Min(Vector2f lhs, Vector2f rhs)
        {
            return new Vector2f(MathF.Min(lhs.X, rhs.X), MathF.Min(lhs.Y, rhs.Y));
        }

        /// <summary>
        /// returns element-wise min of two vectors
        /// </summary>
        public Vector2f Min(Vector2f rhs) => Min(this, rhs);

        #endregion Min / Max

        #region Polar / Cartesian

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// Theta is in radians.
        /// </summary>
        public static Vector2f ToCartesian(Vector2f lhs)
        {
            return new Vector2f(MathF.Cos(lhs.Theta) * lhs.R, MathF.Sin(lhs.Theta) * lhs.R);
        }

        /// <summary>
        /// treat this as polar coordinate (R, Theta), return cartesian equivalent (X, Y)
        /// </summary>
        public Vector2f ToCartesian() => ToCartesian(this);

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public static Vector2f ToPolar(Vector2f lhs)
        {
            return new Vector2f(lhs.Magnitude(), MathF.Atan2(lhs.Y, lhs.X));
        }

        /// <summary>
        /// treat this as cartesian coordinate (X, Y), return polar equivalent (R, Theta)
        /// </summary>
        public Vector2f ToPolar() => ToPolar(this);

        /// <summary>
        /// Get the angle of the vector in radians
        /// </summary>
        public static float AngleOf(Vector2f lhs)
        {
            return MathF.Atan2(lhs.Y, lhs.X);
        }

        /// <summary>
        /// Get the angle of the vector in radians
        /// </summary>
        public float AngleOf() => AngleOf(this);

        #endregion Polar / Cartesian

        #region Clamp

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public static Vector2f Clamp(Vector2f lhs, Vector2f min, Vector2f max)
        {
            return lhs.Max(min).Min(max);
        }

        /// <summary>
        /// clamp the components of this vector in between the 'element-wise' minimum and maximum of 2 other vectors
        /// </summary>
        public Vector2f Clamp(Vector2f min, Vector2f max) => Clamp(this, min, max);

        #endregion Clamp

        #region Lerp

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public static Vector2f Lerp(Vector2f lhs, Vector2f rhs, float t)
        {
            return new Vector2f
            (
                (1.0f - t) * lhs.X + t * rhs.X,
                (1.0f - t) * lhs.Y + t * rhs.Y
            );
        }

        /// <summary>
        /// linearly interpolate between this vector, and another vector, given normalised parameter 't'
        /// </summary>
        public Vector2f Lerp(Vector2f rhs, float t) => Lerp(this, rhs, t);

        #endregion Lerp

        #region Angle Between

        /// <summary>
        /// return the angle between two vectors in radians
        /// </summary>
        public static float AngleBetween(Vector2f lhs, Vector2f rhs)
        {
            var dot = Dot(lhs, rhs);
            var cosTheta = dot / (lhs.Magnitude() * rhs.Magnitude());
            var angle = MathF.Acos(cosTheta);
            return angle;
        }

        /// <summary>
        /// return the angle between two vectors in radians
        /// </summary>
        public float AngleBetwen(Vector2f rhs) => AngleBetween(this, rhs);

        #endregion Angle Between

        #region Projection

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public static Vector2f Project(Vector2f lhs, Vector2f rhs)
        {
            var scalarProjection = lhs.Dot(rhs) / rhs.Magnitude();
            var normal = rhs.Normal();
            var projection = normal * scalarProjection;
            return projection;
        }

        /// <summary>
        /// Calculate the projection of lhs onto rhs
        /// </summary>
        public Vector2f Project(Vector2f rhs) => Project(this, rhs);

        #endregion Projection

        #region Reflect

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>
        public static Vector2f Reflect(Vector2f lhs, Vector2f rhs)
        {
            var normal = rhs.Normal();
            var projection = lhs.Dot(normal) * normal;
            var reflection = lhs - 2.0f * projection;
            return reflection;
        }

        /// <summary>
        /// Reflect a vector (lhs) around another vector (rhs)
        /// </summary>
        public Vector2f Reflect(Vector2f rhs) => Reflect(this, rhs);

        #endregion Reflect

        #region Vector2 / Matrix2x2 Operations

        public Vector2f Multiply(Matrix2x2f rhs) => Matrix2x2f.Multiply(this, rhs);

        #endregion Vector2 / Matrix2x2 Operations

        #region Limit

        /// <summary>
        /// Limit the magnitude of a vector by a max value
        /// </summary>
        public static Vector2f LimitMagnitude(Vector2f lhs, float max)
        {
            return lhs.Magnitude() > max
                ? lhs.Normal() * max
                : lhs;
        }

        /// <summary>
        /// Limit the magnitude of a vector by a max value
        /// </summary>
        public Vector2f LimitMagnitude(float max) => LimitMagnitude(this, max);

        /// <summary>
        /// Limit the amount a vectors' direction can change. Returns a vector with a magnitude matching the desired
        /// vectors' magnitude and a direction limited to maxTheta.
        /// </summary>
        public static Vector2f LimitAngleDelta(Vector2f current, Vector2f desired, float maxTheta)
        {
            float angleDifference = TrigUtil.DeltaAngle(current.AngleOf(), desired.AngleOf());

            // Limit the angle change
            float newAngle = current.AngleOf() + Utils.Clamp(angleDifference, -maxTheta, maxTheta);
            var newVelocity = new Vector2f(MathF.Cos(newAngle), MathF.Sin(newAngle)) * desired.Magnitude();
            return newVelocity;
        }

        /// <summary>
        /// Limit the amount a vectors' direction can change. Returns a vector with a magnitude matching the desired
        /// vectors' magnitude and a direction limited to maxTheta.
        /// </summary>
        public Vector2f LimitAngleDelta(Vector2f desired, float maxTheta) => LimitAngleDelta(this, desired, maxTheta);

        #endregion Limit
    }
}