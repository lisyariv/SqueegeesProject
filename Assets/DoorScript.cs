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

    public GameObject yesButton;
    public GameObject noButton;

    void Awake()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
    
    private void OnTriggerEnter2D()
    {
        if(collider.gameObject.tag == "MC")
        {
            playerInRange = true;
        }

    }

     private void OnTriggerExit2D()
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
            PopUpText.text = "Would you like to exit the school?";
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoBack()
    {
        PopUpText.enabled = false;
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
}
