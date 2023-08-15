using Godot;
using System;

public partial class Main : Node2D
{
	public override void _Ready()
	{	
	}

	public override void _PhysicsProcess(double delta)
	{
		GetTree().CallGroup("enemy", "SetTarget", GetNode("Player"));
	}
}
