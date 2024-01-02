using Godot;
using System;

public partial class Start_Screen_Star : Node2D
{
	AnimationPlayer StarAnimation;
	AudioStreamPlayer StarSound;
	int animationIndex;
    Random rand = new Random();

    public override void _Ready()
	{
		this.Visible = false;
        StarAnimation = this.GetNode<AnimationPlayer>("%StarAnimation");
		StarSound = this.GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

	private void OnStarTimerTimeout()
	{	
        if (rand.Next(0, 3) <= 1)
        {
			this.Visible = true;
			this.Position = new Vector2 (rand.Next(32, 288), rand.Next(32, 288));

			animationIndex = rand.Next(0, 3);

			switch (animationIndex)
			{
				case 0:
					StarAnimation.Play("Small");
					break;
				case 1:
					StarAnimation.Play("Medium");
					break;
				case 2:
					StarAnimation.Play("Large");
					break;
			}

			StarSound.Play();
        }
    }

	private void OnStarAnimationFinished(string AnimationName)
	{
		this.Visible = false;
	}
}
