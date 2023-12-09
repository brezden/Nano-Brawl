using Godot;
using System;

public partial class Press_Any_Button : Node
{
    BoxContainer StartGameContainer;

    public override void _Ready() {
        StartGameContainer = this.GetNode("%StartGameContainer") as BoxContainer;
    }

    private void OnTimerTimeout() {
        StartGameContainer.Visible = !StartGameContainer.Visible;
    }
}
