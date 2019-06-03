using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeratorCommands : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.LeftBracket))
        {
            DataHolder.SpendCoins += 20;
        }
        
        if(Input.GetKeyDown(KeyCode.RightBracket))
        {
            DataHolder.Coins -= 20;
        }

        if(Input.GetKeyDown(KeyCode.Minus))
        {
            DataHolder.IceBean += 1;
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            DataHolder.ExplosionBean += 1;
        }


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DataHolder.GreasyBean += 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) //If 1 is pressed...
        {
            if(SceneManager.GetActiveScene().name == "Test_DayTime") //And if the current scene is "Test_DayTime" or "Test_Tutorial_DayTime" then...
            {
                GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().dayTimer -= 5; //It'll find the game object "Game Manager" and get the script component called "Puzzle Minigame" and get the variable "dayTimer" inside and reduce it by 5
            }

            if(SceneManager.GetActiveScene().name == "Test_Tutorial_DayTime")
            {
                GameObject.Find("GameManager").GetComponent<Tutorial>().dayTimer -= 5;
            }

            if(SceneManager.GetActiveScene().name == "Test_NightTime")
            {
                GameObject.Find("GameManager").GetComponent<WaveSpawn>().endTimer -= 5;
            }

            if(SceneManager.GetActiveScene().name == "Test_Tutorial_NightTime")
            {
                GameObject.Find("GameManager").GetComponent<WaveSpawn>().endTimer -= 5;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(DataHolder.Coins);
        }
    }
}
