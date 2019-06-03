using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour {

    private AudioSource aud;

    private void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
    }

    public void Ring ()
    {
        GameObject.Find("GameManager").GetComponent<PuzzleMinigame>().StartRound();
        aud.Play();
        gameObject.GetComponent<DeskBell>().enabled = false;
    }
}
