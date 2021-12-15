using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemiAi : MonoBehaviour
{
    private float distance;
    private NavMeshAgent myAgent;
    public Transform target;
    private Animator myAnim;
    public GameObject zombie;
    public bool life;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distance = Vector3.Distance (zombie.transform.position, target.transform.position);
        if(distance > 20)
        {
            myAgent.enabled = false;
            myAnim.SetBool("Idle",true);
            myAnim.SetBool("Run",false);
            myAnim.SetBool("Atack",false);
            
        }
        if (distance <= 20 & distance > 1.5f)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAnim.SetBool("Idle",false);
            myAnim.SetBool("Run",true);
            myAnim.SetBool("Atack",false);
            
        }
        if (distance <= 1.5f)
        {
            myAgent.enabled = false;
            myAnim.SetBool("Idle",false);
            myAnim.SetBool("Run",false);
            myAnim.SetBool("Atack",true);
           
        }
    }
}
