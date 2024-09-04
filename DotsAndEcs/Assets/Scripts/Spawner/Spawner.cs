using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Spawner : IComponentData
{
    public Entity _prefab;
    public float2 _spawnPosition;
    public float _nextSpawnTime;
    public float _spawnRate;
}
