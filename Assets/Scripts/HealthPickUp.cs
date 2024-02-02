using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        //Set the current number of coins to display
        if (healthText.text != SC_2DCoin.PlayerHealth.ToString())
        {
            healthText.text = SC_2DCoin.PlayerHealth.ToString();
        }
    }

}
