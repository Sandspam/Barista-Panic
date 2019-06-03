using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool button;

    public GameObject pauseMenuUI;

    private void Start()
    {
        if(!button)
            pauseMenuUI = gameObject.transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        if (!button)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < gameObjects.Length; i++)
            gameObjects[i].GetComponentInParent<MeleeEnemyController>().canMove = true;

        GameObject.FindGameObjectWithTag("Pet").GetComponent<PetController>().canMove = true;
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitToMenu ()
    {
        SceneManager.LoadScene("Test_MainMenu");
    }

    public void ToSettings ()
    {
        gameObject.transform.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(4).gameObject.SetActive(true);
    }

    public void BackSettings ()
    {
        gameObject.transform.parent.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.parent.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.parent.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.parent.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(3).gameObject.SetActive(true);
        gameObject.transform.parent.parent.parent.gameObject.transform.Find("PauseMenu").transform.GetChild(4).gameObject.SetActive(false);
    }
}
