using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class Wander : SteeringBehaviour
{ 
    public float radius = 1.5f;
    public float offset = 3f;
    public float jitter = 0.3f;

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        #region Calculate RandomDir
        // SET randomDir to new Vector3 x = randX & z = randZ
        //Vector3 randomDir = new Vector3(Vector3.left = randX, z = randZ);
        // SET randomDir to normalized randomDir
        //randomDir = randomDir.normalized;
        // SET randomDir to randomDir x jitter
        //randomDir = randomDir * jitter;
        #endregion

        #region Calculate TargetDir
        // SET targetDir to targetDir + randomDir
        Vector3 targetDir = new Vector3();
        // SET targetDir to normalized targetDir
        targetDir = targetDir.normalized;
        // SET targetDir to targetDir x radius
        targetDir = targetDir * radius;
        #endregion

        #region Calculate Force
        // SET seekPos to owner's position + targetDir
        Vector3 seekPos = Vector3.zero;
        // SET seekPos to seekPos + owner's forward x offset 
        seekPos = seekPos + Vector3.forward * offset;

        #region GIZMOS
        Vector3 offsetPos = transform.position + transform.forward.normalized * offset;
        GizmosGL.AddCircle(offsetPos + Vector3.up * 0.1f,
                           radius,
                           Quaternion.LookRotation(Vector3.down),
                           16,
                           Color.red);
        GizmosGL.AddCircle(seekPos + Vector3.up * 0.15f,
                           radius * 0.6f,
                           Quaternion.LookRotation(Vector3.down),
                           16,
                           Color.blue);
        #endregion

        // SET desiredForce to seekPos - position
        Vector3 desiredForce = seekPos - transform.position;
        // IF desiredForce is not zero
        //if(desiredForce != 0)
        {
            // SET desiredForce to desiredForce normalized x weighting
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desiredForce - owner's velocity
            force = desiredForce - owner.velocity;
        }
        #endregion

        return force;
    }
}
