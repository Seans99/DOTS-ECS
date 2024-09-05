using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject _prefab;
    public float _spawnRate;

    class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Spawner
            {
                _prefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic),
                _spawnPosition = new float2(0, 6f),
                _nextSpawnTime = 0,
                _spawnRate = authoring._spawnRate,
            });
        }
    }
}
