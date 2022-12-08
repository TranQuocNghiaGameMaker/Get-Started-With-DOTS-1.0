using System.Collections;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;


[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct ISystemSpawnCube : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<CubePrefabEntity>();
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var ecsSpawner = SystemAPI.GetSingletonEntity<ECSSpawnerTag>();
        var spawnASpect = SystemAPI.GetAspectRW<SpawnCubeAspect>(ecsSpawner);
        var numberToSpawn = spawnASpect.NumberToSpawn;
        var start = numberToSpawn / 2 * -1;
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        for(int i = 0;i < numberToSpawn; i++)
        {
            for(int j = 0;j < numberToSpawn; j++)
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
                var cube = ecb.Instantiate(spawnASpect.CubePrefab);
                ecb.SetComponent(cube, new LocalToWorldTransform
                {
                    Value = UniformPos

                });
                ecb.SetComponent(cube, new DistanceToOrigin
                {
                    Value = magnitude
                });
            }
        }
        ecb.Playback(state.EntityManager);
    }
}
