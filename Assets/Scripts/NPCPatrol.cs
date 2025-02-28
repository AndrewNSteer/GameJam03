using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public GameObject player;

    public NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    public Vector3 destinationPoint;
    bool walkPoint;
    [SerializeField] float walkDistance;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPoint) SeachForDestination();
        if (walkPoint) agent.SetDestination(destinationPoint);
        if (Vector3.Distance(transform.position, destinationPoint) < 10) walkPoint = false;
    }
    
    void SeachForDestination()
    {
        float z = Random.Range(-walkDistance, walkDistance);
        float x = Random.Range(-walkDistance, walkDistance);

            destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destinationPoint, Vector3.down, groundLayer))
        {
            walkPoint = true ;
        }
    }
}
