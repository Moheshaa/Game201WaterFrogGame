using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathCounter : MonoBehaviour
{
    Text breathText;

    // Start is called before the first frame update
    void Start()
    {
        breathText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (breathText.text != Player.breath.ToString())
        {
            breathText.text = Player.breath.ToString();
        }
    }
}
