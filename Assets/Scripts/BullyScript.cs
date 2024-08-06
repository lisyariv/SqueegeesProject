using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BullyScript : MonoBehaviour
{
    public DialogueTrigger trigger;

    public bool playerInRange;
    public static bool dialogueIsDone;
    public bool visualCueIsShown;
    public bool dialogueCanPlay;
    // public bool isEmptyVisible;

    public GameObject Button;
    // public GameObject empty;

    public Vector3 LeftRight;

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

    void Awake()
    {
        // empty.SetActive(false);
        // isEmptyVisible = false;
        Button.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true)
        {
            trigger.visualCue.SetActive(true);
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
                   trigger.StartDialogue();
                   dialogueIsDone = true;
                   Debug.Log("dialogue is done");
                   Button.SetActive(true);
                }

            }
        }
        else
        {
            trigger.visualCue.SetActive(false);
            visualCueIsShown = false;
            playerInRange = false;
        }

        if(dialogueIsDone == true)
        {
            trigger.visualCue.SetActive(false);
            playerInRange = false;
        }

        // if(isEmptyVisible == true)
        // {
        //     dialogueIsDone = true;
        // }
        //GetComponent<Transform>().position += LeftRight;
    }

     public void ChangeScene()
    {
        SceneManager.LoadScene("Fight2");
    }
    // public void OnCollisionEnter2D()
    // {

    // }


}
