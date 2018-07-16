using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {


    private int collisionCount = 0;
    private float timeSinceExit;
    private bool spotSelected = false;


    private void Update()
    {

        if (collisionCount == 1 && Time.time > timeSinceExit + 1 && spotSelected == false && Time.time >10f )
        {
            spotSelected = true;
            SendMessageUpwards("OnFindClearArea");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
        timeSinceExit = Time.time;
    }

    public bool getSpotSelected() {
        return spotSelected;
    }
}
