using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;

var u = new Vector2f(5, 5);
var v = new Vector2f(7, 0);
var projection = u.Project(v);
Console.WriteLine(projection);