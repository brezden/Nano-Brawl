using Godot;
using System;

public partial class Press_Any_Button : Node
{
    private Timer _timer;
    private float _flashRate = 0.5f; // seconds

    public override void _Ready() {
        _timer = new Timer();
        AddChild(_timer);
        _timer.WaitTime = _flashRate;
        _timer.Connect("timeout", this, nameof(OnTimerTimeout));
        _timer.Start();
    }

    private void OnTimerTimeout() {
        Visible = !Visible; // Toggle visibility
    }
}
