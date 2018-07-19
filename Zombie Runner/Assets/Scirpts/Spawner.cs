using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject player;

    private Transform[] spawnPoints;
    private RadioSystem radioSystem;

    void Start () {
        spawnPoints = GetComponentsInChildren<Transform>();
        radioSystem = FindObjectOfType<RadioSystem>();
    }

    public void ReSpawn()
    {
        int spawner;
        spawner = Random.Range(1, spawnPoints.Length);
        GameObject newPlayer = Instantiate(player, spawnPoints[spawner].transform.position, Quaternion.identity);
        newPlayer.transform.parent = radioSystem.transform;
    }
}
