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
    public static bool timeZero = false;
    private int successScore;
    public Image gameOver;


    void Start()
    {
        timer = timerInterval;
        successScore = 30;
        gameOver.enabled = false;
    }

    void Update()
    {
        
        MonoBehaviour.print( timeZero); 
        if (startGame)
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
                timeZero = true;
                if (GameController.endscore<successScore) { gameOver.enabled = true; }

                //endRound();
            }

        }

    }

    //implement next round
    public void ResetBtn()
    {
        timer = timerInterval;
        canCount = true;
        doOnce = false;
    }


    //todo: tuco/police, end of round menu

    //void endRound()
    //{
        //reset to next round
    //}


}
