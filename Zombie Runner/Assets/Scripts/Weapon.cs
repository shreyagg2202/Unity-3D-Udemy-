﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit " + hit.transform.name);
            //TODO: add some hit effect for visual players
            EnemyHealth Target = hit.transform.GetComponent<EnemyHealth>();
            if (Target==null) return;
            Target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
