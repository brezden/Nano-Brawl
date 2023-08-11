using Godot;
using System;

public partial class Main : Node2D
{
	public override void _Ready()
	{

		GetTree().CallGroup("enemy", "set_target", GetNode("Player"));
	}
}
