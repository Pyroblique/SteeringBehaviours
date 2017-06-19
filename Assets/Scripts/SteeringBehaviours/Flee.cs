using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{

    public Transform target;
    public float stoppingDistance = 5f;

    public override Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // IF target is null, 
        if (target == null)
        {
            // RETURN force
            return force;
        }
        // SET desiredForce to direction away from target
        Vector3 desiredForce = target.position * -1f;
        // SET desiredForce y to zero
        desiredForce.y = 0f;

        // IF desiredForce.magnitude is greater than stoppingDistance
        if (desiredForce.magnitude > stoppingDistance)
        {
            // SET desiredForce to desiredForce normalized x weighting
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desiredForce - owner's velocity
            force = desiredForce - owner.velocity;
        }

        // RETURN force
        return force;
    }
}
