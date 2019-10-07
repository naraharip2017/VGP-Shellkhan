using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackController : MonoBehaviour
{

    public List<GameItemController> items;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public List<GameObject> slots;

    int counter = 0;
    int NUM_SLOTS = 3;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToBackpack(GameItemController gameItem)
    {
        print("Getting slot");

        switch (counter)
        {
            case 0:
                slot1.GetComponent<SlotController>().PutItemInSlot(gameItem);
                break;
            case 1:
                slot2.GetComponent<SlotController>().PutItemInSlot(gameItem);
                break;
            case 2:
                slot3.GetComponent<SlotController>().PutItemInSlot(gameItem);
                break;



        }

        if (counter >= NUM_SLOTS)
        {
            counter = 0;
        }
        else
        {
            ++counter;
        }

    }





}
