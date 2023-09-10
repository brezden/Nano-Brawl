using Godot;
using System;

public partial class Score : Label
{	
	int enemies = 0;

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
