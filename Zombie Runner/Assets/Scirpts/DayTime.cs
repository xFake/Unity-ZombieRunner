using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour {

    public float timeScale = 60f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ChangeSunPosition();
    }

    public void ChangeSunPosition() {
        float translation = Time.deltaTime /360 * timeScale;
        transform.Rotate(translation, 0, 0);

    }
}
