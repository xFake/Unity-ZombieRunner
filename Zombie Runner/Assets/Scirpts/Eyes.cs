using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    private Camera eyes;
    private float deffaultFOV;
    private float minFOV = 40f;
	// Use this for initialization
	void Start () {
        eyes = GetComponent<Camera>();
        deffaultFOV = eyes.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Zoom")){
            if (eyes.fieldOfView > minFOV)
            {
                eyes.fieldOfView = eyes.fieldOfView / 1.1f;
            }
        }
        else {
            eyes.fieldOfView = deffaultFOV;
        }
    }
}
