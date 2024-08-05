using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class storyscript : MonoBehaviour
{
    public GameObject dialoguePanel;

    public TextMeshProUGUI dialogueText;

    Story[] currentMessages;

    public bool dialogueIsPlaying = false;
    public bool dialogueIsDone = false;

    int activeMessage = 0;
    // Start is called before the first frame update
    void Start()
    {
      dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(!dialogueIsPlaying)
        {
           return;
        }
    }

    public void OpenDialogue(Story[] messages)
    {
      currentMessages = messages;
      activeMessage = 0;
      dialoguePanel.SetActive(true);
      dialogueIsPlaying = true;

      //Debug.Log("Started conversation!v Loaded messages:" + messages.Length);
      DisplayMessage();

    }

    void DisplayMessage()
    {
      Story messageToDisplay = currentMessages[activeMessage];
      dialogueText.text = messageToDisplay.message;
    }

    public void NextMessage()
    {
      activeMessage++;
      if(activeMessage < currentMessages.Length)
      {
        Debug.Log(activeMessage);
        Debug.Log(currentMessages.Length);
        DisplayMessage();
      }
      else
      {
        Debug.Log("Conversation ended!");
        dialogueIsPlaying = false;
        dialogueIsDone = true;
        dialoguePanel.SetActive(false);
        ChangeScene();
      }

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
