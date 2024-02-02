using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField]public float breathMax = 20f;
    public static float breath;

    private bool inWater = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public int health = 100;

  
    void Update()
    {
        if (inWater)
        {


            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);

            //TIMER SLIDER

            breath-=.005f;
            if (breath <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
            //Debug.Log(breath);


        }
        else
        {

            breath = breathMax;
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }

    Flip();

    }


    private bool IsGrounded()
    {
    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    {
    isFacingRight = !isFacingRight;
    Vector3 localScale = transform.localScale;
    localScale.x *= -1f;
    transform.localScale = localScale;
    }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "fish")
        {
            health = health - 5;
            //Debug.Log(health);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "water")
        {
            inWater = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "water")
        {
            inWater = false;
            breath = 30f;
        }
    }


}
