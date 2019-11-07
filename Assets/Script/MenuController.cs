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

    void switchMenu(GameObject someMenu)
    {
        mainMenu.SetActive(false);
        instructions.SetActive(false);
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

    public void startup()
    {
        gameObject.SetActive(true);
        switchMenu(mainMenu);
    }

    public void hideAndPlay()
    {
        gameObject.SetActive(false);
        GameTimer.startGame = true;
        
    }
}
