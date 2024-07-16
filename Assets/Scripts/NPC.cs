using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject contButton;
    // public GameObject diamond;
    public GameObject gameManager;

    public Text dialogueText;

    public string[] dialogue;
    public string[] dialogue2;

    private int index;

    public float wordSpeed;

    public bool playerIsClose;

    public int interactCount = 0;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(interactCount == 0)
            {
                if(dialoguePanel.activeInHierarchy)
                {
                  zeroText();
                }
                else
                {    
                  dialoguePanel.SetActive(true);
                  StartCoroutine(Typing());
                  interactCount = 1;
                }
            }
           

            // if(interactCount == 1)
            // {
            //     if(gameManager.GetComponent<GameManagerScript>().isDiamondCollected == false && dialoguePanel.activeInHierarchy)
            //     {
            //         zeroText();
            //     }

            //     else if(gameManager.GetComponent<GameManagerScript>().isDiamondCollected == true)
            //     {
            //        dialoguePanel.SetActive(true);
            //        StartCoroutine(Typing());
            //     }
            // }

        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
      {
        dialogueText.text += letter;
        yield return new WaitForSeconds(wordSpeed);
      }  
      
    //     foreach(char letter in dialogue2[index].ToCharArray())
    //   {
    //     dialogueText.text += letter;
    //     yield return new WaitForSeconds(wordSpeed);
    //   }  
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        //  if(index < dialogue2.Length - 1)
        // {
        //     index++;
        //     dialogueText.text = "";
        //     StartCoroutine(Typing());
        // }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MC"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("MC"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
