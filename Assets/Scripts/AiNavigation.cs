using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavigation : MonoBehaviour
{
    public GameObject theDestination;
    NavMeshAgent theAgent;
    //public static bool isHappy;
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
