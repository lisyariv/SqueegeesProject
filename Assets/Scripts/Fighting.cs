using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Fighting : MonoBehaviour
{
    public List<GameObject> objectPrefabs;
    public Vector3 objectPos;
    public GameObject player;

    public bool fight;
    public float timer;
    public float spawnTimer;
    public int holdIndex;

    public TextMeshProUGUI informationText;

    // Start is called before the first frame update
    void Start()
    {
        holdIndex = Random.Range(0, objectPrefabs.Count);
        fight = true;
        Instantiate(objectPrefabs[holdIndex], objectPos, Quaternion.identity);
        Debug.Log("Dodge the enemy's attacks!");
        objectPos.x = Random.Range(-11, 12);
        objectPos.y = 5;
    }

    // Update is called once per frame
    void Update()
    {
        informationText.text = "Dodge the insults and retaliate with objections! \n Controls : WASD \n HP : " + player.GetComponent<PlayerFight>().playerConfidence + "\n Time : " + timer;
        timer -= Time.deltaTime;
        spawnTimer += Time.deltaTime;
        objectPos.x = Random.Range(-11, 12);
        spawnObjects();
        if (timer <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
        

    } 

    //Function created for spawning the dialogue texts at random points. 

    void spawnObjects()
    {
        for (int index = 0; index < objectPrefabs.Count + 1; index++)
        {
            
            if (spawnTimer >= 0.20)
            {
                spawnTimer = 0;
                holdIndex = Random.Range(0, objectPrefabs.Count);
                Instantiate(objectPrefabs[holdIndex], objectPos, Quaternion.identity);
            }
        }

    }
}
