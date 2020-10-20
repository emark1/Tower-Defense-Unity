using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;

    [SerializeField] Queue<Tower> towerQueue = new Queue<Tower>();
    [SerializeField] Transform towerParentTransform;

    public void AddTower(Waypoint waypoint) {
        if (towerQueue.Count < 5) {
            // Tower newTower = new Tower();
            Tower newTower = Instantiate(tower, waypoint.transform.position, waypoint.transform.rotation);
            newTower.transform.parent = towerParentTransform.transform;
            newTower.baseWaypoint = waypoint;
            towerQueue.Enqueue(newTower);
            waypoint.isPlacable = false;
        } else {
            Debug.Log("Tower limit reached");
            Tower oldestTower = towerQueue.Dequeue();
            oldestTower.baseWaypoint.isPlacable = true;
            oldestTower.transform.position = waypoint.transform.position;
            oldestTower.baseWaypoint = waypoint;
            towerQueue.Enqueue(oldestTower);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
