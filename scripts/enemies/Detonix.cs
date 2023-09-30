using Godot;
using System;

public partial class Detonix : CharacterBody2D
{
	private AnimationPlayer AnimationPlayer;
	private Node Target;
	private Vector2 TargetPosition;
	private float Speed = 20f;
	private float delta;

	public override void _Ready()
	{
		AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		this.delta = (float)delta;
		AnimationPlayer.Play("idle");
	}

	public void SetTarget(Player playerNode)
	{
		TargetPosition = playerNode.Position;
		Vector2 Direction = (TargetPosition - Position).Normalized();
		Velocity = Direction * Speed;

		if (Position.DistanceTo(TargetPosition) < Speed * this.delta)
		{
			Position = TargetPosition;
		}
		else
		{
			MoveAndSlide();
		}
    }
}
