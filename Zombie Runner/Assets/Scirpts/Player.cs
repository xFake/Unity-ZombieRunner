using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject landingArea;

    private bool reSpawn = false;
    private Spawner[] spawnPoints;
    private AudioSource innerVoiceAS;

	void Start () {
        spawnPoints = FindObjectsOfType<Spawner>();
    }

    void Update()
    {
        if (reSpawn == true)
        {
            ReSpawn();
            reSpawn = false;
        }
    }

    private void ReSpawn() {
        int spawner;
        spawner = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[spawner].transform.position;
    }

    private void CallHeli()
    {
    }

    public void DropFlare() {
        Instantiate(landingArea,transform.position,transform.rotation);
    }
}
