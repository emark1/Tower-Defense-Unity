using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   

    [SerializeField] float spawnCounter = 3f;
    [SerializeField] List<EnemyMover> enemyList;

    bool spawn = true;

    IEnumerator Start() {
        do {
            yield return StartCoroutine(CountDownAndSpawn());
        } while (spawn);
    }

    IEnumerator CountDownAndSpawn () {
        yield return new WaitForSeconds(spawnCounter);
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        EnemyMover newEnemy = Instantiate(enemyList[0], transform.position, transform.rotation) as EnemyMover;
        newEnemy.transform.parent = transform;
    }


}
