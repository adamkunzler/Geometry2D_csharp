using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;

var v1 = new Vector4f(1, 2, 3, 4);

var m1 = new Matrix4x4f(
    1, 2, 3, 4, 
    5, 6, 7, 8, 
    9, 10,11,12,
    5, 4, 3, 2);
var m2 = new Matrix4x4f(
    1, 1, 1, -1, 
    1, 1, -1, 1,
    1, -1, 1, 1,
    -1, 1, 1, 1);
Console.WriteLine(v1 * m1);