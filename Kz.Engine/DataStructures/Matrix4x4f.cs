using Kz.Engine.General;

namespace Kz.Engine.DataStructures
{
    /// <summary>
    /// A Row-Major 4x4 Matrix
    ///
    ///     M11     M12     M13     M14         M11     M12     M13     M14
    ///     M21     M22     M23     M24         M21     M22     M23     M24
    ///     M31     M32     M33     M34         M31     M32     M33     M34
    ///     M41     M42     M43     M44         M41     M42     M43     M44
    ///
    ///     Aliases
    ///     a b c d
    ///     e f g h
    ///     i j k l
    ///     m n o p
    ///
    /// </summary>
    public class Matrix4x4f
    {
        #region ctor

        private float[] _data = new float[16];

        public float M11
        { get { return _data[0]; } set { _data[0] = value; } }

        public float M12
        { get { return _data[1]; } set { _data[1] = value; } }

        public float M13
        { get { return _data[2]; } set { _data[2] = value; } }

        public float M14
        { get { return _data[3]; } set { _data[3] = value; } }

        public float M21
        { get { return _data[4]; } set { _data[4] = value; } }

        public float M22
        { get { return _data[5]; } set { _data[5] = value; } }

        public float M23
        { get { return _data[6]; } set { _data[6] = value; } }

        public float M24
        { get { return _data[7]; } set { _data[7] = value; } }

        public float M31
        { get { return _data[8]; } set { _data[8] = value; } }

        public float M32
        { get { return _data[9]; } set { _data[9] = value; } }

        public float M33
        { get { return _data[10]; } set { _data[10] = value; } }

        public float M34
        { get { return _data[11]; } set { _data[11] = value; } }

        public float M41
        { get { return _data[12]; } set { _data[12] = value; } }

        public float M42
        { get { return _data[13]; } set { _data[13] = value; } }

        public float M43
        { get { return _data[14]; } set { _data[14] = value; } }

        public float M44
        { get { return _data[15]; } set { _data[15] = value; } }

        #region Aliases

        public float A => M11;

        public float B => M12;

        public float C => M13;

        public float D => M14;

        public float E => M21;

        public float F => M22;

        public float G => M23;

        public float H => M24;

        public float I => M31;

        public float J => M32;

        public float K => M33;

        public float L => M34;

        public float M => M41;

        public float N => M42;

        public float O => M43;

        public float P => M44;

        #endregion Aliases

        public Matrix4x4f()
        {
            M11 = 0.0f;
            M12 = 0.0f;
            M13 = 0.0f;
            M14 = 0.0f;

            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;
            M24 = 0.0f;

            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
            M34 = 0.0f;

            M41 = 0.0f;
            M42 = 0.0f;
            M43 = 0.0f;
            M44 = 0.0f;
        }

        public Matrix4x4f
        (
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44
        )
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;

            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;

            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;

            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public override string ToString()
        {
            var matrixString = MatrixUtil.PrintMatrix(_data, 4, 4);
            return matrixString;
        }

        #endregion ctor

        #region Equality

        public static bool AreEqual(Matrix4x4f lhs, Matrix4x4f rhs)
        {
            return Utils.EpsilonEquals(lhs.M11, rhs.M11) && Utils.EpsilonEquals(lhs.M12, rhs.M12) && Utils.EpsilonEquals(lhs.M13, rhs.M13) && Utils.EpsilonEquals(lhs.M14, rhs.M14) &&
                   Utils.EpsilonEquals(lhs.M21, rhs.M21) && Utils.EpsilonEquals(lhs.M22, rhs.M22) && Utils.EpsilonEquals(lhs.M23, rhs.M23) && Utils.EpsilonEquals(lhs.M24, rhs.M24) &&
                   Utils.EpsilonEquals(lhs.M31, rhs.M31) && Utils.EpsilonEquals(lhs.M32, rhs.M32) && Utils.EpsilonEquals(lhs.M33, rhs.M33) && Utils.EpsilonEquals(lhs.M34, rhs.M34) &&
                   Utils.EpsilonEquals(lhs.M41, rhs.M41) && Utils.EpsilonEquals(lhs.M42, rhs.M42) && Utils.EpsilonEquals(lhs.M43, rhs.M43) && Utils.EpsilonEquals(lhs.M44, rhs.M44);
        }

        #endregion Equality

        #region Identity

        public static Matrix4x4f Identity()
        {
            return new Matrix4x4f
            (
                1.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 1.0f
            );
        }

        #endregion Identity

        #region Addition

        public static Matrix4x4f Add(Matrix4x4f lhs, Matrix4x4f rhs)
        {
            return new Matrix4x4f
            (
                lhs.M11 + rhs.M11, lhs.M12 + rhs.M12, lhs.M13 + rhs.M13, lhs.M14 + rhs.M14,
                lhs.M21 + rhs.M21, lhs.M22 + rhs.M22, lhs.M23 + rhs.M23, lhs.M24 + rhs.M24,
                lhs.M31 + rhs.M31, lhs.M32 + rhs.M32, lhs.M33 + rhs.M33, lhs.M34 + rhs.M34,
                lhs.M41 + rhs.M41, lhs.M42 + rhs.M42, lhs.M43 + rhs.M43, lhs.M44 + rhs.M44
            );
        }

        public Matrix4x4f Add(Matrix4x4f rhs) => Add(this, rhs);

        public static Matrix4x4f operator +(Matrix4x4f lhs, Matrix4x4f rhs) => Add(lhs, rhs);

        #endregion Addition

        #region Subtraction

        public static Matrix4x4f Subtract(Matrix4x4f lhs, Matrix4x4f rhs)
        {
            return new Matrix4x4f
            (
                lhs.M11 - rhs.M11, lhs.M12 - rhs.M12, lhs.M13 - rhs.M13, lhs.M14 - rhs.M14,
                lhs.M21 - rhs.M21, lhs.M22 - rhs.M22, lhs.M23 - rhs.M23, lhs.M24 - rhs.M24,
                lhs.M31 - rhs.M31, lhs.M32 - rhs.M32, lhs.M33 - rhs.M33, lhs.M34 - rhs.M34,
                lhs.M41 - rhs.M41, lhs.M42 - rhs.M42, lhs.M43 - rhs.M43, lhs.M44 - rhs.M44
            );
        }

        public Matrix4x4f Subtract(Matrix4x4f rhs) => Subtract(this, rhs);

        public static Matrix4x4f operator -(Matrix4x4f lhs, Matrix4x4f rhs) => Subtract(lhs, rhs);

        #endregion Subtraction

        #region Scalar Multiplication

        public static Matrix4x4f Multiply(Matrix4x4f lhs, float rhs)
        {
            return new Matrix4x4f
            (
                lhs.M11 * rhs, lhs.M12 * rhs, lhs.M13 * rhs, lhs.M14 * rhs,
                lhs.M21 * rhs, lhs.M22 * rhs, lhs.M23 * rhs, lhs.M24 * rhs,
                lhs.M31 * rhs, lhs.M32 * rhs, lhs.M33 * rhs, lhs.M34 * rhs,
                lhs.M41 * rhs, lhs.M42 * rhs, lhs.M43 * rhs, lhs.M44 * rhs
            );
        }

        public Matrix4x4f Multiply(float rhs) => Multiply(this, rhs);

        public static Matrix4x4f operator *(Matrix4x4f lhs, float rhs) => Multiply(lhs, rhs);

        public static Matrix4x4f operator *(float lhs, Matrix4x4f rhs) => Multiply(rhs, lhs);

        #endregion Scalar Multiplication

        #region Scalar Division

        public static Matrix4x4f Divide(Matrix4x4f lhs, float rhs)
        {
            return new Matrix4x4f
            (
                lhs.M11 / rhs, lhs.M12 / rhs, lhs.M13 / rhs, lhs.M14 / rhs,
                lhs.M21 / rhs, lhs.M22 / rhs, lhs.M23 / rhs, lhs.M24 / rhs,
                lhs.M31 / rhs, lhs.M32 / rhs, lhs.M33 / rhs, lhs.M34 / rhs,
                lhs.M41 / rhs, lhs.M42 / rhs, lhs.M43 / rhs, lhs.M44 / rhs
            );
        }

        public Matrix4x4f Divide(float rhs) => Divide(this, rhs);

        public static Matrix4x4f operator /(Matrix4x4f lhs, float rhs) => Divide(lhs, rhs);

        #endregion Scalar Division

        #region Matrix Multiplication (dot product)

        public static Matrix4x4f Multiply(Matrix4x4f lhs, Matrix4x4f rhs)
        {
            var c11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31 + lhs.M14 * rhs.M41;
            var c12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32 + lhs.M14 * rhs.M42;
            var c13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33 + lhs.M14 * rhs.M43;
            var c14 = lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34 + lhs.M14 * rhs.M44;

            var c21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31 + lhs.M24 * rhs.M41;
            var c22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32 + lhs.M24 * rhs.M42;
            var c23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33 + lhs.M24 * rhs.M43;
            var c24 = lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34 + lhs.M24 * rhs.M44;

            var c31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31 + lhs.M34 * rhs.M41;
            var c32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32 + lhs.M34 * rhs.M42;
            var c33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33 + lhs.M34 * rhs.M43;
            var c34 = lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34 + lhs.M34 * rhs.M44;

            var c41 = lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31 + lhs.M44 * rhs.M41;
            var c42 = lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32 + lhs.M44 * rhs.M42;
            var c43 = lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33 + lhs.M44 * rhs.M43;
            var c44 = lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34 + lhs.M44 * rhs.M44;

            return new Matrix4x4f
            (
                c11, c12, c13, c14,
                c21, c22, c23, c24,
                c31, c32, c33, c34,
                c41, c42, c43, c44
            );
        }

        public Matrix4x4f Multiply(Matrix4x4f rhs) => Multiply(this, rhs);

        public static Matrix4x4f operator *(Matrix4x4f lhs, Matrix4x4f rhs) => Multiply(lhs, rhs);

        #endregion Matrix Multiplication (dot product)

        #region Transpose

        public static Matrix4x4f Transpose(Matrix4x4f lhs)
        {
            return new Matrix4x4f
            (
                lhs.M11, lhs.M21, lhs.M31, lhs.M41,
                lhs.M12, lhs.M22, lhs.M32, lhs.M42,
                lhs.M13, lhs.M23, lhs.M33, lhs.M43,
                lhs.M14, lhs.M24, lhs.M34, lhs.M44
            );
        }

        public Matrix4x4f Transpose() => Transpose(this);

        #endregion Transpose

        #region Determinant

        public static float Determinant(Matrix4x4f lhs)
        {
            var ma = new Matrix3x3f
            (
                lhs.F, lhs.G, lhs.H,
                lhs.J, lhs.K, lhs.L,
                lhs.N, lhs.O, lhs.P
            );
            var detMa = ma.Determinant();

            var mb = new Matrix3x3f
            (
                lhs.E, lhs.G, lhs.H,
                lhs.I, lhs.K, lhs.L,
                lhs.M, lhs.O, lhs.P
            );
            var detMb = mb.Determinant();

            var mc = new Matrix3x3f
            (
                lhs.E, lhs.F, lhs.H,
                lhs.I, lhs.J, lhs.L,
                lhs.M, lhs.N, lhs.P
            );
            var detMc = mc.Determinant();

            var md = new Matrix3x3f
            (
                lhs.E, lhs.F, lhs.G,
                lhs.I, lhs.J, lhs.K,
                lhs.M, lhs.N, lhs.O
            );
            var detMd = md.Determinant();

            var determinant = lhs.A * detMa - lhs.B * detMb + lhs.C * detMc - lhs.D * detMd;
            return determinant;
        }

        public float Determinant() => Determinant(this);

        #endregion Determinant

        #region Inverse

        public static Matrix4x4f? Inverse(Matrix4x4f m)
        {
            var A2323 = m.M33 * m.M44 - m.M34 * m.M43;
            var A1323 = m.M32 * m.M44 - m.M34 * m.M42;
            var A1223 = m.M32 * m.M43 - m.M33 * m.M42;
            var A0323 = m.M31 * m.M44 - m.M34 * m.M41;
            var A0223 = m.M31 * m.M43 - m.M33 * m.M41;
            var A0123 = m.M31 * m.M42 - m.M32 * m.M41;
            var A2313 = m.M23 * m.M44 - m.M24 * m.M43;
            var A1313 = m.M22 * m.M44 - m.M24 * m.M42;
            var A1213 = m.M22 * m.M43 - m.M23 * m.M42;
            var A2312 = m.M23 * m.M34 - m.M24 * m.M33;
            var A1312 = m.M22 * m.M34 - m.M24 * m.M32;
            var A1212 = m.M22 * m.M33 - m.M23 * m.M32;
            var A0313 = m.M21 * m.M44 - m.M24 * m.M41;
            var A0213 = m.M21 * m.M43 - m.M23 * m.M41;
            var A0312 = m.M21 * m.M34 - m.M24 * m.M31;
            var A0212 = m.M21 * m.M33 - m.M23 * m.M31;
            var A0113 = m.M21 * m.M42 - m.M22 * m.M41;
            var A0112 = m.M21 * m.M32 - m.M22 * m.M31;

            var det = m.M11 * (m.M22 * A2323 - m.M23 * A1323 + m.M24 * A1223)
                - m.M12 * (m.M21 * A2323 - m.M23 * A0323 + m.M24 * A0223)
                + m.M13 * (m.M21 * A1323 - m.M22 * A0323 + m.M24 * A0123)
                - m.M14 * (m.M21 * A1223 - m.M22 * A0223 + m.M23 * A0123);
            if (det == 0) return null;

            det = 1.0f / det;
            
            return new Matrix4x4f
            (
                det * (m.M22 * A2323 - m.M23 * A1323 + m.M24 * A1223),
                det * -(m.M12 * A2323 - m.M13 * A1323 + m.M14 * A1223),
                det * (m.M12 * A2313 - m.M13 * A1313 + m.M14 * A1213),
                det * -(m.M12 * A2312 - m.M13 * A1312 + m.M14 * A1212),
                det * -(m.M21 * A2323 - m.M23 * A0323 + m.M24 * A0223),
                det * (m.M11 * A2323 - m.M13 * A0323 + m.M14 * A0223),
                det * -(m.M11 * A2313 - m.M13 * A0313 + m.M14 * A0213),
                det * (m.M11 * A2312 - m.M13 * A0312 + m.M14 * A0212),
                det * (m.M21 * A1323 - m.M22 * A0323 + m.M24 * A0123),
                det * -(m.M11 * A1323 - m.M12 * A0323 + m.M14 * A0123),
                det * (m.M11 * A1313 - m.M12 * A0313 + m.M14 * A0113),
                det * -(m.M11 * A1312 - m.M12 * A0312 + m.M14 * A0112),
                det * -(m.M21 * A1223 - m.M22 * A0223 + m.M23 * A0123),
                det * (m.M11 * A1223 - m.M12 * A0223 + m.M13 * A0123),
                det * -(m.M11 * A1213 - m.M12 * A0213 + m.M13 * A0113),
                det * (m.M11 * A1212 - m.M12 * A0212 + m.M13 * A0112)
            );
        }

        public Matrix4x4f Inverse() => Inverse(this);

        #endregion Inverse

        #region IsAllZeroes

        /// <summary>
        /// Returns true if all elements of the matrix are 0
        /// </summary>
        public bool IsAllZeroes()
        {
            bool allZeroes = true;
            for (var i = 0; i < 16; i++)
            {
                if (Utils.EpsilonEquals(_data[i], 0.0f))
                    continue;

                allZeroes = false;
            }
            return allZeroes;
        }

        #endregion IsAllZeroes

        #region Trace

        public static float Trace(Matrix4x4f lhs)
        {
            return lhs.M11 + lhs.M22 + lhs.M33 + lhs.M44;
        }

        public float Trace() => Trace(this);

        #endregion Trace

        #region Vector4 / Matrix4x4 Operations

        public static Vector4f Multiply(Vector4f lhs, Matrix4x4f rhs)
        {
            var a = lhs.X * rhs.M11 + lhs.Y * rhs.M21 + lhs.Z * rhs.M31 + lhs.W * rhs.M41;
            var b = lhs.X * rhs.M12 + lhs.Y * rhs.M22 + lhs.Z * rhs.M32 + lhs.W * rhs.M42;
            var c = lhs.X * rhs.M13 + lhs.Y * rhs.M23 + lhs.Z * rhs.M33 + lhs.W * rhs.M43;
            var d = lhs.X * rhs.M14 + lhs.Y * rhs.M24 + lhs.Z * rhs.M34 + lhs.W * rhs.M44;
            return new Vector4f(a, b, c, d);
        }

        public Vector4f Multiply(Vector4f rhs) => Multiply(rhs, this);

        public static Vector4f operator *(Vector4f lhs, Matrix4x4f rhs) => Multiply(lhs, rhs);

        public static Vector4f operator *(Matrix4x4f lhs, Vector4f rhs) => Multiply(rhs, lhs);

        #endregion Vector4 / Matrix4x4 Operations
    }
}