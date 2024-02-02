using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatforms : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            rb.gravityScale += 1;
        }
    }
}
