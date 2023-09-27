using Godot;
using System;

public partial class Score : Label
{
	int Enemies = 0;

	public void IncreaseScore()
	{
		Enemies++;
		Text = "Enemies: " + Enemies;
	}

	public void DecreaseScore()
	{
		Enemies--;
		Text = "Enemies: " + Enemies;
	}
}
