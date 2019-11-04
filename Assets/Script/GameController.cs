using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject[] ingredients;
    public GameObject recipes;
    public bool recipeCreated = false;
    public int score;

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
        if (!recipeCreated)
        {
            createNewRecipe(2);
            recipeCreated = true;
        }


    }



    public void createNewRecipe(int numItems)
    {
        bool[] doseExist = new bool[ingredients.Length];

        System.Random rnd = new System.Random();


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
