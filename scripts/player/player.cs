using Godot;
using System;

public partial class Player : CharacterBody2D
{

    public int Speed = 75;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
        MoveAndSlide();
    }
}

