using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteration : MonoBehaviour
{
    public GameObject mainCharacter;
    public float minDistance;
    bool pressed;
    public GameObject backpack;
    public Sprite potSprite;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
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
        BackpackController backpackController = backpack.GetComponent<BackpackController>();

        GameItemController slot1Item = backpackController.slot1.GetComponent<SlotController>().gameItem;

        if (slot1Item != null)
        {
            print("Item in Slot 1:" + slot1Item.itemName);

        }

        GameItemController slot2Item = backpackController.slot2.GetComponent<SlotController>().gameItem;

        if (slot2Item != null)
        {
            print("Item in Slot 2:" + slot2Item.itemName);

        }


        GameItemController slot3Item = backpackController.slot3.GetComponent<SlotController>().gameItem;

        if (slot3Item != null)
        {
            print("Item in Slot 3:" + slot3Item.itemName);

        }

        spriteRenderer.sprite = potSprite;







    }
}
