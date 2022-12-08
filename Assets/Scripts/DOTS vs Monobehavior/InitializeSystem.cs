using TMPro;
using Unity.Entities;
using UnityEngine;

public class InitializeSystem : MonoBehaviour
{
    [SerializeField] int numberToSpawn;
    [SerializeField] bool useECS;
    private ViewDistanceSetter camView;
    private TextMeshProUGUI numberText;
    // Start is called before the first frame update
    void Start()
    {
        GetNumberEntitiesSpawn();
        GetCameraDistanceSetter();
        GetText();
    }

    private void GetNumberEntitiesSpawn()
    {
        var ecsSpawnerQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(NumberToSpawn));
        ecsSpawnerQuery.GetSingletonRW<NumberToSpawn>().ValueRW.Value = numberToSpawn;
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
