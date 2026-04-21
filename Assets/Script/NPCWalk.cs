using UnityEngine;
using UnityEngine.AI;

public class NPCWalk : MonoBehaviour
{
    public NavMeshAgent agent;

    public float walkRadius = 20f;
    public float waitTime = 3f;

    float timer;

    void Start()
    {
        timer = waitTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            Vector3 newPos = RandomNavSphere(transform.position, walkRadius);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDir = Random.insideUnitSphere * distance;
        randomDir += origin;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, distance, NavMesh.AllAreas);

        return hit.position;
    }
}