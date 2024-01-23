using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAgent : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        if (agent.velocity.magnitude > 0f) {
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
