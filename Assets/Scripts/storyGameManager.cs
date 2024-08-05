using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyGameManager : MonoBehaviour
{
    public Story[] messages;
    public GameObject dialogueManager;
    public int dialoguestarts = 0;

    void Awake()
    {
        
    }

    public void StartDialogue()
    {
        FindObjectOfType<storyscript>().OpenDialogue(messages);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.GetComponent<storyscript>().dialogueIsPlaying == false && dialogueManager.GetComponent<storyscript>().dialogueIsDone == false)
        {
            FindObjectOfType<storyscript>().OpenDialogue(messages);
        }
    }
}

[System.Serializable]
public class Story
{
    public string message;
}
