using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class GameObjectSpawner : Spawner
{
    public static WaveMonoComponent[] WAVE_MONO_COMPONENTS;
    public override void Initialize(int w, int h, GameObject prefab)
    {
        WAVE_MONO_COMPONENTS = new WaveMonoComponent[w * h];
        var startX = w / 2 * -1;
        var startZ = h / 2 * -1;
        int indexer = 0;
        for(int i = 0;i < w; i++)
        {
            for(int j = 0;j < h; j++)
            {
                var xPos = startX + i + 1;
                var zPos = startZ + j + 1;
                var magnitude = Mathf.Sqrt(xPos * xPos + zPos * zPos);
                var obj = Instantiate(prefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                WaveMonoComponent waveMonoComponent = obj.GetComponent<WaveMonoComponent>();
                waveMonoComponent.DistanceToOrigin = magnitude;
                WAVE_MONO_COMPONENTS[indexer] = waveMonoComponent;
                indexer++;
            }
        }
    }
}
