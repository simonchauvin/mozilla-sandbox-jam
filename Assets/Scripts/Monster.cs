using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public float speed;

    private Player player;


    private NavMeshAgent agent;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.destination = player.transform.position;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            agent.Stop();
        }
    }
}
