using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemController: MonoBehaviour
{
    public GameObject mainCharacter;
    public float minDistance;
    bool pressed;
    public string itemName;

    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {

        this.sprite = this.GetComponent<SpriteRenderer>().sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if the item needs to be picked up
        if (pressed && mainCharacter != null)
        {
            if (Vector3.Distance(mainCharacter.transform.position, transform.position) < minDistance)
            {
                pressed = false; // Resetting pressed
                addItemtoBackpack();
            }

        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
    }


    private void addItemtoBackpack()
    {

        BackpackController backpack = mainCharacter.GetComponent<Character>().backpack.GetComponent<BackpackController>();
        backpack.AddItemToBackpack(this);

    }



}
