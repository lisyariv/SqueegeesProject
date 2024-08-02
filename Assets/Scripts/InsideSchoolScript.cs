using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsideSchoolScript : MonoBehaviour
{
    public Text popUpText;

    public bool playerInRange;
    public bool ifYesIsPressed;
    public bool ifNoIsPressed;
    public bool popUpIsPlaying;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject player;

    void Awake()
    {
        playerInRange = false;
        ifYesIsPressed = false;
        ifNoIsPressed = false;

        yesButton.SetActive(false);
        noButton.SetActive(false);
        popUpText.enabled = false;

        player.GetComponent<PlayerMovement>().ableToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true)
        {
            player.GetComponent<PlayerMovement>().ableToMove = false;
            popUpText.enabled = true;
            popUpText.text = "Would you like to enter the school?";
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
        SceneManager.LoadScene("SchoolScene");
        player.GetComponent<PlayerMovement>().ableToMove = true;
    }

    public void GoBack()
    {
        player.GetComponent<PlayerMovement>().ableToMove = true;
        popUpText.enabled = false;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        playerInRange = false;
    }
}
