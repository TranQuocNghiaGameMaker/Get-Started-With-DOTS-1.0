using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


[UpdateInGroup(typeof(InitializationSystemGroup))]
[BurstCompile]
public partial struct ISystemSpawnCube : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<CubePrefabEntity>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
        new SpawnCubeJob
        {
            ECB = ecb
        }.ScheduleParallel();
    }
}
[BurstCompile]
public partial struct SpawnCubeJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ECB;
    [BurstCompile]
    private void Execute(SpawnCubeAspect ecsSpawner,[EntityInQueryIndex] int sortkey)
    {
        var numberToSpawn = ecsSpawner.NumberToSpawn;
        var start = numberToSpawn / 2 * -1;
        for (int i = 0; i < numberToSpawn; i++)
        {
            for (int j = 0; j < numberToSpawn; j++)
            {
                float xPos = start + (i + 1) * 1;
                float zPos = start + (j + 1) * 1;
                float magnitude = math.sqrt(xPos * xPos + zPos * zPos);
                var Pos = new float3(xPos, 0, zPos);
                var UniformPos = new UniformScaleTransform
                {
                    Position = Pos,
                    Scale = 0.95f
                };
                var cube = ECB.Instantiate(sortkey,ecsSpawner.CubePrefab);
                ECB.SetComponent(sortkey,cube, new LocalToWorldTransform
                {
                    Value = UniformPos

                });
                ECB.SetComponent(sortkey,cube, new DistanceToOrigin
                {
                    Value = magnitude
                });
            }
        }
    }
}
