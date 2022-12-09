using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CubeAuthoring : MonoBehaviour
{
    
}
public partial class CubeBaker : Baker<CubeAuthoring>
{
    public override void Bake(CubeAuthoring authoring)
    {
        AddComponent<DistanceToOrigin>();
        AddComponent<LifeTime>();
        AddComponent<CubeTag>();
    }
}