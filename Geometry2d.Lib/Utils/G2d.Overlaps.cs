using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region IShape OVERLAPS IShape

        public static bool Overlaps(IShape lhs, IShape rhs)
        {
            return lhs switch
            {
                Vector2 v => rhs switch
                {
                    Vector2 v2 => Intersects(v, v2).Count > 0,
                    Line l2 => Intersects(v, l2).Count > 0,
                    Rectangle r2 => Intersects(v, r2).Count > 0,
                    Circle c2 => Intersects(v, c2).Count > 0,
                    Triangle t2 => Intersects(v, t2).Count > 0,
                    Polygon poly2 => Intersects(v, poly2).Count > 0,
                    Ray ray2 => Intersects(v, ray2).Count > 0,
                    _ => false,
                },
                Line l => rhs switch
                {
                    Vector2 v2 => Intersects(l, v2).Count > 0,
                    Line l2 => Intersects(l, l2).Count > 0,
                    Rectangle r2 => Intersects(l, r2).Count > 0,
                    Circle c2 => Intersects(l, c2).Count > 0,
                    Triangle t2 => Intersects(l, t2).Count > 0,
                    Polygon poly2 => Intersects(l, poly2).Count > 0,
                    Ray ray2 => Intersects(l, ray2).Count > 0,
                    _ => false,
                },
                Rectangle r => rhs switch
                {
                    Vector2 v2 => Intersects(r, v2).Count > 0,
                    Line l2 => Intersects(r, l2).Count > 0,
                    Rectangle r2 => Intersects(r, r2).Count > 0,
                    Circle c2 => Intersects(r, c2).Count > 0,
                    Triangle t2 => Intersects(r, t2).Count > 0,
                    Polygon poly2 => Intersects(r, poly2).Count > 0,
                    Ray ray2 => Intersects(r, ray2).Count > 0,
                    _ => false,
                },
                Circle c => rhs switch
                {
                    Vector2 v2 => Intersects(c, v2).Count > 0,
                    Line l2 => Intersects(c, l2).Count > 0,
                    Rectangle r2 => Intersects(c, r2).Count > 0,
                    Circle c2 => Intersects(c, c2).Count > 0,
                    Triangle t2 => Intersects(c, t2).Count > 0,
                    Polygon poly2 => Intersects(c, poly2).Count > 0,
                    Ray ray2 => Intersects(c, ray2).Count > 0,
                    _ => false,
                },
                Triangle t => rhs switch
                {
                    Vector2 v2 => Intersects(t, v2).Count > 0,
                    Line l2 => Intersects(t, l2).Count > 0,
                    Rectangle r2 => Intersects(t, r2).Count > 0,
                    Circle c2 => Intersects(t, c2).Count > 0,
                    Triangle t2 => Intersects(t, t2).Count > 0,
                    Polygon poly2 => Intersects(t, poly2).Count > 0,
                    Ray ray2 => Intersects(t, ray2).Count > 0,
                    _ => false,
                },
                Polygon poly => rhs switch
                {
                    Vector2 v2 => Intersects(poly, v2).Count > 0,
                    Line l2 => Intersects(poly, l2).Count > 0,
                    Rectangle r2 => Intersects(poly, r2).Count > 0,
                    Circle c2 => Intersects(poly, c2).Count > 0,
                    Triangle t2 => Intersects(poly, t2).Count > 0,
                    Polygon poly2 => Intersects(poly, poly2).Count > 0,
                    Ray ray2 => Intersects(poly, ray2).Count > 0,
                    _ => false,
                },
                Ray ray => rhs switch
                {
                    Vector2 v2 => Intersects(ray, v2).Count > 0,
                    Line l2 => Intersects(ray, l2).Count > 0,
                    Rectangle r2 => Intersects(ray, r2).Count > 0,
                    Circle c2 => Intersects(ray, c2).Count > 0,
                    Triangle t2 => Intersects(ray, t2).Count > 0,
                    Polygon poly2 => Intersects(ray, poly2).Count > 0,
                    Ray ray2 => Intersects(ray, ray2).Count > 0,
                    _ => false,
                },
                _ => false,
            };
        }

        #endregion IShape OVERLAPS IShape        
    }
}
