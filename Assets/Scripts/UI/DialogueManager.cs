using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public bool dialogueIsRunning;

    public Text nameText;
    public Text dialogueText;

    public Animator anim;

    private string dialogName;

    public Queue<string> sentences;

	void Start ()
    {
        sentences = new Queue<string>();
	}

    private void Update()
    {
        if(dialogueIsRunning)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }

    public void StartDialogue(Dialogue dialogue, string objectName)
    {
        anim.SetBool("IsOpen", true);

        dialogueIsRunning = true;
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextMessage();
        dialogName = objectName;
        
    }

    public void DisplayNextMessage()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
        dialogueIsRunning = false;
        Time.timeScale = 1f;
        Debug.Log(dialogName);
        if(GameObject.Find(dialogName).GetComponent<DialogueTrigger>().showsUpOnce)
        {
            Destroy(GameObject.Find(dialogName));
        }
    }
}
