using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{   

    [SerializeField] float spawnCounter = 3f;
    [SerializeField] List<EnemyMover> enemyList;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip enemySpawnedSFX;
    int score = 0;
    bool spawn = true;

    IEnumerator Start() {
        spawnedEnemies.text = score.ToString();

        do {
            yield return StartCoroutine(CountDownAndSpawn());
        } while (spawn);
    }

    IEnumerator CountDownAndSpawn () {
        yield return new WaitForSeconds(spawnCounter);
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        score++;
        spawnedEnemies.text = score.ToString();
        GetComponent<AudioSource>().PlayOneShot(enemySpawnedSFX);
        EnemyMover newEnemy = Instantiate(enemyList[0], transform.position, transform.rotation) as EnemyMover;
        newEnemy.transform.parent = transform;
    }


}
