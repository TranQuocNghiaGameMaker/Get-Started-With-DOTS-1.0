using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;



public readonly partial struct WaveAspect : IAspect
{
    private readonly Entity _entity;
    private readonly TransformAspect _transform;
    private readonly RefRO<DistanceToOrigin> _distance;
    private readonly RefRW<LifeTime> _lifeTime;
    public void UpdateLifeTime(float deltaTime)
    {
        float value = math.mul(deltaTime, 5f);
        _lifeTime.ValueRW.Value += value; 
    }

    public void CreateWaveEffect()
    {
        var position = _transform.Position;
        position.y = math.sin((_distance.ValueRO.Value - _lifeTime.ValueRO.Value) * 0.5f);
        _transform.Position = position;
    }
}
