using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour 
{

	
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("Test_MainMenu");
        DataHolder.TotalCoins += DataHolder.Coins;
        DataHolder.TotalCoins -= DataHolder.PendingCoins;
        DataHolder.ArmorTier = 0;
        DataHolder.MovementSpeedIncrease = 1f;
    }

    public void Continue ()
    {
        SceneManager.LoadScene("Test_DayTime");
        DataHolder.TotalCoins += DataHolder.Coins;
        DataHolder.TotalCoins -= DataHolder.PendingCoins;
        DataHolder.ArmorTier = 0;
        DataHolder.MovementSpeedIncrease = 1f;
    }
}
