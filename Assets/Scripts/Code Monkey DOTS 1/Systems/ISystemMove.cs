using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
//Create system run on main thread, can't use Burst Compile
[BurstCompile]
public partial struct ISystemMove : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
       /* var deltaTime = SystemAPI.Time.DeltaTime;
        var random = SystemAPI.GetSingletonRW<RandomComponent>();
        JobHandle moveJob = new MoveJob { 
            deltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);
        moveJob.Complete();

        new CheckArrivedJob
        {
            randomComponent = random
        }.Run();*/
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    [BurstCompile]
    public void Execute(MoveAspect moveObject)
    {
        moveObject.Move(deltaTime);
    }
}

[BurstCompile]
public partial struct CheckArrivedJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public RefRW<RandomComponent> randomComponent;
    [BurstCompile]
    public void Execute(MoveAspect moveObject)
    {
        moveObject.ChangeTargetWhenArrive(randomComponent);
    }
}