using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject endOfDayTextHolder;
    public bool dayEnded;
    public int money;
    private bool tutorial;
    private int numberOfTimeGottenCorrectInARow;
    private GameObject tryAgainDialogue;
    private GameObject goodLuckDialogue;
    private GameObject goodJobDialogue;
    private int kattsOrderIncorrectly;
    private int kultistsOrdered;
    private int kultistsGotWrong;
    private int kultistsGotCorrect;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Test_Tutorial_DayTime")
        {
            tryAgainDialogue = GameObject.Find("TryAgainDialogue").gameObject;
            goodLuckDialogue = GameObject.Find("GoodluckDialogue").gameObject;
            goodJobDialogue = GameObject.Find("GoodjobDialogue").gameObject;
            tutorial = true;
            GameObject.Find("Amount of Money").GetComponent<Text>().text = "Cash: $" + money;
        }
    }

    public void RoundEndCollection (bool isRegularCustomer, bool isKultist)
    {
        if (!tutorial)
        {
            if (gameObject.GetComponent<PuzzleMinigame>().gotBoxOneRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<PuzzleMinigame>().gotBoxTwoRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<PuzzleMinigame>().gotBoxThreeRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<PuzzleMinigame>().gotBoxFourRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (!dayEnded)
            {
                gameObject.GetComponent<PuzzleMinigame>().orderFinished = true;
            }

            //If you got all the boxes incorrect for the regular Katt costumer...
            if((!gameObject.GetComponent<PuzzleMinigame>().gotBoxOneRight || !gameObject.GetComponent<PuzzleMinigame>().gotBoxTwoRight || !gameObject.GetComponent<PuzzleMinigame>().gotBoxThreeRight || !gameObject.GetComponent<PuzzleMinigame>().gotBoxFourRight) && isRegularCustomer)
            {
                kattsOrderIncorrectly += 1;
                //Add a Kultist to spawn the next daytime shift
            }

            //If you did all the boxes wrong for the kultist...
            if ((!gameObject.GetComponent<PuzzleMinigame>().gotBoxOneRight && !gameObject.GetComponent<PuzzleMinigame>().gotBoxTwoRight && !gameObject.GetComponent<PuzzleMinigame>().gotBoxThreeRight && !gameObject.GetComponent<PuzzleMinigame>().gotBoxFourRight) && isKultist)
            {
                //Then note that the kultist got their order wrong
                kultistsOrdered += 1;
                kultistsGotWrong += 1;
            }

            //If you did all the boxes correct for the kultist...
            if ((gameObject.GetComponent<PuzzleMinigame>().gotBoxOneRight || gameObject.GetComponent<PuzzleMinigame>().gotBoxTwoRight || gameObject.GetComponent<PuzzleMinigame>().gotBoxThreeRight || gameObject.GetComponent<PuzzleMinigame>().gotBoxFourRight) && isKultist)
            {
                //Then note that the kultist got their order correct
                kultistsOrdered += 1;
                kultistsGotCorrect += 1;
            }
        }

        if(tutorial)
        {
            if (gameObject.GetComponent<Tutorial>().gotBoxOneRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<Tutorial>().gotBoxTwoRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<Tutorial>().gotBoxThreeRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (gameObject.GetComponent<Tutorial>().gotBoxFourRight && isRegularCustomer)
            {
                money += Random.Range(1, 5);
            }

            if (!dayEnded)
            {
                gameObject.GetComponent<Tutorial>().orderFinished = true;
            }
        }

        if (!tutorial)
        {
            gameObject.GetComponent<PuzzleMinigame>().gotBoxOneRight = false;
            gameObject.GetComponent<PuzzleMinigame>().gotBoxTwoRight = false;
            gameObject.GetComponent<PuzzleMinigame>().gotBoxThreeRight = false;
            gameObject.GetComponent<PuzzleMinigame>().gotBoxFourRight = false;
            gameObject.GetComponent<PuzzleMinigame>().arrow1 = false;
            gameObject.GetComponent<PuzzleMinigame>().arrow2 = false;
            gameObject.GetComponent<PuzzleMinigame>().arrow3 = false;
            gameObject.GetComponent<PuzzleMinigame>().arrow4 = false;
            gameObject.GetComponent<PuzzleMinigame>().kattArrived = false;
        }

        if(tutorial)
        {
            if(goodJobDialogue != null && gameObject.GetComponent<Tutorial>().gotBoxOneRight == true &&gameObject.GetComponent<Tutorial>().gotBoxTwoRight == true &&gameObject.GetComponent<Tutorial>().gotBoxThreeRight == true &&gameObject.GetComponent<Tutorial>().gotBoxFourRight == true)
            {
                goodJobDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                numberOfTimeGottenCorrectInARow += 1;
            }

            if (tryAgainDialogue != null && gameObject.GetComponent<Tutorial>().gotBoxOneRight == false || tryAgainDialogue != null && gameObject.GetComponent<Tutorial>().gotBoxTwoRight == false || tryAgainDialogue != null && gameObject.GetComponent<Tutorial>().gotBoxThreeRight == false || tryAgainDialogue != null && gameObject.GetComponent<Tutorial>().gotBoxFourRight == false)
            {
                tryAgainDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                numberOfTimeGottenCorrectInARow = 0;
                gameObject.GetComponent<Tutorial>().dayTimer = 60;
                return;
            }

            if(numberOfTimeGottenCorrectInARow >= 2)
            {
                goodLuckDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                tryAgainDialogue = null;
                goodLuckDialogue = null;
                Destroy(GameObject.Find("TryAgainDialogue"));
                Destroy(GameObject.Find("GoodjobDialogue"));
                numberOfTimeGottenCorrectInARow = 0;
            }

            gameObject.GetComponent<Tutorial>().gotBoxOneRight = false;
            gameObject.GetComponent<Tutorial>().gotBoxTwoRight = false;
            gameObject.GetComponent<Tutorial>().gotBoxThreeRight = false;
            gameObject.GetComponent<Tutorial>().gotBoxFourRight = false;
            gameObject.GetComponent<Tutorial>().arrow1 = false;
            gameObject.GetComponent<Tutorial>().arrow2 = false;
            gameObject.GetComponent<Tutorial>().arrow3 = false;
            gameObject.GetComponent<Tutorial>().arrow4 = false;
            gameObject.GetComponent<Tutorial>().kattArrived = false;

            if (!GameObject.Find("DialogueUI").GetComponent<DialogueManager>().dialogueIsRunning && GameObject.Find("OrderExplanationDialogue") != null)
            {
                GameObject.Find("OrderExplanationDialogue").gameObject.SetActive(false);
            }
        }
        GameObject.Find("Amount of Money").GetComponent<Text>().text = "Cash: $" + money;
        if(!tutorial)
        Destroy(gameObject.GetComponent<PuzzleMinigame>().cupInstace);

        if (tutorial)
            Destroy(gameObject.GetComponent<Tutorial>().cupInstace);
    }

    public void EndOfDayText()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Katt");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);

        Destroy(GameObject.Find("MrCandlesmith"));
        endOfDayTextHolder.SetActive(true);
        GameObject.Find("You earned: $").GetComponent<Text>().text = "Today's cash: $" + money + ".";
        DataHolder.Coins += money;

        DataHolder.Kultists = kattsOrderIncorrectly;

        //If you didn't get all the kultists orders wrong...
        if(kultistsGotWrong != kultistsOrdered)
        {
            //Then add the kultists that got their order correct to the night time
            DataHolder.KultistsAtNight += kultistsGotCorrect;
        }

        //If you got all the kultists wrong, no kultists will come at night-time
        if(kultistsGotWrong == kultistsOrdered)
        {
            DataHolder.KultistsAtNight = 0;
        }
        Destroy(gameObject);
    }
}
