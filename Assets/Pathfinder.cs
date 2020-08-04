using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startingBlock;
    [SerializeField] Waypoint endingBlock;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        Pathfind();
    }

    private void Pathfind() {
        queue.Enqueue(startingBlock);
        while(queue.Count > 0 && isRunning) {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            Debug.Log("Searching from: " + searchCenter);
            if (searchCenter == endingBlock) {
                Debug.Log("ENDPOINT FOUND AT " + searchCenter);
                isRunning = false;
            };
            ExploreNeighbors(searchCenter);
        }
        Debug.Log("FINISHED SEARCHING");
    }

    private void ExploreNeighbors(Waypoint from) {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try {
                Waypoint neighbor = grid[neighborCoordinates];
                if (neighbor.isExplored == false && !queue.Contains(neighbor)) {
                    neighbor.SetTopColor(Color.blue);
                    queue.Enqueue(neighbor);
                    Debug.Log("Queueing " + neighbor);
                }
            } catch {
                //nothing
            }
        }
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
                waypoint.SetTopColor(Color.green);
            } else if (endingBlock.GetGridPos() == waypoint.GetGridPos()) {
                waypoint.SetTopColor(Color.red);
            }
        }
    }
}
