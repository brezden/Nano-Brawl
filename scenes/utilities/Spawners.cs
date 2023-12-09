using System;
using Godot;

public partial class Spawners : Node2D
{
	[Signal]
	public delegate void EnemySpawnWithArgumentEventHandler(int amount);

	[Signal]
	public delegate void EnemyCounterIncreaseEventHandler();

	[Signal]
	public delegate void EnemyCounterDecreaseEventHandler();

	private Node detonixScene;
	private Marker2D leftSpawner;
	private Marker2D rightSpawner;
	private Marker2D topSpawner;
	private Marker2D bottomSpawner;
	private Random random = new Random();

	public override void _Ready()
	{
		detonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
		leftSpawner = GetNode<Marker2D>("Left Spawn");
		rightSpawner = GetNode<Marker2D>("Right Spawn");
		topSpawner = GetNode<Marker2D>("Top Spawn");
		bottomSpawner = GetNode<Marker2D>("Bottom Spawn");
		SpawnEnemies(15);
	}

	public void SpawnEnemies(int enemyAmount)
	{
		for (int i = 0; i < enemyAmount; i++)
		{
			int spawnerNumber = random.Next(0, 4);
			var enemy = detonixScene.Duplicate() as Detonix;
			Vector2 randomOffset = new Vector2(
				((float)random.NextDouble() * 10) - 5,
				((float)random.NextDouble() * 10) - 5
			);

			switch (spawnerNumber)
			{
				case 0:
					enemy.Position = this.leftSpawner.Position + randomOffset;
					break;
				case 1:
					enemy.Position = this.rightSpawner.Position + randomOffset;
					break;
				case 2:
					enemy.Position = this.topSpawner.Position + randomOffset;
					break;
				case 3:
					enemy.Position = this.bottomSpawner.Position + randomOffset;
					break;
			}

			AddChild(enemy);
			EmitSignal(SignalName.EnemyCounterIncrease);
		}
	}

	public void OnPlayerEnemyHitWithArgument(Detonix enemy)
	{
		enemy.QueueFree();
		EmitSignal(SignalName.EnemyCounterDecrease);
	}
}
