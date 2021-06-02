﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bumped into the wall!");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
