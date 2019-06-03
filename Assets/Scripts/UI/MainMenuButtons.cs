using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour 
{

	
    public void StartGame()
    {
        SceneManager.LoadScene("Test_DayTime");
    }

    public void Tutorial ()
    {
        SceneManager.LoadScene("Test_Tutorial_DayTime");
    }

    public void Options ()
    {
        gameObject.transform.parent.parent.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.parent.parent.GetChild(2).gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits ()
    {
        gameObject.transform.parent.parent.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.parent.parent.GetChild(2).gameObject.SetActive(true);
    }
}
