using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    player = GameObject.FindGameObjectWithTag("Player");

    Vector3 direction = player.transform.position - transform.position; //Can alter for changing how the bullet exits the enemy body later on if need be :)
    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; //adjust rotation of bullet
    transform.rotation = Quaternion.Euler(0, 0, rot + 90); //z input can change the degrees of the bullet for rotation
    }

    // Update is called once per frame
    void Update()
    {
    timer += Time.deltaTime;

    if(timer > 5) //make sure bullets don't pile up, can change timer if needed
    {
    Destroy(gameObject);
    }
    }
    void OnTriggerEnter2D(Collider2D other)   // destroy bullet on collision with player
    {
    if (other.gameObject.CompareTag("Player"))
    {
    Destroy(gameObject);
    }
    }
}
