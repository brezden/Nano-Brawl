using Godot;
using System;
using System.Transactions;

public partial class Player : Godot.CharacterBody2D
{
	int Acceleration = 500;
	int MaxSpeed = 60;
	int Friction = 500;

	[Signal]
	public delegate void EnemyHitWithArgumentEventHandler(Detonix Detonix);

	public override void _Ready() { }

	public override void _PhysicsProcess(double delta)
	{
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D CollisionObject = GetSlideCollision(i);
			Node CollidedNode = CollisionObject?.GetCollider() as Node;

			if (
				CollisionObject != null
				&& CollidedNode != null
				&& CollidedNode.IsInGroup("enemy")
				&& CollidedNode is Detonix
			)
			{
				EmitSignal(nameof(EnemyHitWithArgument), CollidedNode as Detonix);
			}
		}

		Vector2 InputVector = Vector2.Zero;
		InputVector.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		InputVector.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		InputVector = InputVector.Normalized();

		if (InputVector != Vector2.Zero)
		{
			Velocity = Velocity.MoveToward(InputVector * MaxSpeed, Acceleration * (float)delta);
		}
		else
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, Friction * (float)delta);
		}
		MoveAndSlide();
	}
}
