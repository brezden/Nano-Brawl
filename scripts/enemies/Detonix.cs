using Godot;
using System;

public partial class Detonix : CharacterBody2D
{
	private AnimationPlayer _animationPlayer;
	private Node target;
	private Vector2 targetPosition;
	private float speed = 20f;
	private float delta;

	public override void _Ready()
	{	
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{	
		this.delta = (float)delta;
		_animationPlayer.Play("idle");
	}

	public void SetTarget(Player playerNode)
	{	
		targetPosition = playerNode.Position;
		Vector2 direction = (targetPosition - Position).Normalized();
        Velocity = direction * speed;

        if (Position.DistanceTo(targetPosition) < speed * this.delta)
        {
            Position = targetPosition;
        }
        else
        {
            MoveAndSlide();
        }
	}
}
