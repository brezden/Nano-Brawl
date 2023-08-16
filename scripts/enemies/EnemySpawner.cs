using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	private Node DetonixScene;
	private static Random _random = new Random();

	public override void _Ready()
	{
		DetonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
		SpawnEnemy(5);
	}

	public void SpawnEnemy(int enemyAmount){
		for(int i = 1; i <= enemyAmount; i++){
			var enemy = DetonixScene.Duplicate() as Detonix;
			enemy.Position = new Vector2(_random.Next(17, 256), _random.Next(17, 256));
			AddChild(enemy);
		}
	}
}
