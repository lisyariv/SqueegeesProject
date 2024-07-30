using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public DialogueTrigger trigger;
    public BullyScript dialogue;
    public trigger4Npc Npc;

    public GameObject dialogueManager;
    public GameObject gameManager;

    public bool playerInRange;
    public bool isDialogue3Done;

    public void Awake()
    {
        isDialogue3Done = false;
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

        if(dialogue.dialogueIsDone == true && Npc.isDialogue2Done == true && playerInRange == true && gameManager.GetComponent<GameManagerScript>().isDiamondCollected == true)
        {
            trigger.visualCue.SetActive(true);
            
            if(Input.GetKey(KeyCode.E))
            {
                trigger.StartDialogue();
                isDialogue3Done = true;
            }
        }
        else
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

        if(isDialogue3Done == true)
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

    }

}
