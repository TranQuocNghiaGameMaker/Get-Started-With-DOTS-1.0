using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMonoSystem : MonoBehaviour
{
    private float _time = 0;
    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime * 5;
        for(int i = 0; i < GameObjectSpawner.WAVE_MONO_COMPONENTS.Length; i++)
        {
            WaveMonoComponent wave = GameObjectSpawner.WAVE_MONO_COMPONENTS[i];
            Vector3 pos = wave.transform.position;
            pos.y = Mathf.Sin((wave.DistanceToOrigin - _time) * 0.5f);
            wave.transform.position = pos;
        }
    }
}
