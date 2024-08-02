using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    private float moveSpeed;

    private int waypointIndex;

    public bool didPlayerWin;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex <= waypoints.Length - 1 && didPlayerWin == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            

            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                GetComponent<Animator>().Play("WalkLeftBully");
            }
            
            if(waypointIndex == 2)
            {
                GetComponent<Animator>().Play("PunchAir");
            }
        }
    }
}
