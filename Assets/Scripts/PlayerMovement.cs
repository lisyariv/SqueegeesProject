
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
  public GameObject dialogueManager;

  public float timer;

  public Text taskText;

  public bool isTextDisplayed;
  public bool ableToMove;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if(dialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == false)
    {

      if(ableToMove == true)
      {
        //GetComponent<AudioSource>().Play();
        if(Input.GetKey(KeyCode.W))
        {
          GetComponent<Transform>().position += upMovement;
          GetComponent<Animator>().Play("walkingWBack");
        }
        else if(Input.GetKey(KeyCode.A))
        {
          GetComponent<Transform>().position += leftMovement;
          GetComponent<Animator>().Play("walkingLeft");
        }
        else if(Input.GetKey(KeyCode.S))
        {
          GetComponent<Transform>().position += downMovement;
          GetComponent<Animator>().Play("walkingForward");
        }
        else if(Input.GetKey(KeyCode.D))
        {
          GetComponent<Transform>().position += rightMovement;
          GetComponent<Animator>().Play("walkingRight");
        }
        else
        {
          ableToMove = false;
          GetComponent<Animator>().Play("Idle");
        }

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
      GameManagerScript.isDiamondCollected = true;
      Destroy(collision.gameObject);
      taskText.text = "You collected Meredith's lost marker!";
      isTextDisplayed = true;
    }
  }

}
