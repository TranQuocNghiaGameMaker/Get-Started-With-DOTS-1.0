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
        foreach (var transform in SystemAPI.Query<TransformAspect>())
        {
            transform.Position += new float3(SystemAPI.Time.DeltaTime, 0, 0);
        }
    }
}
