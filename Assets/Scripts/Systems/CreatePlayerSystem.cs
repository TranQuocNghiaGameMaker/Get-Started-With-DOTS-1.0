using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
//Create system run on main thread, can't use Burst Compile
public partial class CreatePlayerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        int spawnAmount = 1000;
        var playerQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var playerSpawnerComponent = SystemAPI.GetSingleton<PlayerPrefabComponent>();
        var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        var ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().
                                                             CreateCommandBuffer(World.Unmanaged);
        if(playerQuery.CalculateEntityCount() < spawnAmount)
        {
            var entity = ecb.Instantiate(playerSpawnerComponent.PlayerPrefab);
            ecb.SetComponent<Speed>(entity, new Speed{
                Value = randomComponent.ValueRW.random.NextFloat(2f,4f)
            });
        }
    }
}
