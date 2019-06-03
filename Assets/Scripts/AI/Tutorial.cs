using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public enum WhatTime
    {
        DAY,
        SHOP,
        NIGHT
    }

    private AudioSource aud;
    private bool dayStarted = false;
    public float amountOfTimeUntilClosing;
    [HideInInspector] public float dayTimer;
    public float customerPatienceTime;

    private float customerPatienceTimer;
    public float timeBetweenOrders;
    private float breakTime;
    public float timeBetweenAppearing;
    public float appearTimer;
    private bool appeared;
    private bool roundStarted = false;
    private Animator playerAnim;
    public WhatTime state;
    public GameObject katt;
    public Transform kattSpawn;
    private bool spawned;
    [HideInInspector] public bool kattArrived;
    [HideInInspector] public bool tutKattArrived;
    [HideInInspector] public bool arrow1;
    [HideInInspector] public bool arrow2;
    [HideInInspector] public bool arrow3;
    [HideInInspector] public bool arrow4;
    [HideInInspector] public bool orderFinished;
    private bool toggled;

    public Image[] boxes;
    public Sprite[] arrows;
    public GameObject coffeeCup;
    public GameObject cupSpawn;
    [HideInInspector] public GameObject cupInstace;
    public GameObject[] ingredients;

    [HideInInspector] public bool gotBoxOneRight;
    [HideInInspector] public bool gotBoxTwoRight;
    [HideInInspector] public bool gotBoxThreeRight;
    [HideInInspector] public bool gotBoxFourRight;

    [HideInInspector] public bool boxOneHasBeenAttempted;
    [HideInInspector] public bool boxTwoHasBeenAttempted;
    [HideInInspector] public bool boxThreeHasBeenAttempted;
    [HideInInspector] public bool boxFourHasBeenAttempted;

    private string arrowKey;

    // Use this for initialization
    void Start ()
    {
        aud = gameObject.GetComponent<AudioSource>();
        if(state == WhatTime.DAY)
        {
            kattSpawn = GameObject.Find("KattSpawn").transform;
            appearTimer = timeBetweenAppearing;
            playerAnim = GameObject.Find("MrCandlesmith").GetComponent<Animator>();
            breakTime = timeBetweenOrders;
            dayTimer = amountOfTimeUntilClosing;
            customerPatienceTimer = customerPatienceTime;
            gameObject.GetComponent<ScoreKeeper>().endOfDayTextHolder.SetActive(false);
            DataHolder.MovementSpeedIncrease = 0.07f;
        }

        if(state == WhatTime.SHOP)
        {
            GameObject.Find("ShopIntroductionDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            DataHolder.SpendCoins = 60;
            Debug.Log(DataHolder.SpendCoins);

        }

        if(state == WhatTime.NIGHT)
        {
            GameObject.Find("IntroNightDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            Time.timeScale = 0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(GameObject.Find("IntroDialogue") != null && !toggled)
        {
            GameObject.Find("IntroDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            toggled = true;
        }

        switch (state)
        {
            case WhatTime.DAY:
                Day();
                break;

            case WhatTime.NIGHT:
                Night();
                break;

            case WhatTime.SHOP:
                Shop();
                break;
        }
	}

    void Day ()
    {

        if (kattArrived && !GameObject.Find("DialogueUI").GetComponent<DialogueManager>().dialogueIsRunning && tutKattArrived && GameObject.Find("OrderExplanationDialogue") != null)
        {
            GameObject.Find("OrderExplanationDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            tutKattArrived = false;
        }

        if (appeared && kattArrived && !GameObject.Find("DialogueUI").GetComponent<DialogueManager>().dialogueIsRunning)
        {
            appearTimer -= Time.deltaTime;

            if (appearTimer <= 0 && !arrow1)
            {
                boxes[2].sprite = arrows[Random.Range(0, arrows.Length)];
                boxes[2].color = new Color(0, 0, 0, 255);
                arrow1 = true;
                appearTimer = timeBetweenAppearing;
            }
        }

        if (orderFinished)
        {
            boxes[0].color = new Color(0, 0, 0, 0);
            boxes[1].color = new Color(0, 0, 0, 0);
            boxes[2].color = new Color(0, 0, 0, 0);
            boxes[3].color = new Color(0, 0, 0, 0);
            breakTime -= Time.deltaTime;
            if (breakTime <= 0)
            {
                StartRound();
                breakTime = timeBetweenOrders;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartRound();
            GameObject.Find("Press Backspace to begin").SetActive(false);
            dayStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrowKey = "DownArrow";
            SelectedANumber();
            Instantiate(ingredients[Random.Range(0, ingredients.Length)], cupSpawn.transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowKey = "LeftArrow";
            SelectedANumber();
            Instantiate(ingredients[Random.Range(0, ingredients.Length)], cupSpawn.transform.position, Quaternion.identity);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowKey = "RightArrow";
            SelectedANumber();
            Instantiate(ingredients[Random.Range(0, ingredients.Length)], cupSpawn.transform.position, Quaternion.identity);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowKey = "UpArrow";
            SelectedANumber();
            Instantiate(ingredients[Random.Range(0, ingredients.Length)], cupSpawn.transform.position, Quaternion.identity);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetBool("talking", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnim.SetBool("talking", false);
        }
        Debug.Log(dayStarted);
        if (dayStarted)
        {
            dayTimer -= Time.deltaTime;
            if (dayTimer <= 0)
            {
                roundStarted = false;
                GameObject.Find("EndOfDayDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
                if (GameObject.Find("EndOfDayDialogue") != null)
                {
                    gameObject.GetComponent<ScoreKeeper>().dayEnded = true;
                    gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(true, false);
                    gameObject.GetComponent<ScoreKeeper>().EndOfDayText();
                }
            }

            GameObject.Find("Time until closing: ").GetComponent<Text>().text = "Time until closing: " + dayTimer.ToString("N0");
        }

        if (roundStarted && kattArrived)
        {
            if (!arrow4)
            {
                boxes[3].sprite = arrows[Random.Range(0, arrows.Length)];
                boxes[3].color = new Color(0, 0, 0, 255);
                arrow4 = true;
            }

            if (appearTimer <= 0 && !arrow2)
            {
                boxes[1].sprite = arrows[Random.Range(0, arrows.Length)];
                boxes[1].color = new Color(0, 0, 0, 255);
                appeared = true;
                arrow2 = true;
                appearTimer = timeBetweenAppearing;
            }

            else if (appearTimer <= 0 && !arrow3)
            {
                boxes[0].sprite = arrows[Random.Range(0, arrows.Length)];
                boxes[0].color = new Color(0, 0, 0, 255);
                appeared = true;
                arrow3 = true;
                appearTimer = timeBetweenAppearing;
            }

            customerPatienceTimer -= Time.deltaTime;
            if (customerPatienceTimer <= 0)
            {
                gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(true, false);
                //StartRound();
            }
        }
        }

    void Shop ()
    {
        if (DataHolder.SpendCoins == 0)
        {
            DataHolder.SpendCoins = 60;
        }

        Debug.Log(DataHolder.SpendCoins);
        if(DataHolder.SpendCoins <= 40)
        {
            GameObject.Find("GoToLoadoutDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    void Night ()
    {

    }

    public void StartRound()
    {
        if (GameObject.Find("PointToDeskbellArrow") != null)
        {
            dayStarted = true;
            Destroy(GameObject.Find("PointToDeskbellArrow"));
            GameObject.Find("Canvas").gameObject.transform.GetChild(3).GetComponent<Button>().enabled = false;
        }

        cupInstace = Instantiate(coffeeCup, cupSpawn.transform.position, Quaternion.identity);
        aud.Play();
        Instantiate(katt, kattSpawn.position, Quaternion.identity);
        appeared = true;
        orderFinished = false;
        Debug.Log("Round Started");
        gotBoxOneRight = false;
        gotBoxTwoRight = false;
        gotBoxThreeRight = false;
        gotBoxFourRight = false;

        boxOneHasBeenAttempted = false;
        boxTwoHasBeenAttempted = false;
        boxThreeHasBeenAttempted = false;
        boxFourHasBeenAttempted = false;
        roundStarted = true;
        customerPatienceTimer = customerPatienceTime;
    }

    public void SelectedANumber()
    {
        if (!boxOneHasBeenAttempted)
        {
            if (arrowKey == boxes[3].sprite.name)
            {
                gotBoxOneRight = true;
                boxes[3].color = new Color(0, 255, 0);
            }

            if (arrowKey != boxes[3].sprite.name)
            {
                gotBoxOneRight = false;
                boxes[3].color = new Color(255, 0, 0);
            }

            boxOneHasBeenAttempted = true;
        }

        else if (!boxTwoHasBeenAttempted)
        {
            if (arrowKey == boxes[2].sprite.name)
            {
                gotBoxTwoRight = true;
                boxes[2].color = new Color(0, 255, 0);
            }

            if (arrowKey != boxes[2].sprite.name)
            {
                gotBoxTwoRight = false;
                boxes[2].color = new Color(255, 0, 0);
            }

            boxTwoHasBeenAttempted = true;
        }

        else if (!boxThreeHasBeenAttempted)
        {
            if (arrowKey == boxes[1].sprite.name)
            {
                gotBoxThreeRight = true;
                boxes[1].color = new Color(0, 255, 0);
            }

            if (arrowKey != boxes[1].sprite.name)
            {
                gotBoxThreeRight = false;
                boxes[1].color = new Color(255, 0, 0);
            }

            boxThreeHasBeenAttempted = true;
        }

        else if (!boxFourHasBeenAttempted)
        {
            if (arrowKey == boxes[0].sprite.name)
            {
                gotBoxFourRight = true;
                boxes[0].color = new Color(0, 255, 0);
            }

            if (arrowKey != boxes[0].sprite.name)
            {
                gotBoxFourRight = false;
                boxes[0].color = new Color(255, 0, 0);
            }

            boxFourHasBeenAttempted = true;
            gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(true, false);
        }
    }
}
