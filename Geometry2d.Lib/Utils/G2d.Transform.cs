using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region TRANSLATE

        public static void Translate(IShape lhs, Vector2 rhs)
        {
            switch (lhs)
            {
                case Vector2 x: Translate(x, rhs); break;                
                case Line x: Translate(x, rhs); break;
                case Rectangle x: Translate(x, rhs); break;
                case Circle x: Translate(x, rhs); break;
                case Triangle x: Translate(x, rhs); break;
                case Polygon x: Translate(x, rhs); break;
                case Ray x: Translate(x, rhs); break;

            };
        }

        public static void Translate(Vector2 lhs, Vector2 rhs)
        {
            lhs += rhs;
        }

        public static void Translate(Line lhs, Vector2 rhs)
        {
            lhs.Start += rhs;
            lhs.End += rhs;
        }

        public static void Translate(Rectangle lhs, Vector2 rhs)
        {
            lhs.Position += rhs;
        }

        public static void Translate(Circle lhs, Vector2 rhs)
        {
            lhs.Origin += rhs;
        }

        public static void Translate(Triangle lhs, Vector2 rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Polygon lhs, Vector2 rhs)
        {
            Translate(lhs.Vertices, rhs);
        }

        public static void Translate(Ray lhs, Vector2 rhs)
        {
            lhs.Origin += rhs;
        }

        private static void Translate(IList<Vector2> vertices, Vector2 rhs)
        {
            for(var i = 0; i < vertices.Count(); i++)
            {
                vertices[i] += rhs;
            }
        }

        #endregion TRANSLATE

        #region ROTATE

        public static void Rotate(IShape lhs)
        {
            switch (lhs)
            {
                case Vector2 x: Rotate(x); break;
                case Line x: Rotate(x); break;
                case Rectangle x: Rotate(x); break;
                case Circle x: Rotate(x); break;
                case Triangle x: Rotate(x); break;
                case Polygon x: Rotate(x); break;
                case Ray x: Rotate(x); break;

            };
        }

        public static void Rotate(Vector2 lhs)
        {

        }

        public static void Rotate(Line lhs)
        {

        }

        public static void Rotate(Rectangle lhs)
        {

        }

        public static void Rotate(Circle lhs)
        {

        }

        public static void Rotate(Triangle lhs)
        {

        }

        public static void Rotate(Polygon lhs)
        {

        }

        public static void Rotate(Ray lhs)
        {

        }

        #endregion ROTATE

        #region SCALE

        public static void Scale(IShape lhs)
        {
            switch (lhs)
            {
                case Vector2 x: Scale(x); break;
                case Line x: Scale(x); break;
                case Rectangle x: Scale(x); break;
                case Circle x: Scale(x); break;
                case Triangle x: Scale(x); break;
                case Polygon x: Scale(x); break;               
            };
        }

        public static void Scale(Vector2 lhs)
        {

        }

        public static void Scale(Line lhs)
        {

        }

        public static void Scale(Rectangle lhs)
        {

        }

        public static void Scale(Circle lhs)
        {

        }

        public static void Scale(Triangle lhs)
        {

        }

        public static void Scale(Polygon lhs)
        {

        }

        #endregion SCALE
    }
}
