using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody myRigidBody;
    float timeElapsed;
    [SerializeField] float timeToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        myRigidBody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        myRigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;
        if (timeElapsed > timeToWait)
        {
            renderer.enabled = true;
            myRigidBody.useGravity = true;
        }
    }
}
