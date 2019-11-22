using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounterInteration : MonoBehaviour
{
    public GameObject mainCharacter;
    public float minDistance;
    bool pressed;
    bool doneCooking = false;
    public GameObject backpack;
    public Sprite potSprite;
    public Sprite finishedCooking;
    public Text scoreUI;
   

    public SpriteRenderer spriteRenderer;

    [SerializeField] private Text uitext;
    [SerializeField] private float timerInterval = 5;


    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public static bool round = true;
    bool startTimer = false;
    private bool pickedUpItem; //true if there's no item on the stove; 


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
        timer = timerInterval;
        uitext.text = "";
        pickedUpItem = true;

    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + GameController.instance.score.ToString();
        if (pressed && mainCharacter != null)
        {
            if (Vector3.Distance(mainCharacter.transform.position, transform.position) < minDistance)
            {
                if (doneCooking == false && pickedUpItem)
                {
                    pressed = false; // Resetting pressed
                    beginCooking();
                }
            }

        }

        if (startTimer)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                uitext.text = timer.ToString("F");
                round = true;
            }
            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                uitext.text = "0.00";
                timer = 0.0f;
                round = false;
                spriteRenderer.sprite = finishedCooking;
                doneCooking = true;
                startTimer = false;
                
                

            }
            
        }

        if (pickedUpItem==false && doneCooking && Vector3.Distance(mainCharacter.transform.position,
            transform.position) < minDistance && pressed && mainCharacter != null)
        {

            doneCooking = false;
            GameController.instance.score += 10;
            spriteRenderer.sprite = null;
            
            ResetBtn();
        }



    }

    //implement next round
    public void ResetBtn()
    {
        timer = timerInterval;
        canCount = true;
        doOnce = false;
        pickedUpItem = true;
        
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
        BackpackController recipeController = GameController.instance.recipes.GetComponent<BackpackController>();

        GameItemController[] backPackItems = backpackController.items;
        GameItemController[] recipeItems = recipeController.items;


        if (getItemsLength(recipeItems) != getItemsLength(backPackItems))
        {
            return;
        }


        bool hasItem = false;


        for (int i = 0; i < recipeItems.Length; ++i)
        {
            if (recipeItems[i] != null && backPackItems[i] != null)
            {
                hasItem = true;
                if (recipeItems[i].itemName != backPackItems[i].itemName)
                {
                    print("Comparing " + recipeItems[i].itemName + " and " + backPackItems[i].itemName + " but not equal");
                    return;
                }
            }


            if (hasItem == false)
            {
                return;
            }

        }




        spriteRenderer.sprite = potSprite;

        pickedUpItem = false;
        startTimer = true;
        backpackController.ClearBackpack();
        recipeController.ClearBackpack();

        GameController.instance.createNewRecipe(4);

        //doneCooking = false;
   
        


    }



    public int getItemsLength(GameItemController[] item)
    {
        int counter = 0;

        while(item[counter] != null)
        {
            ++counter;
        }

        return counter;

    }



}
