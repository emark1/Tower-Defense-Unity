using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBase : MonoBehaviour
{
    public int baseHealth = 5;

    public void DamageBase() {
        baseHealth -= 1;
        if (baseHealth <= 0) {
            Debug.Log("BASE DESTROYED GAME OVER");
        }
    }

}
