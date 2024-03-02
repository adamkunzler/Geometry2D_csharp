using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;



var m1 = new Matrix3x3f(1, 2, 3, 4, 5, 6, 7, 8, 9);
var m2 = new Matrix3x3f(
    1, 2, 3, 
    2, 1, 2, 
    3, 2, 1);
Console.WriteLine(m2.Inverse());