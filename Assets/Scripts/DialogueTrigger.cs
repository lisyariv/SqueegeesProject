using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

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
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            if(Input.GetKey(KeyCode.E))
            {
            //    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MC")
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MC")
        {
            playerInRange = false;
        }

    }

    // private void OnClick()
    // {
    //     Debug.Log(inkJSON.text);
    // }
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
