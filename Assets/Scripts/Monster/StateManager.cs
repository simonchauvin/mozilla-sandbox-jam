using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// States of the monster.
    /// </summary>
    enum State { chase, wander };

    /// <summary>
    /// Waypoints
    /// </summary>
    public Transform waypointFolder;

    // GAME OBJECTS
    private Player player;

    // COMPONENTS
    private NavMeshAgent agent;

    // VARIABLES
    private State currentState;
    private bool arrived;
    private Transform currentDestination;
    private Transform lastDestination;
    private Transform[] waypoints;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        agent = GetComponentInParent<NavMeshAgent>();
        waypoints = waypointFolder.GetComponentsInChildren<Transform>();

        currentState = State.wander;
        arrived = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    switch (currentState)
        {
            case State.chase:
                // Follow the player
                agent.destination = player.transform.position;
                break;
            case State.wander:
                // Choose to go to the closest waypoint
                if (arrived)
                {
                    Transform closest = null;
                    for (int i = 1; i < waypoints.Length; i++)
                    {
                        if (currentDestination == null || (Vector3.Distance(currentDestination.position, waypoints[i].position) > 0.2f && (lastDestination == null || Vector3.Distance(lastDestination.position, waypoints[i].position) > 0.2f)))
                        {
                            if ( closest == null || Vector3.Distance(transform.position, waypoints[i].position) < Vector3.Distance(transform.position, closest.position) )
                            {
                                closest = waypoints[i];
                            }
                        }
                    }
                    lastDestination = currentDestination;
                    currentDestination = closest;
                    arrived = false;
                }
                else
                {
                    agent.destination = currentDestination.position;
                    if (Vector3.Distance(transform.position, currentDestination.position) < 0.2f)
                    {
                        arrived = true;
                    }
                }
                break;
        }
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            currentState = State.chase;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            currentState = State.wander;
            arrived = true;
        }
    }
}
