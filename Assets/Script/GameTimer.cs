using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text uitext;
    [SerializeField] private float timerInterval;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public static bool round = true;

    private void Start()
    {
        timer = timerInterval;
    }
    private void Update()
    {
        if(timer>=0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uitext.text = timer.ToString("F");
            round = true;
        }
        else if (timer <=0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uitext.text = "0.00";
            timer = 0.0f;
<<<<<<< HEAD
            round = false;
            //endRound();
=======
            GameOver();
>>>>>>> 6ce3ea90c8090ca8fb144d507e631417cc1f47b6
        }

    }

    //implement next round
    public void ResetBtn()
    {
        timer = timerInterval;
        canCount = true;
        doOnce = false;
    }
<<<<<<< HEAD

    //todo: tuco/police, end of round menu

    //void endRound()
    //{
        //reset to next round
    //}

=======
    public void ResetBin()
    {
        timer = timerInterval;
        canCount = true;
        doOnce = false;

    }
    void GameOver()
    {

    }
>>>>>>> 6ce3ea90c8090ca8fb144d507e631417cc1f47b6
}
