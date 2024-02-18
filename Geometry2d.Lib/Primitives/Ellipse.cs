using Kz.DataStructures;

namespace Geometry2d.Lib.Primitives
{
    /// <summary>
    /// Represents an Ellipse
    ///
    /// ((x * x) / (a * a)) + ((y * y) / (b * b)) = 1
    /// </summary>
    public class Ellipse : IShape
    {
        #region ctor

        public Vector2f Origin { get; set; }

        /// <summary>
        /// The semi-major axis length (e.g radius of longest side)
        /// </summary>
        public float A { get; set; }

        /// <summary>
        /// The semi-major axis length (e.g radius of longest side)
        /// </summary>
        public float H => A;

        /// <summary>
        /// The semi-major axis length (e.g radius of longest side)
        /// </summary>
        public float SemiMajorAxis => A;

        /// <summary>
        /// The semi-minor axis length (e.g radius of narrowest side)
        /// </summary>
        public float B { get; set; }

        /// <summary>
        /// The semi-minor axis length (e.g radius of narrowest side)
        /// </summary>
        public float V => B;

        /// <summary>
        /// The semi-minor axis length (e.g radius of narrowest side)
        /// </summary>
        public float SemiMinorAxis => B;

        public Ellipse()
        {
            Origin = Vector2f.Zero;
            A = 0;
            B = 0;            
        }

        public Ellipse(Vector2f origin, float a, float b, float theta = 0.0f)
        {
            Origin = origin;
            A = a;
            B = b;            
        }

        public Ellipse(float x, float y, float a, float b, float theta = 0.0f)
        {
            Origin= new Vector2f(x, y);
            A = a;
            B = b;            
        }

        public override string ToString()
        {
            return $"Ellipse [{Origin}, {A}, {B}]";
        }

        #endregion ctor

        #region Properties of an Ellipse

        /// <summary>
        /// Calculates the area of an ellipse
        /// </summary>
        public static float Area(Ellipse lhs)
        {
            return MathF.PI * lhs.A * lhs.B;
        }

        /// <summary>
        /// Calculates the area of an ellipse
        /// </summary>
        public float Area() => Area(this);

        /// <summary>
        /// Calculate Circumference of an ellipse using Ramanujan's Approximation
        /// </summary>
        public static float Circumference(Ellipse lhs)
        {
            var h = MathF.Pow(lhs.A - lhs.B, 2.0f) / MathF.Pow(lhs.A + lhs.B, 2.0f);
            return MathF.PI * (lhs.A + lhs.B) * (1.0f + (3.0f * h) / (10.0f + MathF.Sqrt(4.0f - 3.0f * h)));
        }

        /// <summary>
        /// Calculate Circumference of an ellipse using Ramanujan's Approximation
        /// </summary>
        public float Circumference() => Circumference(this);

        /// <summary>
        /// Calculates the Eccentricity (e) of an ellipse. e = 0 is a circle. 0 < e < 1
        ///
        /// e = c / a
        /// c is the distance from the center to either focus
        /// </summary>
        public static float Eccentricity(Ellipse lhs)
        {
            return 0.0f;
        }

        /// <summary>
        /// Calculates the Eccentricity (e) of an ellipse. e = 0 is a circle. 0 < e < 1
        ///
        /// e = c / a
        /// c is the distance from the center to either focus
        /// </summary>
        public float Eccentricity() => Eccentricity(this);

        /// <summary>
        /// Calculates the Eccentricity (e) of an ellipse. e = 0 is a circle. 0 < e < 1
        ///
        /// e = c / a
        /// c is the distance from the center to either focus
        /// </summary>
        public static float E(Ellipse lhs) => Eccentricity(lhs);

        /// <summary>
        /// The length of the major axis (2a)
        /// </summary>
        public static float MajorAxisLength(Ellipse lhs)
        {
            return 2.0f * lhs.A;
        }

        /// <summary>
        /// The length of the major axis (2a)
        /// </summary>
        public float MajorAxisLength() => MajorAxisLength(this);

        /// <summary>
        /// The length of the minor axis (2b)
        /// </summary>
        public static float MinorAxisLength(Ellipse lhs)
        {
            return 2.0f * lhs.B;
        }

        /// <summary>
        /// The length of the minor axis (2b)
        /// </summary>
        public float MinorAxisLength() => MinorAxisLength(this);

        /// <summary>
        /// Calculates the focal distance (the distance from center to a focus)
        /// </summary>        
        public static float FocalDistance(Ellipse lhs)
        {
            return MathF.Sqrt(lhs.A * lhs.A - lhs.B * lhs.B);
        }

        /// <summary>
        /// Calculates the focal distance (the distance from center to a focus)
        /// </summary>        
        public float FocalDistance() => FocalDistance(this);

        /// <summary>
        /// Calculates and returns the Foci of the ellipse
        /// </summary>        
        public static (Vector2f Focus1, Vector2f Focus2) Foci(Ellipse lhs)
        {
            var c = FocalDistance(lhs);
            
            var focus1 = new Vector2f(lhs.Origin.X + c, lhs.Origin.Y);            
            var focus2 = new Vector2f(lhs.Origin.X - c, lhs.Origin.Y);
            
            return (focus1, focus2);
        }

        /// <summary>
        /// Calculates and returns the Foci of the ellipse
        /// </summary>        
        public (Vector2f Focus1, Vector2f Focus2) Foci() => Foci(this);

        #endregion Properties of an Ellipse
    }
}