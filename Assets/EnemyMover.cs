using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogPathCoordinates(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LogPathCoordinates (List<Waypoint> path) {
        Debug.Log("Starting Patrol");
        foreach(Waypoint block in path) {
            Debug.Log("Visiting block: " + block.transform.position);
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending Patrol");
    }
}

