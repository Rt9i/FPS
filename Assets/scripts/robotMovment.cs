using UnityEngine;
using UnityEngine.AI;

public class robotMovment : MonoBehaviour
{
    Transform target;

    [SerializeField]
    NavMeshAgent agent;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!target)
            return;

        UpdateAnimations();
        agent.SetDestination(target.position);
    }

    void UpdateAnimations()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;
        anim.SetBool("Walk_Anim", isMoving);
    }
}
