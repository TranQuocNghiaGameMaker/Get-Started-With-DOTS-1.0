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
        var ecsSpawner = SystemAPI.GetSingletonEntity<ECSSpawnerTag>();
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        new SpawnCubeJob
        {
            ECB = ecb
        }.Run();
    }
}
[BurstCompile]
public partial struct SpawnCubeJob : IJobEntity
{
    public EntityCommandBuffer ECB;
    [BurstCompile]
    private void Execute(SpawnCubeAspect ecsSpawner)
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
                    Scale = 0.85f
                };
                var cube = ECB.Instantiate(ecsSpawner.CubePrefab);
                ECB.SetComponent(cube, new LocalToWorldTransform
                {
                    Value = UniformPos

                });
                ECB.SetComponent(cube, new DistanceToOrigin
                {
                    Value = magnitude
                });
            }
        }
        //ecb.Playback(state.EntityManager);
    }
}
