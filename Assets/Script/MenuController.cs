using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public static MenuController instance;
    // Start is called before the first frame update

    public GameObject mainMenu;
    public GameObject instructions;
    public GameObject nextRound;
    public GameObject endGameScreen;
    public GameObject winGameScreen;

    public Text uitext;
    public static int round = 1;
    void Awake()
    {
        instance = this;
        startup();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMenu(GameObject someMenu)
    {
        mainMenu.SetActive(false);
        instructions.SetActive(false);
        nextRound.SetActive(false);
        endGameScreen.SetActive(false);
        winGameScreen.SetActive(false);
        someMenu.SetActive(true);
    }

    public void showMain()
    {
        switchMenu(mainMenu);
    }

    public void showInstructions()
    {
        switchMenu(instructions);
    }

    public void showEndScreen()
    {
        gameObject.SetActive(true);
        switchMenu(endGameScreen);
    }

    public void showWinScreen()
    {
        switchMenu(winGameScreen);
    }

    public void showNextRound()
    {

        gameObject.SetActive(true);
        if (round > 3)
        {
            showWinScreen();
        }
        else
        {
            switchMenu(nextRound);
            uitext.text = "Round " + round;
        }
    }

    public void startup()
    {
        gameObject.SetActive(true);
        switchMenu(mainMenu);
    }

    public void startNextRound()
    {

        if (round == 1)
        {
            GameController.instance.numItemsInRecipe = 3;
            GameTimer.startGame = true;

        }
        else if(round==2)
        {
            GameController.instance.numItemsInRecipe = 4;
        }
        else if (round == 3)
        {
            GameController.instance.numItemsInRecipe = 5;
        }
        GameController.instance.createNewRecipe(GameController.instance.numItemsInRecipe);
        round++;
        gameObject.SetActive(false);
    }

}
