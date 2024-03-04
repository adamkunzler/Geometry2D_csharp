// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Raylib_cs;
using Color = Raylib_cs.Color;

internal class Program
{
    public static void Main()
    {
        //
        // Initialization
        //        
        Raylib.InitWindow(1024, 1024, ".: POC :.");
        Raylib.SetTargetFPS(60);

        //
        // MAIN RENDER LOOP
        //
        while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
        {
            //
            // PROCESS INPUTS
            //
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                // do something...
            }

            //
            // UPDATE STUFF
            //

            // TODO

            //
            // RENDER STUFF
            //
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // TODO

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

