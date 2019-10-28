using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteration : MonoBehaviour
{
    public GameObject mainCharacter;
    public float minDistance;
    bool pressed;
    public GameObject backpack;

    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        this.sprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && mainCharacter != null)
        {
            if (Vector3.Distance(mainCharacter.transform.position, transform.position) < minDistance)
            {
                pressed = false; // Resetting pressed
                beginCooking();
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

    public void beginCooking()
    {
        BackpackController backpack = mainCharacter.GetComponent<Character>().backpack.GetComponent<BackpackController>();
        
        print("item.name: " + backpack.slot1);
    }
}
