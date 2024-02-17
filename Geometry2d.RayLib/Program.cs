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

        var shapes = new List<IShape>();

        var p = new Vector2(150.0f, 150.0f);
        var l = new Line(63.0f, 204.0f, 172.0f, 232.0f);
        var r = new Rectangle(120.0f, 120.0f, 200.0f, 80.0f);
        var c = new Circle(300.0f, 300.0f, 35.0f);
        var t = new Triangle(130.0f, 235.0f, 212.0f, 338.0f, 66.0f, 306.0f);
        var ray = new Ray(new Vector2(0.0f, 0.0f), new Vector2(1.0f, 1.0f));
        var e = new Ellipse(325.0f, 50.0f, 50.0f, 25.0f);
        var poly = new Polygon
        (
            new Vector2(218.0f, 18.0f),
            new Vector2(265.0f, 52.0f),
            new Vector2(229.0f, 97.0f),
            new Vector2(199.0f, 70.0f),
            new Vector2(170.0f, 96.0f),
            new Vector2(108.0f, 77.0f),
            new Vector2(100.0f, 35.0f),
            new Vector2(140.0f, 22.0f),
            new Vector2(179.0f, 46.0f)
        );
        var polyRect = new PolyRectangle(20.0f, 80.0f, 55.0f, 70.0f);

        
        
        shapes.Add(l);
        shapes.Add(r);
        shapes.Add(c);
        shapes.Add(t);        
        shapes.Add(poly);
        shapes.Add(e);
        shapes.Add(polyRect);
        

        var theta = 0.0f;
        var rayTheta = 0.0f;

        var doRotate = false;

        //
        // Initialization
        //
        const int screenWidth = 1536;
        const int screenHeight = 1536;
        const int screenScale = 4;

        const int middleX = (screenWidth / screenScale) / 2;
        const int middleY = (screenHeight / screenScale) / 2;

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
                Console.WriteLine(e);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.One))
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
                mouse = new RegularPolygon(0.0f, 0.0f, 4, 25.0f);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Seven))
            {
                //mouse = new Ray();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                G2d.Translate(e, new Vector2(5, 0));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                G2d.Translate(e, new Vector2(-5, 0));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                foreach (var shape in shapes)
                {
                    G2d.Scale(shape, new Vector2(1.1f, 1.1f));
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                foreach (var shape in shapes)
                {
                    G2d.Scale(shape, new Vector2(0.75f, 0.75f));
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.R))
            {
                doRotate = !doRotate;
            }

            #endregion Keyboard Input

            #region Mouse Input

            //
            // Draw shapes around with mouse
            //
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                // get shape that contains mouse
                IShape shape = new Vector2();
                foreach (var s in shapes)
                {
                    if (G2d.Contains(s, mouse))
                    {
                        shape = s;
                        break;
                    }
                }

                var delta = Raylib.GetMouseDelta();
                G2d.Translate(shape, new Vector2(delta.X / screenScale, delta.Y / screenScale));
            }

            #endregion Mouse Input

            //
            // Update
            //

            UpdateMouse(Raylib.GetMousePosition(), mousePoint, mouse, screenScale);

            if (doRotate)
            {
                theta = G2d.DegreesToRadians(1);
                rayTheta += theta;
                if (rayTheta > MathF.PI * 2.0f) rayTheta = 0.0f;
            }
            
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

                Gfx.DrawLine(l, G2d.Contains(l, mouse) 
                    ? Color.Gold 
                    : G2d.Overlaps(l, mouse) ? Color.Purple : Color.RayWhite);

                Gfx.DrawRectangle(r, G2d.Contains(r, mouse) 
                    ? Color.Gold 
                    : G2d.Overlaps(r, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(r.Middle, Color.RayWhite);

                Gfx.DrawCircle(c, G2d.Contains(c, mouse) 
                    ? Color.Gold 
                    : G2d.Overlaps(c, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(c.Origin, Color.RayWhite);

                Gfx.DrawTriangle(t, G2d.Contains(t, mouse) 
                    ? Color.Gold 
                    : G2d.Overlaps(t, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(t.Centroid(), Color.RayWhite);

                Gfx.DrawPolygon(poly, G2d.Contains(poly, mouse) 
                    ? Color.Gold 
                    : G2d.Overlaps(poly, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(poly.Center(), Color.RayWhite);
                
                Gfx.DrawPolygon(polyRect, G2d.Contains(polyRect, mouse)
                    ? Color.Gold
                    : G2d.Overlaps(polyRect, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(polyRect.Center(), Color.RayWhite);

                Gfx.DrawEllipse(e, G2d.Contains(e, mouse)
                    ? Color.Gold
                    : G2d.Overlaps(e, mouse) ? Color.Purple : Color.RayWhite);
                Gfx.DrawPoint(e.Origin, Color.RayWhite);
                var eFoci = e.Foci();
                Gfx.DrawPoint(eFoci.Focus1, Color.RayWhite);
                Gfx.DrawPoint(eFoci.Focus2, Color.RayWhite);

                #endregion Draw Static Shapes

                #region Mouse Shape Interactions

                foreach (var shape in shapes)
                {
                    //
                    // SHAPE INTERSECTIONS
                    //
                    var intersections = G2d.Intersects(shape, mouse);
                    foreach (var intersection in intersections)
                        Gfx.DrawCircle(new Circle(intersection, 3), Color.Green);

                    //
                    // SHAPE CLOSEST
                    //
                    Gfx.DrawCircle(new Circle(G2d.Closest(mouse, shape), 2), Color.Blue, true);
                }

                #endregion Mouse Shape Intersections
                                
                #region Draw AABB

                // triangle centers
                Gfx.DrawCircle(new Circle(t.Centroid(), 2), Color.Red, true);
                Gfx.DrawCircle(new Circle(t.Circumcenter(), 2), Color.Purple, true);
                Gfx.DrawCircle(new Circle(t.Incenter(), 2), Color.Green, true);
                Gfx.DrawCircle(new Circle(t.Orthocenter(), 2), Color.Blue, true);                
                Gfx.DrawCircle(t.Incircle(), Color.Green);
                
                Gfx.DrawCircle(G2d.BoundingCircle(t), Color.DarkGray);
                Gfx.DrawCircle(G2d.BoundingCircle(poly), Color.DarkGray);

                #endregion Draw AABB

                #region Transformation

                if (doRotate)
                {
                    foreach (var shape in shapes)
                    {
                        if (shape is Ray rr)
                        {
                            G2d.Rotate(rr, rayTheta);
                        }
                        else
                        {
                            G2d.Rotate(shape, theta);
                        }
                    }
                }

                G2d.Rotate(e, new Vector2(middleX, middleY), theta, true);

                #endregion Transformation

                #region Reflections
                
                var reflectData = G2d.Reflect(ray, shapes, 20);
                Gfx.DrawRayReflections(ray, reflectData, Color.Red);
                
                #endregion Reflections
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"OOPS: {ex.Message}");
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
                c.Origin.X = mx;
                c.Origin.Y = my;
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

            case RegularPolygon poly:
                poly.BuildRegularPolygon(new Vector2(mx, my), 5, 25.0f);
                break;

            case Ray ray:
                ray.Origin.X = 0.0f;
                ray.Origin.Y = 0;
                ray.Direction = (new Vector2(mx, my) - ray.Origin).Normal();
                break;
        }
    }
}