// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;
using Geometry2d.RayLib;
using Raylib_cs;
using System.Drawing;
using Color = Raylib_cs.Color;
using Ray = Geometry2d.Lib.Primitives.Ray;
using Rectangle = Geometry2d.Lib.Primitives.Rectangle;

internal class Program
{
    public static void Main()
    {        
        IShape mouse = new Vector2();
        var mousePoint = new Vector2();

        var p = new Vector2(50.0f, 50.0f);
        var l = new Line(10.0f, 10.0f, 75.0f, 150.0f);
        var r = new Rectangle(20.0f, 20.0f, 200.0f, 80.0f);
        var c = new Circle(200.0f, 200.0f, 35.0f);        
        var t = new Triangle(130.0f, 150.0f, 160.0f, 240.0f, 25.0f, 245.0f);
        var poly = new Polygon
        (
            new Vector2(195.0f, 109.0f),
            new Vector2(216.0f, 125.0f),
            new Vector2(210.0f, 145.0f),
            new Vector2(195.0f, 135.0f),
            new Vector2(169.0f, 148.0f),
            new Vector2(146.0f, 132.0f),
            new Vector2(147.0f, 110.0f),
            new Vector2(163.0f, 119.0f)
        );

        //
        // Initialization
        //
        const int screenWidth = 1024;
        const int screenHeight = 1024;
        const int screenScale = 4;

        Raylib.InitWindow(screenWidth, screenHeight, ".: Geometry 2D :.");
        Raylib.SetTargetFPS(60);

        var target = Raylib.LoadRenderTexture(screenWidth / screenScale, screenHeight / screenScale);

        //
        // MAIN RENDER LOOP
        //
        while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
        {
            //
            // Process Inputs
            //

            #region Keyboard Input

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                // do something...
                Console.WriteLine($"mouse: {mouse}");
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.One))
            {
                mouse = new Vector2();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Two))
            {
                mouse = new Line();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Three))
            {
                mouse = new Rectangle();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Four))
            {
                mouse = new Circle();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Five))
            {
                mouse = new Triangle();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Six))
            {
                mouse = new Polygon(0.0f, 0.0f, 5, 25.0f);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Seven))
            {
                mouse = new Ray();
            }

            #endregion Keyboard Input

            //
            // Update
            //

            UpdateMouse(Raylib.GetMousePosition(), mousePoint, mouse, screenScale);
            
            //
            // Draw
            //

            #region Draw To Target Texture

            Raylib.BeginTextureMode(target);
            Raylib.ClearBackground(Color.Black);
                                                
            Gfx.DrawShape(mouse, Color.RayWhite);

            try
            {
                #region Draw Static Shapes

                Gfx.DrawLine(l, Color.RayWhite);
                
                Gfx.DrawRectangle(r, G2d.Contains(r, mouse) ? Color.Gold : Color.RayWhite);
                Gfx.DrawPoint(r.Middle, Color.RayWhite);

                Gfx.DrawCircle(c, G2d.Contains(c, mouse) ? Color.Gold : Color.RayWhite);
                Gfx.DrawPoint(c.Position, Color.RayWhite);
                                
                Gfx.DrawTriangle(t, G2d.Contains(t, mouse) ? Color.Gold : Color.RayWhite);
                Gfx.DrawPoint(t.Center(), Color.RayWhite);
                
                Gfx.DrawPolygon(poly, G2d.Contains(poly, mouse) ? Color.Gold : Color.RayWhite);
                Gfx.DrawPoint(poly.Center(), Color.RayWhite);

                #endregion Draw Static Shapes

                #region Mouse Shape Intersections

                var interLine = G2d.Intersects(l, mouse);
                foreach (var intersection in interLine)
                    Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                var interRect = G2d.Intersects(r, mouse);
                foreach (var intersection in interRect)
                    Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                var interCircle = G2d.Intersects(c, mouse);
                foreach (var intersection in interCircle)
                    Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                var interTriangle = G2d.Intersects(t, mouse);
                foreach (var intersection in interTriangle)
                    Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                var interPoly = G2d.Intersects(poly, mouse);
                foreach (var intersection in interPoly)
                    Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                #endregion Mouse Shape Intersections

                #region Mouse Shape Closest

                if(mouse is Line ml)
                    Gfx.DrawCircle(new Circle(G2d.Closest(ml, l), 3), Color.Blue);

                #endregion Mouse Shape Closest

                #region Ray Intersections

                if (mouse is Ray ray)
                {
                    Gfx.DrawRay(ray, Color.RayWhite);

                    var rayInterLine = ray.Intersects(l);
                    foreach (var intersection in rayInterLine)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                    var rayInterRect = ray.Intersects(r);
                    foreach (var intersection in rayInterRect)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                    var rayInterCircle = ray.Intersects(c);
                    foreach (var intersection in rayInterCircle)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                    var rayInterTriangle = ray.Intersects(t);
                    foreach (var intersection in rayInterTriangle)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                    var rayInterPoly = ray.Intersects(poly);
                    foreach (var intersection in rayInterPoly)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);
                }

                #endregion Ray Intersections

                #region Mouse Point Closest

                Gfx.DrawCircle(new Circle(G2d.Closest(mousePoint, l), 2), Color.Red, true);
                Gfx.DrawCircle(new Circle(G2d.Closest(mousePoint, r), 2), Color.Red, true);                
                Gfx.DrawCircle(new Circle(G2d.Closest(mousePoint, t), 2), Color.Red, true);
                Gfx.DrawCircle(new Circle(G2d.Closest(mousePoint, poly), 2), Color.Red, true);                
                Gfx.DrawCircle(new Circle(G2d.Closest(mousePoint, c), 2), Color.Red, true);

                #endregion Mouse Point Closest
            }
            catch
            {
                Console.WriteLine("oops");
            }

            Raylib.EndTextureMode();

            #endregion Draw To Target Texture

            #region Draw Target Texture to Window

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            var src = new Raylib_cs.Rectangle(0, 0, target.Texture.Width, -target.Texture.Height);
            var dest = new Raylib_cs.Rectangle(0, 0, screenWidth, screenHeight);
            Raylib.DrawTexturePro(
                target.Texture,
                src,
                dest,
                new System.Numerics.Vector2(0.0f, 0.0f),
                0,
                Color.White);

            Raylib.EndDrawing();

            #endregion Draw Target Texture to Window
        }

        //
        // De-Initialization
        //

        Raylib.CloseWindow();        // Close window and OpenGL context
    }

    private static void UpdateMouse(System.Numerics.Vector2 mouse, Vector2 mousePoint, IShape mouseShape, int screenScale)
    {                
        var mx = (mouse.X / screenScale);
        var my = (mouse.Y / screenScale);

        mousePoint.X = mx;
        mousePoint.Y = my;

        switch (mouseShape)
        {
            case Vector2 v:                
                v.X = mx;
                v.Y = my;
                break;
            case Line l:                
                l.Start.X = mx - 25.0f;
                l.Start.Y = my - 17.5f;
                l.End.X = mx + 25.0f;
                l.End.Y = my + 17.5f;
                break;
            case Rectangle r:
                r.Position.X = mx - 25.0f;
                r.Position.Y = my - 15.0f;
                r.Size.X = 50.0f;
                r.Size.Y = 30.0f;                
                break;
            case Circle c:
                c.Position.X = mx;
                c.Position.Y = my;
                c.Radius = 25.0f;                
                break;
            case Triangle t:                                
                t.Vertices[0].X = mx;
                t.Vertices[0].Y = my - 15.0f;
                t.Vertices[1].X = mx + 15.0f;
                t.Vertices[1].Y = my + 15.0f;
                t.Vertices[2].X = mx - 15.0f;
                t.Vertices[2].Y = my + 15.0f;
                break;
            case Polygon poly:
                poly.BuildRegularPolygon(new Vector2(mx, my), 5, 25.0f);
                break;
            case Ray ray:                
                ray.Origin.X = 0;
                ray.Origin.Y = 0;
                ray.Direction = new Vector2(mx, my).Normal();
                break;
        }
    }
}