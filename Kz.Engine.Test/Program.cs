using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;

var m1 = new Matrix2x2f(1, 2, 3, 4);
var m2 = new Matrix2x2f(5, 6, 7, 8);
var m3 = m1 * m2;
Console.WriteLine(m1.Trace());