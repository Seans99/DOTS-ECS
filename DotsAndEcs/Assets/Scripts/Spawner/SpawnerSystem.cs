using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

    }

    public void OnDestroy(ref SystemState state)
    {

    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO._nextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO._prefab);
                float3 pos = new float3(spawner.ValueRO._spawnPosition.x, spawner.ValueRO._spawnPosition.y, 0);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));
                spawner.ValueRW._nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO._spawnRate;
            }
        }
    }
}
