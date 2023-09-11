using Godot;
using System;

public partial class Clock : Sprite2D
{
	private float MaxTime = 33f;
	private float CurrentTime = 33f;

	private ColorRect ClockProgress;

	public override void _Ready()
	{
		ClockProgress = (ColorRect)GetNode("ClockProgress");
	}

	public override void _Process(double delta)
	{
		if (CurrentTime >= 0)
		{
			CurrentTime -= (float)delta;
			ClockProgress.Scale = new Vector2(1, (CurrentTime / MaxTime));
		}
	}
}
