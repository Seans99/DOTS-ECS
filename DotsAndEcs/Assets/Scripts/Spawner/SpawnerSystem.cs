using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnerSystem : ISystem
{
    private Random _random;

    public void OnCreate(ref SystemState state)
    {
        _random = new Random((uint)UnityEngine.Random.Range(1, 100000));
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO._nextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                float randomX = _random.NextFloat(-6f, 6f);
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO._prefab);
                float3 pos = new float3(randomX, spawner.ValueRO._spawnPosition.y, 0);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));
                spawner.ValueRW._nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO._spawnRate;
            }
        }
    }
}
