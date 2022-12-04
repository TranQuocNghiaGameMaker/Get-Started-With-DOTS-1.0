using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class GameObjectAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
}
public partial class GameObjectBaker : Baker<GameObjectAuthoring>
{
    public override void Bake(GameObjectAuthoring authoring)
    {
        AddComponent(new Speed { Value = authoring.Speed });
    }
}