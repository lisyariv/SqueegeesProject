
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 rightMovement;
    public Vector3 leftMovement;
    public Vector3 upMovement;
    public Vector3 downMovement;

    public GameObject gameManager;

    public float timer;

    public Text taskText;

    public bool isTextDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying == false)
        {
            if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().position += upMovement;
        }

        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position += leftMovement;
        }

        if(Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().position += downMovement;
        }

        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += rightMovement;
        }
        }
        if(isTextDisplayed == true)
        {
          timer += Time.deltaTime;

            if(timer >= 3)
            {
                taskText.enabled = false;
                timer = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "taskItem")
        {
            gameManager.GetComponent<GameManagerScript>().isDiamondCollected = true;
            Destroy(collision.gameObject);
            taskText.text = "You collected the task item!";
            isTextDisplayed = true;

        }
    }

}
