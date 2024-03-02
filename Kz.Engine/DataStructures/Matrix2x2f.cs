using Kz.Engine.General;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// A Row-Major 2x2 Matrix
    ///
    ///     M11 M12
    ///     M21 M22
    ///
    /// </summary>
    public class Matrix2x2f
    {
        #region ctor

        private float[] _data = new float[4];

        public float M11
        { get { return _data[0]; } set { _data[0] = value; } }

        public float M12
        { get { return _data[1]; } set { _data[1] = value; } }

        public float M21
        { get { return _data[2]; } set { _data[2] = value; } }

        public float M22
        { get { return _data[3]; } set { _data[3] = value; } }

        public Matrix2x2f()
        {
            M11 = 0.0f;
            M12 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
        }

        public Matrix2x2f(float m11, float m12, float m21, float m22)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
        }

        public override string ToString()
        {
            var matrixString = MatrixUtil.PrintMatrix(_data, 2, 2);
            return matrixString;
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Matrix2x2f lhs, Matrix2x2f rhs)
        {
            return Utils.EpsilonEquals(lhs.M11, rhs.M11) && Utils.EpsilonEquals(lhs.M12, rhs.M12) &&
                   Utils.EpsilonEquals(lhs.M21, rhs.M21) && Utils.EpsilonEquals(lhs.M22, rhs.M22);
        }

        public bool AreEqual(Matrix2x2f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Addition

        public static Matrix2x2f Add(Matrix2x2f lhs, Matrix2x2f rhs)
        {
            return new Matrix2x2f
            (
                lhs.M11 + rhs.M11, lhs.M12 + rhs.M12,
                lhs.M21 + rhs.M21, lhs.M22 + rhs.M22
            );
        }

        public Matrix2x2f Add(Matrix2x2f rhs) => Add(this, rhs);

        public static Matrix2x2f operator +(Matrix2x2f lhs, Matrix2x2f rhs) => Add(lhs, rhs);

        #endregion Addition

        #region Subtraction

        public static Matrix2x2f Subtract(Matrix2x2f lhs, Matrix2x2f rhs)
        {
            return new Matrix2x2f
            (
                lhs.M11 - rhs.M11, lhs.M12 - rhs.M12,
                lhs.M21 - rhs.M21, lhs.M22 - rhs.M22
            );
        }

        public Matrix2x2f Subtract(Matrix2x2f rhs) => Subtract(this, rhs);

        public static Matrix2x2f operator -(Matrix2x2f lhs, Matrix2x2f rhs) => Subtract(lhs, rhs);

        #endregion Subtraction

        #region Scalar Multiplication

        public static Matrix2x2f Multiply(Matrix2x2f lhs, float rhs)
        {
            return new Matrix2x2f
            (
                lhs.M11 * rhs, lhs.M12 * rhs,
                lhs.M21 * rhs, lhs.M22 * rhs
            );
        }

        public Matrix2x2f Multiply(float rhs) => Multiply(this, rhs);

        public static Matrix2x2f operator *(Matrix2x2f lhs, float rhs) => Multiply(lhs, rhs);

        public static Matrix2x2f operator *(float rhs, Matrix2x2f lhs) => Multiply(lhs, rhs);

        #endregion Scalar Multiplication

        #region Scalar Division

        public static Matrix2x2f Divide(Matrix2x2f lhs, float rhs)
        {
            return new Matrix2x2f
            (
                lhs.M11 / rhs, lhs.M12 / rhs,
                lhs.M21 / rhs, lhs.M22 / rhs
            );
        }

        public Matrix2x2f Divide(float rhs) => Divide(this, rhs);

        public static Matrix2x2f operator /(Matrix2x2f lhs, float rhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Matrix Multiplication (dot product)

        public static Matrix2x2f Multiply(Matrix2x2f lhs, Matrix2x2f rhs)
        {
            var a = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21;
            var b = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22;
            var c = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21;
            var d = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22;

            return new Matrix2x2f
            (
                a, b,
                c, d
            );
        }

        public Matrix2x2f Multiply(Matrix2x2f rhs) => Multiply(this, rhs);

        public static Matrix2x2f operator *(Matrix2x2f lhs, Matrix2x2f rhs) => Multiply(lhs, rhs);

        #endregion Matrix Multiplication (dot product)

        #region Transpose

        public static Matrix2x2f Transpose(Matrix2x2f lhs)
        {
            return new Matrix2x2f
            (
                lhs.M11, lhs.M21,
                lhs.M12, lhs.M22
            );
        }

        public Matrix2x2f Transpose() => Transpose(this);

        #endregion Transpose

        #region Determinant

        public static float Determinant(Matrix2x2f lhs)
        {
            return lhs.M11 * lhs.M22 - lhs.M12 * lhs.M21;
        }

        public float Determinant() => Determinant(this);

        #endregion Determinant

        #region Inverse

        public static Matrix2x2f? Inverse(Matrix2x2f lhs)
        {
            var determinant = lhs.Determinant();
            if (Utils.EpsilonEquals(determinant, 0.0f)) return null;

            var temp = new Matrix2x2f
            (
                lhs.M22, -lhs.M12,
                -lhs.M21, lhs.M11
            );

            return (1.0f / determinant) * temp;
        }

        public Matrix2x2f? Inverse() => Inverse(this);

        #endregion Inverse

        #region Rank

        public static int Rank(Matrix2x2f lhs)
        {
            if (Utils.EpsilonEquals(lhs.M11, 0.0f) && Utils.EpsilonEquals(lhs.M12, 0.0f) &&
                Utils.EpsilonEquals(lhs.M21, 0.0f) && Utils.EpsilonEquals(lhs.M22, 0.0f)) return 0;

            var determinant = lhs.Determinant();
            if (Utils.EpsilonEquals(determinant, 0.0f)) return 1;

            return 2;
        }

        public int Rank() => Rank(this);

        #endregion Rank

        #region Eigenvalues / Eigenvectors

        // TODO

        #endregion Eigenvalues / Eigenvectors

        #region Trace

        public static float Trace(Matrix2x2f lhs)
        {
            return lhs.M11 + lhs.M22;
        }

        public float Trace() => Trace(this);

        #endregion Trace

        #region Vector2 / Matrix Operations

        public static Vector2f Multiply(Matrix2x2f lhs, Vector2f rhs)
        {
            var a = lhs.M11 * rhs.X + lhs.M12 * rhs.Y;
            var b = lhs.M21 * rhs.X + lhs.M22 * rhs.Y;
            return new Vector2f(a, b);
        }

        public Vector2f Multiply(Vector2f rhs) => Multiply(this, rhs);

        public static Vector2f operator *(Matrix2x2f lhs, Vector2f rhs) => Multiply(lhs, rhs);
        
        public static Vector2f operator *(Vector2f lhs, Matrix2x2f rhs) => Multiply(rhs, lhs);

        #endregion Vector2 / Matrix Operations

        #region Transformation Matrices

        /// <summary>
        /// Get a rotation matrix assuming origin is 0,0
        /// </summary>        
        public static Matrix2x2f Rotation(float theta)
        {
            return new Matrix2x2f
            (
                MathF.Cos(theta), -MathF.Sin(theta),
                MathF.Sin(theta), MathF.Cos(theta)
            );
        }

        /// <summary>
        /// Get a scaling matrix assuming origin is 0,0
        /// </summary>        
        public static Matrix2x2f Scaling(float xScale, float yScale)
        {
            return new Matrix2x2f
            (
                xScale, 0,
                0, yScale
            );
        }

        #endregion Transformation Matrices
    }
}