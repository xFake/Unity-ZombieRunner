using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombie;
    public int maxZombieCount = 100;

    private int zombieCount = 0;
    private ZombieSpawner[] zombieSpawnPoints;
    private float lastZombieSpawnTime;

    void Start () {
        zombieSpawnPoints = FindObjectsOfType<ZombieSpawner>();
    }

    void Update () {
        if (zombieCount < maxZombieCount && Time.time > lastZombieSpawnTime + 1f)
        {
            SpawnZombie();
        }
    }

    public void SpawnZombie()
    {
        int spawner;
        spawner = Random.Range(0, zombieSpawnPoints.Length);
        Vector3 spawnerPosition = zombieSpawnPoints[spawner].transform.position;
        GameObject newZombie = Instantiate(zombie, spawnerPosition, Quaternion.identity);
        newZombie.transform.parent = gameObject.transform;
        zombieCount++;
        lastZombieSpawnTime = Time.time;
    }
}
