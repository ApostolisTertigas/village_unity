using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class NPCController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;
    public Transform target; // Assign a target in the inspector, for example, the player or a point of interest

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        // Use the Rigidbody for physics calculations
        rb.isKinematic = true; // NavMeshAgent controls the movement

        // Set up agent properties
        agent.updateRotation = false; // Let's the Rigidbody control rotation
        agent.updatePosition = true; // Update position using NavMeshAgent
    }

    void Update()
    {
        // Set the destination of the NPC to the target's position
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        // Avoidance and additional physics can be handled here if needed
        // Implement custom obstacle avoidance or use Unity's built-in avoidance
    }

    // This is called by Unity when the NPC collides with something
    void OnCollisionEnter(Collision collision)
    {
        // Implement custom collision handling logic
        // For example, if colliding with another NPC, you might want to stop and recalculate path
    }
}