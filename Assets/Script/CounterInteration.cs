using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounterInteration : MonoBehaviour
{
    public GameObject mainCharacter;
    public float minDistance;
    bool pressed;
    public GameObject backpack;
    public Sprite potSprite;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private Text uitext;
    [SerializeField] private float timerInterval = 5;


    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public static bool round = true;
    bool startTimer = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        timer = timerInterval;

    }

    // Update is called once per frame
    void Update()
    {

        if (pressed && mainCharacter != null)
        {
            if (Vector3.Distance(mainCharacter.transform.position, transform.position) < minDistance)
            {
                pressed = false; // Resetting pressed
                beginCooking();
            }

        }

        if (startTimer) { 
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

        spriteRenderer.sprite = potSprite;
       

        startTimer = true;




    }
}
