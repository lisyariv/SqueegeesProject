using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    [Header("Visual Cue")]
    public GameObject visualCue;
    public GameObject dialogueManager;

    public bool dialogueCanPlay;
    public bool visualCueIsShown;

    // [Header("ink JSON")]
    // [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);

    }

    private void Update()
    {
        if(playerInRange && !dialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            visualCueIsShown = true;

            if(visualCueIsShown == true)
            {
                dialogueCanPlay = true;
            }
            else
            {
                dialogueCanPlay = false;
            }

            if(dialogueCanPlay == true)
            {
                if(Input.GetKey(KeyCode.E))
                {
                  FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
                  Debug.Log("Message is displayed.");
                }
            }
        }
        else
        {
            visualCue.SetActive(false);
            visualCueIsShown = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MC")
        {
            playerInRange = true;
        }

    }

}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
