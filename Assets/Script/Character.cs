using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float walkSpeed;

    private Vector3 target;

    
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
        //if(GameTimer.round)
        //{
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, walkSpeed, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -walkSpeed, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-walkSpeed, 0, 0);
                target = transform.position;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(walkSpeed, 0, 0);
                target = transform.position;
            }
        //}
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stops moving the player once it cloides with something
        rigidBody.freezeRotation=true;
  
    }





}
