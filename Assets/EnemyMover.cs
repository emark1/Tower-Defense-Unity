using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    EnemyDamage enemyDamage; 
    FriendlyBase friendlyBase;
    HealthDisplay healthDisplay;
    [SerializeField] AudioClip baseDamageSFX;

    void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
        enemyDamage = GetComponent<EnemyDamage>();
        friendlyBase = FindObjectOfType<FriendlyBase>();
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }


    IEnumerator FollowPath (List<Waypoint> path) {
        var pathLength = path.Count;
        var iteration = 0;
        foreach(Waypoint block in path) {
            iteration += 1;
            if (iteration == pathLength) {
                transform.position = block.transform.position;
                GetComponent<AudioSource>().PlayOneShot(baseDamageSFX);
                yield return new WaitForSeconds(1f);
                friendlyBase.DamageBase();
                enemyDamage.DestroyEnemy();
                healthDisplay.UpdateHealth();
            } else {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
            }
        }
    }
}

