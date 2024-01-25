using UnityEngine;
using UnityEngine.AI;

public class FollowerAgent : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(player.position);

        if (agent.velocity.magnitude > 0f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}