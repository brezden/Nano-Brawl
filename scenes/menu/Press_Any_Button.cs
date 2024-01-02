using Godot;
using System;

public partial class Press_Any_Button : Node
{
    BoxContainer StartGameContainer;

    public override void _Ready()
    {
        StartGameContainer = GetNode<BoxContainer>("%StartGameContainer");
        SetProcessInput(true);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey || @event is InputEventJoypadButton)
        {
            if (@event.IsPressed())
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        GD.Print("Game Starting!");
    }

    private void OnTimerTimeout()
    {
        StartGameContainer.Visible = !StartGameContainer.Visible;
    }
}
