using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFight : MonoBehaviour
{
    public Vector3 upDirection;
    public Vector3 downDirection;
    public Vector3 leftDirection;
    public Vector3 rightDirection;
    public bool haswon;
    public GameObject fight;
    public int playerConfidence;




    // Start is called before the first frame update
    void Start()
    {
        haswon = false;
        playerConfidence = 7;
        

    }

    // Update is called once per frame
    void Update()
    {
        // Causes the player to move a specific direction if a certain key is pressed. 
        if (Input.GetKey(KeyCode.W)){
            GetComponent<Transform>().position += upDirection;
        }
        if (Input.GetKey(KeyCode.S)){
            GetComponent<Transform>().position += downDirection;
        }
        if (Input.GetKey(KeyCode.A)){
            GetComponent<Transform>().position += leftDirection;
        }
        if (Input.GetKey(KeyCode.D)){
            GetComponent<Transform>().position += rightDirection;
        }

        if ((playerConfidence > 0 && fight.GetComponent<Fighting>().timer <= 0) || (playerConfidence > 0 && fight.GetComponent<Fighting>().globalTimer >= 150))
        {
            haswon = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Expression")
        {
            playerConfidence--;
            if(fight.GetComponent<Fighting>().timer <= 20)
            {
                playerConfidence--;
            }
            Destroy(collision.gameObject);
            if (playerConfidence <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("MainScene");
                fight.GetComponent<Fighting>().fight = false;
            }
        }
        if(collision.gameObject.tag == "Retaliate")
        {
            playerConfidence++;
            if(playerConfidence >= 8)
            {
                playerConfidence = 7;
            }
            Destroy(collision.gameObject);
            if(Random.Range(0,2) == 0)
            {
                fight.GetComponent<Fighting>().timer -= 10;
            } else
            {
                fight.GetComponent<Fighting>().timer += 7;
                if(fight.GetComponent<Fighting>().timer >= 60)
                {
                    fight.GetComponent<Fighting>().timer = 60;
                }
            }
        }
    }
    public int getConfidence()
    {
        return playerConfidence;
    }
    
}
