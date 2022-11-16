using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed = 15f;
    private float vertical;
    private float horizontal;
    private Animator anim;
    public bool isFacingRight;
    public bool isFacingLeft;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
        // flip();
        
    }

    private void normalizeAnim()
    {
        anim.SetBool("MoveRight", false);
        anim.SetBool("MoveLeft", false);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveDown", false);
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == -1)
        {
            normalizeAnim();
            anim.SetBool("MoveLeft", true);
            anim.SetBool("Idle", false);
            // anim.SetTrigger("MoveLeft");
            rb.velocity = new Vector2(horizontal * MoveSpeed * Time.deltaTime, 0 * Time.deltaTime);
        } else if (horizontal == 1)
        {
            // anim.SetTrigger("MoveRight");
            normalizeAnim();
            anim.SetBool("MoveRight", true);
            anim.SetBool("Idle", false);
        }

        if (vertical == 1)
        {
            normalizeAnim();
            anim.SetBool("MoveUp", true);
            anim.SetBool("Idle", false);

            // anim.SetTrigger("MoveUp");
        } else if (vertical == -1)
        {
            normalizeAnim();
            anim.SetBool("MoveDown", true);
            anim.SetBool("Idle", false);
            // anim.SetTrigger("MoveDown");
        }

        if (vertical == 0 && horizontal == 0)
        {
            normalizeAnim();
            anim.SetBool("Idle", true);
        }

        rb.velocity = new Vector2(horizontal * MoveSpeed * Time.deltaTime, vertical * MoveSpeed * Time.deltaTime);
    }

    private void flip()
    {
        if (horizontal < 0f)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.x, transform.localScale.x);
        } else if (horizontal < 0f)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.x, transform.localScale.x);
        }
    }

    
}
