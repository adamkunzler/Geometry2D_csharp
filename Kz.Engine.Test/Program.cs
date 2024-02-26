using Kz.Engine.Geometry2d.Primitives;

var line = new Line(2, 3, 4, 7);
var form = line.StandardForm();
Console.WriteLine($"{form.A}x + {form.B} = {form.C}");