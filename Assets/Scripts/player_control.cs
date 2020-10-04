using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player_control : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 5f;
    public float boost = 1.5f;
    public float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0;
        Jump();
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move, 0f, 0f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = moveSpeed * boost;
            anim.SetBool("boost", true);
        }
        else
        {
            speed = moveSpeed;
            anim.SetBool("boost", false);
        }

        transform.position += movement * Time.deltaTime * speed;

        direction(move);
        anim.SetFloat("move", Math.Abs(move));
        anim.SetBool("jumping", !isGrounded());
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, .5f);
    }

    void direction(float dir)
    {
        Vector3 forward = new Vector3(0, 90, 0);
        Vector3 backward = new Vector3(0, -90, 0);

        if (dir < -.01f)
            transform.eulerAngles = backward;
        else if (dir > .01f)
            transform.eulerAngles = forward;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
}
