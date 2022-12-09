using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject PlayerPrefab;
}

public partial class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        AddComponent(new PlayerPrefabComponent
        {
            PlayerPrefab = GetEntity(authoring.PlayerPrefab)
        });
    }
}
