using System;
using Godot;

public partial class Power_Up : Area2D
{
	public override void _Ready()
	{
		Sprite2D powerUpSprite = GetNode<Sprite2D>("Sprite");
		powerUpSprite.Frame = new Random().Next(0, 8);
	}

	public void OnBodyEntered(Node body)
	{
		QueueFree();
	}
}
