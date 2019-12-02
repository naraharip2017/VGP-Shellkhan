using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject[] ingredients;
    public GameObject recipes;
    public bool recipeCreated = true;
    public int score;
    public static int endscore;
    public int numItemsInRecipe;
 

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        endscore = score;

         

            

        
        
    }



    public void createNewRecipe(int numItems)
    {
        bool[] doseExist = new bool[ingredients.Length];

        System.Random rnd = new System.Random();

        recipes.GetComponent<BackpackController>().ClearBackpack();
        for (int i = 0; i < numItems; ++i)
        {
            int index = rnd.Next(0, ingredients.Length);


            while (doseExist[index])
            {
                index = rnd.Next(0, ingredients.Length);
            }

            GameObject tmpObject = ingredients[index];
            recipes.GetComponent<BackpackController>().AddItemToBackpack(tmpObject.GetComponent<GameItemController>());
            doseExist[index] = true;



        }




    }

}
