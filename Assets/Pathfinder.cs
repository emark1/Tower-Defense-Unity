using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startingBlock;
    [SerializeField] Waypoint endingBlock;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping == false) {
                grid.Add(waypoint.GetGridPos(), waypoint);
                waypoint.SetTopColor(Color.gray);
            } else {
                Debug.LogWarning("Not loading block at " + waypoint.GetGridPos() + ", block already exists");
            }
            
            if (startingBlock.GetGridPos() == waypoint.GetGridPos()) {
                waypoint.SetTopColor(Color.red);
            } else if (endingBlock.GetGridPos() == waypoint.GetGridPos()) {
                waypoint.SetTopColor(Color.green);
            }
        }
    }
}
