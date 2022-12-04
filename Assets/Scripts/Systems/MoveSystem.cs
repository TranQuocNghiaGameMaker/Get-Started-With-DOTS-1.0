using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach ((var transform,var speed,var target) in SystemAPI.Query<TransformAspect,RefRO<Speed>,RefRO<TargetPosition>>())
        {
            var direction = math.normalize(target.ValueRO.Value - transform.Position);
            transform.Position += direction * SystemAPI.Time.DeltaTime * speed.ValueRO.Value;
        }
    }
}
