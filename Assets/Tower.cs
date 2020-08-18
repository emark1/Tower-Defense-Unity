using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 45f;
    [SerializeField] ParticleSystem bullets;
    bool inRange = false;

    Spawner spawner;


    void Update()
    {
        FaceAndFire();
    }

    private void FaceAndFire() {
        FindEnemies();
        
        if (targetEnemy != null) {
            if (RangeFinder() <= 45f) {
                if (targetEnemy == null) {return;}
                objectToPan.LookAt(targetEnemy);
                FireWeapon(true);
            } else {
                FireWeapon(false);
                objectToPan.rotation = Quaternion.identity;
            }
        }
    }

    private void FindEnemies() {
        var sceneEnemies = FindObjectsOfType<EnemyMover>();
        if (sceneEnemies.Length == 0) {return;}
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyMover testEnemy in sceneEnemies) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy) {
        float closestEnemyDistance = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
        float testEnemyDistance = Vector3.Distance(testEnemy.position, gameObject.transform.position);
        if (closestEnemyDistance < testEnemyDistance) {
            return closestEnemy;
        } else {
            return testEnemy;
        }
    }

    private void FireWeapon(bool firing) {
        var emission = bullets.emission;
        if (firing) {
            emission.enabled = true;
        } else {
            emission.enabled = false;
        }
    }

    private float RangeFinder() {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        return distanceToEnemy;
    }


}
