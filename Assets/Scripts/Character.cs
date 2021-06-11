using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer character;
    [Header("Balance variables")]
    [SerializeField]





    public float UpSpeed;
    public Rigidbody2D rb;


    public bool isGrounded;

    public float gravInc = 50;
    public int counter;
    public float DownSpeed = 50;

    public int jumpCount = 0;
    public float secCount = 0;
    public bool validUp = true;
    public float sec;


    public int HP = 30;

    public int currentHP = 30;
    [SerializeField]
    private float jumpForce = 5;

    private float horizontal;
    private float vertical;
    private Vector3 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() //movimiento
    {



        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("JumpAnimation", true);


        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == (true) && validUp == (true))
        {
            rb.AddForce(transform.up * UpSpeed);
            secCount = 0;
            validUp = false;
            secCount = sec + 3;



        }

    }

    void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().damageAmount) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Hazard>().damageAmount;

            animator.SetTrigger("DamageSide");
            currentHP -= collision.GetComponent<Hazard>().damageAmount;
            animator.SetTrigger("DamageSide");
        }

        if (collision.CompareTag("Heal"))
        {
            currentHP += collision.GetComponent<Heal>().healAmount;



            

            if ((currentHP + collision.GetComponent<Heal>().healAmount) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().healAmount;
        }
    }
}

   
