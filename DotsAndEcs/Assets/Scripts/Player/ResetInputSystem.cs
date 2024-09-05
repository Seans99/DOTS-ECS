using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateBefore(typeof(EndSimulationEntityCommandBufferSystem))]
public partial struct ResetInputSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        foreach (var (tag, entity) in SystemAPI.Query<FireBulletTag>().WithEntityAccess())
        {
            ecb.SetComponentEnabled<FireBulletTag>(entity, false);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
