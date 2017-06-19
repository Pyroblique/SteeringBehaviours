using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public List<GameObject> objects = new List<GameObject>();

    private float spawnTimer = 0f;

    void OnDrawGizmos()
    {
        // Draw a cube to indicate where the box is that we're spawning objects
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    // Generates a random point within the transform's scale
    Vector3 GenerateRandomPoint()
    {
        // SET halfScale to half of the transform's scale
        Vector3 halfScale = 0.5f * transform.localScale;
        // SET randomPoint vector to zero
        Vector3 randomPoint = Vector3.zero;
        // SET randomPoint x, y, & z to Random Range between -halfScale to halfScale (HINT: can do individually)
        randomPoint.x = Random.Range(-halfScale.x, halfScale.x);
        randomPoint.y = Random.Range(-halfScale.y, halfScale.y);
        randomPoint.z = Random.Range(-halfScale.z, halfScale.z);
        // RETURN randomPoint
        return randomPoint;
    }

    // Spawns the prefab at a given position and with rotation
    public void Spawn(Vector3 position, Quaternion rotation)
    {
        // SET clone to new instance of prefab
        GameObject clone = (GameObject)Instantiate(prefab);
        // ADD clone to objects list
        objects.Add(clone);
        // SET clone's position to position
        clone.transform.position = position;
        // SET clone's rotation to rotation
        clone.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // SET spawnTimer to spawnTimer + delta time
        spawnTimer = spawnTimer + Time.deltaTime;
        // IF spawnTimer > spawnRate
        if (spawnTimer >= spawnRate)
        {
            // SET randomPoint to GenerateRandomPoint()
            Vector3 randomPoint = GenerateRandomPoint();
            // CALL Spawn() and pass spawner position + randomPoint, Quaternion identity
            Spawn(transform.position + randomPoint, Quaternion.identity);
            // SET spawnTimer to zero
            spawnTimer = 0f;
        }
    }
}

