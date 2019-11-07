using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float walkSpeed;
    private Animator animator;

    private Vector3 target;


    public GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (GameTimer.round)
        {


            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, walkSpeed, 0);
                target = transform.position;
                setWalkAnimation("WalkUp");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -walkSpeed, 0);
                target = transform.position;
                setWalkAnimation("WalkDown");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-walkSpeed, 0, 0);
                target = transform.position;
                setWalkAnimation("WalkLeft");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(walkSpeed, 0, 0);
                target = transform.position;
                setWalkAnimation("WalkRight");
            }
            else
            {
                animator.SetBool("WalkUp", false);
                animator.SetBool("WalkDown", false);
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkRight", false);


            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stops moving the player once it cloides with something
        rigidBody.freezeRotation = true;

    }

    private void setWalkAnimation(string walk)
    {
        string[] walks = { "WalkUp", "WalkDown", "WalkLeft", "WalkRight" };

        for (int i = 0; i < walks.Length; ++i)
        {
            if (walk == walks[i])
            {
                animator.SetBool(walks[i], true);
            }
            else
            {
                animator.SetBool(walks[i], false);
            }
        }





    }





}
