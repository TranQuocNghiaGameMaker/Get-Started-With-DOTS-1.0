using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomAuthoring : MonoBehaviour
{
}
public partial class RandomBaker : Baker<RandomAuthoring>
{
    public override void Bake(RandomAuthoring authoring)
    {
        AddComponent(new RandomComponent { random = new Random(1) }); ;
    }
}
