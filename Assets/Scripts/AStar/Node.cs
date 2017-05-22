using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool walkable;
    public Vector3 position;
    public int gridX;
    public Node parent;
    public int gridZ;
    public int gCost;
    public int hCost; // Heuristic
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    // Constructor
    public Node(bool walkable, Vector3 position)
    {
        this.walkable = walkable;
        this.position = position;
        this.gridX = gridX;
        this.gridZ = gridZ;
    }
}
