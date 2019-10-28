using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteration : MonoBehaviour
{
    bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && GetComponent<Character>() != null)
        {
            if (Vector3.Distance(GetComponent<GameItemController>().mainCharacter.transform.position, transform.position) < GetComponent<GameItemController>().minDistance) 
            {
                pressed = false; // Resetting pressed
                beginCooking();
            }

        }
    }




    public void beginCooking()
    {
        GameObject item1 = GetComponent<BackpackController>().slot1;
        GameObject item2 = GetComponent<BackpackController>().slot2;
        GameObject item3 = GetComponent<BackpackController>().slot3;

        print(item1);

    }
}
