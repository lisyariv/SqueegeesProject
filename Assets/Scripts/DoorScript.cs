using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public Text PopUpText;

    public bool playerInRange;
    public bool ifYesIsPressed;
    public bool ifNoIsPressed;
    public bool popUpIsPlaying;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject player;

    void Awake()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
        PopUpText.enabled = false;
        player.GetComponent<PlayerMovement>().ableToMove = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true)
        {
            player.GetComponent<PlayerMovement>().ableToMove = false;
            PopUpText.enabled = true;
            yesButton.SetActive(true);
            noButton.SetActive(true);
            popUpIsPlaying = true;
        }
        else
        {
            player.GetComponent<PlayerMovement>().ableToMove = true;
            yesButton.SetActive(false);
            noButton.SetActive(false);
            playerInRange = false;
            popUpIsPlaying = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MC")
        {
            Debug.Log("Player is in range.");
            playerInRange = true;
        }
    }

    public void ChangeScene()
    {
        player.GetComponent<PlayerMovement>().ableToMove = true;
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeScene2()
    {
         player.GetComponent<PlayerMovement>().ableToMove = true;
        SceneManager.LoadScene("Classroom1Scene");
    }

     public void ChangeScene3()
    {
        player.GetComponent<PlayerMovement>().ableToMove = true;
        SceneManager.LoadScene("Classroom2Scene");
    }

    public void ChangeScene4()
    {
        player.GetComponent<PlayerMovement>().ableToMove = true;
        SceneManager.LoadScene("CafeteriaScene");
    }

    public void GoBack()
    {
        player.GetComponent<PlayerMovement>().ableToMove = true;
        PopUpText.enabled = false;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        playerInRange = false;
    }
}
