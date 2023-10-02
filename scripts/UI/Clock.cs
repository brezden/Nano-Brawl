using Godot;

public partial class Clock : Sprite2D {
    private float maxTime = 33f;
    private float currentTime = 33f;
    private ColorRect clockProgress;

    public override void _Ready() {
        clockProgress = (ColorRect)GetNode("ClockProgress");
    }

    public override void _Process(double delta) {
        if (currentTime >= 0) {
            currentTime -= (float)delta;
            float ScaleFactor = currentTime / maxTime;
            ClockProgress.Scale = new Vector2(1, ScaleFactor);

            float RedComponent = 1 - ScaleFactor;
            float GreenComponent = ScaleFactor;
            ClockProgress.Color = new Color(RedComponent, GreenComponent, 0);
        }
    }
}
