using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public List<GameObject> expressionPrefabs;
    public Vector3 expressionPos1;
    public List<Vector3> expressionPosList;
    public float MinX, MaxX, MinY, MaxY;


    public bool fight;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        Instantiate(expressionPrefabs[0]);
        Debug.Log("Dodge the enemy's attacks!");
    }

    // Update is called once per frame
    void Update()
    {
        setMinAndMax();
        timer -= Time.deltaTime;
        fighting();
    }

    private void setMinAndMax()
    {

    }
    public void fighting()
    {
        while (timer >= 0)
        {
            
            


            //Call to end the fight whe the player's confidence hits 0 or below 0. 

        }

    }
    //Function created for spawning the dialogue texts at random points. 

}
