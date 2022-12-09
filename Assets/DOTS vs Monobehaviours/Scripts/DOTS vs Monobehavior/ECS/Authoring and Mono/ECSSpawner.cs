using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEditor.Rendering;
using UnityEngine;

public class ECSSpawner : MonoBehaviour
{
    public GameObject CubePrefab;
    [HideInInspector] public int NumberToSpawn;
}

public partial class ECSBaker : Baker<ECSSpawner>
{
    public override void Bake(ECSSpawner authoring)
    {
        AddComponent(new CubePrefabEntity
        {
            CubePrefab = GetEntity(authoring.CubePrefab)
        });
        AddComponent(new NumberToSpawn
        {
            Value = authoring.NumberToSpawn
        });
    }
}