using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackController : MonoBehaviour
{


    public GameItemController[] items;
    public SlotController[] slots;

    int counter = 0;

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


        int length = items.Length;

        if (counter >= length)
        {
            counter = 0;
        }

        items[counter] = gameItem;
        slots[counter].PutItemInSlot(gameItem);
        ++counter;

    }


   public void ClearBackpack()
    {
        counter = 0;

        for (int i =0; i < items.Length; ++i)
        {
            items[i] = null;
            slots[i].clearItem();

        }
    }

   public void DeleteLastElement()
   {
       if (counter > 0)
       {
           items[counter - 1] = null;
           slots[counter - 1].clearItem();
           counter--;
       }

   }

}
