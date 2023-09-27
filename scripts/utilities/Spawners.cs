using Godot;
using System;

public partial class Spawners : Node2D
{
	[Signal]
	public delegate void EnemySpawnWithArgumentEventHandler(int amount);

	[Signal]
	public delegate void EnemyCounterIncreaseEventHandler();

	[Signal]
	public delegate void EnemyCounterDecreaseEventHandler();

	private Node DetonixScene;
	private Marker2D LeftSpawner;
	private Marker2D RightSpawner;
	private Marker2D TopSpawner;
	private Marker2D BottomSpawner;
	private static Random Random = new Random();

	public override void _Ready()
	{
		DetonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
		LeftSpawner = GetNode<Marker2D>("Left Spawn");
		RightSpawner = GetNode<Marker2D>("Right Spawn");
		TopSpawner = GetNode<Marker2D>("Top Spawn");
		BottomSpawner = GetNode<Marker2D>("Bottom Spawn");
		SpawnEnemies(15);
	}

	public void SpawnEnemies(int EnemyAmount)
	{
		for (int i = 0; i < EnemyAmount; i++)
		{
			int SpawnerNumber = Random.Next(0, 4);
			var Enemy = DetonixScene.Duplicate() as Detonix;
			Vector2 RandomOffset = new Vector2(
				(float)Random.NextDouble() * 10 - 5,
				(float)Random.NextDouble() * 10 - 5
			);

			switch (SpawnerNumber)
			{
				case 0:
					Enemy.Position = this.LeftSpawner.Position + RandomOffset;
					break;
				case 1:
					Enemy.Position = this.RightSpawner.Position + RandomOffset;
					break;
				case 2:
					Enemy.Position = this.TopSpawner.Position + RandomOffset;
					break;
				case 3:
					Enemy.Position = this.BottomSpawner.Position + RandomOffset;
					break;
			}

			AddChild(Enemy);
			EmitSignal(SignalName.EnemyCounterIncrease);
		}
	}

	public void _on_player_Enemy_hit_with_argument(Detonix Enemy)
	{
		Enemy.QueueFree();
		EmitSignal(SignalName.EnemyCounterDecrease);
	}
}
