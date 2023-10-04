using System;
using Godot;

public partial class Gameplay : Node2D
{
	public override void _Ready() { }

	public override void _PhysicsProcess(double delta)
	{
		GetTree().CallGroup("enemy", "SetTarget", GetNode("Player"));
	}
}
