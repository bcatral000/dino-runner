using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //spawns obstacles from an array of prefabs 
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    //how often an object will spawn within a specific range of 1 or 2 seconds
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    //function to spawn objects
    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    //stops spawning objects after a game over
    private void OnDisable()
    {
        CancelInvoke();
    }


    private void Spawn()
    {
        float spawnChance = Random.value;

        //loops through each of our objects
        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                //spawns obstacle where the spawner is
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));

    }
}
