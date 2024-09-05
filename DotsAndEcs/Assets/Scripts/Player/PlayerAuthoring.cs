using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public float _moveSpeed;

    public GameObject _bulletPrefab;

    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<PlayerTag>(playerEntity);
            AddComponent<PlayerMoveInput>(playerEntity);
            AddComponent(playerEntity, new PlayerMoveSpeed
            {
                _value = authoring._moveSpeed,
            });
            AddComponent<FireBulletTag>(playerEntity);
            SetComponentEnabled<FireBulletTag>(playerEntity, false);
            AddComponent(playerEntity, new BulletPrefab
            {
                _value = GetEntity(authoring._bulletPrefab, TransformUsageFlags.Dynamic),
            });
        }
    }
}

public struct PlayerMoveInput : IComponentData
{
    public float2 _value;
}

public struct PlayerMoveSpeed : IComponentData
{
    public float _value;
}

public struct PlayerTag : IComponentData { }

public struct BulletPrefab : IComponentData
{
    public Entity _value;
}

public struct BulletMoveSpeed : IComponentData
{
    public float _value;
}

public struct FireBulletTag : IComponentData, IEnableableComponent { }