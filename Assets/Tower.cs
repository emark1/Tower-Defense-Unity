using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    void Update()
    {
        FaceNearestEnemy();
    }

    private void FaceNearestEnemy() {
        objectToPan.LookAt(targetEnemy);
    }


}
