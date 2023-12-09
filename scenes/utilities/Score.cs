using System;
using Godot;

public partial class Score : Label
{
	private int enemies = 0;

	public void IncreaseScore()
	{
		enemies++;
		Text = "Enemies: " + enemies;
	}

	public void DecreaseScore()
	{
		enemies--;
		Text = "Enemies: " + enemies;
	}
}
