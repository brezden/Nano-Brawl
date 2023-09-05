using Godot;
using System;

public partial class Spawners : Node2D
{
	[Signal]
	public delegate void EnemySpawnWithArgumentEventHandler(int amount);
	private Node DetonixScene;
	private Marker2D LeftSpawner;
	private Marker2D RightSpawner;
	private Marker2D TopSpawner;
	private Marker2D BottomSpawner;
	private static Random random = new Random();

	public override void _Ready()
	{
		DetonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
		LeftSpawner = GetNode<Marker2D>("Left Spawn");
		RightSpawner = GetNode<Marker2D>("Right Spawn");
		TopSpawner = GetNode<Marker2D>("Top Spawn");
		BottomSpawner = GetNode<Marker2D>("Bottom Spawn");
		SpawnEnemies(15);
	}

	public void SpawnEnemies(int enemyAmount)
	{
		for (int i = 0; i < enemyAmount; i++)
		{
			int randomNumber = random.Next(0, 4);
			var enemy = DetonixScene.Duplicate() as Detonix;
			Vector2 randomOffset = new Vector2((float)random.NextDouble() * 10 - 5, (float)random.NextDouble() * 10 - 5);

			switch (randomNumber)
			{
				case 0:
					enemy.Position = this.LeftSpawner.Position + randomOffset;
					break;
				case 1:
					enemy.Position = this.RightSpawner.Position + randomOffset;
					break;
				case 2:
					enemy.Position = this.TopSpawner.Position + randomOffset;
					break;
				case 3:
					enemy.Position = this.BottomSpawner.Position + randomOffset;
					break;
			}

			AddChild(enemy);
		}

		GetTree().CallGroup("score", "SetScore", enemyAmount);
	}

	public void _on_player_enemy_hit_with_argument(Detonix enemy)
	{
		enemy.QueueFree();
		SpawnEnemies(1);
	}
}