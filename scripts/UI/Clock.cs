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
			float scale_factor = CurrentTime / MaxTime;
			ClockProgress.Scale = new Vector2(1, scale_factor);

			float redComponent = 1 - scale_factor;
			float greenComponent = scale_factor;
			ClockProgress.Color = new Color(redComponent, greenComponent, 0);
		}
	}
}
