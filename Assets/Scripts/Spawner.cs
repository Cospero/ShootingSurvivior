using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float SpawnRadius;
    [SerializeField] private Transform center;


    [Serializable]

    class Wave
    {
        public float spawnTime;
        public Enemy enemyPrefab;
        public int countMin, countMax;
    }

    [SerializeField] private Wave[] waves;

    private int waveIndex;

    private Wave CurrentWave => waves[waveIndex];

    private bool HasWaves => waveIndex < waves.Length;





    private void Update()
    {
        if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.spawnTime)
        {
            Spawn();
            waveIndex++;
        }
    }


    private void Spawn()
    {
        int count = UnityEngine.Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);
        for (int i  = 0; i < count; i++)
        {
            var position = center.position + (Vector3)UnityEngine.Random.insideUnitCircle * SpawnRadius;
            Instantiate(CurrentWave.enemyPrefab, position, Quaternion.identity);
        }
    }

}
