using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] Color exploredColor;
    

    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlacable = true;

    void Update () {
        // if (isExplored) {
        //     SetTopColor(exploredColor);
        // }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (isPlacable) {
                FindObjectOfType<TowerFactory>().AddTower(this);
                
            } else {
                Debug.Log("Can't place here");
            }
        // } && isPlacable) {
        //     Debug.Log("Mouse is over: " + GetGridPos());
        // } else {
        //     Debug.Log("Can't place here");
        // }
        }
        
    }

    public Vector3Int GetGridPosVertical () {
        return new Vector3Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(-1),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public int GetGridSize() {
        return gridSize;
    }

    public Vector2Int GetGridPos() {     
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

}
