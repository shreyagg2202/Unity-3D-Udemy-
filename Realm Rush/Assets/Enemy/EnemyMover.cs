using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5f)] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PrintWaypointName());
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        
        foreach (Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }    
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator PrintWaypointName()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
