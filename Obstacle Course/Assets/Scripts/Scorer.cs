using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;

    private void OnCollisionEnter(Collision collision)
    {
        hits++;
        Debug.Log("You've bumbed into a thing this many times: " + hits);
    }
}
