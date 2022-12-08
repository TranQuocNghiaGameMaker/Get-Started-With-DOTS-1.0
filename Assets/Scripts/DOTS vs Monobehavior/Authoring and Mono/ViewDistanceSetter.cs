using Unity.Entities;
using UnityEngine;

public class ViewDistanceSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ecsSpawnerQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(NumberToSpawn));
        int numberToSpawn = ecsSpawnerQuery.GetSingleton<NumberToSpawn>().Value;
        SetDistanceFromOrigin(numberToSpawn);
    }

    private void SetDistanceFromOrigin(float distance)
    {
        Vector3 viewDirection = transform.position.normalized;
        transform.position = viewDirection * distance;
    }
}
