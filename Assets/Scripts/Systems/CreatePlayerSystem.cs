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
        var playerQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var playerSpawnerComponent = SystemAPI.GetSingleton<PlayerPrefabComponent>();
        int spawnAmount = 2;
        if(playerQuery.CalculateEntityCount() < spawnAmount)
        {
            EntityManager.Instantiate(playerSpawnerComponent.PlayerPrefab);
        }
    }
}
