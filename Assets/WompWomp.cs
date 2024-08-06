using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WompWomp : MonoBehaviour
{
    public TextMeshProUGUI Womp;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Womp.text = "As Leiland is bombarded by mean words from the bully, he becomes overwhelmed";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 12 && timer >= 6)
        {
            Womp.text = "No longer able to take the harsh words, Leiland runs away, leaving the school";
        }
        else if (timer <= 18 && timer >= 12)
        {
            Womp.text = "For the rest of the year Leiland did not show up to school";
        }
        else if (timer <= 24 && timer >= 18)
        {
            Womp.text = "Womp Womp";
        }
        else if (timer >= 24 && timer <= 30)
        {
            SceneManager.LoadScene("HomescreenScene");
        }
    }

}
