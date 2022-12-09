using TMPro;
using Unity.Entities;
using UnityEngine;

public class InitializeSystem : MonoBehaviour
{
    [SerializeField] int numberToSpawn;
    [SerializeField] bool useECS;

    [Tooltip("For Monobehaviour system")]
    [Header("MonoBehaviour 's prefab")]
    [SerializeField] GameObject cubePrefab;

    private ViewDistanceSetter camView;
    private TextMeshProUGUI numberText;
    void Start()
    {
        if (!useECS)
        {
            var spawnerObj = new GameObject("Spawner", typeof(GameObjectSpawner));
            spawnerObj.GetComponent<GameObjectSpawner>().Initialize(numberToSpawn, numberToSpawn, cubePrefab);
            new GameObject("Wave System", typeof(WaveMonoSystem));
            World.DefaultGameObjectInjectionWorld.DestroyAllSystemsAndLogException();
        }
        else
        {
           GetNumberEntitiesSpawn(numberToSpawn);
        }
        GetCameraDistanceSetter();
        GetText();
    }

    private void GetNumberEntitiesSpawn(int number)
    {
        var ecsSpawnerQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(NumberToSpawn));
        ecsSpawnerQuery.GetSingletonRW<NumberToSpawn>().ValueRW.Value = number;
    }

    private void GetCameraDistanceSetter()
    {
        camView = GetComponentInChildren<ViewDistanceSetter>();
        camView.SetDistanceFromOrigin(numberToSpawn);
    }
    [ContextMenu("Get Text")]
    private void GetText()
    {
        numberText = GameObject.Find("NumberText").GetComponent<TextMeshProUGUI>();
        numberText.text = "Number to spawn: " + (numberToSpawn * numberToSpawn);
    }
    
}
