using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject landingArea;
    public int hitPoints = 100;

    private bool reSpawn = false;
    private bool spotSelected = false;
    private Spawner[] spawnPoints;
    private AudioSource innerVoiceAS;
    private Vector3 landingSpot;
    private Quaternion landingRotation;
    private GameManager gameManager;

    void Start () {
        spawnPoints = FindObjectsOfType<Spawner>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (reSpawn == true)
        {
            Invoke("ReSpawn", 10f);
            // to do some counting so the player will know when spawn happens
            reSpawn = false;
        }

        if (Input.GetButton("CallHeli") && spotSelected == true)
        {
            Instantiate(landingArea, landingSpot, landingRotation);
            SendMessageUpwards("OnMakeInitialHeliCall");
            spotSelected = false;
            gameManager.BlinkText(spotSelected);
        }
    }

    private void ReSpawn() {
        int spawner;
        spawner = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[spawner].transform.position;
    }

    public void SelectSpot()
    {
        landingSpot = transform.position;
        landingRotation = transform.rotation;
        spotSelected = true;
        gameManager.BlinkText(spotSelected);
    }
    
    public void DamageTaken() {
        if (hitPoints <= 0) {
            Destroy(gameObject);
            reSpawn = true;
        }
    }
    public bool getSpotSelected() {
        return spotSelected;
    }
}
