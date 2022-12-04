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
        foreach ((var transform,var speed) in SystemAPI.Query<TransformAspect,RefRO<Speed>>())
        {
            transform.Position += new float3(SystemAPI.Time.DeltaTime * speed.ValueRO.Value, 0, 0);
        }
    }
}
