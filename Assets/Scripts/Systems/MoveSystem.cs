using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
//Create system run on main thread, can't use Burst Compile
public partial class MoveSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = SystemAPI.Time.DeltaTime;
        var random = SystemAPI.GetSingletonRW<RandomComponent>();
        foreach (var moveObject in SystemAPI.Query<MoveAspect>())
        {
            moveObject.Move(deltaTime);
            moveObject.ChangeTargetWhenArrive(random);
        }
    }
}
