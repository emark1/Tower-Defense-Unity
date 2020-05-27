using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;   
    TextMesh textMesh; 

    void Update()
    {
        Vector3 snapPosition;

        snapPosition.x = Mathf.RoundToInt(transform.position.x/10f) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z/10f) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;


    }
}
