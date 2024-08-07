using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static bool isDiamondCollected;

    public TextMeshProUGUI taskText;

    public GameObject DialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        isDiamondCollected = false;

        taskText.text = "Walk to the school entrance";
    }

    void Awake()
    {
        if(GameManagerScript.isDiamondCollected == true && DialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == false)
        {
            taskText.text = "Take Meredith's marker to her";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(BullyScript.dialogueIsDone == true && DialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == false)
        {
            taskText.text = "Talk to someone about your horrible encounter";
        }

        if(trigger4Npc.isDialogue2Done == true && DialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == false)
        {
            taskText.text = "Find Meredith's lost marker";
        }

        if(GameManagerScript.isDiamondCollected == true && DialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == false)
        {
            taskText.text = "Take Meredith's marker to her";
        }
    }

    
}
