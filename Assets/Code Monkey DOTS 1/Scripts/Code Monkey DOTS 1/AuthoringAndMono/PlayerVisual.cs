using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Entity targetEntity;
    
    private Entity GetRandomEntity()
    {
        var playerTagEntitiesQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTag));
        NativeArray<Entity> entities = playerTagEntitiesQuery.ToEntityArray(Allocator.Temp);
        if(entities.Length <= 0)
        {
            return Entity.Null;
        }
        else
        {
            return entities[Random.Range(0, entities.Length - 1)];
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetEntity = GetRandomEntity();
        }
        if(targetEntity != Entity.Null)
        {
            Vector3 targetPos = World.DefaultGameObjectInjectionWorld.EntityManager.
                                            GetComponentData<LocalToWorldTransform>(targetEntity).Value.Position;
            transform.position = targetPos;
        }
    }
}
