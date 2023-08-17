using Godot;
using System;
using System.Collections.Generic;

public partial class EnemySpawner : Node2D
{
    private Node DetonixScene;
    private static Random _random = new Random();

    private List<Vector2> spawnPositions = new List<Vector2>
    {
        new Vector2(17, 144),
        new Vector2(144, 17),
        new Vector2(272, 144),
        new Vector2(144, 272)
    };

    public override void _Ready()
    {
        DetonixScene = ResourceLoader.Load<PackedScene>("res://scenes/enemies/Detonix.tscn").Instantiate();
        SpawnEnemy(5);
    }

    public void SpawnEnemy(int enemyAmount)
    {
        for (int i = 1; i <= enemyAmount; i++)
        {
            var enemy = DetonixScene.Duplicate() as Detonix;
            enemy.Position = GetRandomPosition();
            AddChild(enemy);
        }
    }

    private Vector2 GetRandomPosition()
    {
        int index = _random.Next(spawnPositions.Count);
        return spawnPositions[index];
    }
}