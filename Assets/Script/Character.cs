using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float walkSpeed = 0.2f;

    private Vector3 target;
    private bool move;

    
    public GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //controlling character movement via arrow keys
        if(GameTimer.round)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, walkSpeed, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, -walkSpeed, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-walkSpeed, 0, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(walkSpeed, 0, 0);
                target = transform.position;
            }
            else
            {
                //controlling character movement via the mouse
                if (Input.GetMouseButtonDown(0))
                {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = transform.position.z;
                    if (move == false)
                    {
                        move = true;
                    }
                }
                if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (move == true)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, target, walkSpeed * 10 * Time.deltaTime);
                    }
                }
            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stops moving the player once it cloides with something
        move = false;
        rigidBody.freezeRotation=true;
  
    }





}
