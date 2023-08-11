using Godot;
using System;

public partial class Detonix : CharacterBody2D
{
	private AnimationPlayer _animationPlayer;
	private Node target;
	
	public override void _Ready()
	{	
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}


	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("move_right"))
		{
			_animationPlayer.Play("idle");
		}
		else
		{
			_animationPlayer.Stop();
		}
	}

	public void SetTarget(Node playerNode)
    {
        target = playerNode;
        GD.Print("Target set to: " + target);
    }
}
