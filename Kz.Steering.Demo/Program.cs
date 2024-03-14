// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Raylib;
using Kz.Steering.Demo;
using Raylib_cs;
using Color = Raylib_cs.Color;

internal class Program
{
    public static float GetRandomNegativeOneToOne(Random r)
    {
        var val = r.NextDouble() * 2.0 - 1.0;
        return (float)val;
    }

    public static void Main()
    {
        var backgroundColor = new Color(41, 37, 33, 255);
        var obstacleColor = new Color(245, 174, 45, 255);
        var random = new Random();

        var numBoids = 500;
        var boidSize = 5.0f;
        var screenWidth = 1536;
        var screenHeight = 1536;

        var screenAABB = new Kz.Engine.Geometry2d.Primitives.Rectangle(0, 0, screenWidth, screenHeight);

        //
        // Initialization
        //
        Raylib.InitWindow(screenWidth, screenHeight, ".: Boids :.");
        Raylib.SetTargetFPS(60);

        // init a group of boids with random positions and velocities
        var boids = new List<Agent>();
        for (var i = 0; i < numBoids; i++)
        {
            var acceleration = Vector2f.Zero;
            var velocity = new Vector2f(GetRandomNegativeOneToOne(random), GetRandomNegativeOneToOne(random)).Normal();
            var position = new Vector2f(random.Next(0, screenWidth), random.Next(0, screenHeight));
            boids.Add(new Agent(acceleration, velocity, position, 10.0f));
        }

        var obstacles = new List<Circle>();
        obstacles.Add(new Circle(500.0f, 750.0f, 100.0f));
        obstacles.Add(new Circle(900.0f, 250.0f, 75.0f));
        obstacles.Add(new Circle(1100.0f, 1050.0f, 150.0f));

        var walls = new List<Line>();
        var wallOffset = 10.0f;
        //walls.Add(new Line(wallOffset, wallOffset, screenWidth - wallOffset, wallOffset)); // top
        //walls.Add(new Line(wallOffset, screenHeight - wallOffset, screenWidth - wallOffset, screenHeight - wallOffset)); // bottom
        //walls.Add(new Line(wallOffset, wallOffset, wallOffset, screenHeight - wallOffset)); // left
        //walls.Add(new Line(screenWidth - wallOffset, wallOffset, screenWidth - wallOffset, screenWidth - wallOffset)); // right

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

            foreach (var boid in boids)
            {
                var mousePosition = new Vector2f(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);
                boid.Update(boids, screenAABB, mousePosition, obstacles, walls);
            }

            //
            // RENDER STUFF
            //
            Raylib.BeginDrawing();
            Raylib.ClearBackground(backgroundColor);

            foreach (var obstacle in obstacles)
            {
                Gfx.DrawCircle(obstacle, obstacleColor);
            }

            foreach (var wall in walls)
            {
                Gfx.DrawLine(wall, obstacleColor);
            }

            foreach (var boid in boids)
            {
                boid.Render(boids);
            }

            Raylib.DrawFPS(10, 10);
            
            Raylib.EndDrawing();
        }

        foreach (var boid in boids)
        {
            boid.Cleanup();
        }

        Raylib.CloseWindow();
    }
}