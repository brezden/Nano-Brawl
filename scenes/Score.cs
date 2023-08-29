using Godot;
using System;

public partial class Score : Label
{	
	int enemies = 0;

	public void SetScore(int enemyCount)
	{	
		enemies += enemyCount;
		Text = "Enemies: " + enemies;
	}

	public void EnemyRemoved(Detonix enemy){
		enemies--;
		Text = "Enemies: " + enemies + "(" + enemy + ")";
	}
}
