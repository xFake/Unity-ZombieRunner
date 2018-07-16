﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private bool called = false;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void SendHeli()
    {
        called = true;
        rigidBody.velocity = new Vector3(0, 0, 50f);
    }
}
