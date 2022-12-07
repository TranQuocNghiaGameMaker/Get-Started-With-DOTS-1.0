using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;



public readonly partial struct MoveAspect : IAspect
{
    private readonly Entity _entity;
    private readonly TransformAspect _transform;

    private readonly RefRW<TargetPosition> _target;
    private readonly RefRO<Speed> speed;
    private float3 direction => math.normalize(_target.ValueRO.Value - _transform.Position);

    private float DistanceToReachTarget => 0.5f;
    public void Move(float deltaTime)
    {
        _transform.Position += direction * speed.ValueRO.Value * deltaTime;
        
    }
    public void ChangeTargetWhenArrive(RefRW<RandomComponent> randomComponent)
    {
        if (math.distancesq(_transform.Position, _target.ValueRO.Value) < DistanceToReachTarget)
        {
            _target.ValueRW.Value = GetRandomPosition(randomComponent);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3
        (
            randomComponent.ValueRW.random.NextFloat(0f, 30f),
            0,
            randomComponent.ValueRW.random.NextFloat(0f, 30f)
        );
    }


}
