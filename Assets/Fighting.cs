using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public List<GameObject> objectPrefabs;
    public Vector3 expressionPos1;
    public List<Vector3> expressionPosList;
    public float MinX, MaxX, MinY, MaxY;
    private Vector2 screenBounds;

    public bool fight;
    public float timer;
    public float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        Instantiate(objectPrefabs[Random.Range(0,3)]);
        Debug.Log("Dodge the enemy's attacks!");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        setMinAndMax();
        timer -= Time.deltaTime;
        spawnTimer += Time.deltaTime;
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
    public void spawnObjects()
    {
        spawnTimer = 0;
        if (spawnTimer >= 6)
        {

        }
    }
}
