using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
  public Image actorImage;
  public TextMeshProUGUI actorName;

  Message[] currentMessages;
  Actor[] currentActors;
  int activeMessage = 0;
 
  private static DialogueManager instance;

  // [Header("dialogue UI")]
  public GameObject dialoguePanel;
  public TextMeshProUGUI dialogueText;

  // private Story currentStory;
 //Allow other scripts to read the value and not edit
  public bool dialogueIsPlaying {get; private set;}

  private void Awake()
  {
    if(instance != null)
    {
        Debug.LogWarning("Found more than one Dialogue Manager in the scene");

    }
    instance = this;
  }

  public static DialogueManager GetInstance()
  {
    return instance;
  }

  public void OpenDialogue(Message[] messages, Actor[] actors)
  {
    currentMessages = messages;
    currentActors = actors;
    activeMessage = 0;
    dialogueIsPlaying = true;
    dialoguePanel.SetActive(true);

    Debug.Log("Started conversation!v Loaded messages:" + messages.Length);
    DisplayMessage();

  }

  void DisplayMessage()
  {
    Message messageToDisplay = currentMessages[activeMessage];
    dialogueText.text = messageToDisplay.message;

    Actor actorToDisplay = currentActors[messageToDisplay.actorId];
    actorName.text = actorToDisplay.name;
    actorImage.sprite = actorToDisplay.sprite;

  }

  public void NextMessage()
  {
    activeMessage++;
    if(activeMessage < currentMessages.Length)
    {
      DisplayMessage();
    }
    else
    {
      Debug.Log("Conversation ended!");
      dialogueIsPlaying = false;
      dialoguePanel.SetActive(false);
    }
  }

  private void Start()
  {
    dialogueIsPlaying = false;
    dialoguePanel.SetActive(false);
  }

  private void Update()
  {
    if(!dialogueIsPlaying)
    {
        return;
    }
  }

  

  // public void EnterDialogueMode(TextAsset inkJSON)
  // {
  //   currentStory = new Story(inkJSON.text);
  //   dialogueIsPlaying = true;
  //   dialoguePanel.SetActive(true);

  //   ContinueStory();
  // }

  // private void ExitDialogueMode()
  // {
  //   dialogueIsPlaying = false;
  //   dialoguePanel.SetActive(false);
  //   dialogueText.text = "";
  // }

  // public void ContinueStory()
  // {
  //   if(currentStory.canContinue)
  //   {
  //     //set text for the current dialogue line
  //     dialogueText.text = currentStory.Continue();
  //   }
  //   else
  //   {
  //     ExitDialogueMode();
  //   }
  // }
}
