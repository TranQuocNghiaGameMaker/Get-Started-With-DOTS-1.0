using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract void Initialize(int w, int h,GameObject prefab);
}