using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
}
public partial class PlayerBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        AddComponent(new Speed { Value = authoring.Speed });
        AddComponent<PlayerTag>();
    }
}