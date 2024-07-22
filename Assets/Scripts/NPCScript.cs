using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public DialogueTrigger trigger;

    public GameObject dialogueManager;
    public GameObject gameManager;

    public bool playerInRange;
    // public GameObject dialogueTriggedr;

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
            }
        }
        else
        {
            trigger.visualCue.SetActive(false);
        }

    }

}
