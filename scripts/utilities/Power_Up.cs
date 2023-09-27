using Godot;
using System;

public partial class Power_Up : Area2D
{
	public override void _Ready()
	{
		Sprite2D PowerUpSprite = GetNode<Sprite2D>("Sprite");
		PowerUpSprite.Frame = new Random().Next(0, 8);
		;
	}

	public void _on_body_entered(Node body)
	{
		GD.Print(body);
		QueueFree();
	}
}
