using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombie;
    public int maxZombieCount = 100; 

    private int zombieCount = 0;
    private Transform[] zombieSpawnPoints;
    private float lastZombieSpawnTime;

    void Start () {
        zombieSpawnPoints = GetComponentsInChildren<Transform>();
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
        spawner = Random.Range(1, zombieSpawnPoints.Length);
        GameObject newZombie = Instantiate(zombie, zombieSpawnPoints[spawner].transform.position, Quaternion.identity);
        newZombie.transform.parent = zombieSpawnPoints[spawner].transform;
        zombieCount++;
        lastZombieSpawnTime = Time.time;
    }
}
