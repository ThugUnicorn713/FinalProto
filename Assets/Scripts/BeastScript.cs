using UnityEngine;
using UnityEngine.AI;

public class BeastScript : MonoBehaviour
{
    public float wanderRadius = 80f;
    public float wanderInterval = 3f;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(SetRandomPoint), 0f, wanderInterval);
    }

    void SetRandomPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

    }
}
