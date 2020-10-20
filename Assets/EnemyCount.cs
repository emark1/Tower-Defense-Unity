using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] Text countText;
    
    int enemyCount = 0;

    void Start()
    {
        countText.text = enemyCount.ToString();
    }

    public void UpdateCountAdd() {
        enemyCount += 1;
        countText.text = enemyCount.ToString();
    }

    public void UpdateCountRemove() {
        enemyCount -= 1;
        countText.text = enemyCount.ToString();
    }
}
