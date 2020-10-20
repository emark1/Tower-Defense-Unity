using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    

    private void OnParticleCollision(GameObject other) {
        health -= 1;
        hitParticle.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyHitSFX);
        if (health <= 0) {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy() {
        var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        float destroyDelay = vfx.main.duration;
        vfx.Play();
        Destroy(vfx.gameObject, destroyDelay);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
