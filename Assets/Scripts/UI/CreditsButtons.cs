using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButtons : MonoBehaviour {

    public GameObject audioCredits;
    public GameObject graphicsCredits;
    public GameObject codingCredits;

    public string whichCreditsToGoTo;

	void Start ()
    {
        audioCredits = gameObject.transform.parent.parent.gameObject.transform.GetChild(3).gameObject;
        graphicsCredits = gameObject.transform.parent.parent.gameObject.transform.GetChild(4).gameObject;
        codingCredits = gameObject.transform.parent.parent.gameObject.transform.GetChild(5).gameObject;
    }
	
	public void NextOne ()
    {
		if(whichCreditsToGoTo == "audio")
        {
            audioCredits.SetActive(true);
            graphicsCredits.SetActive(false);
            codingCredits.SetActive(false);
        }

        if (whichCreditsToGoTo == "graphics")
        {
            audioCredits.SetActive(false);
            graphicsCredits.SetActive(true);
            codingCredits.SetActive(false);
        }

        if (whichCreditsToGoTo == "coding")
        {
            audioCredits.SetActive(false);
            graphicsCredits.SetActive(false);
            codingCredits.SetActive(true);
        }
    }

    public void BackToMainMenu ()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.transform.parent.parent.transform.GetChild(1).gameObject.SetActive(true);
    }
}
