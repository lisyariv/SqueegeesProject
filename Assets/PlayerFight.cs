using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public Vector3 upDirection;
    public Vector3 downDirection;
    public Vector3 leftDirection;
    public Vector3 rightDirection;

    public int playerConfidence;
    public GameObject timerChance;

    // Start is called before the first frame update
    void Start()
    {
        playerConfidence = 10;
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
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Expression")
        {
            playerConfidence--;
            Destroy(collision.gameObject);
            if (playerConfidence <= 0)
            {
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "Ability")
        {
            playerConfidence++;
            if(Random.Range(0,3) == 0)
            {
                timerChance.GetComponent<Fighting>().timer -= 10;
            } else
            {
                timerChance.GetComponent<Fighting>().timer += 5;
                if(timerChance.GetComponent<Fighting>().timer >= 200)
                {
                    timerChance.GetComponent<Fighting>().timer = 200;
                }
            }
        }
    }
    public int getConfidence()
    {
        return playerConfidence;
    }
    
}
