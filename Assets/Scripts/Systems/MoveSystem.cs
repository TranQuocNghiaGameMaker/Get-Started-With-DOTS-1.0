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
        var deltaTime = SystemAPI.Time.DeltaTime;
        var random = SystemAPI.GetSingletonRW<RandomComponent>();
        foreach (var moveObject in SystemAPI.Query<MoveAspect>())
        {
            moveObject.Move(deltaTime,random);
        }
    }
}
