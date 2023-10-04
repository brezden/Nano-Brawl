using System;
using System.Transactions;
using Godot;

public partial class Player : Godot.CharacterBody2D
{
	private int acceleration = 500;
	private int maxSpeed = 60;
	private int friction = 500;

	[Signal]
	public delegate void EnemyHitWithArgumentEventHandler(Detonix detonix);

	public override void _Ready() { }

	public override void _PhysicsProcess(double delta)
	{
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collisionObject = GetSlideCollision(i);
			Node collidedNode = collisionObject?.GetCollider() as Node;

			if (
				collisionObject != null
				&& collidedNode != null
				&& collidedNode.IsInGroup("enemy")
				&& collidedNode is Detonix
			)
			{
				EmitSignal(nameof(EnemyHitWithArgument), collidedNode as Detonix);
			}
		}

		Vector2 inputVector = Vector2.Zero;
		inputVector.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		inputVector.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		inputVector = inputVector.Normalized();

		if (inputVector != Vector2.Zero)
		{
			Velocity = Velocity.MoveToward(inputVector * maxSpeed, acceleration * (float)delta);
		}
		else
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, friction * (float)delta);
		}

		MoveAndSlide();
	}
}
