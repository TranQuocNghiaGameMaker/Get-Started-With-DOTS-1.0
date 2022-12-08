using System.Collections;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;



public readonly partial struct SpawnCubeAspect : IAspect
{
    private readonly Entity _entity;
    private readonly TransformAspect _transform;
    private readonly RefRO<CubePrefabEntity> _cubePrefabEntity;
    private readonly RefRO<NumberToSpawn> _numberToSpawn;

    public int NumberToSpawn => _numberToSpawn.ValueRO.Value;
    public Entity CubePrefab => _cubePrefabEntity.ValueRO.CubePrefab;
}
