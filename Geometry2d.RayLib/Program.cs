// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Geometry2d.Lib.Primitives;
using Geometry2d.RayLib;
using Raylib_cs;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Threading;
using System.Xml.Linq;
using Color = Raylib_cs.Color;
using Ray = Geometry2d.Lib.Primitives.Ray;
using Rectangle = Geometry2d.Lib.Primitives.Rectangle;

class Program
{
    public static void Main()
    {
        //var triangle = new Triangle(
        //    700.0f, 50.0f,            
        //    900.0f, 300.0f,
        //    550.0f, 450.0f);

        //var poly = new Polygon(
        //    new Vector2(50.0f, 50.0f),
        //    new Vector2(200.0f, 100.0f),
        //    new Vector2(250.0f, 250.0f),
        //    new Vector2(100.0f, 250.0f),
        //    new Vector2(150.0f, 175.0f),
        //    new Vector2(25.0f, 90.0f));

        var mousePoint = new Vector2();
                       
        
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

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                // do something...
            }

            mousePoint.X = Raylib.GetMousePosition().X / screenScale;
            mousePoint.Y = Raylib.GetMousePosition().Y / screenScale;


            //
            // Update
            //

            // TODO

            //
            // Draw
            //

            #region Draw To Target Texture

            Raylib.BeginTextureMode(target);
            Raylib.ClearBackground(Color.Black);

            //Gfx.DrawPoint(new Vector2(50.0f, 50.0f), Color.RayWhite);
            Gfx.DrawPoint(mousePoint, Color.RayWhite);

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

    
}