using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    // Public:
    public Vector3 force;
    public Vector3 velocity;
    public float maxVelocity = 100f;

    // Private:
    private List<SteeringBehaviour> behaviours;

    private Vector3 prevPosition;

    // Use this for initialization
    void Start()
    {
        // Obtain steering behaviours attached to AIAgent
        behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
    }

    // Update is called once per frame
    void Update()
    {
        ComputeForces();
        ApplyVelocity();
    }

    void ComputeForces()
    {
        // SET force to zero
        force = Vector3.zero;

        // FOR i := 0 to behaviours count
        for (int i = 0; i < behaviours.Count; i++)
        {
            // IF behavior is enabled
            SteeringBehaviour behaviour = behaviours[i];
            if (!behaviour.enabled) continue;

            // SET force to force + behaviour force
            force += behaviour.GetForce() * behaviour.weighting;

            // IF force is greater than maxVelocity
            if (force.magnitude > maxVelocity)
            {
                // SET force to force normalized x maxVelocity
                force = force.normalized * maxVelocity;
                // BREAK
                break;
            }
        }
    }

    void ApplyVelocity()
    {
        // SET velocity to velocity + force x delta time
        velocity += force * Time.deltaTime;
        velocity.y = 0f;
        // IF velocity is greater than maxVelocity
        if (velocity.magnitude > maxVelocity)
        {
            // SET velocity to velocity normalized maxVelocity
            velocity = velocity.normalized * maxVelocity;
        }
        // IF velocity is greater than zero
        if (velocity != Vector3.zero)
        {
            // SET position to position + velocity x delta time
            transform.position += velocity * Time.deltaTime;
            // SET rotation to quaternion LookRotation (velocity)
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}

