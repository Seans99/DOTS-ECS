using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class BulletAuthoring : MonoBehaviour
{
    public float _bulletSpeed;

    public class BulletAuthoringBaker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BulletMoveSpeed { _value = authoring._bulletSpeed });
        }
    }
}
