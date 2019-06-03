using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMinigame : MonoBehaviour
{
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
    public GameObject katt;
    public GameObject kultist;
    private Transform spawn;
    private bool kattIsKultist;
    private bool kattIsRegular;
    [HideInInspector] public bool kattArrived;
    [HideInInspector] public bool arrow1;
    [HideInInspector] public bool arrow2;
    [HideInInspector] public bool arrow3;
    [HideInInspector] public bool arrow4;
    [HideInInspector] public bool orderFinished;
    private GameObject kattInstance;

    public Image[] boxes;
    public Sprite[] arrows;
    public GameObject coffeeCup;
    public GameObject cupSpawn;
    public GameObject[] ingredients;
    [HideInInspector] public GameObject cupInstace;

    [HideInInspector] public bool gotBoxOneRight;
    [HideInInspector] public bool gotBoxTwoRight;
    [HideInInspector] public bool gotBoxThreeRight;
    [HideInInspector] public bool gotBoxFourRight;
    [HideInInspector] public bool gotBoxFiveRight;
    [HideInInspector] public bool gotBoxSixRight;
    [HideInInspector] public bool gotBoxSevenRight;

    [HideInInspector] public bool boxOneHasBeenAttempted;
    [HideInInspector] public bool boxTwoHasBeenAttempted;
    [HideInInspector] public bool boxThreeHasBeenAttempted;
    [HideInInspector] public bool boxFourHasBeenAttempted;
    [HideInInspector] public bool boxFiveHasBeenAttempted;
    [HideInInspector] public bool boxSixHasBeenAttempted;
    [HideInInspector] public bool boxSevenHasBeenAttempted;

    private string arrowKey;

    private void Start()
    {
        Time.timeScale = 1f;
        DataHolder.Coins = 0;
        aud = gameObject.GetComponent<AudioSource>();
        spawn = GameObject.Find("KattSpawn").transform;
        appearTimer = timeBetweenAppearing;
        playerAnim = GameObject.Find("MrCandlesmith").GetComponent<Animator>();
        breakTime = timeBetweenOrders;
        dayTimer = amountOfTimeUntilClosing;
        customerPatienceTimer = customerPatienceTime;
        gameObject.GetComponent<ScoreKeeper>().endOfDayTextHolder.SetActive(false);
        DataHolder.MovementSpeedIncrease = 0.07f;
    }

    private void Update()
    {
        if(appeared && kattArrived)
        {
            appearTimer -= Time.deltaTime;

            //If appear timer is lower than 0 and arrow 1 has not spawned yet...
            if (appearTimer <= 0 && !arrow1)
            {
                //Set the Arrow gameobject to true...
                if (boxes[2].GetComponent<GradientChange>().toggle)
                {
                    boxes[2].gameObject.SetActive(true);
                }
                boxes[2].sprite = arrows[Random.Range(0, arrows.Length)];
                //boxes[2].color = new Color(255, 255, 255, 255);
                arrow1 = true;
                appearTimer = timeBetweenAppearing;
            }
        }

        if(orderFinished)
        {
            boxes[0].color = new Color(0, 0, 0, 0);
            boxes[0].gameObject.SetActive(false);
            boxes[1].color = new Color(0, 0, 0, 0);
            boxes[1].gameObject.SetActive(false);
            boxes[2].color = new Color(0, 0, 0, 0);
            boxes[2].gameObject.SetActive(false);
            boxes[3].color = new Color(0, 0, 0, 0);
            boxes[3].gameObject.SetActive(false);
            breakTime -= Time.deltaTime;
            if (breakTime <= 0)
            {
                StartRound();
                breakTime = timeBetweenOrders;
            }
        }

        /*if(Input.GetKeyDown(KeyCode.Backspace))
        {
            StartRound();
            GameObject.Find("Press Backspace to begin").SetActive(false);
            dayStarted = true;
        }*/

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

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetBool("talking", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnim.SetBool("talking", false);
        }

        if (dayStarted)
        {
            dayTimer -= Time.deltaTime;
            if(dayTimer <= 0)
            {
                roundStarted = false;
                gameObject.GetComponent<ScoreKeeper>().dayEnded = true;
                gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(kattIsRegular, kattIsKultist);
                gameObject.GetComponent<ScoreKeeper>().EndOfDayText();
            }

            GameObject.Find("Time until closing: ").GetComponent<Text>().text = "Time until closing: " + dayTimer.ToString("N0");
        }

        //When the round starts and the katt arrived at the desk...
        if (roundStarted && kattArrived)
        {
            //If arrow 4 has not appeared yet...
            if (!arrow4)
            {
                if (boxes[3].GetComponent<GradientChange>().toggle)
                {
                    boxes[3].gameObject.SetActive(true);
                }
                boxes[3].sprite = arrows[Random.Range(0, arrows.Length)];
                //boxes[3].color = new Color(255, 255, 255, 255);
                arrow4 = true;
            }

            //If arrow 2 has not appeared yet...
            if (appearTimer <= 0 && !arrow2)
            {
                if (boxes[1].GetComponent<GradientChange>().toggle)
                {
                    boxes[1].gameObject.SetActive(true);
                }
                boxes[1].sprite = arrows[Random.Range(0, arrows.Length)];
                //boxes[1].color = new Color(255, 255, 255, 255);
                boxes[1].GetComponent<GradientChange>().Refresh();
                appeared = true;
                arrow2 = true;
                appearTimer = timeBetweenAppearing;
            }

            //If arrow 3 has not appeared yet...
            else if (appearTimer <= 0 && !arrow3)
            {
                if (boxes[0].GetComponent<GradientChange>().toggle)
                {
                    boxes[0].gameObject.SetActive(true);
                }
                boxes[0].sprite = arrows[Random.Range(0, arrows.Length)];
                //boxes[0].color = new Color(255, 255, 255, 255);
                boxes[0].GetComponent<GradientChange>().Refresh();
                appeared = true;
                arrow3 = true;
                appearTimer = timeBetweenAppearing;
            }

            customerPatienceTimer -= Time.deltaTime;
            if (customerPatienceTimer <= 0)
            {
                gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(kattIsRegular, kattIsKultist);
                kattIsRegular = false;
                kattIsKultist = false;
                //StartRound();
            }
        }
    }

    public void StartRound ()
    {
        if (GameObject.Find("PointToDeskbellArrow") != null)
        {
            Destroy(GameObject.Find("PointToDeskbellArrow"));
            dayStarted = true;
            GameObject.Find("Canvas").gameObject.transform.GetChild(2).GetComponent<Button>().enabled = false;
        }
        aud.Play();
        if (DataHolder.Kultists == 0)
        {
            kattInstance = Instantiate(katt, spawn.position, Quaternion.identity);
        }
        //Handles Kultist spawning
        if(DataHolder.Kultists > 0)
        {
            kattInstance = Instantiate(kultist, spawn.position, Quaternion.identity);
            DataHolder.Kultists -= 1;
        }


        if(kattInstance.GetComponent<KattController>().isKultist)
        {
            kattIsKultist = true;
        }

        if(kattInstance.GetComponent<KattController>().isRegularCustomer)
        {
            kattIsRegular = true;
        }

        cupInstace = Instantiate(coffeeCup, cupSpawn.transform.position, Quaternion.identity);
        appeared = true;
        orderFinished = false;
        Debug.Log("Round Started");
        gotBoxOneRight = false;
        gotBoxTwoRight = false;
        gotBoxThreeRight = false;
        gotBoxFourRight = false;
        gotBoxFiveRight = false;
        gotBoxSixRight = false;
        gotBoxSevenRight = false;

        boxOneHasBeenAttempted = false;
        boxTwoHasBeenAttempted = false;
        boxThreeHasBeenAttempted = false;
        boxFourHasBeenAttempted = false;
        boxFiveHasBeenAttempted = false;
        boxSixHasBeenAttempted = false;
        boxSevenHasBeenAttempted = false;
        roundStarted = true;
        customerPatienceTimer = customerPatienceTime;
    }

    public void SelectedANumber ()
    {
        if (!boxOneHasBeenAttempted)
        {
            if (arrowKey == boxes[3].sprite.name)
            {
                gotBoxOneRight = true;
                boxes[3].color = new Color(0, 255, 0, 255);
                boxes[3].GetComponent<GradientChange>().Refresh();
            }

            if (arrowKey != boxes[3].sprite.name)
            {
                gotBoxOneRight = false;
                boxes[3].color = new Color(255, 0, 0, 255);
                boxes[3].GetComponent<GradientChange>().Refresh();
            }

            boxOneHasBeenAttempted = true;
        }

        else if (!boxTwoHasBeenAttempted)
        {
            if (arrowKey == boxes[2].sprite.name)
            {
                gotBoxTwoRight = true;
                boxes[2].color = new Color(0, 255, 0, 255);
                boxes[2].GetComponent<GradientChange>().Refresh();
            }

            if (arrowKey != boxes[2].sprite.name)
            {
                gotBoxTwoRight = false;
                boxes[2].color = new Color(255, 0, 0, 255);
                boxes[2].GetComponent<GradientChange>().Refresh();
            }
            
            boxTwoHasBeenAttempted = true;
        }

        else if (!boxThreeHasBeenAttempted)
        {
            if (arrowKey == boxes[1].sprite.name)
            {
                gotBoxThreeRight = true;
                boxes[1].color = new Color(0, 255, 0, 255);
                boxes[1].GetComponent<GradientChange>().Refresh();
            }

            if (arrowKey != boxes[1].sprite.name)
            {
                gotBoxThreeRight = false;
                boxes[1].color = new Color(255, 0, 0, 255);
                boxes[1].GetComponent<GradientChange>().Refresh();
            }

            boxThreeHasBeenAttempted = true;
        }

        else if (!boxFourHasBeenAttempted)
        {
            if (arrowKey == boxes[0].sprite.name)
            {
                gotBoxFourRight = true;
                boxes[0].color = new Color(0, 255, 0, 255);
                boxes[0].GetComponent<GradientChange>().Refresh();
            }

            if (arrowKey != boxes[0].sprite.name)
            {
                gotBoxFourRight = false;
                boxes[0].color = new Color(255, 0, 0, 255);
                boxes[0].GetComponent<GradientChange>().Refresh();
            }

            boxFourHasBeenAttempted = true;
            gameObject.GetComponent<ScoreKeeper>().RoundEndCollection(kattIsRegular, kattIsKultist);
            kattIsRegular = false;
            kattIsKultist = false;
        }
    }
}
