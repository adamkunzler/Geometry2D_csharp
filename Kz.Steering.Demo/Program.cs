// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Trigonometry;
using Kz.Steering.Demo.Rules;
using Raylib_cs;
using System.Numerics;
using System;
using Color = Raylib_cs.Color;
using Kz.Engine.General;
using Kz.Steering.Demo;

public class Agent
{
    #region ctor

    private static uint CURRENT_ID = 0;
    public uint Id { get; init; }

    public Vector2f Acceleration { get; private set; }
    public Vector2f Velocity { get; private set; }
    public Vector2f Position { get; private set; }

    public float Size { get; private set; }
    public float HalfSize => Size / 2.0f;
        
    public Agent()
    {
        Id = CURRENT_ID++;
        Acceleration = Vector2f.Zero;
        Velocity = Vector2f.Zero;
        Position = Vector2f.Zero;
        Size = 1.0f;
    }

    public Agent(Vector2f acceleration, Vector2f velocity, Vector2f position, float size)
    {
        Id = CURRENT_ID++;
        Acceleration = acceleration;
        Velocity = velocity;
        Position = position;
        Size = size;

    }

    public Agent(Vector2f position, float size)
    {
        Id = CURRENT_ID++;
        Acceleration = Vector2f.Zero;
        Velocity = Vector2f.Zero;
        Position = position;
        Size = size;
    }

    public override string ToString()
    {
        return $"Boid #{Id}: {Position}";
    }

    #endregion ctor

    #region Fields

    private float _neighbordDistance = 200.0f;
    
    private float _mass = 1.0f;

    // maximum amount an agent can turn
    private float _maxTurningRate = TrigUtil.DegreesToRadians(2.5f);

    // maximum amount an agent can move
    private float _maxSpeed = 5.0f;
    public float MaxSpeed => _maxSpeed;

    // maximum force an agent can power itself
    private float _maxForce = 3.5f;

    #endregion Fields

    private Vector2f _steeringForce = Vector2f.Zero;

    public void Update(List<Agent> others, Kz.Engine.Geometry2d.Primitives.Rectangle aabb, Vector2f mousePosition)
    {
        // Get Neighbors
        //var neighbors = GetNeighbors(others);

        // calculate rules
        var target = new Vector2f(mousePosition.X, mousePosition.Y);
        var seekForce = Vector2f.Zero;// Behaviors.Seek(this, target);
        var fleeForce = Vector2f.Zero;// Behaviors.Flee(this, target, 500.0f * 500.0f);
        var arriveForce = Behaviors.Arrive(this, target, Deceleration.Normal);


        // combined force of all steering behaviours
        var totalSteeringForce = seekForce + fleeForce + arriveForce;
        _steeringForce = totalSteeringForce; // for debugging/rendering

        // acceleration = force / mass
        Acceleration = (totalSteeringForce / _mass).LimitMagnitude(_maxForce);
        
        var newVelocity = Velocity + Acceleration;

        // constrain changes in velocity to maxTurningAngle and maxVelocity
        Velocity = Vector2f
            .LimitAngleDelta(Velocity, newVelocity, _maxTurningRate)
            .LimitMagnitude(_maxSpeed);        
        Position += Velocity;

        // bound to aabb
        if (Position.X < aabb.Position.X + HalfSize) Position.X = aabb.Position.X + aabb.Size.X + HalfSize;
        else if (Position.X > aabb.Position.X + aabb.Size.X + HalfSize) Position.X = aabb.Position.X + HalfSize;
        if (Position.Y < aabb.Position.Y + HalfSize) Position.Y = aabb.Position.Y + aabb.Size.Y + HalfSize;
        else if (Position.Y > aabb.Position.Y + aabb.Size.Y + HalfSize) Position.Y = aabb.Position.Y + HalfSize;
    }
    
    public void Render(List<Agent> others)
    {
        // render agent
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Size, Color.DarkGreen);
        
        // render direction vector
        var theta = Velocity.AngleOf();
        var xx = Position.X + MathF.Cos(theta) * Size * 2.0f;
        var yy = Position.Y + MathF.Sin(theta) * Size * 2.0f;
        Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)xx, (int)yy, Color.RayWhite);

        // special case: agent #0
        if(Id == 0 && true)
        {
            // render neighborDistance
            Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, _neighbordDistance, Color.RayWhite);

            // render neighbors
            foreach(var neighbor in GetNeighbors(others))
            {
                Raylib.DrawCircleLines((int)neighbor.Position.X, (int)neighbor.Position.Y, Size * 1.2f, Color.RayWhite);
            }

            // steering force
            var steeringForce = _steeringForce * Size;
            Raylib.DrawLine(
                (int)Position.X, (int)Position.Y,
                (int)Position.X + (int)steeringForce.X,
                (int)Position.Y + (int)steeringForce.Y, 
                Color.Red);
        }
    }

    public void Cleanup()
    {
    }

    #region Private Methods
       
    private List<Agent> GetNeighbors(List<Agent> others)
    {
        var neighbors = new List<Agent>();
        foreach(var agent in others)
        {
            if (agent == this) continue;

            var distance = (this.Position - agent.Position).Magnitude();
            if (distance > _neighbordDistance) continue;

            neighbors.Add(agent);
        }
        return neighbors;
    }

    #endregion Private Methods
}

internal class Program
{    
    public static float GetRandomNegativeOneToOne(Random r)
    {
        var val = r.NextDouble() * 2.0 - 1.0;
        return (float)val;
    }

    public static void Main()
    {
        var random = new Random();

        var numBoids = 1;
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
                boid.Update(boids, screenAABB, mousePosition);
            }

            //
            // RENDER STUFF
            //
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            foreach (var boid in boids)
            {
                boid.Render(boids);
            }

            Raylib.DrawFPS(10, 10);
            Raylib.DrawText($"Mouse: {Raylib.GetMousePosition().X}, {Raylib.GetMousePosition().Y}", 10, 35, 20, Color.RayWhite);
            Raylib.DrawText("Steering Force", 10, 65, 20, Color.Red);

            Raylib.EndDrawing();
        }

        foreach (var boid in boids)
        {
            boid.Cleanup();
        }

        Raylib.CloseWindow();
    }
}
