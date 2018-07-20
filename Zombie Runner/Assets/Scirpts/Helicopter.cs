using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRunner;

public class Helicopter : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Player player;
    private float speed = 50f;
    private Vector3 aboveLandingSpot;
    private float step;
    private bool aboveLandingSpotFlag = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        step = speed * Time.deltaTime;

    }
    private void Update()
    {
        if (transform.position == aboveLandingSpot) {
            aboveLandingSpotFlag = true;
        }
        if (transform.position.y > player.GetLandingSpot().y && aboveLandingSpotFlag == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.GetLandingSpot(), step);
        }
        if (transform.position.z >= 0 && transform.position.z < aboveLandingSpot.z)
        {
            rigidBody.velocity = Vector3.zero;
            transform.position =  Vector3.MoveTowards(transform.position, aboveLandingSpot, step);
        }

    }

    public void SendHeli()
    {
        rigidBody.velocity = new Vector3(0, 0, speed);
        float tempX = player.GetLandingSpot().x;
        float tempZ = player.GetLandingSpot().z;
        aboveLandingSpot = new Vector3(tempX, 250, tempZ);
    }
}
