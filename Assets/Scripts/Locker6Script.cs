using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker6Script : MonoBehaviour
{
    public bool playerInRange;
    
    public GameObject marker;
    public GameObject dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true && dialogueManager.GetComponent<DialogueManager>().dialogueIsPlaying == true)
        {
            marker.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MC")
        {
           playerInRange = true; 
        }
    }
}
