using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    private Player player;


    private NavMeshAgent agent;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.destination = player.transform.position;
	}
}
