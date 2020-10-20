using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    [SerializeField] Text healthText;

    FriendlyBase friendlyBase;
    

    // Start is called before the first frame update
    void Start()
    {
        friendlyBase = FindObjectOfType<FriendlyBase>();
        healthText.text = friendlyBase.baseHealth.ToString();
    }

    public void UpdateHealth() {
        healthText.text = friendlyBase.baseHealth.ToString();
    }

}
