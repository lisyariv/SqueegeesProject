using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BullyScript : MonoBehaviour
{
    public DialogueTrigger trigger;

    public bool playerInRange;
    public bool dialogueIsDone;

    public GameObject Button;

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
    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true)
        {
            trigger.visualCue.SetActive(true);

            if(Input.GetKey(KeyCode.E))
            {
                trigger.StartDialogue();
                dialogueIsDone = true;
            }
        }
        else
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

        if(dialogueIsDone == true)
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }
    }

     public void ChangeScene()
    {
        SceneManager.LoadScene("HomescreenScene");
    }
}
