using Godot;
using System;
using System.Collections.Generic;
using System.Threading;

public partial class EnemySpawner : Node2D
{   
    [Signal]
    public delegate void EnemySpawnWithArgumentEventHandler(int amount);

    private Node DetonixScene;
    private static Random random = new Random();

    public override void _Ready()
    {
        DetonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
        int enemyCount = 15;
        SpawnEnemies(enemyCount);
        GetTree().CallGroup("score", "SetScore", enemyCount);
    }

    public void SpawnEnemies(int enemyAmount)
    {
        for (int i = 1; i <= enemyAmount; i++)
        {   
            GD.Print(i);
            int randomNumber = random.Next(0, 4);
            var enemy = DetonixScene.Duplicate() as Detonix;

            switch (randomNumber)
            {
                case 0:
                    enemy.Position = new Vector2((144 + random.Next(-32, 33)), 0);
                    break;
                case 1:
                    enemy.Position = new Vector2((144 + random.Next(-32, 33)), 288);
                    break;
                case 2:
                    enemy.Position = new Vector2(288, (144 + random.Next(-32, 33)));
                    break;
                case 3:
                    enemy.Position = new Vector2(0, (144 + random.Next(-32, 33)));
                    break;
            }

            AddChild(enemy);
        }
    }

    public void _on_player_enemy_hit_with_argument(Detonix enemy)
    {
        enemy.QueueFree();
        EmitSignal(nameof(EnemySpawnWithArgument), 1);
    }
}