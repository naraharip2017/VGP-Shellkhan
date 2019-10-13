using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text uitext;
    [SerializeField] private float timerInterval;

    private float timer;
    private bool canCount = false;
    private bool doOnce = false;

    private void Start()
    {
        timer = timerInterval;
    }
    private void Update()
    {
        if(timer>=0f && canCount)
        {
            timer -= Time.deltaTime;
            uitext.text = timer.ToString("F");
        }
        else if (timer <=0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uitext.text = "0.00";
            timer = 0.0f;
        }
    }
}
