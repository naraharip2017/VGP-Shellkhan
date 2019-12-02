using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public Text uitext;
    public float timerInterval;

    public float timer;
    private bool canCount = true;
    private bool doOnce = false;

    public static bool round = false;
    public static bool startGame = false;
    private int successScore;

    private bool beenHere = false;

    void Start()
    {
        timer = timerInterval;
        successScore = 30;
        
    }

    void Update()
    {
        
        if (startGame)
        {
            
            if (timer > 0.0f && canCount)
            {
                beenHere = true;
                timer -= Time.deltaTime;
                uitext.text = timer.ToString("F");
                round = true;
                if(GameController.endscore >= successScore)
                {
                    round = false;
                    timer = 0.0f;
                }
            }
            else if (timer <= 0.0f && !doOnce)
            {
                print("in timer");
                canCount = false;
                doOnce = true;
                uitext.text = "0.00";
                round = false;
                if (GameController.endscore<successScore && beenHere)
                {
                    MenuController.instance.showEndScreen();
                }
                else if(GameController.endscore >= successScore && beenHere)
                {
                    MenuController.instance.showNextRound();
                    GameController.instance.score = 0;
                }
            }
            

        }

    }

    //implement next round
    public void ResetBtn()
    {
        timer = timerInterval;
        MenuController.instance.startNextRound();
        canCount = true;
        doOnce = false;
        beenHere = false;
    }


    //todo: tuco/police, end of round menu

    //void endRound()
    //{
        //reset to next round
    //}


}
