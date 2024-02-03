using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shooty mechanism for the puffer fish and perhaps the other enemies later on - A

public class EnemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
   

    float distance = Vector2.Distance(transform.position, player.transform.position); // will only shoot when player is in the vicinity of the enemy, prevents shooting from immediate game start.
    Debug.Log(distance);

    if(distance < 15) //change distance here :)
    {
    timer += Time.deltaTime;

    if (timer > 2)
    {
    timer = 0;
    shoot();
    }
 }

   }
    void shoot() 
    {
    Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
