using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public int x, y; // Coordinate in grid
    [SerializeField] private bool walkable;
    [SerializeField] private bool hasUnite;
    public zoneType type;

    public Case up, down, left, right;
    public List<Case> neighbours = new List<Case>();

    [SerializeField]private GameObject wall;
    private GameObject walll;


    //for PathFinding
    public Case parent;

    public int gCost;
    public int hCost;
    public int fCost 
    {  
        get { return gCost + hCost; } 
    }


    private void Awake()
    {
        if (!walkable)
        {
            walll = GameObject.Instantiate(wall);
            walll.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }

    // Get Coordinate
    public int GetX() { return x; }
    public int GetY() { return y; }
    // Set Coordinate
    public void SetX(int nx) { x = nx; }
    public void SetY(int ny) { y = ny; }

    public bool IsWalkable() { return walkable; }
    public bool HasUnite() { return hasUnite; }

    public void DestroyWall()
    {
        walkable = false;
        // TODO play particules
        Destroy(walll);
    }



}

public enum zoneType
{
    Red,
    Blue,
    Neutral
}