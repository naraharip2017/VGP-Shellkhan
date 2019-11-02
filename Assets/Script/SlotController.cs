using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public GameItemController gameItem;


    public void PutItemInSlot(GameItemController gameItem)
    {
        this.gameItem = gameItem;
        spriteRenderer.sprite = gameItem.sprite;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameItem != null)
        {
            spriteRenderer.sprite = gameItem.sprite;
        }
        else
        {
            spriteRenderer.sprite = null;
        }
        
     
    }

    public void clearItem()
    {
        spriteRenderer.sprite = null;
        gameItem = null;

    }


}
