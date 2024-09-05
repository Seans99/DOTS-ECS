using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct FireBulletSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
        foreach (var (bulletPrefab, transform) in SystemAPI.Query<BulletPrefab, LocalTransform>().WithAll<FireBulletTag>()) 
        {
            var newBullet = ecb.Instantiate(bulletPrefab._value);
            var bulletTransform = LocalTransform.FromPositionRotation(transform.Position, transform.Rotation);
            ecb.SetComponent(newBullet, bulletTransform);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
