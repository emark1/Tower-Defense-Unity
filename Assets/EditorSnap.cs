﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;    

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x/10f) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z/10f) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
    }
}
