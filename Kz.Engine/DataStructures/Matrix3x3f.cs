using Kz.Engine.General;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// A Row-Major 3x3 Matrix
    ///
    ///     M11     M12     M13
    ///     M21     M22     M23
    ///     M31     M32     M33
    ///
    ///     Aliases
    ///     a b c
    ///     d e f
    ///     g h i
    ///     
    /// </summary>
    public struct Matrix3x3f
    {
        #region ctor

        private float[] _data = new float[9];

        public float M11
        { get { return _data[0]; } set { _data[0] = value; } }

        public float M12
        { get { return _data[1]; } set { _data[1] = value; } }

        public float M13
        { get { return _data[2]; } set { _data[2] = value; } }

        public float M21
        { get { return _data[3]; } set { _data[3] = value; } }

        public float M22
        { get { return _data[4]; } set { _data[4] = value; } }

        public float M23
        { get { return _data[5]; } set { _data[5] = value; } }

        public float M31
        { get { return _data[6]; } set { _data[6] = value; } }

        public float M32
        { get { return _data[7]; } set { _data[7] = value; } }

        public float M33
        { get { return _data[8]; } set { _data[8] = value; } }

        #region Aliases

        public float A => M11;

        public float B => M12;

        public float C => M13;

        public float D => M21;

        public float E => M22;

        public float F => M23;

        public float G => M31;

        public float H => M32;

        public float I => M33;

        #endregion Aliases

        public Matrix3x3f()
        {
            M11 = 0.0f;
            M12 = 0.0f;
            M13 = 0.0f;

            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix3x3f
        (
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;

            M21 = m21;
            M22 = m22;
            M23 = m23;

            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        public override string ToString()
        {
            var matrixString = MatrixUtil.PrintMatrix(_data, 3, 3);
            return matrixString;
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Matrix3x3f lhs, Matrix3x3f rhs)
        {
            return Utils.EpsilonEquals(lhs.M11, rhs.M11) && Utils.EpsilonEquals(lhs.M12, rhs.M12) && Utils.EpsilonEquals(lhs.M13, rhs.M13) &&
                   Utils.EpsilonEquals(lhs.M21, rhs.M21) && Utils.EpsilonEquals(lhs.M22, rhs.M22) && Utils.EpsilonEquals(lhs.M23, rhs.M23) &&
                   Utils.EpsilonEquals(lhs.M31, rhs.M31) && Utils.EpsilonEquals(lhs.M32, rhs.M32) && Utils.EpsilonEquals(lhs.M33, rhs.M33);
        }

        public bool AreEqual(Matrix3x3f rhs) => AreEqual(this, rhs);

        #endregion Equality

        #region Identity

        public static Matrix3x3f Identity()
        {
            return new Matrix3x3f
            (
                1.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 1.0f
            );
        }

        #endregion Identity

        #region Addition

        public static Matrix3x3f Add(Matrix3x3f lhs, Matrix3x3f rhs)
        {
            return new Matrix3x3f
            (
                lhs.M11 + rhs.M11, lhs.M12 + rhs.M12, lhs.M13 + rhs.M13,
                lhs.M21 + rhs.M21, lhs.M22 + rhs.M22, lhs.M23 + rhs.M23,
                lhs.M31 + rhs.M31, lhs.M32 + rhs.M32, lhs.M33 + rhs.M33
            );
        }

        public Matrix3x3f Add(Matrix3x3f rhs) => Add(this, rhs);

        public static Matrix3x3f operator +(Matrix3x3f lhs, Matrix3x3f rhs) => Add(lhs, rhs);

        #endregion Addition

        #region Subtraction

        public static Matrix3x3f Subtract(Matrix3x3f lhs, Matrix3x3f rhs)
        {
            return new Matrix3x3f
            (
                lhs.M11 - rhs.M11, lhs.M12 - rhs.M12, lhs.M13 - rhs.M13,
                lhs.M21 - rhs.M21, lhs.M22 - rhs.M22, lhs.M23 - rhs.M23,
                lhs.M31 - rhs.M31, lhs.M32 - rhs.M32, lhs.M33 - rhs.M33
            );
        }

        public Matrix3x3f Subtract(Matrix3x3f rhs) => Subtract(this, rhs);

        public static Matrix3x3f operator -(Matrix3x3f lhs, Matrix3x3f rhs) => Subtract(lhs, rhs);

        #endregion Subtraction

        #region Scalar Multiplication

        public static Matrix3x3f Multiply(Matrix3x3f lhs, float rhs)
        {
            return new Matrix3x3f
            (
                lhs.M11 * rhs, lhs.M12 * rhs, lhs.M13 * rhs,
                lhs.M21 * rhs, lhs.M22 * rhs, lhs.M23 * rhs,
                lhs.M31 * rhs, lhs.M32 * rhs, lhs.M33 * rhs
            );
        }

        public Matrix3x3f Multiply(float rhs) => Multiply(this, rhs);

        public static Matrix3x3f operator *(Matrix3x3f lhs, float rhs) => Multiply(lhs, rhs);

        public static Matrix3x3f operator *(float rhs, Matrix3x3f lhs) => Multiply(lhs, rhs);

        #endregion Scalar Multiplication

        #region Scalar Division

        public static Matrix3x3f Divide(Matrix3x3f lhs, float rhs)
        {
            return new Matrix3x3f
            (
                lhs.M11 / rhs, lhs.M12 / rhs, lhs.M13 / rhs,
                lhs.M21 / rhs, lhs.M22 / rhs, lhs.M23 / rhs,
                lhs.M31 / rhs, lhs.M32 / rhs, lhs.M33 / rhs
            );
        }

        public Matrix3x3f Divide(float rhs) => Divide(this, rhs);

        public static Matrix3x3f operator /(Matrix3x3f lhs, float rhs) => Divide(lhs, rhs);

        public static Matrix3x3f operator /(float rhs, Matrix3x3f lhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Matrix Multiplication (dot product)

        public static Matrix3x3f Multiply(Matrix3x3f lhs, Matrix3x3f rhs)
        {
            var c11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31;
            var c12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32;
            var c13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33;

            var c21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31;
            var c22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32;
            var c23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33;

            var c31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31;
            var c32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32;
            var c33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33;

            return new Matrix3x3f
            (
                c11, c12, c13,
                c21, c22, c23,
                c31, c32, c33
            );
        }

        public Matrix3x3f Multiply(Matrix3x3f rhs) => Multiply(this, rhs);

        public static Matrix3x3f operator *(Matrix3x3f lhs, Matrix3x3f rhs) => Multiply(lhs, rhs);

        #endregion Matrix Multiplication (dot product)

        #region Transpose

        public static Matrix3x3f Transpose(Matrix3x3f lhs)
        {
            return new Matrix3x3f
            (
                lhs.M11, lhs.M21, lhs.M31,
                lhs.M12, lhs.M22, lhs.M32,
                lhs.M13, lhs.M23, lhs.M33
            );
        }

        public Matrix3x3f Transpose() => Transpose(this);

        #endregion Transpose

        #region Determinant

        public static float Determinant(Matrix3x3f lhs)
        {
            var a = lhs.M11 * (lhs.M22 * lhs.M33 - lhs.M23 * lhs.M32);
            var b = lhs.M12 * (lhs.M21 * lhs.M33 - lhs.M23 * lhs.M31);
            var c = lhs.M13 * (lhs.M21 * lhs.M32 - lhs.M22 * lhs.M31);

            return a - b + c;
        }

        public float Determinant() => Determinant(this);

        #endregion Determinant

        #region Inverse

        public static Matrix3x3f? Inverse(Matrix3x3f lhs)
        {
            var determinant = lhs.Determinant();
            if (Utils.EpsilonEquals(determinant, 0.0f)) return null;

            var minors = new Matrix3x3f
            (
                (lhs.E * lhs.I - lhs.F * lhs.H), (lhs.D * lhs.I - lhs.F * lhs.G), (lhs.D * lhs.H - lhs.E * lhs.G),
                (lhs.B * lhs.I - lhs.C * lhs.H), (lhs.A * lhs.I - lhs.C * lhs.G), (lhs.A * lhs.H - lhs.B * lhs.G),
                (lhs.B * lhs.F - lhs.C * lhs.E), (lhs.A * lhs.F - lhs.C * lhs.D), (lhs.A * lhs.E - lhs.B * lhs.D)
            );

            var cofactors = new Matrix3x3f
            (
                minors.A, -minors.B, minors.C,
                -minors.D, minors.E, -minors.F,
                minors.G, -minors.H, minors.I
            );

            var adjugate = cofactors.Transpose();

            var inverse = (1.0f / determinant) * adjugate;
            return inverse;
        }

        public Matrix3x3f? Inverse() => Inverse(this);

        #endregion Inverse

        #region IsAllZeroes

        /// <summary>
        /// Returns true if all elements of the matrix are 0
        /// </summary>
        public bool IsAllZeroes()
        {
            bool allZeroes = true;
            for (var i = 0; i < 9; i++)
            {
                if (Utils.EpsilonEquals(_data[i], 0.0f))
                    continue;

                allZeroes = false;
            }
            return allZeroes;
        }

        #endregion IsAllZeroes

        #region Trace

        public static float Trace(Matrix3x3f lhs)
        {
            return lhs.M11 + lhs.M22 + lhs.M33;
        }

        public float Trace() => Trace(this);

        #endregion Trace

        #region Vector3 / Matrix3x3 Operations

        public static Vector3f Multiply(Vector3f lhs, Matrix3x3f rhs)
        {
            var a = rhs.A * lhs.X + rhs.B * lhs.Y + rhs.C * lhs.Z;
            var b = rhs.D * lhs.X + rhs.E * lhs.Y + rhs.F * lhs.Z;
            var c = rhs.G * lhs.X + rhs.H * lhs.Y + rhs.I * lhs.Z;
            return new Vector3f(a, b, c);
        }

        public Vector3f Multiply(Vector3f rhs) => Multiply(rhs, this);

        public static Vector3f operator *(Vector3f lhs, Matrix3x3f rhs) => Multiply(lhs, rhs);

        public static Vector3f operator *(Matrix3x3f lhs, Vector3f rhs) => Multiply(rhs, lhs);

        #endregion Vector3 / Matrix3x3 Operations

        #region Transformation Matrices

        /// <summary>
        /// Get an x-rotation matrix assuming origin is 0,0 (Roll)
        /// </summary>
        public static Matrix3x3f RotationX(float theta)
        {
            return new Matrix3x3f
            (
                1.0f, 0.0f, 0.0f,
                0.0f, MathF.Cos(theta), -MathF.Sin(theta),
                0.0f, MathF.Sin(theta), MathF.Cos(theta)
            );
        }

        /// <summary>
        /// Get an y-rotation matrix assuming origin is 0,0 (Pitch)
        /// </summary>
        public static Matrix3x3f RotationY(float theta)
        {
            return new Matrix3x3f
            (
                MathF.Cos(theta), 0.0f, MathF.Sin(theta),
                0.0f, 1.0f, 0.0f,
                -MathF.Sin(theta), 0.0f, MathF.Cos(theta)
            );
        }

        /// <summary>
        /// Get an z-rotation matrix assuming origin is 0,0 (Yaw)
        /// </summary>
        public static Matrix3x3f RotationZ(float theta)
        {
            return new Matrix3x3f
            (
                MathF.Cos(theta), -MathF.Sin(theta), 0.0f,
                MathF.Sin(theta), MathF.Cos(theta), 0.0f,
                0.0f, 0.0f, 1.0f
            );
        }

        /// <summary>
        /// Get a scaling matrix assuming origin is 0,0
        /// </summary>
        public static Matrix3x3f Scaling(float xScale, float yScale, float zScale)
        {
            return new Matrix3x3f
            (
                xScale, 0.0f, 0.0f,
                0.0f, yScale, 0.0f,
                0.0f, 0.0f, zScale
            );
        }

        /// <summary>
        /// To use:
        ///     1) create a Vector3f (x, y, 1) from the Vector2f (x, y)
        ///     2) Multiply the Vector3f with the translation matrix
        ///     3) pull out the Vector3f x and y components back into a Vector2f
        /// </summary>
        public static Matrix3x3f Translation(float xTranslate, float yTranslate)
        {
            return new Matrix3x3f
            (
                1.0f, 0.0f, xTranslate,
                0.0f, 1.0f, yTranslate,
                0.0f, 0.0f, 1.0f
            );
        }

        #endregion Transformation Matrices
    }
}