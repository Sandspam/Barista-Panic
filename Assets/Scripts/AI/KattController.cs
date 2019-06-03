using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KattController : MonoBehaviour 
{
    public GameObject target;
    public GameObject exit;
    public float moveSpeed;
    public AnimationClip drop;
    private Animator anim;
    private bool arrived;
    private float animTimer;
    private bool leaving;
    private bool tutorial;
    private bool canMove;

    public bool isKultist;
    public bool isRegularCustomer;

    public float RMin;
    public float RMax;
    public float GMin;
    public float GMax;
    public float BMin;
    public float BMax;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Test_Tutorial_DayTime")
            tutorial = true;

        RMin /= 255;
        RMax /= 255;
        GMin /= 255;
        GMax /= 255;
        BMin /= 255;
        BMax /= 255;

        arrived = false;
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(Random.Range(RMin, RMax), Random.Range(GMin, GMax), Random.Range(BMin, BMax), 255);
        target = GameObject.Find("KattStop");
        exit = GameObject.Find("KattExit");
        animTimer = drop.length;
        if(isKultist && GameObject.Find("KultistDialogue") != null)
        {
            GameObject.Find("KultistDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    private void Update()
    {

        if(Time.timeScale == 0f)
        {
            canMove = false;
        }

        else
        {
            canMove = true;
        }
        MoveToSpot();
        if(arrived)
        {
            if (!tutorial)
            {
                if (!GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow1 || !GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow2 || !GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow3 || !GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow4 && !leaving)
                {
                    anim.SetBool("talking", true);
                    anim.SetBool("walking", false);
                }

                if (GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow1 && GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow2 && GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow3 && GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().arrow4)
                {
                    anim.SetBool("talking", false);
                }
            }

            if(tutorial)
            {
                if (!GameObject.Find("GameManager").GetComponent<Tutorial>().arrow1 || !GameObject.Find("GameManager").GetComponent<Tutorial>().arrow2 || !GameObject.Find("GameManager").GetComponent<Tutorial>().arrow3 || !GameObject.Find("GameManager").GetComponent<Tutorial>().arrow4 && !leaving)
                {
                    anim.SetBool("talking", true);
                    anim.SetBool("walking", false);
                }

                if (GameObject.Find("GameManager").GetComponent<Tutorial>().arrow1 && GameObject.Find("GameManager").GetComponent<Tutorial>().arrow2 && GameObject.Find("GameManager").GetComponent<Tutorial>().arrow3 && GameObject.Find("GameManager").GetComponent<Tutorial>().arrow4)
                {
                    anim.SetBool("talking", false);
                }
            }
        }
        if (!tutorial)
        {
            if (GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().orderFinished == true)
            {
                leaving = true;
            }
        }

        if (tutorial)
        {
            if (GameObject.Find("GameManager").GetComponent<Tutorial>().orderFinished == true && tutorial)
            {
                leaving = true;
            }
        }

        if (leaving && canMove)
        {
            anim.SetBool("talking", false);
            anim.SetBool("walking", true);
            transform.position = Vector2.MoveTowards(transform.position, exit.transform.position, moveSpeed);
            if (transform.position.x <= exit.transform.position.x)
            {
                Destroy(gameObject);
            }
        }
    }

    void MoveToSpot ()
    {
        if (!arrived && canMove)
        {
            anim.SetBool("walking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);
            if (transform.position.x <= target.transform.position.x)
            {
                if (!tutorial)
                {
                    arrived = true;
                    GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().kattArrived = true;
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (tutorial)
                {
                    arrived = true;
                    GameObject.Find("GameManager").GetComponent<Tutorial>().kattArrived = true;
                    GameObject.Find("GameManager").GetComponent<Tutorial>().tutKattArrived = true;
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
}
