using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger4Npc : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueManager dlogM;
    // public BullyScript dialogue;

    public bool playerInRange;
    public static bool isDialogue2Done;

    public GameObject triggerObject;
    public GameObject invisibleBarrier;

    public void Start()
    {
        
    }

    public void Awake()
    {
        if(isDialogue2Done == true)
        {
            triggerObject.SetActive(false);
            invisibleBarrier.SetActive(false);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if(BullyScript.dialogueIsDone == true && playerInRange == true && isDialogue2Done == false)
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

        if(isDialogue2Done == true && dlogM.dialogueIsPlaying == false)
        {
            //trigger.visualCue.SetActive(t);
            playerInRange = false;
            triggerObject.SetActive(false);
            invisibleBarrier.SetActive(false);
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
}
