namespace Kz.Engine.DataStructures
{
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

        public static Vector3f Divide(Vector3f lhs, float rhs)
        {
            return new Vector3f(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public Vector3f Divide(float rhs) => Divide(this, rhs);

        public static Vector3f operator /(Vector3f lhs, float rhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Dot Product

        public static float Dot(Vector3f lhs, Vector3f rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        public float Dot(Vector3f rhs) => Dot(this, rhs);

        #endregion Dot Product

        #region Magnitude

        public static float Magnitude(Vector3f lhs)
        {
            return MathF.Sqrt(lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z);
        }

        public float Magnitude() => Magnitude(this);

        public static float Magnitude2(Vector3f lhs)
        {
            return lhs.X * lhs.X + lhs.Y * lhs.Y + lhs.Z * lhs.Z;
        }

        public float Magnitude2() => Magnitude2(this);

        #endregion Magnitude

        #region Normal

        public static Vector3f Normal(Vector3f lhs)
        {
            var magnitude = lhs.Magnitude();
            var normal = lhs / magnitude;
            return normal;
        }

        public Vector3f Normal() => Normal(this);

        #endregion Normal
    }
}