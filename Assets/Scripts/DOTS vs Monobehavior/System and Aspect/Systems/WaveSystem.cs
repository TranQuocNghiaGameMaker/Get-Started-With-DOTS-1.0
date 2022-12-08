using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


[BurstCompile]
public partial struct WaveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<CubeTag>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var deltaTime = SystemAPI.Time.DeltaTime;
        new WaveJob
        {
            DeltaTime = deltaTime
        }.Run();
    }
}

public partial struct WaveJob : IJobEntity
{
    public float DeltaTime;
    private void Execute(WaveAspect waveAspect)
    {
        waveAspect.UpdateLifeTime(DeltaTime);
        waveAspect.CreateWaveEffect();
    }
}
