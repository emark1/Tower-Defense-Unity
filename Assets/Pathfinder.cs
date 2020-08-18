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
    Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void CreatePath () {
        path.Add(endingBlock);
        endingBlock.isPlacable = false;
        Waypoint previous = endingBlock.exploredFrom;
        while (previous != startingBlock) {
            path.Add(previous);
            previous.isPlacable = false;
            previous = previous.exploredFrom;
        }

        path.Add(startingBlock);
        startingBlock.isPlacable = false;
        path.Reverse();
    }



    public List<Waypoint> GetPath() {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void BreadthFirstSearch() {
        queue.Enqueue(startingBlock);
        while(queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            if (searchCenter == endingBlock) {
                isRunning = false;
            };
            ExploreNeighbors();
        }
    }

    private void ExploreNeighbors() {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
                if (grid.ContainsKey(neighborCoordinates)) {
                    Waypoint neighbor = grid[neighborCoordinates];
                    if (neighbor.isExplored == false && !queue.Contains(neighbor)) {
                        queue.Enqueue(neighbor);
                        neighbor.exploredFrom = searchCenter;
                    }
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
