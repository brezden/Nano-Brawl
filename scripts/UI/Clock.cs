using Godot;

public partial class Clock : Sprite2D
{
	private float maxTime = 33f;
	private float currentTime = 33f;
	private ColorRect clockProgress;

	public override void _Ready()
	{
		clockProgress = (ColorRect)GetNode("ClockProgress");
	}

	public override void _Process(double delta)
	{
		if (currentTime >= 0)
		{
			currentTime -= (float)delta;
			float scaleFactor = currentTime / maxTime;
			clockProgress.Scale = new Vector2(1, scaleFactor);

			float redComponent = 1 - scaleFactor;
			float greenComponent = scaleFactor;
			clockProgress.Color = new Color(redComponent, greenComponent, 0);
		}
	}
}
