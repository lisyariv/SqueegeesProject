using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public DialogueTrigger trigger;

    public GameObject dialogueManager;
    public GameObject gameManager;

    public bool playerInRange;
    public bool isDialogue2Done;

    public void Awake()
    {
        isDialogue2Done = false;
        playerInRange = false;
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

    void Update()
    {

        if(playerInRange == true && dialogueManager.GetComponent<DialogueManager>().isDialogue1Done == true && gameManager.GetComponent<GameManagerScript>().isDiamondCollected == true)
        {
            trigger.visualCue.SetActive(true);
            
            if(Input.GetKey(KeyCode.E))
            {
                trigger.StartDialogue();
                isDialogue2Done = true;
            }
        }
        else
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

        if(isDialogue2Done == true)
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

    }

}
