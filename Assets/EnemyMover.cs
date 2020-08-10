using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath (List<Waypoint> path) {
        Debug.Log("Starting Patrol");
        foreach(Waypoint block in path) {
            Debug.Log("Visiting block: " + block.transform.position);
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending Patrol");
    }
}

