using UnityEngine;
using UnityEngine.AI;

public class robot : MonoBehaviour
{
    [SerializeField]
    Transform target;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
